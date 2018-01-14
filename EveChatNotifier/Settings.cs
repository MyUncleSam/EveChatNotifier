﻿using NAudio.Wave;
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

            // set notify option
            NotifyOptions curOption = NotifyOptions.Toast;

            if(Properties.Settings.Default.ShowToast && string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
            {
                curOption = NotifyOptions.Toast;
            }
            if(Properties.Settings.Default.ShowToast && !string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
            {
                curOption = NotifyOptions.Both;
            }
            if(!Properties.Settings.Default.ShowToast && !string.IsNullOrWhiteSpace(Properties.Settings.Default.SoundFilePath))
            {
                curOption = NotifyOptions.Sound;
            }
            cbNotify.SelectedItem = curOption;

            // sound file to play
            if(curOption == NotifyOptions.Both || curOption == NotifyOptions.Sound)
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

            // set autostart object
            try
            {
                cbAutoStart.Checked = Autostart.ManageAutostart.Instance.Enabled;
            }
            catch(Exception ex)
            {
                Logging.WriteLine(string.Format("Error getting autostart enabled state:{0}{1}", Environment.NewLine, ex.ToString()));
                cbAutoStart.Enabled = false;
            }

            // set font size
            nudFontSizeTitle.Value = Convert.ToDecimal(Properties.Settings.Default.ToastFontSizeTitle);
            nudFontSizeContent.Value = Convert.ToDecimal(Properties.Settings.Default.ToastFontSizeContent);
        }

        private void cbMoveLog_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox curCb = (CheckBox)sender;
            folderMoveLogs.Enabled = curCb.Checked;
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
            if(!fileNotifySound.Enabled)
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
            Properties.Settings.Default.NotifyKeywords = tbNotifyKeywords.Text;
            Properties.Settings.Default.SoundVolume = tbarVolume.Value;
            Properties.Settings.Default.CheckForUpdates = cbUpdates.Checked;
            Properties.Settings.Default.ToastFontSizeTitle = Convert.ToInt32(nudFontSizeTitle.Value);
            Properties.Settings.Default.ToastFontSizeContent = Convert.ToInt32(nudFontSizeContent.Value);

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
                }
                catch (Exception ex)
                {
                    Logging.WriteLine(string.Format("Error changing autostart enabled:{0}{1}", Environment.NewLine, ex.ToString()));
                }
            }
        }
    }
}
