namespace AionBot.View
{
    partial class ViewMain
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
            this.components = new System.ComponentModel.Container();
            this.timerReadMemory = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.gbGameLogin = new System.Windows.Forms.GroupBox();
            this.btnFindGame = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.cBCharacterPosition = new System.Windows.Forms.ComboBox();
            this.btnShowPathDialog = new System.Windows.Forms.Button();
            this.tBGamePath = new System.Windows.Forms.TextBox();
            this.cbEnableAutoPin = new System.Windows.Forms.CheckBox();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.cbAutoLogIn = new System.Windows.Forms.CheckBox();
            this.tabCharacter = new System.Windows.Forms.TabPage();
            this.gbCharacterInformation = new System.Windows.Forms.GroupBox();
            this.lblFT = new System.Windows.Forms.Label();
            this.lblDP = new System.Windows.Forms.Label();
            this.lblMP = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.tbLvl = new System.Windows.Forms.TextBox();
            this.tbClass = new System.Windows.Forms.TextBox();
            this.tbCharacterName = new System.Windows.Forms.TextBox();
            this.pbFT = new System.Windows.Forms.ProgressBar();
            this.pbDP = new System.Windows.Forms.ProgressBar();
            this.pbMP = new System.Windows.Forms.ProgressBar();
            this.pbHP = new System.Windows.Forms.ProgressBar();
            this.tabWaypoints = new System.Windows.Forms.TabPage();
            this.gbWaypoints = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxRestFor = new System.Windows.Forms.TextBox();
            this.checkBoxRest = new System.Windows.Forms.CheckBox();
            this.checkBoxFly = new System.Windows.Forms.CheckBox();
            this.checkBoxCollect = new System.Windows.Forms.CheckBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.btnRemoveWaypoint = new System.Windows.Forms.Button();
            this.btnAddWaypoint = new System.Windows.Forms.Button();
            this.dGVWaypoints = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCollect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.timerAutoLogIn = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.gbGameLogin.SuspendLayout();
            this.tabCharacter.SuspendLayout();
            this.gbCharacterInformation.SuspendLayout();
            this.tabWaypoints.SuspendLayout();
            this.gbWaypoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVWaypoints)).BeginInit();
            this.tabLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerReadMemory
            // 
            this.timerReadMemory.Tick += new System.EventHandler(this.timerReadMemory_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabLogin);
            this.tabControl.Controls.Add(this.tabCharacter);
            this.tabControl.Controls.Add(this.tabWaypoints);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1039, 640);
            this.tabControl.TabIndex = 0;
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.button1);
            this.tabLogin.Controls.Add(this.gbAccount);
            this.tabLogin.Controls.Add(this.gbGameLogin);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(1031, 614);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.textBox2);
            this.gbAccount.Controls.Add(this.lblPassword);
            this.gbAccount.Controls.Add(this.lblLogin);
            this.gbAccount.Controls.Add(this.textBox1);
            this.gbAccount.Controls.Add(this.lblLicense);
            this.gbAccount.Controls.Add(this.lblLoggedUser);
            this.gbAccount.Controls.Add(this.btnLogIn);
            this.gbAccount.Location = new System.Drawing.Point(8, 16);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(288, 243);
            this.gbAccount.TabIndex = 1;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Account";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(66, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 20);
            this.textBox2.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(4, 69);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(24, 29);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Login:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(1, 149);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(59, 13);
            this.lblLicense.TabIndex = 2;
            this.lblLicense.Text = "License to:";
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Location = new System.Drawing.Point(0, 109);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(60, 13);
            this.lblLoggedUser.TabIndex = 1;
            this.lblLoggedUser.Text = "Logged as:";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(204, 22);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 60);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // gbGameLogin
            // 
            this.gbGameLogin.Controls.Add(this.btnFindGame);
            this.gbGameLogin.Controls.Add(this.btnOpenConfig);
            this.gbGameLogin.Controls.Add(this.btnSaveConfig);
            this.gbGameLogin.Controls.Add(this.cBCharacterPosition);
            this.gbGameLogin.Controls.Add(this.btnShowPathDialog);
            this.gbGameLogin.Controls.Add(this.tBGamePath);
            this.gbGameLogin.Controls.Add(this.cbEnableAutoPin);
            this.gbGameLogin.Controls.Add(this.tbPin);
            this.gbGameLogin.Controls.Add(this.tbPassword);
            this.gbGameLogin.Controls.Add(this.tbLogin);
            this.gbGameLogin.Controls.Add(this.cbAutoLogIn);
            this.gbGameLogin.Enabled = false;
            this.gbGameLogin.Location = new System.Drawing.Point(8, 288);
            this.gbGameLogin.Name = "gbGameLogin";
            this.gbGameLogin.Size = new System.Drawing.Size(288, 216);
            this.gbGameLogin.TabIndex = 0;
            this.gbGameLogin.TabStop = false;
            this.gbGameLogin.Text = "Game login information";
            // 
            // btnFindGame
            // 
            this.btnFindGame.Location = new System.Drawing.Point(119, 19);
            this.btnFindGame.Name = "btnFindGame";
            this.btnFindGame.Size = new System.Drawing.Size(160, 23);
            this.btnFindGame.TabIndex = 26;
            this.btnFindGame.Text = "Find Game";
            this.btnFindGame.UseVisualStyleBackColor = true;
            this.btnFindGame.Click += new System.EventHandler(this.btnFindGame_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(6, 178);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(273, 23);
            this.btnOpenConfig.TabIndex = 25;
            this.btnOpenConfig.Text = "Open Config";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(6, 149);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(273, 23);
            this.btnSaveConfig.TabIndex = 24;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // cBCharacterPosition
            // 
            this.cBCharacterPosition.FormattingEnabled = true;
            this.cBCharacterPosition.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cBCharacterPosition.Location = new System.Drawing.Point(4, 97);
            this.cBCharacterPosition.Name = "cBCharacterPosition";
            this.cBCharacterPosition.Size = new System.Drawing.Size(102, 21);
            this.cBCharacterPosition.TabIndex = 23;
            // 
            // btnShowPathDialog
            // 
            this.btnShowPathDialog.Location = new System.Drawing.Point(255, 123);
            this.btnShowPathDialog.Name = "btnShowPathDialog";
            this.btnShowPathDialog.Size = new System.Drawing.Size(24, 20);
            this.btnShowPathDialog.TabIndex = 22;
            this.btnShowPathDialog.Text = "...";
            this.btnShowPathDialog.UseVisualStyleBackColor = true;
            this.btnShowPathDialog.Click += new System.EventHandler(this.btnShowPathDialog_Click);
            // 
            // tBGamePath
            // 
            this.tBGamePath.Enabled = false;
            this.tBGamePath.Location = new System.Drawing.Point(6, 123);
            this.tBGamePath.Name = "tBGamePath";
            this.tBGamePath.Size = new System.Drawing.Size(243, 20);
            this.tBGamePath.TabIndex = 21;
            this.tBGamePath.Text = "F:\\GameforgeLive\\GameforgeLive.exe";
            // 
            // cbEnableAutoPin
            // 
            this.cbEnableAutoPin.AutoSize = true;
            this.cbEnableAutoPin.Location = new System.Drawing.Point(119, 74);
            this.cbEnableAutoPin.Name = "cbEnableAutoPin";
            this.cbEnableAutoPin.Size = new System.Drawing.Size(130, 17);
            this.cbEnableAutoPin.TabIndex = 20;
            this.cbEnableAutoPin.Text = "Enable auto PIN input";
            this.cbEnableAutoPin.UseVisualStyleBackColor = true;
            // 
            // tbPin
            // 
            this.tbPin.Location = new System.Drawing.Point(6, 71);
            this.tbPin.Name = "tbPin";
            this.tbPin.Size = new System.Drawing.Size(100, 20);
            this.tbPin.TabIndex = 19;
            this.tbPin.Text = "PIN";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(6, 45);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 18;
            this.tbPassword.Text = "Password";
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(6, 19);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 17;
            this.tbLogin.Text = "Login";
            // 
            // cbAutoLogIn
            // 
            this.cbAutoLogIn.AutoSize = true;
            this.cbAutoLogIn.Location = new System.Drawing.Point(119, 48);
            this.cbAutoLogIn.Name = "cbAutoLogIn";
            this.cbAutoLogIn.Size = new System.Drawing.Size(111, 17);
            this.cbAutoLogIn.TabIndex = 16;
            this.cbAutoLogIn.Text = "Enable auto log in";
            this.cbAutoLogIn.UseVisualStyleBackColor = true;
            this.cbAutoLogIn.CheckedChanged += new System.EventHandler(this.cbAutoLogIn_CheckedChanged_1);
            // 
            // tabCharacter
            // 
            this.tabCharacter.Controls.Add(this.gbCharacterInformation);
            this.tabCharacter.Location = new System.Drawing.Point(4, 22);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tabCharacter.Size = new System.Drawing.Size(1031, 614);
            this.tabCharacter.TabIndex = 1;
            this.tabCharacter.Text = "Character";
            this.tabCharacter.UseVisualStyleBackColor = true;
            // 
            // gbCharacterInformation
            // 
            this.gbCharacterInformation.Controls.Add(this.lblFT);
            this.gbCharacterInformation.Controls.Add(this.lblDP);
            this.gbCharacterInformation.Controls.Add(this.lblMP);
            this.gbCharacterInformation.Controls.Add(this.lblHP);
            this.gbCharacterInformation.Controls.Add(this.tbLvl);
            this.gbCharacterInformation.Controls.Add(this.tbClass);
            this.gbCharacterInformation.Controls.Add(this.tbCharacterName);
            this.gbCharacterInformation.Controls.Add(this.pbFT);
            this.gbCharacterInformation.Controls.Add(this.pbDP);
            this.gbCharacterInformation.Controls.Add(this.pbMP);
            this.gbCharacterInformation.Controls.Add(this.pbHP);
            this.gbCharacterInformation.Enabled = false;
            this.gbCharacterInformation.Location = new System.Drawing.Point(8, 6);
            this.gbCharacterInformation.Name = "gbCharacterInformation";
            this.gbCharacterInformation.Size = new System.Drawing.Size(528, 178);
            this.gbCharacterInformation.TabIndex = 15;
            this.gbCharacterInformation.TabStop = false;
            this.gbCharacterInformation.Text = "Character Information";
            // 
            // lblFT
            // 
            this.lblFT.AutoSize = true;
            this.lblFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFT.Location = new System.Drawing.Point(149, 130);
            this.lblFT.Name = "lblFT";
            this.lblFT.Size = new System.Drawing.Size(38, 22);
            this.lblFT.TabIndex = 25;
            this.lblFT.Text = "FT:";
            // 
            // lblDP
            // 
            this.lblDP.AutoSize = true;
            this.lblDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDP.Location = new System.Drawing.Point(149, 92);
            this.lblDP.Name = "lblDP";
            this.lblDP.Size = new System.Drawing.Size(40, 22);
            this.lblDP.TabIndex = 24;
            this.lblDP.Text = "DP:";
            // 
            // lblMP
            // 
            this.lblMP.AutoSize = true;
            this.lblMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMP.Location = new System.Drawing.Point(149, 54);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(41, 22);
            this.lblMP.TabIndex = 23;
            this.lblMP.Text = "MP:";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHP.Location = new System.Drawing.Point(149, 17);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(40, 22);
            this.lblHP.TabIndex = 22;
            this.lblHP.Text = "HP:";
            // 
            // tbLvl
            // 
            this.tbLvl.Enabled = false;
            this.tbLvl.Location = new System.Drawing.Point(102, 69);
            this.tbLvl.Name = "tbLvl";
            this.tbLvl.Size = new System.Drawing.Size(41, 20);
            this.tbLvl.TabIndex = 21;
            this.tbLvl.Text = "Level";
            this.tbLvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbClass
            // 
            this.tbClass.Enabled = false;
            this.tbClass.Location = new System.Drawing.Point(6, 45);
            this.tbClass.Name = "tbClass";
            this.tbClass.Size = new System.Drawing.Size(137, 20);
            this.tbClass.TabIndex = 20;
            this.tbClass.Text = "Class";
            this.tbClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCharacterName
            // 
            this.tbCharacterName.Enabled = false;
            this.tbCharacterName.Location = new System.Drawing.Point(6, 19);
            this.tbCharacterName.Name = "tbCharacterName";
            this.tbCharacterName.Size = new System.Drawing.Size(137, 20);
            this.tbCharacterName.TabIndex = 19;
            this.tbCharacterName.Text = "Name";
            this.tbCharacterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbFT
            // 
            this.pbFT.Location = new System.Drawing.Point(190, 130);
            this.pbFT.Name = "pbFT";
            this.pbFT.Size = new System.Drawing.Size(321, 23);
            this.pbFT.TabIndex = 18;
            // 
            // pbDP
            // 
            this.pbDP.Location = new System.Drawing.Point(190, 92);
            this.pbDP.Name = "pbDP";
            this.pbDP.Size = new System.Drawing.Size(321, 23);
            this.pbDP.TabIndex = 17;
            // 
            // pbMP
            // 
            this.pbMP.Location = new System.Drawing.Point(190, 54);
            this.pbMP.Name = "pbMP";
            this.pbMP.Size = new System.Drawing.Size(321, 23);
            this.pbMP.TabIndex = 16;
            // 
            // pbHP
            // 
            this.pbHP.Location = new System.Drawing.Point(190, 16);
            this.pbHP.Name = "pbHP";
            this.pbHP.Size = new System.Drawing.Size(321, 23);
            this.pbHP.TabIndex = 15;
            // 
            // tabWaypoints
            // 
            this.tabWaypoints.Controls.Add(this.gbWaypoints);
            this.tabWaypoints.Controls.Add(this.dGVWaypoints);
            this.tabWaypoints.Location = new System.Drawing.Point(4, 22);
            this.tabWaypoints.Name = "tabWaypoints";
            this.tabWaypoints.Padding = new System.Windows.Forms.Padding(3);
            this.tabWaypoints.Size = new System.Drawing.Size(1031, 614);
            this.tabWaypoints.TabIndex = 3;
            this.tabWaypoints.Text = "Waypoints";
            this.tabWaypoints.UseVisualStyleBackColor = true;
            // 
            // gbWaypoints
            // 
            this.gbWaypoints.Controls.Add(this.label1);
            this.gbWaypoints.Controls.Add(this.lblZ);
            this.gbWaypoints.Controls.Add(this.lblY);
            this.gbWaypoints.Controls.Add(this.lblX);
            this.gbWaypoints.Controls.Add(this.btnOpen);
            this.gbWaypoints.Controls.Add(this.btnSave);
            this.gbWaypoints.Controls.Add(this.textBoxRestFor);
            this.gbWaypoints.Controls.Add(this.checkBoxRest);
            this.gbWaypoints.Controls.Add(this.checkBoxFly);
            this.gbWaypoints.Controls.Add(this.checkBoxCollect);
            this.gbWaypoints.Controls.Add(this.textBoxZ);
            this.gbWaypoints.Controls.Add(this.textBoxY);
            this.gbWaypoints.Controls.Add(this.textBoxX);
            this.gbWaypoints.Controls.Add(this.btnRemoveWaypoint);
            this.gbWaypoints.Controls.Add(this.btnAddWaypoint);
            this.gbWaypoints.Enabled = false;
            this.gbWaypoints.Location = new System.Drawing.Point(762, 6);
            this.gbWaypoints.Name = "gbWaypoints";
            this.gbWaypoints.Size = new System.Drawing.Size(260, 322);
            this.gbWaypoints.TabIndex = 19;
            this.gbWaypoints.TabStop = false;
            this.gbWaypoints.Text = "Waypoints";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Rest for (s):";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblZ.Location = new System.Drawing.Point(3, 265);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(21, 17);
            this.lblZ.TabIndex = 30;
            this.lblZ.Text = "Z:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblY.Location = new System.Drawing.Point(3, 221);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(21, 17);
            this.lblY.TabIndex = 29;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblX.Location = new System.Drawing.Point(3, 177);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 17);
            this.lblX.TabIndex = 28;
            this.lblX.Text = "X:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 106);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(126, 23);
            this.btnOpen.TabIndex = 27;
            this.btnOpen.Text = "Open from file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxRestFor
            // 
            this.textBoxRestFor.Location = new System.Drawing.Point(6, 154);
            this.textBoxRestFor.MaxLength = 5;
            this.textBoxRestFor.Name = "textBoxRestFor";
            this.textBoxRestFor.Size = new System.Drawing.Size(126, 20);
            this.textBoxRestFor.TabIndex = 25;
            // 
            // checkBoxRest
            // 
            this.checkBoxRest.AutoSize = true;
            this.checkBoxRest.Location = new System.Drawing.Point(138, 94);
            this.checkBoxRest.Name = "checkBoxRest";
            this.checkBoxRest.Size = new System.Drawing.Size(54, 17);
            this.checkBoxRest.TabIndex = 24;
            this.checkBoxRest.Text = "Rest?";
            this.checkBoxRest.UseVisualStyleBackColor = true;
            // 
            // checkBoxFly
            // 
            this.checkBoxFly.AutoSize = true;
            this.checkBoxFly.Location = new System.Drawing.Point(138, 71);
            this.checkBoxFly.Name = "checkBoxFly";
            this.checkBoxFly.Size = new System.Drawing.Size(117, 17);
            this.checkBoxFly.TabIndex = 23;
            this.checkBoxFly.Text = "Fly from previouse?";
            this.checkBoxFly.UseVisualStyleBackColor = true;
            // 
            // checkBoxCollect
            // 
            this.checkBoxCollect.AutoSize = true;
            this.checkBoxCollect.Location = new System.Drawing.Point(138, 48);
            this.checkBoxCollect.Name = "checkBoxCollect";
            this.checkBoxCollect.Size = new System.Drawing.Size(64, 17);
            this.checkBoxCollect.TabIndex = 22;
            this.checkBoxCollect.Text = "Collect?";
            this.checkBoxCollect.UseVisualStyleBackColor = true;
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(6, 285);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(249, 20);
            this.textBoxZ.TabIndex = 21;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(6, 241);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(249, 20);
            this.textBoxY.TabIndex = 20;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(6, 197);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(249, 20);
            this.textBoxX.TabIndex = 19;
            // 
            // btnRemoveWaypoint
            // 
            this.btnRemoveWaypoint.Location = new System.Drawing.Point(6, 48);
            this.btnRemoveWaypoint.Name = "btnRemoveWaypoint";
            this.btnRemoveWaypoint.Size = new System.Drawing.Size(126, 23);
            this.btnRemoveWaypoint.TabIndex = 18;
            this.btnRemoveWaypoint.Text = "Remove Last Waypoint";
            this.btnRemoveWaypoint.UseVisualStyleBackColor = true;
            this.btnRemoveWaypoint.Click += new System.EventHandler(this.btnRemoveWaypoint_Click);
            // 
            // btnAddWaypoint
            // 
            this.btnAddWaypoint.Location = new System.Drawing.Point(6, 19);
            this.btnAddWaypoint.Name = "btnAddWaypoint";
            this.btnAddWaypoint.Size = new System.Drawing.Size(126, 23);
            this.btnAddWaypoint.TabIndex = 17;
            this.btnAddWaypoint.Text = "Add Waypoint";
            this.btnAddWaypoint.UseVisualStyleBackColor = true;
            this.btnAddWaypoint.Click += new System.EventHandler(this.btnAddWaypoint_Click);
            // 
            // dGVWaypoints
            // 
            this.dGVWaypoints.AllowUserToAddRows = false;
            this.dGVWaypoints.AllowUserToDeleteRows = false;
            this.dGVWaypoints.AllowUserToResizeColumns = false;
            this.dGVWaypoints.AllowUserToResizeRows = false;
            this.dGVWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dGVWaypoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVWaypoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colX,
            this.colY,
            this.colZ,
            this.colCollect,
            this.colFly,
            this.colRest,
            this.colRestFor});
            this.dGVWaypoints.Location = new System.Drawing.Point(8, 6);
            this.dGVWaypoints.Name = "dGVWaypoints";
            this.dGVWaypoints.ReadOnly = true;
            this.dGVWaypoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVWaypoints.Size = new System.Drawing.Size(750, 602);
            this.dGVWaypoints.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colX
            // 
            this.colX.HeaderText = "X";
            this.colX.Name = "colX";
            this.colX.ReadOnly = true;
            // 
            // colY
            // 
            this.colY.HeaderText = "Y";
            this.colY.Name = "colY";
            this.colY.ReadOnly = true;
            // 
            // colZ
            // 
            this.colZ.HeaderText = "Z";
            this.colZ.Name = "colZ";
            this.colZ.ReadOnly = true;
            // 
            // colCollect
            // 
            this.colCollect.HeaderText = "Collect";
            this.colCollect.Name = "colCollect";
            this.colCollect.ReadOnly = true;
            this.colCollect.Width = 50;
            // 
            // colFly
            // 
            this.colFly.HeaderText = "Fly to";
            this.colFly.Name = "colFly";
            this.colFly.ReadOnly = true;
            // 
            // colRest
            // 
            this.colRest.HeaderText = "Rest";
            this.colRest.Name = "colRest";
            this.colRest.ReadOnly = true;
            // 
            // colRestFor
            // 
            this.colRestFor.HeaderText = "Rest for (s)";
            this.colRestFor.Name = "colRestFor";
            this.colRestFor.ReadOnly = true;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.rtbLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1031, 614);
            this.tabLogs.TabIndex = 2;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // rtbLogs
            // 
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.Location = new System.Drawing.Point(3, 3);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbLogs.Size = new System.Drawing.Size(1025, 608);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            // 
            // timerAutoLogIn
            // 
            this.timerAutoLogIn.Interval = 10000;
            this.timerAutoLogIn.Tick += new System.EventHandler(this.timerAutoLogIn_Tick);
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 640);
            this.Controls.Add(this.tabControl);
            this.Name = "ViewMain";
            this.Text = "AionBOT v0.000000001";
            this.tabControl.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.gbAccount.PerformLayout();
            this.gbGameLogin.ResumeLayout(false);
            this.gbGameLogin.PerformLayout();
            this.tabCharacter.ResumeLayout(false);
            this.gbCharacterInformation.ResumeLayout(false);
            this.gbCharacterInformation.PerformLayout();
            this.tabWaypoints.ResumeLayout(false);
            this.gbWaypoints.ResumeLayout(false);
            this.gbWaypoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVWaypoints)).EndInit();
            this.tabLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerReadMemory;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabCharacter;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.TabPage tabWaypoints;
        private System.Windows.Forms.DataGridView dGVWaypoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCollect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRestFor;
        private System.Windows.Forms.Timer timerAutoLogIn;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.GroupBox gbGameLogin;
        private System.Windows.Forms.Button btnFindGame;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.ComboBox cBCharacterPosition;
        private System.Windows.Forms.Button btnShowPathDialog;
        private System.Windows.Forms.TextBox tBGamePath;
        private System.Windows.Forms.TextBox tbPin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.CheckBox cbAutoLogIn;
        private System.Windows.Forms.GroupBox gbCharacterInformation;
        private System.Windows.Forms.Label lblFT;
        private System.Windows.Forms.Label lblDP;
        private System.Windows.Forms.Label lblMP;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.TextBox tbLvl;
        private System.Windows.Forms.TextBox tbClass;
        private System.Windows.Forms.TextBox tbCharacterName;
        private System.Windows.Forms.ProgressBar pbFT;
        private System.Windows.Forms.ProgressBar pbDP;
        private System.Windows.Forms.ProgressBar pbMP;
        private System.Windows.Forms.ProgressBar pbHP;
        private System.Windows.Forms.GroupBox gbWaypoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxRestFor;
        private System.Windows.Forms.CheckBox checkBoxRest;
        private System.Windows.Forms.CheckBox checkBoxFly;
        private System.Windows.Forms.CheckBox checkBoxCollect;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button btnRemoveWaypoint;
        private System.Windows.Forms.Button btnAddWaypoint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbEnableAutoPin;
    }
}

