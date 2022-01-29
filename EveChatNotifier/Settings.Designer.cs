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
            this.btnTest = new System.Windows.Forms.Button();
            this.tbHelp = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDeleteLogs = new System.Windows.Forms.Label();
            this.cbDeleteLogs = new System.Windows.Forms.CheckBox();
            this.folderMoveLogs = new EveChatNotifier.HelperControls.FolderChooser();
            this.fileLog = new EveChatNotifier.HelperControls.FileChooser();
            this.folderEveChatLogs = new EveChatNotifier.HelperControls.FolderChooser();
            this.cbMoveLog = new System.Windows.Forms.CheckBox();
            this.lblMoveLogs = new System.Windows.Forms.Label();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.lblEveChatLogPath = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tbarVolume = new System.Windows.Forms.TrackBar();
            this.tbNotifyKeywords = new System.Windows.Forms.TextBox();
            this.lblSoundFile = new System.Windows.Forms.Label();
            this.lblNotifyKeywords = new System.Windows.Forms.Label();
            this.fileNotifySound = new EveChatNotifier.HelperControls.FileChooser();
            this.lblNotifyOption = new System.Windows.Forms.Label();
            this.cbNotify = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudAutoStartDelay = new System.Windows.Forms.NumericUpDown();
            this.lblAutostartDelay = new System.Windows.Forms.Label();
            this.tbMotdUsername = new System.Windows.Forms.TextBox();
            this.lblMotdUsername = new System.Windows.Forms.Label();
            this.cbIgnoreOwn = new System.Windows.Forms.CheckBox();
            this.lblIgnoreOwn = new System.Windows.Forms.Label();
            this.cbIgnoreMotd = new System.Windows.Forms.CheckBox();
            this.lblIgnoreMotd = new System.Windows.Forms.Label();
            this.nudFontSizeContent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFontSizeTitle = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.lblAutostart = new System.Windows.Forms.Label();
            this.cbUpdates = new System.Windows.Forms.CheckBox();
            this.lblUpdateCheck = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbIgnoreChannels = new System.Windows.Forms.TextBox();
            this.tbIgnorePilots = new System.Windows.Forms.TextBox();
            this.lblIgnoreChannels = new System.Windows.Forms.Label();
            this.lblIgnorePilots = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbAlwaysPilots = new System.Windows.Forms.TextBox();
            this.lblAlwaysPilots = new System.Windows.Forms.Label();
            this.tbAlwaysChannels = new System.Windows.Forms.TextBox();
            this.lblAlwaysChannels = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoStartDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeTitle)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.tbHelp);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(-52, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 121);
            this.panel1.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Enabled = false;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(657, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(91, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Apply && Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTestVolume_Click);
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
            this.tbHelp.Size = new System.Drawing.Size(595, 41);
            this.tbHelp.TabIndex = 0;
            this.tbHelp.Text = "Hover over a settings text to get more information about it.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(754, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
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
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDeleteLogs);
            this.groupBox1.Controls.Add(this.cbDeleteLogs);
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
            this.groupBox1.Size = new System.Drawing.Size(846, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat Log File Locations";
            // 
            // lblDeleteLogs
            // 
            this.lblDeleteLogs.AutoSize = true;
            this.lblDeleteLogs.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblDeleteLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteLogs.Location = new System.Drawing.Point(6, 99);
            this.lblDeleteLogs.Name = "lblDeleteLogs";
            this.lblDeleteLogs.Size = new System.Drawing.Size(64, 13);
            this.lblDeleteLogs.TabIndex = 9;
            this.lblDeleteLogs.Text = "Delete Logs";
            this.lblDeleteLogs.MouseEnter += new System.EventHandler(this.lblDeleteLogs_MouseEnter);
            // 
            // cbDeleteLogs
            // 
            this.cbDeleteLogs.AutoSize = true;
            this.cbDeleteLogs.Location = new System.Drawing.Point(104, 99);
            this.cbDeleteLogs.Name = "cbDeleteLogs";
            this.cbDeleteLogs.Size = new System.Drawing.Size(15, 14);
            this.cbDeleteLogs.TabIndex = 8;
            this.cbDeleteLogs.UseVisualStyleBackColor = true;
            this.cbDeleteLogs.CheckedChanged += new System.EventHandler(this.cbDeleteLogs_CheckedChanged);
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
            this.folderMoveLogs.TabIndex = 6;
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
            this.fileLog.TabIndex = 3;
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
            this.folderEveChatLogs.TabIndex = 1;
            // 
            // cbMoveLog
            // 
            this.cbMoveLog.AutoSize = true;
            this.cbMoveLog.Location = new System.Drawing.Point(104, 79);
            this.cbMoveLog.Name = "cbMoveLog";
            this.cbMoveLog.Size = new System.Drawing.Size(15, 14);
            this.cbMoveLog.TabIndex = 5;
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
            this.lblMoveLogs.Size = new System.Drawing.Size(90, 13);
            this.lblMoveLogs.TabIndex = 4;
            this.lblMoveLogs.Text = "Backup Log Path";
            this.lblMoveLogs.MouseEnter += new System.EventHandler(this.lblMoveLogs_MouseEnter);
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogPath.Location = new System.Drawing.Point(6, 50);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(92, 13);
            this.lblLogPath.TabIndex = 2;
            this.lblLogPath.Text = "Program Log Path";
            this.lblLogPath.MouseEnter += new System.EventHandler(this.lblLogFile_MouseEnter);
            // 
            // lblEveChatLogPath
            // 
            this.lblEveChatLogPath.AutoSize = true;
            this.lblEveChatLogPath.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblEveChatLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEveChatLogPath.Location = new System.Drawing.Point(6, 22);
            this.lblEveChatLogPath.Name = "lblEveChatLogPath";
            this.lblEveChatLogPath.Size = new System.Drawing.Size(97, 13);
            this.lblEveChatLogPath.TabIndex = 0;
            this.lblEveChatLogPath.Text = "Eve\'s Chatlog Path";
            this.lblEveChatLogPath.MouseEnter += new System.EventHandler(this.lblEveChatLogs_MouseEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblVolume);
            this.groupBox2.Controls.Add(this.tbarVolume);
            this.groupBox2.Controls.Add(this.tbNotifyKeywords);
            this.groupBox2.Controls.Add(this.lblSoundFile);
            this.groupBox2.Controls.Add(this.lblNotifyKeywords);
            this.groupBox2.Controls.Add(this.fileNotifySound);
            this.groupBox2.Controls.Add(this.lblNotifyOption);
            this.groupBox2.Controls.Add(this.cbNotify);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notifications";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.Location = new System.Drawing.Point(6, 79);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 4;
            this.lblVolume.Text = "Volume";
            this.lblVolume.MouseEnter += new System.EventHandler(this.lblVolume_MouseEnter);
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
            this.tbarVolume.Size = new System.Drawing.Size(735, 25);
            this.tbarVolume.TabIndex = 5;
            this.tbarVolume.TickFrequency = 10;
            this.tbarVolume.Value = 100;
            // 
            // tbNotifyKeywords
            // 
            this.tbNotifyKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotifyKeywords.Location = new System.Drawing.Point(105, 105);
            this.tbNotifyKeywords.Name = "tbNotifyKeywords";
            this.tbNotifyKeywords.Size = new System.Drawing.Size(735, 20);
            this.tbNotifyKeywords.TabIndex = 7;
            // 
            // lblSoundFile
            // 
            this.lblSoundFile.AutoSize = true;
            this.lblSoundFile.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblSoundFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoundFile.Location = new System.Drawing.Point(6, 49);
            this.lblSoundFile.Name = "lblSoundFile";
            this.lblSoundFile.Size = new System.Drawing.Size(53, 13);
            this.lblSoundFile.TabIndex = 2;
            this.lblSoundFile.Text = "Audio File";
            this.lblSoundFile.MouseEnter += new System.EventHandler(this.lblSoundFile_MouseEnter);
            // 
            // lblNotifyKeywords
            // 
            this.lblNotifyKeywords.AutoSize = true;
            this.lblNotifyKeywords.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblNotifyKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyKeywords.Location = new System.Drawing.Point(6, 108);
            this.lblNotifyKeywords.Name = "lblNotifyKeywords";
            this.lblNotifyKeywords.Size = new System.Drawing.Size(53, 13);
            this.lblNotifyKeywords.TabIndex = 6;
            this.lblNotifyKeywords.Text = "Keywords";
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
            this.fileNotifySound.TabIndex = 3;
            this.fileNotifySound.EnabledChanged += new System.EventHandler(this.fileNotifySound_EnabledChanged);
            // 
            // lblNotifyOption
            // 
            this.lblNotifyOption.AutoSize = true;
            this.lblNotifyOption.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblNotifyOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyOption.Location = new System.Drawing.Point(6, 22);
            this.lblNotifyOption.Name = "lblNotifyOption";
            this.lblNotifyOption.Size = new System.Drawing.Size(99, 13);
            this.lblNotifyOption.TabIndex = 0;
            this.lblNotifyOption.Text = "Notification Method";
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
            this.cbNotify.TabIndex = 1;
            this.cbNotify.SelectedValueChanged += new System.EventHandler(this.cbNotify_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.nudAutoStartDelay);
            this.groupBox3.Controls.Add(this.lblAutostartDelay);
            this.groupBox3.Controls.Add(this.tbMotdUsername);
            this.groupBox3.Controls.Add(this.lblMotdUsername);
            this.groupBox3.Controls.Add(this.cbIgnoreOwn);
            this.groupBox3.Controls.Add(this.lblIgnoreOwn);
            this.groupBox3.Controls.Add(this.cbIgnoreMotd);
            this.groupBox3.Controls.Add(this.lblIgnoreMotd);
            this.groupBox3.Controls.Add(this.nudFontSizeContent);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nudFontSizeTitle);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbAutoStart);
            this.groupBox3.Controls.Add(this.lblAutostart);
            this.groupBox3.Controls.Add(this.cbUpdates);
            this.groupBox3.Controls.Add(this.lblUpdateCheck);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(846, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Settings";
            // 
            // nudAutoStartDelay
            // 
            this.nudAutoStartDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAutoStartDelay.Location = new System.Drawing.Point(261, 13);
            this.nudAutoStartDelay.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudAutoStartDelay.Name = "nudAutoStartDelay";
            this.nudAutoStartDelay.Size = new System.Drawing.Size(44, 20);
            this.nudAutoStartDelay.TabIndex = 5;
            // 
            // lblAutostartDelay
            // 
            this.lblAutostartDelay.AutoSize = true;
            this.lblAutostartDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutostartDelay.Location = new System.Drawing.Point(134, 19);
            this.lblAutostartDelay.Name = "lblAutostartDelay";
            this.lblAutostartDelay.Size = new System.Drawing.Size(124, 13);
            this.lblAutostartDelay.TabIndex = 4;
            this.lblAutostartDelay.Text = "Autostart Delay (minutes)";
            this.lblAutostartDelay.MouseEnter += new System.EventHandler(this.LblAutostartDelay_MouseEnter);
            // 
            // tbMotdUsername
            // 
            this.tbMotdUsername.Location = new System.Drawing.Point(601, 36);
            this.tbMotdUsername.Name = "tbMotdUsername";
            this.tbMotdUsername.Size = new System.Drawing.Size(172, 20);
            this.tbMotdUsername.TabIndex = 13;
            // 
            // lblMotdUsername
            // 
            this.lblMotdUsername.AutoSize = true;
            this.lblMotdUsername.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblMotdUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotdUsername.Location = new System.Drawing.Point(486, 40);
            this.lblMotdUsername.Name = "lblMotdUsername";
            this.lblMotdUsername.Size = new System.Drawing.Size(90, 13);
            this.lblMotdUsername.TabIndex = 12;
            this.lblMotdUsername.Text = "MOTD Username";
            this.lblMotdUsername.MouseEnter += new System.EventHandler(this.motdUserName);
            // 
            // cbIgnoreOwn
            // 
            this.cbIgnoreOwn.AutoSize = true;
            this.cbIgnoreOwn.Location = new System.Drawing.Point(758, 19);
            this.cbIgnoreOwn.Name = "cbIgnoreOwn";
            this.cbIgnoreOwn.Size = new System.Drawing.Size(15, 14);
            this.cbIgnoreOwn.TabIndex = 15;
            this.cbIgnoreOwn.UseVisualStyleBackColor = true;
            // 
            // lblIgnoreOwn
            // 
            this.lblIgnoreOwn.AutoSize = true;
            this.lblIgnoreOwn.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblIgnoreOwn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgnoreOwn.Location = new System.Drawing.Point(643, 19);
            this.lblIgnoreOwn.Name = "lblIgnoreOwn";
            this.lblIgnoreOwn.Size = new System.Drawing.Size(58, 13);
            this.lblIgnoreOwn.TabIndex = 14;
            this.lblIgnoreOwn.Text = "Ignore Self";
            this.lblIgnoreOwn.MouseEnter += new System.EventHandler(this.ignoreOwnMessages);
            // 
            // cbIgnoreMotd
            // 
            this.cbIgnoreMotd.AutoSize = true;
            this.cbIgnoreMotd.Location = new System.Drawing.Point(601, 19);
            this.cbIgnoreMotd.Name = "cbIgnoreMotd";
            this.cbIgnoreMotd.Size = new System.Drawing.Size(15, 14);
            this.cbIgnoreMotd.TabIndex = 11;
            this.cbIgnoreMotd.UseVisualStyleBackColor = true;
            // 
            // lblIgnoreMotd
            // 
            this.lblIgnoreMotd.AutoSize = true;
            this.lblIgnoreMotd.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblIgnoreMotd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgnoreMotd.Location = new System.Drawing.Point(486, 19);
            this.lblIgnoreMotd.Name = "lblIgnoreMotd";
            this.lblIgnoreMotd.Size = new System.Drawing.Size(72, 13);
            this.lblIgnoreMotd.TabIndex = 10;
            this.lblIgnoreMotd.Text = "Ignore MOTD";
            this.lblIgnoreMotd.MouseEnter += new System.EventHandler(this.ignoreMotd_MouseEnter);
            // 
            // nudFontSizeContent
            // 
            this.nudFontSizeContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFontSizeContent.Location = new System.Drawing.Point(423, 38);
            this.nudFontSizeContent.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudFontSizeContent.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudFontSizeContent.Name = "nudFontSizeContent";
            this.nudFontSizeContent.Size = new System.Drawing.Size(44, 20);
            this.nudFontSizeContent.TabIndex = 9;
            this.nudFontSizeContent.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Message Font Size";
            this.label2.MouseEnter += new System.EventHandler(this.fontSize_MouseEnter);
            // 
            // nudFontSizeTitle
            // 
            this.nudFontSizeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFontSizeTitle.Location = new System.Drawing.Point(423, 12);
            this.nudFontSizeTitle.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudFontSizeTitle.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudFontSizeTitle.Name = "nudFontSizeTitle";
            this.nudFontSizeTitle.Size = new System.Drawing.Size(44, 20);
            this.nudFontSizeTitle.TabIndex = 7;
            this.nudFontSizeTitle.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Title Font Size";
            this.label1.MouseEnter += new System.EventHandler(this.fontSize_MouseEnter);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(104, 39);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(15, 14);
            this.cbAutoStart.TabIndex = 3;
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // lblAutostart
            // 
            this.lblAutostart.AutoSize = true;
            this.lblAutostart.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblAutostart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutostart.Location = new System.Drawing.Point(6, 40);
            this.lblAutostart.Name = "lblAutostart";
            this.lblAutostart.Size = new System.Drawing.Size(91, 13);
            this.lblAutostart.TabIndex = 2;
            this.lblAutostart.Text = "Autostart Program";
            this.lblAutostart.MouseEnter += new System.EventHandler(this.lblAutostart_MouseEnter);
            // 
            // cbUpdates
            // 
            this.cbUpdates.AutoSize = true;
            this.cbUpdates.Location = new System.Drawing.Point(104, 19);
            this.cbUpdates.Name = "cbUpdates";
            this.cbUpdates.Size = new System.Drawing.Size(15, 14);
            this.cbUpdates.TabIndex = 1;
            this.cbUpdates.UseVisualStyleBackColor = true;
            // 
            // lblUpdateCheck
            // 
            this.lblUpdateCheck.AutoSize = true;
            this.lblUpdateCheck.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblUpdateCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateCheck.Location = new System.Drawing.Point(6, 19);
            this.lblUpdateCheck.Name = "lblUpdateCheck";
            this.lblUpdateCheck.Size = new System.Drawing.Size(99, 13);
            this.lblUpdateCheck.TabIndex = 0;
            this.lblUpdateCheck.Text = "Check For Updates";
            this.lblUpdateCheck.MouseEnter += new System.EventHandler(this.lblUpdateCheck_MouseEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbIgnoreChannels);
            this.groupBox4.Controls.Add(this.tbIgnorePilots);
            this.groupBox4.Controls.Add(this.lblIgnoreChannels);
            this.groupBox4.Controls.Add(this.lblIgnorePilots);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 367);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(846, 74);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ignore List";
            // 
            // tbIgnoreChannels
            // 
            this.tbIgnoreChannels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIgnoreChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIgnoreChannels.Location = new System.Drawing.Point(105, 42);
            this.tbIgnoreChannels.Name = "tbIgnoreChannels";
            this.tbIgnoreChannels.Size = new System.Drawing.Size(735, 20);
            this.tbIgnoreChannels.TabIndex = 3;
            // 
            // tbIgnorePilots
            // 
            this.tbIgnorePilots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIgnorePilots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIgnorePilots.Location = new System.Drawing.Point(105, 16);
            this.tbIgnorePilots.Name = "tbIgnorePilots";
            this.tbIgnorePilots.Size = new System.Drawing.Size(735, 20);
            this.tbIgnorePilots.TabIndex = 1;
            // 
            // lblIgnoreChannels
            // 
            this.lblIgnoreChannels.AutoSize = true;
            this.lblIgnoreChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgnoreChannels.Location = new System.Drawing.Point(6, 45);
            this.lblIgnoreChannels.Name = "lblIgnoreChannels";
            this.lblIgnoreChannels.Size = new System.Drawing.Size(85, 13);
            this.lblIgnoreChannels.TabIndex = 2;
            this.lblIgnoreChannels.Text = "Channel Names:";
            this.lblIgnoreChannels.MouseEnter += new System.EventHandler(this.lblIgnoreChannels_MouseEnter);
            // 
            // lblIgnorePilots
            // 
            this.lblIgnorePilots.AutoSize = true;
            this.lblIgnorePilots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgnorePilots.Location = new System.Drawing.Point(6, 19);
            this.lblIgnorePilots.Name = "lblIgnorePilots";
            this.lblIgnorePilots.Size = new System.Drawing.Size(66, 13);
            this.lblIgnorePilots.TabIndex = 0;
            this.lblIgnorePilots.Text = "Pilot Names:";
            this.lblIgnorePilots.MouseEnter += new System.EventHandler(this.lblIgnorePilots_MouseEnter);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tbAlwaysPilots);
            this.groupBox5.Controls.Add(this.lblAlwaysPilots);
            this.groupBox5.Controls.Add(this.tbAlwaysChannels);
            this.groupBox5.Controls.Add(this.lblAlwaysChannels);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 447);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(846, 74);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Always Notify List";
            // 
            // tbAlwaysPilots
            // 
            this.tbAlwaysPilots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAlwaysPilots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlwaysPilots.Location = new System.Drawing.Point(105, 16);
            this.tbAlwaysPilots.Name = "tbAlwaysPilots";
            this.tbAlwaysPilots.Size = new System.Drawing.Size(735, 20);
            this.tbAlwaysPilots.TabIndex = 1;
            // 
            // lblAlwaysPilots
            // 
            this.lblAlwaysPilots.AutoSize = true;
            this.lblAlwaysPilots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlwaysPilots.Location = new System.Drawing.Point(6, 19);
            this.lblAlwaysPilots.Name = "lblAlwaysPilots";
            this.lblAlwaysPilots.Size = new System.Drawing.Size(66, 13);
            this.lblAlwaysPilots.TabIndex = 0;
            this.lblAlwaysPilots.Text = "Pilot Names:";
            this.lblAlwaysPilots.MouseEnter += new System.EventHandler(this.lblAlwaysPilots_MouseEnter);
            // 
            // tbAlwaysChannels
            // 
            this.tbAlwaysChannels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAlwaysChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlwaysChannels.Location = new System.Drawing.Point(105, 42);
            this.tbAlwaysChannels.Name = "tbAlwaysChannels";
            this.tbAlwaysChannels.Size = new System.Drawing.Size(735, 20);
            this.tbAlwaysChannels.TabIndex = 3;
            // 
            // lblAlwaysChannels
            // 
            this.lblAlwaysChannels.AutoSize = true;
            this.lblAlwaysChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlwaysChannels.Location = new System.Drawing.Point(6, 45);
            this.lblAlwaysChannels.Name = "lblAlwaysChannels";
            this.lblAlwaysChannels.Size = new System.Drawing.Size(85, 13);
            this.lblAlwaysChannels.TabIndex = 2;
            this.lblAlwaysChannels.Text = "Channel Names:";
            this.lblAlwaysChannels.MouseEnter += new System.EventHandler(this.lblAlwaysChannels_MouseEnter);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(870, 579);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoStartDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSizeTitle)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbUpdates;
        private System.Windows.Forms.Label lblUpdateCheck;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.Label lblAutostart;
        private System.Windows.Forms.NumericUpDown nudFontSizeTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFontSizeContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIgnoreMotd;
        private System.Windows.Forms.Label lblIgnoreMotd;
        private System.Windows.Forms.CheckBox cbIgnoreOwn;
        private System.Windows.Forms.Label lblIgnoreOwn;
        private System.Windows.Forms.TextBox tbMotdUsername;
        private System.Windows.Forms.Label lblMotdUsername;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbIgnoreChannels;
        private System.Windows.Forms.TextBox tbIgnorePilots;
        private System.Windows.Forms.TextBox tbAlwaysPilots;
        private System.Windows.Forms.TextBox tbAlwaysChannels;
        private System.Windows.Forms.Label lblIgnoreChannels;
        private System.Windows.Forms.Label lblIgnorePilots;
        private System.Windows.Forms.Label lblAlwaysPilots;
        private System.Windows.Forms.Label lblAlwaysChannels;
        private System.Windows.Forms.NumericUpDown nudAutoStartDelay;
        private System.Windows.Forms.Label lblAutostartDelay;
        private System.Windows.Forms.CheckBox cbDeleteLogs;
        private System.Windows.Forms.Label lblDeleteLogs;
    }
}