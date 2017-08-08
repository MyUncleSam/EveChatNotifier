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
        public Settings()
        {
            InitializeComponent();

            this.Text = string.Format("Settings - v{0}", Application.ProductVersion);

            cbNotify.DataSource = Enum.GetValues(typeof(NotifyOptions));

            // set eve chat path
            string replDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderEveChatLogs.SelectedFolder = Properties.Settings.Default.EveChatLogsPath.Replace("%DOCUMENTS%", replDocumentsPath);

            // set program log path
            string exePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            fileLog.SelectedFile = Properties.Settings.Default.LogFile.Replace("%EXEPATH%", exePath);

            // set move old logs
            cbMoveLog.Checked = Properties.Settings.Default.MoveOldLogs;

            // set move old logs path
            folderMoveLogs.SelectedFolder = Properties.Settings.Default.MoveOldLogsPath.Replace("%CHATLOGS%", folderEveChatLogs.SelectedFolder);

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
                fileNotifySound.SelectedFile = Properties.Settings.Default.SoundFilePath;
            }
            else
            {
                fileNotifySound.SelectedFile = "";
            }

            // set notify keywords
            tbNotifyKeywords.Text = Properties.Settings.Default.NotifyKeywords;
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
                    break;
                case NotifyOptions.Sound:
                    fileNotifySound.Enabled = true;
                    break;
                case NotifyOptions.Both:
                    fileNotifySound.Enabled = true;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EveChatLogsPath = folderEveChatLogs.SelectedFolder;
            Properties.Settings.Default.LogFile = fileLog.SelectedFile;
            Properties.Settings.Default.MoveOldLogs = cbMoveLog.Checked;
            Properties.Settings.Default.MoveOldLogsPath = folderMoveLogs.SelectedFolder;
            Properties.Settings.Default.NotifyKeywords = tbNotifyKeywords.Text;

            NotifyOptions no = (NotifyOptions)cbNotify.SelectedItem;
            switch (no)
            {
                case NotifyOptions.Toast:
                    Properties.Settings.Default.ShowToast = true;
                    Properties.Settings.Default.SoundFilePath = "";
                    break;
                case NotifyOptions.Sound:
                    Properties.Settings.Default.ShowToast = false;
                    Properties.Settings.Default.SoundFilePath = fileNotifySound.SelectedFile;
                    break;
                case NotifyOptions.Both:
                    Properties.Settings.Default.ShowToast = true;
                    Properties.Settings.Default.SoundFilePath = fileNotifySound.SelectedFile;
                    break;
            }
            
            Properties.Settings.Default.Save();

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
            tbHelp.Text = "Path to the folder where all eve chat logs are. These files are going to be monitored.";
        }

        private void lblLogFile_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "Path to the file this program is writing its logfile into. All actions done by this tool are protocolled in there.";
        }

        private void lblMoveLogs_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "If activated the programm tries to move all eve chat log files to the old folder directory.";
        }

        private void lblNotifyOption_Enter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("Kind of notification:{0}Toast: Outlook like notification; Sound: only play the sound file; Both: ...", Environment.NewLine);
        }

        private void lblSoundFile_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = string.Format("The sound file which should be played. Please keep in mind that this sound should be short because there is no abort function!{0}Supported files are e.g.: mp3, wav, ogg", Environment.NewLine);
        }

        private void lblNotifyKeywords_MouseEnter(object sender, EventArgs e)
        {
            tbHelp.Text = "Here you can add additional keywords you want to use for notification. Please seperate them using ','! Not case sensitive.";
        }
    }
}
