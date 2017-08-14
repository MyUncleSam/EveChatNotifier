namespace EveChatNotifier
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbHelp = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.folderMoveLogs = new EveChatNotifier.HelperControls.FolderChooser();
            this.fileLog = new EveChatNotifier.HelperControls.FileChooser();
            this.folderEveChatLogs = new EveChatNotifier.HelperControls.FolderChooser();
            this.cbMoveLog = new System.Windows.Forms.CheckBox();
            this.lblMoveLogs = new System.Windows.Forms.Label();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.lblEveChatLogPath = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNotifyKeywords = new System.Windows.Forms.TextBox();
            this.lblSoundFile = new System.Windows.Forms.Label();
            this.lblNotifyKeywords = new System.Windows.Forms.Label();
            this.fileNotifySound = new EveChatNotifier.HelperControls.FileChooser();
            this.lblNotifyOption = new System.Windows.Forms.Label();
            this.cbNotify = new System.Windows.Forms.ComboBox();
            this.tbarVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.btnTestVolume = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tbHelp);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(-52, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 121);
            this.panel1.TabIndex = 0;
            // 
            // tbHelp
            // 
            this.tbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHelp.Location = new System.Drawing.Point(56, 3);
            this.tbHelp.Multiline = true;
            this.tbHelp.Name = "tbHelp";
            this.tbHelp.ReadOnly = true;
            this.tbHelp.Size = new System.Drawing.Size(692, 41);
            this.tbHelp.TabIndex = 2;
            this.tbHelp.Text = "Hover a settings text to get more information about it.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(754, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(835, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.folderMoveLogs);
            this.groupBox1.Controls.Add(this.fileLog);
            this.groupBox1.Controls.Add(this.folderEveChatLogs);
            this.groupBox1.Controls.Add(this.cbMoveLog);
            this.groupBox1.Controls.Add(this.lblMoveLogs);
            this.groupBox1.Controls.Add(this.lblLogPath);
            this.groupBox1.Controls.Add(this.lblEveChatLogPath);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "move destination";
            // 
            // folderMoveLogs
            // 
            this.folderMoveLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderMoveLogs.Enabled = false;
            this.folderMoveLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderMoveLogs.Location = new System.Drawing.Point(125, 75);
            this.folderMoveLogs.Name = "folderMoveLogs";
            this.folderMoveLogs.SelectedFolder = "";
            this.folderMoveLogs.Size = new System.Drawing.Size(715, 22);
            this.folderMoveLogs.TabIndex = 11;
            // 
            // fileLog
            // 
            this.fileLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileLog.BackColor = System.Drawing.SystemColors.Window;
            this.fileLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLog.Location = new System.Drawing.Point(104, 47);
            this.fileLog.Name = "fileLog";
            this.fileLog.SelectedFile = "";
            this.fileLog.Size = new System.Drawing.Size(736, 22);
            this.fileLog.TabIndex = 10;
            // 
            // folderEveChatLogs
            // 
            this.folderEveChatLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderEveChatLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderEveChatLogs.Location = new System.Drawing.Point(104, 19);
            this.folderEveChatLogs.Name = "folderEveChatLogs";
            this.folderEveChatLogs.SelectedFolder = "";
            this.folderEveChatLogs.Size = new System.Drawing.Size(736, 22);
            this.folderEveChatLogs.TabIndex = 9;
            // 
            // cbMoveLog
            // 
            this.cbMoveLog.AutoSize = true;
            this.cbMoveLog.Location = new System.Drawing.Point(104, 79);
            this.cbMoveLog.Name = "cbMoveLog";
            this.cbMoveLog.Size = new System.Drawing.Size(15, 14);
            this.cbMoveLog.TabIndex = 8;
            this.cbMoveLog.UseVisualStyleBackColor = true;
            this.cbMoveLog.CheckedChanged += new System.EventHandler(this.cbMoveLog_CheckedChanged);
            // 
            // lblMoveLogs
            // 
            this.lblMoveLogs.AutoSize = true;
            this.lblMoveLogs.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblMoveLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveLogs.Location = new System.Drawing.Point(6, 78);
            this.lblMoveLogs.Name = "lblMoveLogs";
            this.lblMoveLogs.Size = new System.Drawing.Size(72, 13);
            this.lblMoveLogs.TabIndex = 7;
            this.lblMoveLogs.Text = "move old logs";
            this.lblMoveLogs.MouseEnter += new System.EventHandler(this.lblMoveLogs_MouseEnter);
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogPath.Location = new System.Drawing.Point(6, 50);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(86, 13);
            this.lblLogPath.TabIndex = 4;
            this.lblLogPath.Text = "program log path";
            this.lblLogPath.MouseEnter += new System.EventHandler(this.lblLogFile_MouseEnter);
            // 
            // lblEveChatLogPath
            // 
            this.lblEveChatLogPath.AutoSize = true;
            this.lblEveChatLogPath.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblEveChatLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEveChatLogPath.Location = new System.Drawing.Point(6, 22);
            this.lblEveChatLogPath.Name = "lblEveChatLogPath";
            this.lblEveChatLogPath.Size = new System.Drawing.Size(92, 13);
            this.lblEveChatLogPath.TabIndex = 1;
            this.lblEveChatLogPath.Text = "eve chatlogs path";
            this.lblEveChatLogPath.MouseEnter += new System.EventHandler(this.lblEveChatLogs_MouseEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnTestVolume);
            this.groupBox2.Controls.Add(this.lblVolume);
            this.groupBox2.Controls.Add(this.tbarVolume);
            this.groupBox2.Controls.Add(this.tbNotifyKeywords);
            this.groupBox2.Controls.Add(this.lblSoundFile);
            this.groupBox2.Controls.Add(this.lblNotifyKeywords);
            this.groupBox2.Controls.Add(this.fileNotifySound);
            this.groupBox2.Controls.Add(this.lblNotifyOption);
            this.groupBox2.Controls.Add(this.cbNotify);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "notification";
            // 
            // tbNotifyKeywords
            // 
            this.tbNotifyKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotifyKeywords.Location = new System.Drawing.Point(105, 105);
            this.tbNotifyKeywords.Name = "tbNotifyKeywords";
            this.tbNotifyKeywords.Size = new System.Drawing.Size(735, 20);
            this.tbNotifyKeywords.TabIndex = 9;
            // 
            // lblSoundFile
            // 
            this.lblSoundFile.AutoSize = true;
            this.lblSoundFile.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblSoundFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoundFile.Location = new System.Drawing.Point(6, 49);
            this.lblSoundFile.Name = "lblSoundFile";
            this.lblSoundFile.Size = new System.Drawing.Size(86, 13);
            this.lblSoundFile.TabIndex = 7;
            this.lblSoundFile.Text = "sound file to play";
            this.lblSoundFile.MouseEnter += new System.EventHandler(this.lblSoundFile_MouseEnter);
            // 
            // lblNotifyKeywords
            // 
            this.lblNotifyKeywords.AutoSize = true;
            this.lblNotifyKeywords.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblNotifyKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyKeywords.Location = new System.Drawing.Point(6, 108);
            this.lblNotifyKeywords.Name = "lblNotifyKeywords";
            this.lblNotifyKeywords.Size = new System.Drawing.Size(80, 13);
            this.lblNotifyKeywords.TabIndex = 8;
            this.lblNotifyKeywords.Text = "notify keywords";
            this.lblNotifyKeywords.MouseEnter += new System.EventHandler(this.lblNotifyKeywords_MouseEnter);
            // 
            // fileNotifySound
            // 
            this.fileNotifySound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNotifySound.BackColor = System.Drawing.SystemColors.Window;
            this.fileNotifySound.Enabled = false;
            this.fileNotifySound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNotifySound.Location = new System.Drawing.Point(104, 46);
            this.fileNotifySound.Name = "fileNotifySound";
            this.fileNotifySound.SelectedFile = "";
            this.fileNotifySound.Size = new System.Drawing.Size(736, 22);
            this.fileNotifySound.TabIndex = 6;
            this.fileNotifySound.EnabledChanged += new System.EventHandler(this.fileNotifySound_EnabledChanged);
            // 
            // lblNotifyOption
            // 
            this.lblNotifyOption.AutoSize = true;
            this.lblNotifyOption.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblNotifyOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyOption.Location = new System.Drawing.Point(6, 22);
            this.lblNotifyOption.Name = "lblNotifyOption";
            this.lblNotifyOption.Size = new System.Drawing.Size(67, 13);
            this.lblNotifyOption.TabIndex = 5;
            this.lblNotifyOption.Text = "how to notify";
            this.lblNotifyOption.MouseEnter += new System.EventHandler(this.lblNotifyOption_Enter);
            // 
            // cbNotify
            // 
            this.cbNotify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNotify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNotify.FormattingEnabled = true;
            this.cbNotify.Location = new System.Drawing.Point(105, 19);
            this.cbNotify.Name = "cbNotify";
            this.cbNotify.Size = new System.Drawing.Size(735, 21);
            this.cbNotify.TabIndex = 0;
            this.cbNotify.SelectedValueChanged += new System.EventHandler(this.cbNotify_SelectedValueChanged);
            // 
            // tbarVolume
            // 
            this.tbarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarVolume.AutoSize = false;
            this.tbarVolume.Enabled = false;
            this.tbarVolume.Location = new System.Drawing.Point(105, 74);
            this.tbarVolume.Maximum = 100;
            this.tbarVolume.Name = "tbarVolume";
            this.tbarVolume.Size = new System.Drawing.Size(660, 25);
            this.tbarVolume.TabIndex = 10;
            this.tbarVolume.TickFrequency = 10;
            this.tbarVolume.Value = 100;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.Location = new System.Drawing.Point(6, 79);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(41, 13);
            this.lblVolume.TabIndex = 11;
            this.lblVolume.Text = "volume";
            this.lblVolume.MouseEnter += new System.EventHandler(this.lblVolume_MouseEnter);
            // 
            // btnTestVolume
            // 
            this.btnTestVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestVolume.Enabled = false;
            this.btnTestVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestVolume.Location = new System.Drawing.Point(771, 74);
            this.btnTestVolume.Name = "btnTestVolume";
            this.btnTestVolume.Size = new System.Drawing.Size(69, 23);
            this.btnTestVolume.TabIndex = 12;
            this.btnTestVolume.Text = "test";
            this.btnTestVolume.UseVisualStyleBackColor = true;
            this.btnTestVolume.Click += new System.EventHandler(this.btnTestVolume_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(870, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEveChatLogPath;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.CheckBox cbMoveLog;
        private System.Windows.Forms.Label lblMoveLogs;
        private HelperControls.FolderChooser folderMoveLogs;
        private HelperControls.FileChooser fileLog;
        private HelperControls.FolderChooser folderEveChatLogs;
        private System.Windows.Forms.TextBox tbHelp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNotifyOption;
        private System.Windows.Forms.ComboBox cbNotify;
        private System.Windows.Forms.Label lblSoundFile;
        private HelperControls.FileChooser fileNotifySound;
        private System.Windows.Forms.TextBox tbNotifyKeywords;
        private System.Windows.Forms.Label lblNotifyKeywords;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar tbarVolume;
        private System.Windows.Forms.Button btnTestVolume;
    }
}