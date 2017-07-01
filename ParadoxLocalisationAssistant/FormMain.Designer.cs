namespace ParadoxLocalisationAssistant
{
    partial class FormMain
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.txtBackupOldOriginalPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtBackupNewOriginalPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackupGamePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDiff = new System.Windows.Forms.TabPage();
            this.btnSelectDiffDiffFilePath = new System.Windows.Forms.Button();
            this.btnSelectDiffOutputPath = new System.Windows.Forms.Button();
            this.btnSelectDiffOldTranslationPath = new System.Windows.Forms.Button();
            this.btnSelectDiffOldOriginalPath = new System.Windows.Forms.Button();
            this.btnSelectDiffNewOriginalPath = new System.Windows.Forms.Button();
            this.txtDiffDiffFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDiffOutputFormat = new System.Windows.Forms.ComboBox();
            this.txtDiffOutputPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDiffOldTranslationFormat = new System.Windows.Forms.ComboBox();
            this.txtDiffOldTranslationPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDiffOldOriginalFormat = new System.Windows.Forms.ComboBox();
            this.txtDiffOldOriginalPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDiffNewOriginalFormat = new System.Windows.Forms.ComboBox();
            this.btnDiff = new System.Windows.Forms.Button();
            this.txtDiffNewOriginalPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabMerge = new System.Windows.Forms.TabPage();
            this.chkMergeIgnoreSame = new System.Windows.Forms.CheckBox();
            this.chkMergeCheckSpecialChar = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMergeCheckFilePath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSelectMergeInputPath = new System.Windows.Forms.Button();
            this.cmbMergeInputFormat = new System.Windows.Forms.ComboBox();
            this.txtMergeInputPath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSelectMergeDiffFilePath = new System.Windows.Forms.Button();
            this.btnSelectMergeOutputPath = new System.Windows.Forms.Button();
            this.btnMergeOldTranslationPath = new System.Windows.Forms.Button();
            this.btnSelectMergeOldOriginalPath = new System.Windows.Forms.Button();
            this.btnSelectMergeNewOriginalPath = new System.Windows.Forms.Button();
            this.txtMergeDiffFilePath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMergeOutputFormat = new System.Windows.Forms.ComboBox();
            this.txtMergeOutputPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMergeOldTranslationFormat = new System.Windows.Forms.ComboBox();
            this.txtMergeOldTranslationPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMergeOldOriginalFormat = new System.Windows.Forms.ComboBox();
            this.txtMergeOldOriginalPath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbMergeNewOriginalFormat = new System.Windows.Forms.ComboBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.txtMergeNewOriginalPath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnSelectConvertInputPath = new System.Windows.Forms.Button();
            this.cmbConvertInputFormat = new System.Windows.Forms.ComboBox();
            this.txtConvertInputPath = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSelectConvertOutputPath = new System.Windows.Forms.Button();
            this.cmbConvertOutputFormat = new System.Windows.Forms.ComboBox();
            this.txtConvertOutputPath = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlMain.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.tabDiff.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabBackup);
            this.tabControlMain.Controls.Add(this.tabDiff);
            this.tabControlMain.Controls.Add(this.tabMerge);
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Location = new System.Drawing.Point(0, 33);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(607, 517);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.txtBackupOldOriginalPath);
            this.tabBackup.Controls.Add(this.label3);
            this.tabBackup.Controls.Add(this.btnBackup);
            this.tabBackup.Controls.Add(this.txtBackupNewOriginalPath);
            this.tabBackup.Controls.Add(this.label2);
            this.tabBackup.Controls.Add(this.txtBackupGamePath);
            this.tabBackup.Controls.Add(this.label1);
            this.tabBackup.Location = new System.Drawing.Point(4, 25);
            this.tabBackup.Margin = new System.Windows.Forms.Padding(4);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(4);
            this.tabBackup.Size = new System.Drawing.Size(599, 488);
            this.tabBackup.TabIndex = 0;
            this.tabBackup.Text = "备份";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // txtBackupOldOriginalPath
            // 
            this.txtBackupOldOriginalPath.Location = new System.Drawing.Point(144, 121);
            this.txtBackupOldOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackupOldOriginalPath.Name = "txtBackupOldOriginalPath";
            this.txtBackupOldOriginalPath.Size = new System.Drawing.Size(357, 22);
            this.txtBackupOldOriginalPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "原始备份到";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(101, 187);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(352, 28);
            this.btnBackup.TabIndex = 6;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtBackupNewOriginalPath
            // 
            this.txtBackupNewOriginalPath.Location = new System.Drawing.Point(144, 76);
            this.txtBackupNewOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackupNewOriginalPath.Name = "txtBackupNewOriginalPath";
            this.txtBackupNewOriginalPath.Size = new System.Drawing.Size(357, 22);
            this.txtBackupNewOriginalPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "备份文件夹";
            // 
            // txtBackupGamePath
            // 
            this.txtBackupGamePath.Location = new System.Drawing.Point(144, 33);
            this.txtBackupGamePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackupGamePath.Name = "txtBackupGamePath";
            this.txtBackupGamePath.Size = new System.Drawing.Size(357, 22);
            this.txtBackupGamePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏文件夹";
            // 
            // tabDiff
            // 
            this.tabDiff.Controls.Add(this.btnSelectDiffDiffFilePath);
            this.tabDiff.Controls.Add(this.btnSelectDiffOutputPath);
            this.tabDiff.Controls.Add(this.btnSelectDiffOldTranslationPath);
            this.tabDiff.Controls.Add(this.btnSelectDiffOldOriginalPath);
            this.tabDiff.Controls.Add(this.btnSelectDiffNewOriginalPath);
            this.tabDiff.Controls.Add(this.txtDiffDiffFilePath);
            this.tabDiff.Controls.Add(this.label8);
            this.tabDiff.Controls.Add(this.cmbDiffOutputFormat);
            this.tabDiff.Controls.Add(this.txtDiffOutputPath);
            this.tabDiff.Controls.Add(this.label7);
            this.tabDiff.Controls.Add(this.cmbDiffOldTranslationFormat);
            this.tabDiff.Controls.Add(this.txtDiffOldTranslationPath);
            this.tabDiff.Controls.Add(this.label5);
            this.tabDiff.Controls.Add(this.cmbDiffOldOriginalFormat);
            this.tabDiff.Controls.Add(this.txtDiffOldOriginalPath);
            this.tabDiff.Controls.Add(this.label4);
            this.tabDiff.Controls.Add(this.cmbDiffNewOriginalFormat);
            this.tabDiff.Controls.Add(this.btnDiff);
            this.tabDiff.Controls.Add(this.txtDiffNewOriginalPath);
            this.tabDiff.Controls.Add(this.label6);
            this.tabDiff.Location = new System.Drawing.Point(4, 25);
            this.tabDiff.Margin = new System.Windows.Forms.Padding(4);
            this.tabDiff.Name = "tabDiff";
            this.tabDiff.Padding = new System.Windows.Forms.Padding(4);
            this.tabDiff.Size = new System.Drawing.Size(599, 488);
            this.tabDiff.TabIndex = 1;
            this.tabDiff.Text = "差分";
            this.tabDiff.UseVisualStyleBackColor = true;
            // 
            // btnSelectDiffDiffFilePath
            // 
            this.btnSelectDiffDiffFilePath.Location = new System.Drawing.Point(400, 171);
            this.btnSelectDiffDiffFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectDiffDiffFilePath.Name = "btnSelectDiffDiffFilePath";
            this.btnSelectDiffDiffFilePath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectDiffDiffFilePath.TabIndex = 15;
            this.btnSelectDiffDiffFilePath.Text = "...";
            this.btnSelectDiffDiffFilePath.UseVisualStyleBackColor = true;
            this.btnSelectDiffDiffFilePath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffOutputPath
            // 
            this.btnSelectDiffOutputPath.Location = new System.Drawing.Point(400, 139);
            this.btnSelectDiffOutputPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectDiffOutputPath.Name = "btnSelectDiffOutputPath";
            this.btnSelectDiffOutputPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectDiffOutputPath.TabIndex = 15;
            this.btnSelectDiffOutputPath.Text = "...";
            this.btnSelectDiffOutputPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffOutputPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffOldTranslationPath
            // 
            this.btnSelectDiffOldTranslationPath.Location = new System.Drawing.Point(400, 107);
            this.btnSelectDiffOldTranslationPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectDiffOldTranslationPath.Name = "btnSelectDiffOldTranslationPath";
            this.btnSelectDiffOldTranslationPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectDiffOldTranslationPath.TabIndex = 15;
            this.btnSelectDiffOldTranslationPath.Text = "...";
            this.btnSelectDiffOldTranslationPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffOldTranslationPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffOldOriginalPath
            // 
            this.btnSelectDiffOldOriginalPath.Location = new System.Drawing.Point(400, 76);
            this.btnSelectDiffOldOriginalPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectDiffOldOriginalPath.Name = "btnSelectDiffOldOriginalPath";
            this.btnSelectDiffOldOriginalPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectDiffOldOriginalPath.TabIndex = 15;
            this.btnSelectDiffOldOriginalPath.Text = "...";
            this.btnSelectDiffOldOriginalPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffOldOriginalPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffNewOriginalPath
            // 
            this.btnSelectDiffNewOriginalPath.Location = new System.Drawing.Point(400, 43);
            this.btnSelectDiffNewOriginalPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectDiffNewOriginalPath.Name = "btnSelectDiffNewOriginalPath";
            this.btnSelectDiffNewOriginalPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectDiffNewOriginalPath.TabIndex = 15;
            this.btnSelectDiffNewOriginalPath.Text = "...";
            this.btnSelectDiffNewOriginalPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffNewOriginalPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // txtDiffDiffFilePath
            // 
            this.txtDiffDiffFilePath.Location = new System.Drawing.Point(113, 171);
            this.txtDiffDiffFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiffDiffFilePath.Name = "txtDiffDiffFilePath";
            this.txtDiffDiffFilePath.Size = new System.Drawing.Size(280, 22);
            this.txtDiffDiffFilePath.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "差分文件";
            // 
            // cmbDiffOutputFormat
            // 
            this.cmbDiffOutputFormat.FormattingEnabled = true;
            this.cmbDiffOutputFormat.Location = new System.Drawing.Point(449, 138);
            this.cmbDiffOutputFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDiffOutputFormat.Name = "cmbDiffOutputFormat";
            this.cmbDiffOutputFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbDiffOutputFormat.TabIndex = 11;
            this.cmbDiffOutputFormat.Tag = "FileFormat";
            // 
            // txtDiffOutputPath
            // 
            this.txtDiffOutputPath.Location = new System.Drawing.Point(113, 139);
            this.txtDiffOutputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiffOutputPath.Name = "txtDiffOutputPath";
            this.txtDiffOutputPath.Size = new System.Drawing.Size(280, 22);
            this.txtDiffOutputPath.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "输出";
            // 
            // cmbDiffOldTranslationFormat
            // 
            this.cmbDiffOldTranslationFormat.FormattingEnabled = true;
            this.cmbDiffOldTranslationFormat.Location = new System.Drawing.Point(449, 106);
            this.cmbDiffOldTranslationFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDiffOldTranslationFormat.Name = "cmbDiffOldTranslationFormat";
            this.cmbDiffOldTranslationFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbDiffOldTranslationFormat.TabIndex = 8;
            this.cmbDiffOldTranslationFormat.Tag = "FileFormat";
            // 
            // txtDiffOldTranslationPath
            // 
            this.txtDiffOldTranslationPath.Location = new System.Drawing.Point(113, 107);
            this.txtDiffOldTranslationPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiffOldTranslationPath.Name = "txtDiffOldTranslationPath";
            this.txtDiffOldTranslationPath.Size = new System.Drawing.Size(280, 22);
            this.txtDiffOldTranslationPath.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "旧汉化";
            // 
            // cmbDiffOldOriginalFormat
            // 
            this.cmbDiffOldOriginalFormat.FormattingEnabled = true;
            this.cmbDiffOldOriginalFormat.Location = new System.Drawing.Point(449, 74);
            this.cmbDiffOldOriginalFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDiffOldOriginalFormat.Name = "cmbDiffOldOriginalFormat";
            this.cmbDiffOldOriginalFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbDiffOldOriginalFormat.TabIndex = 5;
            this.cmbDiffOldOriginalFormat.Tag = "FileFormat";
            // 
            // txtDiffOldOriginalPath
            // 
            this.txtDiffOldOriginalPath.Location = new System.Drawing.Point(113, 75);
            this.txtDiffOldOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiffOldOriginalPath.Name = "txtDiffOldOriginalPath";
            this.txtDiffOldOriginalPath.Size = new System.Drawing.Size(280, 22);
            this.txtDiffOldOriginalPath.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "旧原文";
            // 
            // cmbDiffNewOriginalFormat
            // 
            this.cmbDiffNewOriginalFormat.FormattingEnabled = true;
            this.cmbDiffNewOriginalFormat.Location = new System.Drawing.Point(449, 42);
            this.cmbDiffNewOriginalFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDiffNewOriginalFormat.Name = "cmbDiffNewOriginalFormat";
            this.cmbDiffNewOriginalFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbDiffNewOriginalFormat.TabIndex = 2;
            this.cmbDiffNewOriginalFormat.Tag = "FileFormat";
            // 
            // btnDiff
            // 
            this.btnDiff.Location = new System.Drawing.Point(97, 258);
            this.btnDiff.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(352, 28);
            this.btnDiff.TabIndex = 14;
            this.btnDiff.Text = "差分";
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // txtDiffNewOriginalPath
            // 
            this.txtDiffNewOriginalPath.Location = new System.Drawing.Point(113, 43);
            this.txtDiffNewOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiffNewOriginalPath.Name = "txtDiffNewOriginalPath";
            this.txtDiffNewOriginalPath.Size = new System.Drawing.Size(280, 22);
            this.txtDiffNewOriginalPath.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "新原文";
            // 
            // tabMerge
            // 
            this.tabMerge.Controls.Add(this.chkMergeIgnoreSame);
            this.tabMerge.Controls.Add(this.chkMergeCheckSpecialChar);
            this.tabMerge.Controls.Add(this.button1);
            this.tabMerge.Controls.Add(this.txtMergeCheckFilePath);
            this.tabMerge.Controls.Add(this.label15);
            this.tabMerge.Controls.Add(this.btnSelectMergeInputPath);
            this.tabMerge.Controls.Add(this.cmbMergeInputFormat);
            this.tabMerge.Controls.Add(this.txtMergeInputPath);
            this.tabMerge.Controls.Add(this.label14);
            this.tabMerge.Controls.Add(this.btnSelectMergeDiffFilePath);
            this.tabMerge.Controls.Add(this.btnSelectMergeOutputPath);
            this.tabMerge.Controls.Add(this.btnMergeOldTranslationPath);
            this.tabMerge.Controls.Add(this.btnSelectMergeOldOriginalPath);
            this.tabMerge.Controls.Add(this.btnSelectMergeNewOriginalPath);
            this.tabMerge.Controls.Add(this.txtMergeDiffFilePath);
            this.tabMerge.Controls.Add(this.label9);
            this.tabMerge.Controls.Add(this.cmbMergeOutputFormat);
            this.tabMerge.Controls.Add(this.txtMergeOutputPath);
            this.tabMerge.Controls.Add(this.label10);
            this.tabMerge.Controls.Add(this.cmbMergeOldTranslationFormat);
            this.tabMerge.Controls.Add(this.txtMergeOldTranslationPath);
            this.tabMerge.Controls.Add(this.label11);
            this.tabMerge.Controls.Add(this.cmbMergeOldOriginalFormat);
            this.tabMerge.Controls.Add(this.txtMergeOldOriginalPath);
            this.tabMerge.Controls.Add(this.label12);
            this.tabMerge.Controls.Add(this.cmbMergeNewOriginalFormat);
            this.tabMerge.Controls.Add(this.btnMerge);
            this.tabMerge.Controls.Add(this.txtMergeNewOriginalPath);
            this.tabMerge.Controls.Add(this.label13);
            this.tabMerge.Location = new System.Drawing.Point(4, 25);
            this.tabMerge.Margin = new System.Windows.Forms.Padding(4);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Size = new System.Drawing.Size(599, 488);
            this.tabMerge.TabIndex = 2;
            this.tabMerge.Text = "合并";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // chkMergeIgnoreSame
            // 
            this.chkMergeIgnoreSame.AutoSize = true;
            this.chkMergeIgnoreSame.Location = new System.Drawing.Point(175, 235);
            this.chkMergeIgnoreSame.Margin = new System.Windows.Forms.Padding(4);
            this.chkMergeIgnoreSame.Name = "chkMergeIgnoreSame";
            this.chkMergeIgnoreSame.Size = new System.Drawing.Size(128, 21);
            this.chkMergeIgnoreSame.TabIndex = 43;
            this.chkMergeIgnoreSame.Text = "忽略未翻译原文";
            this.chkMergeIgnoreSame.UseVisualStyleBackColor = true;
            // 
            // chkMergeCheckSpecialChar
            // 
            this.chkMergeCheckSpecialChar.AutoSize = true;
            this.chkMergeCheckSpecialChar.Location = new System.Drawing.Point(36, 235);
            this.chkMergeCheckSpecialChar.Margin = new System.Windows.Forms.Padding(4);
            this.chkMergeCheckSpecialChar.Name = "chkMergeCheckSpecialChar";
            this.chkMergeCheckSpecialChar.Size = new System.Drawing.Size(114, 21);
            this.chkMergeCheckSpecialChar.TabIndex = 43;
            this.chkMergeCheckSpecialChar.Text = "检查特殊字符";
            this.chkMergeCheckSpecialChar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 256);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // txtMergeCheckFilePath
            // 
            this.txtMergeCheckFilePath.Location = new System.Drawing.Point(113, 256);
            this.txtMergeCheckFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeCheckFilePath.Name = "txtMergeCheckFilePath";
            this.txtMergeCheckFilePath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeCheckFilePath.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 260);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 17);
            this.label15.TabIndex = 40;
            this.label15.Text = "检查文件";
            // 
            // btnSelectMergeInputPath
            // 
            this.btnSelectMergeInputPath.Location = new System.Drawing.Point(400, 139);
            this.btnSelectMergeInputPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectMergeInputPath.Name = "btnSelectMergeInputPath";
            this.btnSelectMergeInputPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectMergeInputPath.TabIndex = 39;
            this.btnSelectMergeInputPath.Text = "...";
            this.btnSelectMergeInputPath.UseVisualStyleBackColor = true;
            this.btnSelectMergeInputPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // cmbMergeInputFormat
            // 
            this.cmbMergeInputFormat.FormattingEnabled = true;
            this.cmbMergeInputFormat.Location = new System.Drawing.Point(449, 138);
            this.cmbMergeInputFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMergeInputFormat.Name = "cmbMergeInputFormat";
            this.cmbMergeInputFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbMergeInputFormat.TabIndex = 38;
            this.cmbMergeInputFormat.Tag = "FileFormat";
            // 
            // txtMergeInputPath
            // 
            this.txtMergeInputPath.Location = new System.Drawing.Point(113, 139);
            this.txtMergeInputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeInputPath.Name = "txtMergeInputPath";
            this.txtMergeInputPath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeInputPath.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 143);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 36;
            this.label14.Text = "输入";
            // 
            // btnSelectMergeDiffFilePath
            // 
            this.btnSelectMergeDiffFilePath.Location = new System.Drawing.Point(400, 203);
            this.btnSelectMergeDiffFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectMergeDiffFilePath.Name = "btnSelectMergeDiffFilePath";
            this.btnSelectMergeDiffFilePath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectMergeDiffFilePath.TabIndex = 35;
            this.btnSelectMergeDiffFilePath.Text = "...";
            this.btnSelectMergeDiffFilePath.UseVisualStyleBackColor = true;
            this.btnSelectMergeDiffFilePath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectMergeOutputPath
            // 
            this.btnSelectMergeOutputPath.Location = new System.Drawing.Point(400, 171);
            this.btnSelectMergeOutputPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectMergeOutputPath.Name = "btnSelectMergeOutputPath";
            this.btnSelectMergeOutputPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectMergeOutputPath.TabIndex = 34;
            this.btnSelectMergeOutputPath.Text = "...";
            this.btnSelectMergeOutputPath.UseVisualStyleBackColor = true;
            this.btnSelectMergeOutputPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnMergeOldTranslationPath
            // 
            this.btnMergeOldTranslationPath.Location = new System.Drawing.Point(400, 107);
            this.btnMergeOldTranslationPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMergeOldTranslationPath.Name = "btnMergeOldTranslationPath";
            this.btnMergeOldTranslationPath.Size = new System.Drawing.Size(37, 23);
            this.btnMergeOldTranslationPath.TabIndex = 33;
            this.btnMergeOldTranslationPath.Text = "...";
            this.btnMergeOldTranslationPath.UseVisualStyleBackColor = true;
            this.btnMergeOldTranslationPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectMergeOldOriginalPath
            // 
            this.btnSelectMergeOldOriginalPath.Location = new System.Drawing.Point(400, 76);
            this.btnSelectMergeOldOriginalPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectMergeOldOriginalPath.Name = "btnSelectMergeOldOriginalPath";
            this.btnSelectMergeOldOriginalPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectMergeOldOriginalPath.TabIndex = 32;
            this.btnSelectMergeOldOriginalPath.Text = "...";
            this.btnSelectMergeOldOriginalPath.UseVisualStyleBackColor = true;
            this.btnSelectMergeOldOriginalPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectMergeNewOriginalPath
            // 
            this.btnSelectMergeNewOriginalPath.Location = new System.Drawing.Point(400, 43);
            this.btnSelectMergeNewOriginalPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectMergeNewOriginalPath.Name = "btnSelectMergeNewOriginalPath";
            this.btnSelectMergeNewOriginalPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectMergeNewOriginalPath.TabIndex = 31;
            this.btnSelectMergeNewOriginalPath.Text = "...";
            this.btnSelectMergeNewOriginalPath.UseVisualStyleBackColor = true;
            this.btnSelectMergeNewOriginalPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // txtMergeDiffFilePath
            // 
            this.txtMergeDiffFilePath.Location = new System.Drawing.Point(113, 203);
            this.txtMergeDiffFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeDiffFilePath.Name = "txtMergeDiffFilePath";
            this.txtMergeDiffFilePath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeDiffFilePath.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 207);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "差分文件";
            // 
            // cmbMergeOutputFormat
            // 
            this.cmbMergeOutputFormat.FormattingEnabled = true;
            this.cmbMergeOutputFormat.Location = new System.Drawing.Point(449, 170);
            this.cmbMergeOutputFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMergeOutputFormat.Name = "cmbMergeOutputFormat";
            this.cmbMergeOutputFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbMergeOutputFormat.TabIndex = 27;
            this.cmbMergeOutputFormat.Tag = "FileFormat";
            // 
            // txtMergeOutputPath
            // 
            this.txtMergeOutputPath.Location = new System.Drawing.Point(113, 171);
            this.txtMergeOutputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeOutputPath.Name = "txtMergeOutputPath";
            this.txtMergeOutputPath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeOutputPath.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 175);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "输出";
            // 
            // cmbMergeOldTranslationFormat
            // 
            this.cmbMergeOldTranslationFormat.FormattingEnabled = true;
            this.cmbMergeOldTranslationFormat.Location = new System.Drawing.Point(449, 106);
            this.cmbMergeOldTranslationFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMergeOldTranslationFormat.Name = "cmbMergeOldTranslationFormat";
            this.cmbMergeOldTranslationFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbMergeOldTranslationFormat.TabIndex = 24;
            this.cmbMergeOldTranslationFormat.Tag = "FileFormat";
            // 
            // txtMergeOldTranslationPath
            // 
            this.txtMergeOldTranslationPath.Location = new System.Drawing.Point(113, 107);
            this.txtMergeOldTranslationPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeOldTranslationPath.Name = "txtMergeOldTranslationPath";
            this.txtMergeOldTranslationPath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeOldTranslationPath.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 111);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "旧汉化";
            // 
            // cmbMergeOldOriginalFormat
            // 
            this.cmbMergeOldOriginalFormat.FormattingEnabled = true;
            this.cmbMergeOldOriginalFormat.Location = new System.Drawing.Point(449, 74);
            this.cmbMergeOldOriginalFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMergeOldOriginalFormat.Name = "cmbMergeOldOriginalFormat";
            this.cmbMergeOldOriginalFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbMergeOldOriginalFormat.TabIndex = 21;
            this.cmbMergeOldOriginalFormat.Tag = "FileFormat";
            // 
            // txtMergeOldOriginalPath
            // 
            this.txtMergeOldOriginalPath.Location = new System.Drawing.Point(113, 75);
            this.txtMergeOldOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeOldOriginalPath.Name = "txtMergeOldOriginalPath";
            this.txtMergeOldOriginalPath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeOldOriginalPath.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 79);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "旧原文";
            // 
            // cmbMergeNewOriginalFormat
            // 
            this.cmbMergeNewOriginalFormat.FormattingEnabled = true;
            this.cmbMergeNewOriginalFormat.Location = new System.Drawing.Point(449, 42);
            this.cmbMergeNewOriginalFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMergeNewOriginalFormat.Name = "cmbMergeNewOriginalFormat";
            this.cmbMergeNewOriginalFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbMergeNewOriginalFormat.TabIndex = 18;
            this.cmbMergeNewOriginalFormat.Tag = "FileFormat";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(97, 319);
            this.btnMerge.Margin = new System.Windows.Forms.Padding(4);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(352, 28);
            this.btnMerge.TabIndex = 30;
            this.btnMerge.Text = "合并";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // txtMergeNewOriginalPath
            // 
            this.txtMergeNewOriginalPath.Location = new System.Drawing.Point(113, 43);
            this.txtMergeNewOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMergeNewOriginalPath.Name = "txtMergeNewOriginalPath";
            this.txtMergeNewOriginalPath.Size = new System.Drawing.Size(280, 22);
            this.txtMergeNewOriginalPath.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 47);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "新原文";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnConvert);
            this.tabPage1.Controls.Add(this.btnSelectConvertInputPath);
            this.tabPage1.Controls.Add(this.cmbConvertInputFormat);
            this.tabPage1.Controls.Add(this.txtConvertInputPath);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.btnSelectConvertOutputPath);
            this.tabPage1.Controls.Add(this.cmbConvertOutputFormat);
            this.tabPage1.Controls.Add(this.txtConvertOutputPath);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(599, 488);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "转换";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(123, 230);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(352, 28);
            this.btnConvert.TabIndex = 48;
            this.btnConvert.Text = "转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnSelectConvertInputPath
            // 
            this.btnSelectConvertInputPath.Location = new System.Drawing.Point(397, 44);
            this.btnSelectConvertInputPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectConvertInputPath.Name = "btnSelectConvertInputPath";
            this.btnSelectConvertInputPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectConvertInputPath.TabIndex = 47;
            this.btnSelectConvertInputPath.Text = "...";
            this.btnSelectConvertInputPath.UseVisualStyleBackColor = true;
            this.btnSelectConvertInputPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // cmbConvertInputFormat
            // 
            this.cmbConvertInputFormat.FormattingEnabled = true;
            this.cmbConvertInputFormat.Location = new System.Drawing.Point(446, 43);
            this.cmbConvertInputFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConvertInputFormat.Name = "cmbConvertInputFormat";
            this.cmbConvertInputFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbConvertInputFormat.TabIndex = 46;
            this.cmbConvertInputFormat.Tag = "FileFormat";
            // 
            // txtConvertInputPath
            // 
            this.txtConvertInputPath.Location = new System.Drawing.Point(110, 44);
            this.txtConvertInputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtConvertInputPath.Name = "txtConvertInputPath";
            this.txtConvertInputPath.Size = new System.Drawing.Size(280, 22);
            this.txtConvertInputPath.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 48);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 17);
            this.label16.TabIndex = 44;
            this.label16.Text = "输入";
            // 
            // btnSelectConvertOutputPath
            // 
            this.btnSelectConvertOutputPath.Location = new System.Drawing.Point(397, 76);
            this.btnSelectConvertOutputPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectConvertOutputPath.Name = "btnSelectConvertOutputPath";
            this.btnSelectConvertOutputPath.Size = new System.Drawing.Size(37, 23);
            this.btnSelectConvertOutputPath.TabIndex = 43;
            this.btnSelectConvertOutputPath.Text = "...";
            this.btnSelectConvertOutputPath.UseVisualStyleBackColor = true;
            this.btnSelectConvertOutputPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // cmbConvertOutputFormat
            // 
            this.cmbConvertOutputFormat.FormattingEnabled = true;
            this.cmbConvertOutputFormat.Location = new System.Drawing.Point(446, 75);
            this.cmbConvertOutputFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConvertOutputFormat.Name = "cmbConvertOutputFormat";
            this.cmbConvertOutputFormat.Size = new System.Drawing.Size(120, 24);
            this.cmbConvertOutputFormat.TabIndex = 42;
            this.cmbConvertOutputFormat.Tag = "FileFormat";
            // 
            // txtConvertOutputPath
            // 
            this.txtConvertOutputPath.Location = new System.Drawing.Point(110, 76);
            this.txtConvertOutputPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtConvertOutputPath.Name = "txtConvertOutputPath";
            this.txtConvertOutputPath.Size = new System.Drawing.Size(280, 22);
            this.txtConvertOutputPath.TabIndex = 41;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 80);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 17);
            this.label17.TabIndex = 40;
            this.label17.Text = "输出";
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Location = new System.Drawing.Point(0, 559);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripMain.Size = new System.Drawing.Size(603, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(603, 24);
            this.menuStripMain.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 581);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.tabControlMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Paradox Localisation Assistant";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            this.tabDiff.ResumeLayout(false);
            this.tabDiff.PerformLayout();
            this.tabMerge.ResumeLayout(false);
            this.tabMerge.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.TabPage tabDiff;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox txtBackupNewOriginalPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackupGamePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackupOldOriginalPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ComboBox cmbDiffOutputFormat;
        private System.Windows.Forms.TextBox txtDiffOutputPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDiffOldTranslationFormat;
        private System.Windows.Forms.TextBox txtDiffOldTranslationPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDiffOldOriginalFormat;
        private System.Windows.Forms.TextBox txtDiffOldOriginalPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDiffNewOriginalFormat;
        private System.Windows.Forms.Button btnDiff;
        private System.Windows.Forms.TextBox txtDiffNewOriginalPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiffDiffFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSelectDiffNewOriginalPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectDiffDiffFilePath;
        private System.Windows.Forms.Button btnSelectDiffOutputPath;
        private System.Windows.Forms.Button btnSelectDiffOldTranslationPath;
        private System.Windows.Forms.Button btnSelectDiffOldOriginalPath;
        private System.Windows.Forms.TabPage tabMerge;
        private System.Windows.Forms.Button btnSelectMergeInputPath;
        private System.Windows.Forms.ComboBox cmbMergeInputFormat;
        private System.Windows.Forms.TextBox txtMergeInputPath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSelectMergeDiffFilePath;
        private System.Windows.Forms.Button btnSelectMergeOutputPath;
        private System.Windows.Forms.Button btnMergeOldTranslationPath;
        private System.Windows.Forms.Button btnSelectMergeOldOriginalPath;
        private System.Windows.Forms.Button btnSelectMergeNewOriginalPath;
        private System.Windows.Forms.TextBox txtMergeDiffFilePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMergeOutputFormat;
        private System.Windows.Forms.TextBox txtMergeOutputPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMergeOldTranslationFormat;
        private System.Windows.Forms.TextBox txtMergeOldTranslationPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMergeOldOriginalFormat;
        private System.Windows.Forms.TextBox txtMergeOldOriginalPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbMergeNewOriginalFormat;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.TextBox txtMergeNewOriginalPath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkMergeCheckSpecialChar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMergeCheckFilePath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkMergeIgnoreSame;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnSelectConvertInputPath;
        private System.Windows.Forms.ComboBox cmbConvertInputFormat;
        private System.Windows.Forms.TextBox txtConvertInputPath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSelectConvertOutputPath;
        private System.Windows.Forms.ComboBox cmbConvertOutputFormat;
        private System.Windows.Forms.TextBox txtConvertOutputPath;
        private System.Windows.Forms.Label label17;
    }
}