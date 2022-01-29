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
using AutoUpdaterDotNET;

namespace EveChatNotifier
{
    public partial class FormMain : Form
    {
        private Timer t = new Timer();
        private List<LogFile> _LogFiles = new List<LogFile>();
        private DateTime lastNotified = DateTime.Now;
        private Settings _Settings = null;

        private string PathEveChatLogs;
        private string PathMoveOldLogs;
        private string PathSoundFile;

        public FormMain()
        {
            // properties upgrade logic
            if (Properties.Settings.Default.NeedsUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NeedsUpgrade = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

            // bugfix for empty paths
            bool pathFix = false;
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.MoveOldLogsPath))
            {
                Properties.Settings.Default.MoveOldLogsPath = "%DEFAULT_EVEOLDPATH%";
                pathFix = true;
            }
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.EveChatLogsPath))
            {
                Properties.Settings.Default.EveChatLogsPath = "%DEFAULT_EVELOGPATH%";
                pathFix = true;
            }
            if (pathFix)
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

            // first launch ask for move logs
            if (!Properties.Settings.Default.AskedToMoveLogs)
            {
                if (!Properties.Settings.Default.MoveOldLogs)
                {
                    if (MessageBox.Show(string.Format("Do you want to let the program move your old log files?{0}{0}Moving the log files is a huge performance boost and highly recommended! If you do not move the logs, this program could need a lot of cpu power.{0}{0}This can be enabled/disabled in the settings at any time.", Environment.NewLine), "Activate log moving", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Properties.Settings.Default.MoveOldLogs = true;
                    }
                }

                Properties.Settings.Default.AskedToMoveLogs = true;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

            // set real paths
            PathEveChatLogs = PathHelper.DecryptPath(Properties.Settings.Default.EveChatLogsPath);
            PathMoveOldLogs = PathHelper.DecryptPath(Properties.Settings.Default.MoveOldLogsPath);
            PathSoundFile = PathHelper.DecryptPath(Properties.Settings.Default.SoundFilePath);

            // create old log folder if needed (and move logs)
            if (Properties.Settings.Default.MoveOldLogs)
            {
                if (!System.IO.Directory.Exists(PathMoveOldLogs))
                {
                    System.IO.Directory.CreateDirectory(PathMoveOldLogs);
                }

                // move old logs
                string[] logFiles = System.IO.Directory.GetFiles(PathEveChatLogs, "*.txt", SearchOption.TopDirectoryOnly);
                foreach (string logFile in logFiles)
                {
                    string moveDestination = System.IO.Path.Combine(PathMoveOldLogs, System.IO.Path.GetFileName(logFile));
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

            // delete old logs
            if (Properties.Settings.Default.DeleteLogs)
            {
                string[] logFIles = System.IO.Directory.GetFiles(PathEveChatLogs, "*.txt", SearchOption.TopDirectoryOnly);
                foreach (string logFIle in logFIles)
                {
                    try
                    {
                        System.IO.File.Delete(logFIle);
                        Logging.WriteLine(string.Format("Deleted old log file '{0}'", logFIle));
                    }
                    catch(Exception ex)
                    {
                        Logging.WriteLine(string.Format("Unablt to delete old log '{1}':{0}´{1}", Environment.NewLine, logFIle, ex.ToString()));
                    }
                }
            }

            Logging.WriteLine("Starting chat notifier.");

            InitializeComponent();

            // set version information
            notifyIcon.Text = string.Format("EveChatNotifier - v{0}", Application.ProductVersion);

            // initialize timer - this timer has to watch all folders for log files
            Logging.WriteLine("Starting log watcher timer");
            t.Tick += T_Tick;
            t.Interval = Properties.Settings.Default.EveChatLogCheckInterval * 1000; // check all X seconds for new log files
            t.Start();
            T_Tick(null, null);

            // generate notify menu entries
            ContextMenu cm = new ContextMenu();
            MenuItem cmExit = new MenuItem("Exit");
            MenuItem cmSettings = new MenuItem("Settings");
            MenuItem cmHomepage = new MenuItem("Homepage");
            MenuItem cmVersion = new MenuItem(string.Format("v{0}", Application.ProductVersion));
            MenuItem cmCheckUpdate = new MenuItem("Check for update");

            // version
            cmVersion.Enabled = false;
            cm.MenuItems.Add(cmVersion);

            // auto update check
            cmCheckUpdate.Click += CmCheckUpdate_Click;
            cm.MenuItems.Add(cmCheckUpdate);

            cm.MenuItems.Add("-");

            // settings
            cmSettings.Click += CmSettings_Click;
            cm.MenuItems.Add(cmSettings);

            // homepage
            cmHomepage.Click += CmHomepage_Click;
            cm.MenuItems.Add(cmHomepage);

            cm.MenuItems.Add("-");

            // exit
            cmExit.Click += CmExit_Click;
            cm.MenuItems.Add(cmExit);

            notifyIcon.ContextMenu = cm;

            // autostart
            try
            {
                Autostart.ManageAutostart.Instance.CheckTask();
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Error checking for autostart:{0}{1}", Environment.NewLine, ex.ToString()));
            }
        }

        private void CmCheckUpdate_Click(object sender, EventArgs e)
        {
            Notifier.GetInstance().Notify("Update check", "Checking for update - if there is a new version you get a new window appears leading your throught the update process.");
            CheckForUpdate();
        }

        private void CmHomepage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MyUncleSam/EveChatNotifier");
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
                string[] logFiles = System.IO.Directory.GetFiles(PathEveChatLogs, "*.txt", SearchOption.TopDirectoryOnly);

                // iterate throught all files and generat logfire entries
                foreach (string curLogFile in logFiles)
                {
                    if (_LogFiles.Exists(exist => exist.FilePath == curLogFile))
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

            // check for channel ignore list
            if (IsIgnoredChannel(curLog))
            {
                return;
            }

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
                    Logging.WriteLine(string.Format("{3}: Message from '{0}' in '{1}': {2}", le.Sender, curLog.LogInfo.ChannelName, le.Text, curLog.LogInfo.PilotName));
                }

                // unable to read sender - but we need it so do nothing
                if (string.IsNullOrWhiteSpace(le.Sender))
                {
                    continue;
                }

                // check if sender is current user (ignore if user wants to ignore this messages)
                if (Properties.Settings.Default.IgnoreOwnMessages && le.Sender.Equals(curLog.LogInfo.PilotName, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                // check if sender is "EVE-System" to prevent MOTD notifications
                if (Properties.Settings.Default.IgnoreMotd && le.Sender.Equals(Properties.Settings.Default.MotdUsername.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                // check if the sender is on the ignore list
                if (IsIgnoredPilot(le))
                {
                    continue;
                }
                bool needsNotify = false;
                // check if sender or channel is in always list
                if (IsAlwaysPilot(le) || IsAlwaysChannel(curLog))
                {
                    needsNotify = true;
                }
                // check if notification is needed
                if (le.Text.ToLower().Contains(curLog.LogInfo.PilotName.ToLower()))
                {
                    needsNotify = true;
                }
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.NotifyKeywords))
                {
                    string[] alsoCheck = Properties.Settings.Default.NotifyKeywords.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string toCheck in alsoCheck)
                    {
                        if (le.Text.ToLower().Contains(toCheck.Trim().ToLower()))
                        {
                            needsNotify = true;
                            break;
                        }
                    }
                }

                // if notification is needed
                if (needsNotify) // isPlaying is managing the notification using sound (only one at a time)
                {
                    Logging.WriteLine(string.Format("{3}: Notify for chat message of '{0}' in '{1}': {2}", le.Sender, curLog.LogInfo.ChannelName, le.Text, curLog.LogInfo.PilotName));
                    Notifier.GetInstance().Notify(string.Format("{0} in '{1}'", le.Sender, curLog.LogInfo.ChannelName), le.Text, PathHelper.DecryptPath(Properties.Settings.Default.SoundFilePath));
                }
            }
        }

        /// <summary>
        /// check if the current logfile is on the ignore list for channels
        /// </summary>
        /// <param name="lf"></param>
        /// <returns></returns>
        public bool IsIgnoredChannel(LogFile lf)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.IgnoreChannels))
            {
                return false;
            }

            string[] ignoreChannels = Properties.Settings.Default.IgnoreChannels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return ignoreChannels.Any(a => a.Trim().Equals(lf.LogInfo.ChannelName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// check if the sender is on the ignore list
        /// </summary>
        /// <param name="le"></param>
        /// <returns></returns>
        public bool IsIgnoredPilot(LogEntry le)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.IgnorePilots))
            {
                return false;
            }

            string[] ignorePilots = Properties.Settings.Default.IgnorePilots.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return ignorePilots.Any(a => a.Trim().Equals(le.Sender.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// check if the current logfile is on the Always list for channels
        /// </summary>
        /// <param name="lf"></param>
        /// <returns></returns>
        public bool IsAlwaysChannel(LogFile lf)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.AlwaysChannels))
            {
                return false;
            }

            string[] alwaysChannels = Properties.Settings.Default.AlwaysChannels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return alwaysChannels.Any(a => a.Trim().Equals(lf.LogInfo.ChannelName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// check if the sender is on the always list
        /// </summary>
        /// <param name="le"></param>
        /// <returns></returns>
        public bool IsAlwaysPilot(LogEntry le)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.AlwaysPilots))
            {
                return false;
            }

            string[] alwaysPilots = Properties.Settings.Default.AlwaysPilots.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return alwaysPilots.Any(a => a.Trim().Equals(le.Sender.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (_Settings == null)
            {
                _Settings = new Settings();
                _Settings.ShowDialog();
                _Settings = null;
            }
            else
            {
                _Settings.Focus();
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Hide();
            CheckForUpdate();
        }

        public void CheckForUpdate()
        {
            // check for new version
            if (Properties.Settings.Default.CheckForUpdates)
            {
                Github.GithubUpdateCheck.UpdateUsingLocalXmlFile("MyUncleSam", "EveChatNotifier");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logging.WriteLine("Cleanup ...");
            foreach (string file in Cleanup.GetInstance().FilesToDelete)
            {
                try
                {
                    Logging.WriteLine(string.Format("Deleting file '{0}'", file));
                    System.IO.File.Delete(file);
                }
                catch (Exception ex)
                {
                    Logging.WriteLine(string.Format("Unable to delete file: {0}", ex.Message));
                }
            }

            Logging.WriteLine("Stopping chat notifier.");
            Properties.Settings.Default.Save();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_Settings == null)
            {
                _Settings = new Settings();
                _Settings.ShowDialog();
                _Settings = null;
            }
            else
            {
                _Settings.Focus();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
