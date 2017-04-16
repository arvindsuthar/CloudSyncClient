namespace CloudSyncClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WizardImageList = new System.Windows.Forms.ImageList(this.components);
            this.WizardTabControl = new System.Windows.Forms.TabControl();
            this.Configure = new System.Windows.Forms.TabPage();
            this.comboboxMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listviewOutput = new System.Windows.Forms.ListView();
            this.listviewProfile = new System.Windows.Forms.ListView();
            this.Profile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AAD_Domain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AD_Domain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.ADDomain = new System.Windows.Forms.TextBox();
            this.ADDomainLabel = new System.Windows.Forms.Label();
            this.AADDomain = new System.Windows.Forms.TextBox();
            this.AzureADDomainLabel = new System.Windows.Forms.Label();
            this.AADDetail = new System.Windows.Forms.Label();
            this.AADResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonVerifyAD = new System.Windows.Forms.Button();
            this.buttonVerifyAAD = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNewProfile = new System.Windows.Forms.Button();
            this.profileName = new System.Windows.Forms.TextBox();
            this.ProfileNameLabel = new System.Windows.Forms.Label();
            this.ADPassword = new System.Windows.Forms.TextBox();
            this.AADPassword = new System.Windows.Forms.TextBox();
            this.ADPasswordLabel = new System.Windows.Forms.Label();
            this.AADClientSecretLabel = new System.Windows.Forms.Label();
            this.ADUsername = new System.Windows.Forms.TextBox();
            this.ADUsernameLabel = new System.Windows.Forms.Label();
            this.AADClientID = new System.Windows.Forms.TextBox();
            this.AzureADClientIDLabel = new System.Windows.Forms.Label();
            this.Schedule = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Writeback = new System.Windows.Forms.TabPage();
            this.labelChangedData = new System.Windows.Forms.Label();
            this.labelLogOutput = new System.Windows.Forms.Label();
            this.listviewDQOutput = new System.Windows.Forms.ListView();
            this.listviewDQ = new System.Windows.Forms.ListView();
            this.ObjectID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ADDomain_ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ADWriteResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonExecute = new System.Windows.Forms.Button();
            this.labelStorage = new System.Windows.Forms.Label();
            this.labelProfile = new System.Windows.Forms.Label();
            this.labelVerified = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WizardTabControl.SuspendLayout();
            this.Configure.SuspendLayout();
            this.Schedule.SuspendLayout();
            this.Writeback.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WizardImageList
            // 
            this.WizardImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("WizardImageList.ImageStream")));
            this.WizardImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.WizardImageList.Images.SetKeyName(0, "Conf.bmp");
            this.WizardImageList.Images.SetKeyName(1, "sched.bmp");
            this.WizardImageList.Images.SetKeyName(2, "Sync.bmp");
            this.WizardImageList.Images.SetKeyName(3, "Review.bmp");
            // 
            // WizardTabControl
            // 
            this.WizardTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.WizardTabControl.Controls.Add(this.Configure);
            this.WizardTabControl.Controls.Add(this.Schedule);
            this.WizardTabControl.Controls.Add(this.Writeback);
            this.WizardTabControl.Controls.Add(this.tabPage1);
            this.WizardTabControl.ImageList = this.WizardImageList;
            this.WizardTabControl.ItemSize = new System.Drawing.Size(100, 100);
            this.WizardTabControl.Location = new System.Drawing.Point(12, 12);
            this.WizardTabControl.Multiline = true;
            this.WizardTabControl.Name = "WizardTabControl";
            this.WizardTabControl.Padding = new System.Drawing.Point(0, 3);
            this.WizardTabControl.SelectedIndex = 0;
            this.WizardTabControl.Size = new System.Drawing.Size(1194, 853);
            this.WizardTabControl.TabIndex = 0;
            // 
            // Configure
            // 
            this.Configure.BackColor = System.Drawing.Color.Transparent;
            this.Configure.Controls.Add(this.comboboxMode);
            this.Configure.Controls.Add(this.label8);
            this.Configure.Controls.Add(this.label7);
            this.Configure.Controls.Add(this.listviewOutput);
            this.Configure.Controls.Add(this.listviewProfile);
            this.Configure.Controls.Add(this.buttonCancel);
            this.Configure.Controls.Add(this.buttonEdit);
            this.Configure.Controls.Add(this.ADDomain);
            this.Configure.Controls.Add(this.ADDomainLabel);
            this.Configure.Controls.Add(this.AADDomain);
            this.Configure.Controls.Add(this.AzureADDomainLabel);
            this.Configure.Controls.Add(this.AADDetail);
            this.Configure.Controls.Add(this.AADResult);
            this.Configure.Controls.Add(this.label2);
            this.Configure.Controls.Add(this.buttonVerifyAD);
            this.Configure.Controls.Add(this.buttonVerifyAAD);
            this.Configure.Controls.Add(this.buttonSave);
            this.Configure.Controls.Add(this.buttonNewProfile);
            this.Configure.Controls.Add(this.profileName);
            this.Configure.Controls.Add(this.ProfileNameLabel);
            this.Configure.Controls.Add(this.ADPassword);
            this.Configure.Controls.Add(this.AADPassword);
            this.Configure.Controls.Add(this.ADPasswordLabel);
            this.Configure.Controls.Add(this.AADClientSecretLabel);
            this.Configure.Controls.Add(this.ADUsername);
            this.Configure.Controls.Add(this.ADUsernameLabel);
            this.Configure.Controls.Add(this.AADClientID);
            this.Configure.Controls.Add(this.AzureADClientIDLabel);
            this.Configure.ImageIndex = 0;
            this.Configure.Location = new System.Drawing.Point(104, 4);
            this.Configure.Name = "Configure";
            this.Configure.Padding = new System.Windows.Forms.Padding(3);
            this.Configure.Size = new System.Drawing.Size(1086, 845);
            this.Configure.TabIndex = 0;
            // 
            // comboboxMode
            // 
            this.comboboxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxMode.FormattingEnabled = true;
            this.comboboxMode.Items.AddRange(new object[] {
            "Headquarters",
            "AD Affiliate"});
            this.comboboxMode.Location = new System.Drawing.Point(240, 223);
            this.comboboxMode.Name = "comboboxMode";
            this.comboboxMode.Size = new System.Drawing.Size(201, 28);
            this.comboboxMode.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 718);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Log output";
            // 
            // listviewOutput
            // 
            this.listviewOutput.Location = new System.Drawing.Point(10, 747);
            this.listviewOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listviewOutput.Name = "listviewOutput";
            this.listviewOutput.Size = new System.Drawing.Size(1000, 90);
            this.listviewOutput.TabIndex = 23;
            this.listviewOutput.UseCompatibleStateImageBehavior = false;
            this.listviewOutput.View = System.Windows.Forms.View.List;
            // 
            // listviewProfile
            // 
            this.listviewProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Profile,
            this.AAD_Domain,
            this.AD_Domain});
            this.listviewProfile.FullRowSelect = true;
            this.listviewProfile.HideSelection = false;
            this.listviewProfile.Location = new System.Drawing.Point(10, 58);
            this.listviewProfile.MultiSelect = false;
            this.listviewProfile.Name = "listviewProfile";
            this.listviewProfile.Size = new System.Drawing.Size(790, 152);
            this.listviewProfile.TabIndex = 20;
            this.listviewProfile.UseCompatibleStateImageBehavior = false;
            this.listviewProfile.View = System.Windows.Forms.View.Details;
            this.listviewProfile.SelectedIndexChanged += new System.EventHandler(this.listviewProfile_SelectedIndexChanged);
            // 
            // Profile
            // 
            this.Profile.Text = "Profile";
            this.Profile.Width = 175;
            // 
            // AAD_Domain
            // 
            this.AAD_Domain.Text = "AAD Domain";
            this.AAD_Domain.Width = 200;
            // 
            // AD_Domain
            // 
            this.AD_Domain.Text = "AD Domain";
            this.AD_Domain.Width = 125;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(698, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 29);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(590, 12);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(102, 29);
            this.buttonEdit.TabIndex = 18;
            this.buttonEdit.Text = "Edit Profile";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // ADDomain
            // 
            this.ADDomain.Location = new System.Drawing.Point(240, 468);
            this.ADDomain.Name = "ADDomain";
            this.ADDomain.Size = new System.Drawing.Size(560, 26);
            this.ADDomain.TabIndex = 6;
            // 
            // ADDomainLabel
            // 
            this.ADDomainLabel.AutoSize = true;
            this.ADDomainLabel.Location = new System.Drawing.Point(112, 472);
            this.ADDomainLabel.Name = "ADDomainLabel";
            this.ADDomainLabel.Size = new System.Drawing.Size(91, 20);
            this.ADDomainLabel.TabIndex = 16;
            this.ADDomainLabel.Text = "AD Domain";
            // 
            // AADDomain
            // 
            this.AADDomain.Location = new System.Drawing.Point(240, 322);
            this.AADDomain.Name = "AADDomain";
            this.AADDomain.Size = new System.Drawing.Size(560, 26);
            this.AADDomain.TabIndex = 3;
            // 
            // AzureADDomainLabel
            // 
            this.AzureADDomainLabel.AutoSize = true;
            this.AzureADDomainLabel.Location = new System.Drawing.Point(66, 325);
            this.AzureADDomainLabel.Name = "AzureADDomainLabel";
            this.AzureADDomainLabel.Size = new System.Drawing.Size(137, 20);
            this.AzureADDomainLabel.TabIndex = 14;
            this.AzureADDomainLabel.Text = "Azure AD Domain";
            // 
            // AADDetail
            // 
            this.AADDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AADDetail.Location = new System.Drawing.Point(831, 22);
            this.AADDetail.Name = "AADDetail";
            this.AADDetail.Size = new System.Drawing.Size(195, 188);
            this.AADDetail.TabIndex = 13;
            this.AADDetail.Text = "AADDetail";
            // 
            // AADResult
            // 
            this.AADResult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AADResult.Location = new System.Drawing.Point(834, 375);
            this.AADResult.Name = "AADResult";
            this.AADResult.Size = new System.Drawing.Size(186, 87);
            this.AADResult.TabIndex = 12;
            this.AADResult.Text = "AADResult";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Manage Sync Profiles";
            // 
            // buttonVerifyAD
            // 
            this.buttonVerifyAD.Location = new System.Drawing.Point(831, 465);
            this.buttonVerifyAD.Name = "buttonVerifyAD";
            this.buttonVerifyAD.Size = new System.Drawing.Size(101, 32);
            this.buttonVerifyAD.TabIndex = 9;
            this.buttonVerifyAD.Text = "Verify AD";
            this.buttonVerifyAD.UseVisualStyleBackColor = true;
            // 
            // buttonVerifyAAD
            // 
            this.buttonVerifyAAD.Location = new System.Drawing.Point(831, 319);
            this.buttonVerifyAAD.Name = "buttonVerifyAAD";
            this.buttonVerifyAAD.Size = new System.Drawing.Size(101, 32);
            this.buttonVerifyAAD.TabIndex = 6;
            this.buttonVerifyAAD.Text = "Verify AAD";
            this.buttonVerifyAAD.UseVisualStyleBackColor = true;
            this.buttonVerifyAAD.Click += new System.EventHandler(this.buttonVerifyAAD_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(482, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 29);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save Profile";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonNewProfile
            // 
            this.buttonNewProfile.Location = new System.Drawing.Point(374, 12);
            this.buttonNewProfile.Name = "buttonNewProfile";
            this.buttonNewProfile.Size = new System.Drawing.Size(102, 29);
            this.buttonNewProfile.TabIndex = 2;
            this.buttonNewProfile.Text = "New Profile";
            this.buttonNewProfile.UseVisualStyleBackColor = true;
            this.buttonNewProfile.Click += new System.EventHandler(this.buttonNewProfile_Click);
            // 
            // profileName
            // 
            this.profileName.Location = new System.Drawing.Point(240, 272);
            this.profileName.Name = "profileName";
            this.profileName.Size = new System.Drawing.Size(560, 26);
            this.profileName.TabIndex = 2;
            // 
            // ProfileNameLabel
            // 
            this.ProfileNameLabel.AutoSize = true;
            this.ProfileNameLabel.Location = new System.Drawing.Point(104, 278);
            this.ProfileNameLabel.Name = "ProfileNameLabel";
            this.ProfileNameLabel.Size = new System.Drawing.Size(99, 20);
            this.ProfileNameLabel.TabIndex = 8;
            this.ProfileNameLabel.Text = "Profile Name";
            // 
            // ADPassword
            // 
            this.ADPassword.Location = new System.Drawing.Point(240, 565);
            this.ADPassword.Name = "ADPassword";
            this.ADPassword.Size = new System.Drawing.Size(560, 26);
            this.ADPassword.TabIndex = 8;
            this.ADPassword.UseSystemPasswordChar = true;
            // 
            // AADPassword
            // 
            this.AADPassword.Location = new System.Drawing.Point(240, 419);
            this.AADPassword.Name = "AADPassword";
            this.AADPassword.Size = new System.Drawing.Size(560, 26);
            this.AADPassword.TabIndex = 5;
            // 
            // ADPasswordLabel
            // 
            this.ADPasswordLabel.AutoSize = true;
            this.ADPasswordLabel.Location = new System.Drawing.Point(98, 568);
            this.ADPasswordLabel.Name = "ADPasswordLabel";
            this.ADPasswordLabel.Size = new System.Drawing.Size(105, 20);
            this.ADPasswordLabel.TabIndex = 5;
            this.ADPasswordLabel.Text = "AD Password";
            // 
            // AADClientSecretLabel
            // 
            this.AADClientSecretLabel.AutoSize = true;
            this.AADClientSecretLabel.Location = new System.Drawing.Point(30, 422);
            this.AADClientSecretLabel.Name = "AADClientSecretLabel";
            this.AADClientSecretLabel.Size = new System.Drawing.Size(173, 20);
            this.AADClientSecretLabel.TabIndex = 4;
            this.AADClientSecretLabel.Text = "Azure AD Client Secret";
            // 
            // ADUsername
            // 
            this.ADUsername.Location = new System.Drawing.Point(240, 516);
            this.ADUsername.Name = "ADUsername";
            this.ADUsername.Size = new System.Drawing.Size(560, 26);
            this.ADUsername.TabIndex = 7;
            // 
            // ADUsernameLabel
            // 
            this.ADUsernameLabel.AutoSize = true;
            this.ADUsernameLabel.Location = new System.Drawing.Point(93, 519);
            this.ADUsernameLabel.Name = "ADUsernameLabel";
            this.ADUsernameLabel.Size = new System.Drawing.Size(110, 20);
            this.ADUsernameLabel.TabIndex = 2;
            this.ADUsernameLabel.Text = "AD Username";
            // 
            // AADClientID
            // 
            this.AADClientID.Location = new System.Drawing.Point(240, 372);
            this.AADClientID.Name = "AADClientID";
            this.AADClientID.Size = new System.Drawing.Size(560, 26);
            this.AADClientID.TabIndex = 4;
            // 
            // AzureADClientIDLabel
            // 
            this.AzureADClientIDLabel.AutoSize = true;
            this.AzureADClientIDLabel.Location = new System.Drawing.Point(60, 375);
            this.AzureADClientIDLabel.Name = "AzureADClientIDLabel";
            this.AzureADClientIDLabel.Size = new System.Drawing.Size(143, 20);
            this.AzureADClientIDLabel.TabIndex = 0;
            this.AzureADClientIDLabel.Text = "Azure AD Client ID";
            // 
            // Schedule
            // 
            this.Schedule.BackColor = System.Drawing.Color.Transparent;
            this.Schedule.Controls.Add(this.label1);
            this.Schedule.Controls.Add(this.label4);
            this.Schedule.ImageIndex = 1;
            this.Schedule.Location = new System.Drawing.Point(104, 4);
            this.Schedule.Name = "Schedule";
            this.Schedule.Padding = new System.Windows.Forms.Padding(3);
            this.Schedule.Size = new System.Drawing.Size(1086, 845);
            this.Schedule.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(393, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 37);
            this.label1.TabIndex = 15;
            this.label1.Text = "Coming Soon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(321, 37);
            this.label4.TabIndex = 14;
            this.label4.Text = "Schedule Cloud Sync";
            // 
            // Writeback
            // 
            this.Writeback.BackColor = System.Drawing.Color.Transparent;
            this.Writeback.Controls.Add(this.labelChangedData);
            this.Writeback.Controls.Add(this.labelLogOutput);
            this.Writeback.Controls.Add(this.listviewDQOutput);
            this.Writeback.Controls.Add(this.listviewDQ);
            this.Writeback.Controls.Add(this.buttonExecute);
            this.Writeback.Controls.Add(this.labelStorage);
            this.Writeback.Controls.Add(this.labelProfile);
            this.Writeback.Controls.Add(this.labelVerified);
            this.Writeback.Controls.Add(this.label5);
            this.Writeback.ImageIndex = 2;
            this.Writeback.Location = new System.Drawing.Point(104, 4);
            this.Writeback.Name = "Writeback";
            this.Writeback.Size = new System.Drawing.Size(1086, 845);
            this.Writeback.TabIndex = 2;
            this.Writeback.Enter += new System.EventHandler(this.Writeback_Enter);
            // 
            // labelChangedData
            // 
            this.labelChangedData.AutoSize = true;
            this.labelChangedData.Location = new System.Drawing.Point(18, 211);
            this.labelChangedData.Name = "labelChangedData";
            this.labelChangedData.Size = new System.Drawing.Size(110, 20);
            this.labelChangedData.TabIndex = 23;
            this.labelChangedData.Text = "Changed data";
            // 
            // labelLogOutput
            // 
            this.labelLogOutput.AutoSize = true;
            this.labelLogOutput.Location = new System.Drawing.Point(18, 494);
            this.labelLogOutput.Name = "labelLogOutput";
            this.labelLogOutput.Size = new System.Drawing.Size(86, 20);
            this.labelLogOutput.TabIndex = 22;
            this.labelLogOutput.Text = "Log output";
            // 
            // listviewDQOutput
            // 
            this.listviewDQOutput.Location = new System.Drawing.Point(22, 518);
            this.listviewDQOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listviewDQOutput.Name = "listviewDQOutput";
            this.listviewDQOutput.Size = new System.Drawing.Size(1000, 147);
            this.listviewDQOutput.TabIndex = 21;
            this.listviewDQOutput.UseCompatibleStateImageBehavior = false;
            this.listviewDQOutput.View = System.Windows.Forms.View.List;
            // 
            // listviewDQ
            // 
            this.listviewDQ.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ObjectID,
            this.Count,
            this.ADDomain_,
            this.ADWriteResult});
            this.listviewDQ.Location = new System.Drawing.Point(22, 234);
            this.listviewDQ.Name = "listviewDQ";
            this.listviewDQ.Size = new System.Drawing.Size(1000, 229);
            this.listviewDQ.TabIndex = 20;
            this.listviewDQ.UseCompatibleStateImageBehavior = false;
            this.listviewDQ.View = System.Windows.Forms.View.Details;
            // 
            // ObjectID
            // 
            this.ObjectID.Text = "ObjectID";
            this.ObjectID.Width = 125;
            // 
            // Count
            // 
            this.Count.Text = "Count";
            this.Count.Width = 125;
            // 
            // ADDomain_
            // 
            this.ADDomain_.Text = "AD Domain";
            this.ADDomain_.Width = 125;
            // 
            // ADWriteResult
            // 
            this.ADWriteResult.Text = "AD Write Result";
            this.ADWriteResult.Width = 200;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(22, 162);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(187, 35);
            this.buttonExecute.TabIndex = 19;
            this.buttonExecute.Text = "Execute Cloud Sync";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(18, 125);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(442, 20);
            this.labelStorage.TabIndex = 18;
            this.labelStorage.Text = "Your results will be stored in Azure Table: XXX, Partition: YYY";
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(18, 89);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(191, 20);
            this.labelProfile.TabIndex = 17;
            this.labelProfile.Text = "Your active profile is: XXX";
            // 
            // labelVerified
            // 
            this.labelVerified.AutoSize = true;
            this.labelVerified.Location = new System.Drawing.Point(18, 55);
            this.labelVerified.Name = "labelVerified";
            this.labelVerified.Size = new System.Drawing.Size(284, 20);
            this.labelVerified.TabIndex = 16;
            this.labelVerified.Text = "You have a verified connection to: XXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(302, 37);
            this.label5.TabIndex = 15;
            this.label5.Text = "Execute Cloud Sync";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.ImageIndex = 3;
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1086, 845);
            this.tabPage1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 37);
            this.label3.TabIndex = 16;
            this.label3.Text = "Coming Soon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 37);
            this.label6.TabIndex = 15;
            this.label6.Text = "Review Cloud Sync";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 877);
            this.Controls.Add(this.WizardTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Cloud Sync Client";
            this.WizardTabControl.ResumeLayout(false);
            this.Configure.ResumeLayout(false);
            this.Configure.PerformLayout();
            this.Schedule.ResumeLayout(false);
            this.Schedule.PerformLayout();
            this.Writeback.ResumeLayout(false);
            this.Writeback.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList WizardImageList;
        private System.Windows.Forms.TabControl WizardTabControl;
        private System.Windows.Forms.TabPage Configure;
        private System.Windows.Forms.TabPage Schedule;
        private System.Windows.Forms.TabPage Writeback;
        private System.Windows.Forms.TextBox AADClientID;
        private System.Windows.Forms.Label AzureADClientIDLabel;
        private System.Windows.Forms.TextBox ADUsername;
        private System.Windows.Forms.Label ADUsernameLabel;
        private System.Windows.Forms.TextBox ADPassword;
        private System.Windows.Forms.TextBox AADPassword;
        private System.Windows.Forms.Label ADPasswordLabel;
        private System.Windows.Forms.Label AADClientSecretLabel;
        private System.Windows.Forms.TextBox profileName;
        private System.Windows.Forms.Label ProfileNameLabel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonNewProfile;
        private System.Windows.Forms.Button buttonVerifyAD;
        private System.Windows.Forms.Button buttonVerifyAAD;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AADDetail;
        private System.Windows.Forms.Label AADResult;
        private System.Windows.Forms.TextBox AADDomain;
        private System.Windows.Forms.Label AzureADDomainLabel;
        private System.Windows.Forms.TextBox ADDomain;
        private System.Windows.Forms.Label ADDomainLabel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ListView listviewProfile;
        private System.Windows.Forms.ColumnHeader Profile;
        private System.Windows.Forms.ColumnHeader AAD_Domain;
        private System.Windows.Forms.ColumnHeader AD_Domain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Label labelVerified;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ListView listviewDQ;
        private System.Windows.Forms.ColumnHeader ObjectID;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.ColumnHeader ADDomain_;
        private System.Windows.Forms.ColumnHeader ADWriteResult;
        private System.Windows.Forms.Label labelLogOutput;
        private System.Windows.Forms.ListView listviewDQOutput;
        private System.Windows.Forms.Label labelChangedData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listviewOutput;
        private System.Windows.Forms.ComboBox comboboxMode;
        private System.Windows.Forms.Label label8;
    }
}

