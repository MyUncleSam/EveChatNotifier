using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using Tulpep.NotificationWindow;

namespace EveChatNotifier
{
    public partial class FormMain : Form
    {
        private Timer t = new Timer();
        private string _LogPath = null;
        private List<LogFile> _LogFiles = new List<LogFile>();
        private static bool isPlaying = false;
        private DateTime lastNotified = DateTime.Now;
        private PopupNotifier Notifier = new PopupNotifier();

        public FormMain()
        {
            // properties upgrade logic
            if(Properties.Settings.Default.NeedsUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NeedsUpgrade = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

            // set real paths
            string replDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Properties.Settings.Default.EveChatLogsPath = Properties.Settings.Default.EveChatLogsPath.Replace("%DOCUMENTS%", replDocumentsPath);

            string exePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            Properties.Settings.Default.LogFile = Properties.Settings.Default.LogFile.Replace("%EXEPATH%", exePath);

            Properties.Settings.Default.MoveOldLogsPath = Properties.Settings.Default.MoveOldLogsPath.Replace("%CHATLOGS%", Properties.Settings.Default.EveChatLogsPath);

            // set log path
            _LogPath = Properties.Settings.Default.EveChatLogsPath;

            // create old log folder if needed (and move logs)
            if (Properties.Settings.Default.MoveOldLogs)
            {
                if(!System.IO.Directory.Exists(Properties.Settings.Default.MoveOldLogsPath))
                {
                    System.IO.Directory.CreateDirectory(Properties.Settings.Default.MoveOldLogsPath);
                }

                // move old logs
                string[] logFiles = System.IO.Directory.GetFiles(Properties.Settings.Default.EveChatLogsPath, "*.txt", SearchOption.TopDirectoryOnly);
                foreach (string logFile in logFiles)
                {
                    string moveDestination = System.IO.Path.Combine(Properties.Settings.Default.MoveOldLogsPath, System.IO.Path.GetFileName(logFile));
                    try
                    {
                        System.IO.File.Move(logFile, moveDestination);
                        Logging.WriteLine(string.Format("Moved old log file '{0}' to '{1}'", logFile, moveDestination));
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteLine(string.Format("Unable to move old log '{0}' to '{1}'", logFile, moveDestination));
                    }
                }
            }

            // popup notifier settings
            Notifier.IsRightToLeft = false;
            Notifier.ShowCloseButton = true;
            Notifier.ShowGrip = false;
            Notifier.Image = Properties.Resources.eve_logo_landing2;

            Notifier.Delay = 5000;
            Notifier.AnimationDuration = 500;

            Notifier.BodyColor = Color.Black;
            Notifier.BorderColor = Color.Red;
            Notifier.ContentColor = Color.White;
            Notifier.ContentHoverColor = Color.White;
            Notifier.HeaderColor = Color.Orange;
            Notifier.TitleColor = Color.Gray;
            
            Notifier.Click += Notifier_Click;

            Logging.WriteLine("Starting chat notifier.");

            InitializeComponent();

            // set version information
            notifyIcon.Text = string.Format("EveChatNotifier - v{0}", Application.ProductVersion);

            // initialize timer - this timer has to watch all folders for log files
            Logging.WriteLine("Starting log watcher timer");
            t.Tick += T_Tick;
            t.Interval = 5 * 1000; // check all 15 seconds for new log entries
            t.Start();
            T_Tick(null, null);

            // generate notify menu entries
            ContextMenu cm = new ContextMenu();
            MenuItem cmExit = new MenuItem("Exit");
            MenuItem cmSettings = new MenuItem("Settings");

            cmSettings.Click += CmSettings_Click;
            cm.MenuItems.Add(cmSettings);

            cmExit.Click += CmExit_Click;
            cm.MenuItems.Add(cmExit);

            notifyIcon.ContextMenu = cm;
        }

        private void CmSettings_Click(object sender, EventArgs e)
        {
            notifyIcon_DoubleClick(null, null);
        }

        private void CmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// timer to check for log files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();

            try
            {
                string[] logFiles = System.IO.Directory.GetFiles(_LogPath, "*.txt", SearchOption.TopDirectoryOnly);
                
                // iterate throught all files and generat logfire entries
                foreach (string curLogFile in logFiles)
                {
                    if(_LogFiles.Exists(exist => exist.FilePath == curLogFile))
                    {
                        continue; // already known log file
                    }

                    // only add logfiles which are last modified in the past X hour
                    if ((DateTime.Now - System.IO.File.GetLastWriteTime(curLogFile)).TotalHours > Properties.Settings.Default.MaxAgeForWatchingLogs)
                    {
                        continue;
                    }

                    // new log file - add to list
                    LogFile toAdd = new LogFile(curLogFile);
                    toAdd.NewChatLines += NewChatLines;
                    toAdd.RemovedLog += ToAdd_RemovedLog;

                    _LogFiles.Add(toAdd);

                    Logging.WriteLine(string.Format("Watching new log file: {0}", curLogFile));
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Error getting log files:{0}{1}", Environment.NewLine, ex.ToString()));
            }
            finally
            {
                t.Start();
            }
        }

        private void ToAdd_RemovedLog(object sender, LogFile.EveChatEventArgs e)
        {
            Logging.WriteLine(string.Format("Removed log file from watching: {0}", ((LogFile)sender).FilePath));
            _LogFiles.Remove((LogFile)sender);
        }

        private void NewChatLines(object sender, LogFile.EveChatEventArgs e)
        {
            LogFile curLog = (LogFile)sender;
            string logLines = e.NewLogLines;

            // check log lines - line for line
            StringReader sr = new StringReader(logLines);

            string curLine = null;
            while ((curLine = sr.ReadLine()) != null)
            {
                curLine = curLine.Trim();

                LogEntry le = LogReader.GetLogEntry(curLine);

                if (Properties.Settings.Default.LogAllMessages)
                {
                    Logging.WriteLine(string.Format("Message from '{0}' in '{1}': {2}", le.Sender, curLog.LogInfo.ChannelName, le.Text));
                }

                // unable to read sender - but we need it so do nothing
                if (string.IsNullOrWhiteSpace(le.Sender))
                {
                    continue;
                }

                // check if notification is needed
                bool needsNotify = false;
                if(le.Text.ToLower().Contains(curLog.LogInfo.PilotName.ToLower()))
                {
                    needsNotify = true;
                }
                if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.NotifyKeywords))
                {
                    string[] alsoCheck = Properties.Settings.Default.NotifyKeywords.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string toCheck in alsoCheck)
                    {
                        if(le.Text.ToLower().Contains(toCheck.Trim().ToLower()))
                        {
                            needsNotify = true;
                        }
                    }
                }

                // if notification is needed
                if (needsNotify) // isPlaying is managing the notification using sound (only one at a time)
                {
                    Logging.WriteLine(string.Format("Notify for chat message of '{0}' in '{1}': {2}", le.Sender, curLog.LogInfo.ChannelName, le.Text));

                    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath) || Properties.Settings.Default.ShowToast)
                    {
                        if ((DateTime.Now - lastNotified).TotalSeconds > 1)
                        {
                            lastNotified = DateTime.Now;
                            // send notification
                            //notifyIcon.ShowBalloonTip(10000, "[EVE] chat notification", string.Format("[{0}] {1}: {2}", curLog.LogInfo.ChannelName, le.Sender, le.Text), ToolTipIcon.Info);

                            

                            Notifier.TitleText = string.Format("{0} in '{1}'", le.Sender, curLog.LogInfo.ChannelName);
                            Notifier.ContentText = le.Text;
                            

                            Notifier.Popup();
                        }
                    }

                    // send sound alert
                    if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
                    {
                        try
                        {
                            if(!isPlaying)
                            {
                                // try playing the file
                                isPlaying = true;
                                IWavePlayer wp = new WaveOut();
                                AudioFileReader afr = new AudioFileReader(Properties.Settings.Default.SoundFilePath);
                                wp.Init(afr);
                                wp.PlaybackStopped += Wp_PlaybackStopped;
                                wp.Play();
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.WriteLine(string.Format("Unable to play sound file '{0}' - removing sound file:{1}{2}", Properties.Settings.Default.SoundFilePath, Environment.NewLine, ex.ToString()));

                            // fallback to windows sounds if we are unable to play the given sound file
                            Properties.Settings.Default.SoundFilePath = null;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                        }
                    }
                }
            }
        }

        private void Notifier_Click(object sender, EventArgs e)
        {
            try
            {
                PopupNotifier pn = (PopupNotifier)sender;
                pn.Hide();
            }
            catch { }
        }

        private void Wp_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            isPlaying = false;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logging.WriteLine("Stopping chat notifier.");
            Properties.Settings.Default.Save();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }
    }
}
