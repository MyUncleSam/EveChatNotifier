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

namespace EveChatNotifier
{
    public partial class FormMain : Form
    {
        private Timer t = new Timer();
        private string _LogPath = null;
        private List<LogFile> _LogFiles = new List<LogFile>();
        private bool firstShown = true;
        private static bool isPlaying = false;
        private DateTime lastNotified = DateTime.Now;

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

            Logging.WriteLine("Starting chat notifier.");

            InitializeComponent();

            // get path to watch
            string replDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _LogPath = Properties.Settings.Default.EveLogFolder.Replace("%DOCUMENTS%", replDocumentsPath);

            // initialize timer - this timer has to watch all folders for log files
            t.Tick += T_Tick;
            t.Interval = 5 * 1000; // check all 15 seconds for new log entries
            t.Start();
            T_Tick(null, null);
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
                    if ((DateTime.Now - System.IO.File.GetLastWriteTime(curLogFile)).TotalHours > 24)
                    {
                        continue;
                    }

                    // new log file - add to list
                    LogFile toAdd = new LogFile(curLogFile);
                    toAdd.NewChatLines += NewChatLines;

                    _LogFiles.Add(toAdd);

                    Logging.WriteLine(string.Format("Watching new log file: {0}", curLogFile));
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Error getting log files:{0}{1}", Environment.NewLine, ex.ToString()));
            }

            t.Start();
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

                // unable to read sender - but we need it so do nothing
                if(string.IsNullOrWhiteSpace(le.Sender))
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
                        if(le.Text.ToLower().Contains(toCheck.ToLower()))
                        {
                            needsNotify = true;
                        }
                    }
                }

                // if notification is needed
                if (needsNotify) // isPlaying is managing the notification using sound (only one at a time)
                {
                    lastNotified = DateTime.Now;
                    Logging.WriteLine(string.Format("Notify for chat message of '{0}' in '{1}': {2}", le.Sender, curLog.LogInfo.ChannelName, le.Text));

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

                    if(string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath) || Properties.Settings.Default.ShowNotification)
                    {
                        if((DateTime.Now - lastNotified).TotalSeconds > 1)
                        {
                            lastNotified = DateTime.Now;
                            // send notification
                            notifyIcon.ShowBalloonTip(10000, "[EVE] chat notification", string.Format("[{0}] {1}: {2}", curLog.LogInfo.ChannelName, le.Sender, le.Text), ToolTipIcon.Info);
                        }
                    }
                }
            }
        }

        private void Wp_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            isPlaying = false;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            tbSoundFile.Text = Properties.Settings.Default.SoundFilePath;

            if(firstShown)
            {
                this.WindowState = FormWindowState.Minimized;
                firstShown = false;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            //this.Focus();
            //this.TopMost = true;
            //this.TopMost = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SoundFilePath = tbSoundFile.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
