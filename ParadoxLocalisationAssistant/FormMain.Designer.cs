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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tabControlMain.SuspendLayout();
            this.tabBackup.SuspendLayout();
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
            this.tabControlMain.TabIndex = 0;
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
            this.txtBackupOldOriginalPath.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "原始备份到";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(76, 152);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(264, 23);
            this.btnBackup.TabIndex = 4;
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
            this.tabDiff.Location = new System.Drawing.Point(4, 22);
            this.tabDiff.Name = "tabDiff";
            this.tabDiff.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiff.Size = new System.Drawing.Size(447, 444);
            this.tabDiff.TabIndex = 1;
            this.tabDiff.Text = "差分";
            this.tabDiff.UseVisualStyleBackColor = true;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 450);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(452, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(452, 24);
            this.menuStripMain.TabIndex = 2;
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
    }
}