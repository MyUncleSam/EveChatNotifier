using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EveChatNotifier
{
    public partial class Settings : Form
    {
        private IWavePlayer wp = new WaveOut();
        private bool initializationFinished = false;

        public Settings()
        {
            InitializeComponent();

            this.Text = string.Format("Settings - v{0}", Application.ProductVersion);

            cbNotify.DataSource = Enum.GetValues(typeof(NotifyOptions));

            // set eve chat path
            folderEveChatLogs.SelectedFolder = PathHelper.DecryptPath(Properties.Settings.Default.EveChatLogsPath);

            // set program log path
            fileLog.SelectedFile = PathHelper.DecryptPath(Properties.Settings.Default.LogFile);

            // set move old logs
            cbMoveLog.Checked = Properties.Settings.Default.MoveOldLogs;

            // set move old logs path
            folderMoveLogs.SelectedFolder = PathHelper.DecryptPath(Properties.Settings.Default.MoveOldLogsPath);

            // set delete logs
            cbDeleteLogs.Checked = Properties.Settings.Default.DeleteLogs;

            // set notify option
            NotifyOptions curOption = NotifyOptions.Toast;

            if (Properties.Settings.Default.ShowToast && string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
            {
                curOption = NotifyOptions.Toast;
            }
            if (Properties.Settings.Default.ShowToast && !string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
            {
                curOption = NotifyOptions.Both;
            }
            if (!Properties.Settings.Default.ShowToast && !string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
            {
                curOption = NotifyOptions.Sound;
            }
            cbNotify.SelectedItem = curOption;

            // sound file to play
            if (curOption == NotifyOptions.Both || curOption == NotifyOptions.Sound)
            {
                fileNotifySound.SelectedFile = PathHelper.DecryptPath(Properties.Settings.Default.SoundFilePath);
            }
            else
            {
                fileNotifySound.SelectedFile = "";
            }

            // set notify keywords
            tbNotifyKeywords.Text = Properties.Settings.Default.NotifyKeywords;

            // set update check
            cbUpdates.Checked = Properties.Settings.Default.CheckForUpdates;

            // set motd username
            tbMotdUsername.Text = Properties.Settings.Default.MotdUsername;

            // set ignore pilot and channel
            tbIgnoreChannels.Text = Properties.Settings.Default.IgnoreChannels;
            tbIgnorePilots.Text = Properties.Settings.Default.IgnorePilots;

            // set always pilot and channel
            tbAlwaysPilots.Text = Properties.Settings.Default.AlwaysPilots;
            tbAlwaysChannels.Text = Properties.Settings.Default.AlwaysChannels;

            // set autostart object
            try
            {
                cbAutoStart.Checked = Autostart.ManageAutostart.Instance.Enabled;
            }
            catch (Exception ex)
            {
                Logging.WriteLine(string.Format("Error getting autostart enabled state:{0}{1}", Environment.NewLine, ex.ToString()));
                cbAutoStart.Enabled = false;
            }
            nudAutoStartDelay.Value = Properties.Settings.Default.AutoStartDelayMinutes;

            // set font size
            nudFontSizeTitle.Value = Convert.ToDecimal(Properties.Settings.Default.ToastFontSizeTitle);
            nudFontSizeContent.Value = Convert.ToDecimal(Properties.Settings.Default.ToastFontSizeContent);

            // set ignore motd and ignore own messages
            cbIgnoreMotd.Checked = Properties.Settings.Default.IgnoreMotd;
            cbIgnoreOwn.Checked = Properties.Settings.Default.IgnoreOwnMessages;

            initializationFinished = true;
        }

        private void cbMoveLog_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox curCb = (CheckBox)sender;
            folderMoveLogs.Enabled = curCb.Checked;

            // disable delete checkbox and uncheck it if move is enabled
            cbDeleteLogs.Enabled = !curCb.Checked;
            if (curCb.Checked)
                cbDeleteLogs.Checked = false;
        }

        public enum NotifyOptions
        {
            Toast = 0,
            Sound = 1,
            Both = 2
        }

        private void cbNotify_SelectedValueChanged(object sender, EventArgs e)
        {
            NotifyOptions curOption = (NotifyOptions)Enum.Parse(typeof(NotifyOptions), cbNotify.SelectedValue.ToString());

            switch (curOption)
            {
                case NotifyOptions.Toast:
                    fileNotifySound.Enabled = false;
                    tbarVolume.Enabled = false;
                    btnTest.Enabled = false;
                    break;
                case NotifyOptions.Sound:
                    fileNotifySound.Enabled = true;
                    tbarVolume.Enabled = true;
                    btnTest.Enabled = true;
                    break;
                case NotifyOptions.Both:
                    fileNotifySound.Enabled = true;
                    tbarVolume.Enabled = true;
                    btnTest.Enabled = true;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();

            // restart the application to apply all new settings
            Application.Restart();
        }

        private void fileNotifySound_EnabledChanged(object sender, EventArgs e)
        {
            if (!fileNotifySound.Enabled)
            {
                fileNotifySound.SelectedFile = "";
            }
        }

        private void lblEveChatLogs_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "Path to the folder where all eve chat logs are located in. This folder is watched for new logs and each log is monitored by this tool for changes.";
        }

        private void lblLogFile_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "Path to the file this program is writing its logfile into. All actions done by this tool are protocolled in there. (You can see all actions in here - even possible errors for support reasons.)";
        }

        private void lblMoveLogs_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "If activated the programm tries to move all eve chat log files to the old folder directory. Highly recommended to save computer ressources!";
        }

        private void lblNotifyOption_Enter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Kind of notification:{0}Toast: Outlook like notification; Sound: only play the sound file; and both", Environment.NewLine);
        }

        private void lblSoundFile_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("The sound file which should be played. Keep in mind that as long the playback needs there will be no new notifications!{0}Supported files are e.g.: mp3, wav, ogg", Environment.NewLine);
        }

        private void lblNotifyKeywords_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "Here you can add additional keywords you want to use for notification. Please seperate them using ',' - not case sensitive. (e.g. if you have nickname everyone uses";
        }

        private void lblVolume_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "Here you can set the volume of your sound notification.";
        }

        private void lblUpdateCheck_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("If enabled the program checks on startup for new versions by calling the github release api.{0}(Simple get request - no information are sent)", Environment.NewLine);
        }

        private void lblAutostart_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("If you want this program can add itselfe to autostart by checking this box.{0}Please enable 'move old logs' to avoid high cpu and hdd usage of this tool!", Environment.NewLine);
        }

        private void fontSize_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Choose a font size between 6 and 30 points.");
        }

        private void ignoreMotd_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("If you set the MOTD you get informed every time your client starts (see 'MOTD Username').");
        }

        private void ignoreOwnMessages(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("This ignores all messages which are sent from the logged in user. This only affects each pilot itselfe.");
        }

        private void motdUserName(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("MOTD can only be detected by username. It should be something like 'EVE-System'. Check the log files to get the correct one.");
        }

        private void btnTestVolume_Click(object sender, EventArgs e)
        {
            SaveChanges();
            Properties.Settings.Default.Reload();

            Notifier.GetInstance().StopPlayback();
            Notifier.GetInstance().Notify("Test User in 'Alliance'", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.", fileNotifySound.SelectedFile);
        }

        private void SaveChanges()
        {
            Properties.Settings.Default.EveChatLogsPath = PathHelper.EncryptedPath(folderEveChatLogs.SelectedFolder);
            Properties.Settings.Default.LogFile = PathHelper.EncryptedPath(fileLog.SelectedFile);
            Properties.Settings.Default.MoveOldLogs = cbMoveLog.Checked;
            Properties.Settings.Default.MoveOldLogsPath = PathHelper.EncryptedPath(folderMoveLogs.SelectedFolder);
            Properties.Settings.Default.DeleteLogs = cbDeleteLogs.Checked;
            Properties.Settings.Default.NotifyKeywords = tbNotifyKeywords.Text;
            Properties.Settings.Default.SoundVolume = tbarVolume.Value;
            Properties.Settings.Default.CheckForUpdates = cbUpdates.Checked;
            Properties.Settings.Default.ToastFontSizeTitle = Convert.ToInt32(nudFontSizeTitle.Value);
            Properties.Settings.Default.ToastFontSizeContent = Convert.ToInt32(nudFontSizeContent.Value);
            Properties.Settings.Default.IgnoreMotd = cbIgnoreMotd.Checked;
            Properties.Settings.Default.IgnoreOwnMessages = cbIgnoreOwn.Checked;
            Properties.Settings.Default.MotdUsername = tbMotdUsername.Text;
            Properties.Settings.Default.IgnoreChannels = tbIgnoreChannels.Text;
            Properties.Settings.Default.IgnorePilots = tbIgnorePilots.Text;
            Properties.Settings.Default.AlwaysPilots = tbAlwaysPilots.Text;
            Properties.Settings.Default.AlwaysChannels = tbAlwaysChannels.Text;
            Properties.Settings.Default.AutoStartDelayMinutes = Convert.ToInt32(nudAutoStartDelay.Value);

            NotifyOptions no = (NotifyOptions)cbNotify.SelectedItem;
            switch (no)
            {
                case NotifyOptions.Toast:
                    Properties.Settings.Default.ShowToast = true;
                    Properties.Settings.Default.SoundFilePath = null;
                    break;
                case NotifyOptions.Sound:
                    Properties.Settings.Default.ShowToast = false;
                    Properties.Settings.Default.SoundFilePath = PathHelper.EncryptedPath(fileNotifySound.SelectedFile);
                    break;
                case NotifyOptions.Both:
                    Properties.Settings.Default.ShowToast = true;
                    Properties.Settings.Default.SoundFilePath = PathHelper.EncryptedPath(fileNotifySound.SelectedFile);
                    break;
            }

            Properties.Settings.Default.Save();

            if (cbAutoStart.Enabled)
            {
                try
                {
                    Autostart.ManageAutostart.Instance.Enabled = cbAutoStart.Checked;
                    Autostart.ManageAutostart.Instance.ChangeDelay(Properties.Settings.Default.AutoStartDelayMinutes);
                }
                catch (Exception ex)
                {
                    Logging.WriteLine(string.Format("Error changing autostart enabled:{0}{1}", Environment.NewLine, ex.ToString()));
                }
            }
        }

        private void lblIgnorePilots_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Here you can specify pilotnames (sender) which are ignored for notification. Please seperate them using ',' - not case sensitive.");
        }

        private void lblIgnoreChannels_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Here you can specify channelname which are ignored for notification. Please seperate them using ',' - not case sensitive.");
        }
        private void lblAlwaysChannels_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Here you can specify channelname which are always notified. Please seperate them using ',' - not case sensitive.");
        }

        private void lblAlwaysPilots_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Here you can specify pilotnames (sender) which are always notified. Please seperate them using ',' - not case sensitive.");
        }

        private void LblAutostartDelay_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("You can add an auto start delay in minutes here (e.g. reduce startup load, wait for network drive, cloud space, ...)");
        }

        private void lblDeleteLogs_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = String.Format("ATTENTION:{0}Enabling this deletes all logfiles in the eve log folder. This cannot be undone so use on your own risk! (This was made to prevent your storage space to be filled with eve logs", Environment.NewLine);
        }

        private void cbDeleteLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (!initializationFinished)
                return;

            CheckBox curBox = (CheckBox)sender;

            if(curBox.Checked)
            {
                if(MessageBox.Show(String.Format("ATTENTION{0}Enabling this deletes all logfiles in the eve log folder.{0}This cannot be undone so use on your own risk!{0}{0}(This was made to prevent your storage space to be filled with eve logs.){0}{0}Do you want to continue enabling it?", Environment.NewLine)
                    , "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    curBox.Checked = false;
                    return;
                }
            }

            // disable move checkbox if this is enabled
            cbMoveLog.Enabled = !curBox.Checked;
            if (curBox.Checked)
                cbMoveLog.Checked = false;
        }
    }
}
