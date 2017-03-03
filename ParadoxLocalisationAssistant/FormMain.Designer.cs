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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlMain.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.tabDiff.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabBackup);
            this.tabControlMain.Controls.Add(this.tabDiff);
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
            this.btnSelectDiffDiffFilePath.Name = "btnSelectDiffDiffFilePath";
            this.btnSelectDiffDiffFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnSelectDiffDiffFilePath.TabIndex = 15;
            this.btnSelectDiffDiffFilePath.Text = "...";
            this.btnSelectDiffDiffFilePath.UseVisualStyleBackColor = true;
            this.btnSelectDiffDiffFilePath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffOutputPath
            // 
            this.btnSelectDiffOutputPath.Location = new System.Drawing.Point(400, 139);
            this.btnSelectDiffOutputPath.Name = "btnSelectDiffOutputPath";
            this.btnSelectDiffOutputPath.Size = new System.Drawing.Size(38, 23);
            this.btnSelectDiffOutputPath.TabIndex = 15;
            this.btnSelectDiffOutputPath.Text = "...";
            this.btnSelectDiffOutputPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffOutputPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffOldTranslationPath
            // 
            this.btnSelectDiffOldTranslationPath.Location = new System.Drawing.Point(400, 107);
            this.btnSelectDiffOldTranslationPath.Name = "btnSelectDiffOldTranslationPath";
            this.btnSelectDiffOldTranslationPath.Size = new System.Drawing.Size(38, 23);
            this.btnSelectDiffOldTranslationPath.TabIndex = 15;
            this.btnSelectDiffOldTranslationPath.Text = "...";
            this.btnSelectDiffOldTranslationPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffOldTranslationPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffOldOriginalPath
            // 
            this.btnSelectDiffOldOriginalPath.Location = new System.Drawing.Point(400, 76);
            this.btnSelectDiffOldOriginalPath.Name = "btnSelectDiffOldOriginalPath";
            this.btnSelectDiffOldOriginalPath.Size = new System.Drawing.Size(38, 23);
            this.btnSelectDiffOldOriginalPath.TabIndex = 15;
            this.btnSelectDiffOldOriginalPath.Text = "...";
            this.btnSelectDiffOldOriginalPath.UseVisualStyleBackColor = true;
            this.btnSelectDiffOldOriginalPath.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // btnSelectDiffNewOriginalPath
            // 
            this.btnSelectDiffNewOriginalPath.Location = new System.Drawing.Point(400, 43);
            this.btnSelectDiffNewOriginalPath.Name = "btnSelectDiffNewOriginalPath";
            this.btnSelectDiffNewOriginalPath.Size = new System.Drawing.Size(38, 23);
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
    }
}