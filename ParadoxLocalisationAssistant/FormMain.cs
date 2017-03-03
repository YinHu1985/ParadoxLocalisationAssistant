using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParadoxLocalisationAssistant
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string gamePath = txtBackupGamePath.Text;
            string newOriginalPath = txtBackupNewOriginalPath.Text;
            string oldOriginalPath = txtBackupOldOriginalPath.Text;
            string language = Properties.Settings.Default.Language;

            Properties.Settings.Default.GamePath = gamePath;
            Properties.Settings.Default.NewOriginalPath = newOriginalPath;
            Properties.Settings.Default.OldOriginalPath = oldOriginalPath;
            Properties.Settings.Default.Save();
            updateTextBoxFromSettings();

            try
            {
                Commands.DoBackup(gamePath, newOriginalPath, oldOriginalPath, language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            updateTextBoxFromSettings();
        }

        private void updateTextBoxFromSettings()
        {
            txtBackupGamePath.Text = Properties.Settings.Default.GamePath;
            txtBackupNewOriginalPath.Text = Properties.Settings.Default.NewOriginalPath;
            txtBackupOldOriginalPath.Text = Properties.Settings.Default.OldOriginalPath;
        }
    }
}
