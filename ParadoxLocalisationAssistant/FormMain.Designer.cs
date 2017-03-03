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
            this.tabControlMain.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.tabDiff.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabBackup);
            this.tabControlMain.Controls.Add(this.tabDiff);
            this.tabControlMain.Location = new System.Drawing.Point(0, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(455, 420);
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
            this.tabBackup.Location = new System.Drawing.Point(4, 22);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(447, 394);
            this.tabBackup.TabIndex = 0;
            this.tabBackup.Text = "备份";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // txtBackupOldOriginalPath
            // 
            this.txtBackupOldOriginalPath.Location = new System.Drawing.Point(108, 98);
            this.txtBackupOldOriginalPath.Name = "txtBackupOldOriginalPath";
            this.txtBackupOldOriginalPath.Size = new System.Drawing.Size(269, 20);
            this.txtBackupOldOriginalPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "原始备份到";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(76, 152);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(264, 23);
            this.btnBackup.TabIndex = 6;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtBackupNewOriginalPath
            // 
            this.txtBackupNewOriginalPath.Location = new System.Drawing.Point(108, 62);
            this.txtBackupNewOriginalPath.Name = "txtBackupNewOriginalPath";
            this.txtBackupNewOriginalPath.Size = new System.Drawing.Size(269, 20);
            this.txtBackupNewOriginalPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "备份文件夹";
            // 
            // txtBackupGamePath
            // 
            this.txtBackupGamePath.Location = new System.Drawing.Point(108, 27);
            this.txtBackupGamePath.Name = "txtBackupGamePath";
            this.txtBackupGamePath.Size = new System.Drawing.Size(269, 20);
            this.txtBackupGamePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏文件夹";
            // 
            // tabDiff
            // 
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
            this.tabDiff.Location = new System.Drawing.Point(4, 22);
            this.tabDiff.Name = "tabDiff";
            this.tabDiff.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiff.Size = new System.Drawing.Size(447, 394);
            this.tabDiff.TabIndex = 1;
            this.tabDiff.Text = "差分";
            this.tabDiff.UseVisualStyleBackColor = true;
            // 
            // txtDiffDiffFilePath
            // 
            this.txtDiffDiffFilePath.Location = new System.Drawing.Point(85, 139);
            this.txtDiffDiffFilePath.Name = "txtDiffDiffFilePath";
            this.txtDiffDiffFilePath.Size = new System.Drawing.Size(211, 20);
            this.txtDiffDiffFilePath.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "差分文件";
            // 
            // cmbDiffOutputFormat
            // 
            this.cmbDiffOutputFormat.FormattingEnabled = true;
            this.cmbDiffOutputFormat.Location = new System.Drawing.Point(302, 112);
            this.cmbDiffOutputFormat.Name = "cmbDiffOutputFormat";
            this.cmbDiffOutputFormat.Size = new System.Drawing.Size(91, 21);
            this.cmbDiffOutputFormat.TabIndex = 11;
            this.cmbDiffOutputFormat.Tag = "FileFormat";
            // 
            // txtDiffOutputPath
            // 
            this.txtDiffOutputPath.Location = new System.Drawing.Point(85, 113);
            this.txtDiffOutputPath.Name = "txtDiffOutputPath";
            this.txtDiffOutputPath.Size = new System.Drawing.Size(211, 20);
            this.txtDiffOutputPath.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "输出";
            // 
            // cmbDiffOldTranslationFormat
            // 
            this.cmbDiffOldTranslationFormat.FormattingEnabled = true;
            this.cmbDiffOldTranslationFormat.Location = new System.Drawing.Point(302, 86);
            this.cmbDiffOldTranslationFormat.Name = "cmbDiffOldTranslationFormat";
            this.cmbDiffOldTranslationFormat.Size = new System.Drawing.Size(91, 21);
            this.cmbDiffOldTranslationFormat.TabIndex = 8;
            this.cmbDiffOldTranslationFormat.Tag = "FileFormat";
            // 
            // txtDiffOldTranslationPath
            // 
            this.txtDiffOldTranslationPath.Location = new System.Drawing.Point(85, 87);
            this.txtDiffOldTranslationPath.Name = "txtDiffOldTranslationPath";
            this.txtDiffOldTranslationPath.Size = new System.Drawing.Size(211, 20);
            this.txtDiffOldTranslationPath.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "旧汉化";
            // 
            // cmbDiffOldOriginalFormat
            // 
            this.cmbDiffOldOriginalFormat.FormattingEnabled = true;
            this.cmbDiffOldOriginalFormat.Location = new System.Drawing.Point(302, 60);
            this.cmbDiffOldOriginalFormat.Name = "cmbDiffOldOriginalFormat";
            this.cmbDiffOldOriginalFormat.Size = new System.Drawing.Size(91, 21);
            this.cmbDiffOldOriginalFormat.TabIndex = 5;
            this.cmbDiffOldOriginalFormat.Tag = "FileFormat";
            // 
            // txtDiffOldOriginalPath
            // 
            this.txtDiffOldOriginalPath.Location = new System.Drawing.Point(85, 61);
            this.txtDiffOldOriginalPath.Name = "txtDiffOldOriginalPath";
            this.txtDiffOldOriginalPath.Size = new System.Drawing.Size(211, 20);
            this.txtDiffOldOriginalPath.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "旧原文";
            // 
            // cmbDiffNewOriginalFormat
            // 
            this.cmbDiffNewOriginalFormat.FormattingEnabled = true;
            this.cmbDiffNewOriginalFormat.Location = new System.Drawing.Point(302, 34);
            this.cmbDiffNewOriginalFormat.Name = "cmbDiffNewOriginalFormat";
            this.cmbDiffNewOriginalFormat.Size = new System.Drawing.Size(91, 21);
            this.cmbDiffNewOriginalFormat.TabIndex = 2;
            this.cmbDiffNewOriginalFormat.Tag = "FileFormat";
            // 
            // btnDiff
            // 
            this.btnDiff.Location = new System.Drawing.Point(73, 210);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(264, 23);
            this.btnDiff.TabIndex = 14;
            this.btnDiff.Text = "差分";
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // txtDiffNewOriginalPath
            // 
            this.txtDiffNewOriginalPath.Location = new System.Drawing.Point(85, 35);
            this.txtDiffNewOriginalPath.Name = "txtDiffNewOriginalPath";
            this.txtDiffNewOriginalPath.Size = new System.Drawing.Size(211, 20);
            this.txtDiffNewOriginalPath.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "新原文";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 450);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(452, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(452, 24);
            this.menuStripMain.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 472);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.tabControlMain);
            this.MainMenuStrip = this.menuStripMain;
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
    }
}