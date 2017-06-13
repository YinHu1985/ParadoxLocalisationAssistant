using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ParadoxLocalisationAssistant
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach(TabPage tab in tabControlMain.TabPages)
            {
                foreach(Control c in tab.Controls)
                {
                    if ((string)c.Tag == "FileFormat" && c is ComboBox)
                    {
                        ComboBox cmb = (ComboBox)c;
                        cmb.DataSource = LocalizationFileFormat.GetAllFileFormats();
                    }
                }
            }
            updateTextBoxFromSettings();
        }

        private void updateTextBoxFromSettings()
        {
            txtBackupGamePath.Text = Properties.Settings.Default.GamePath;
            txtBackupNewOriginalPath.Text = Properties.Settings.Default.NewOriginalPath;
            txtBackupOldOriginalPath.Text = Properties.Settings.Default.OldOriginalPath;

            txtDiffNewOriginalPath.Text = Properties.Settings.Default.NewOriginalPath;
            cmbDiffNewOriginalFormat.Text = Properties.Settings.Default.NewOriginalFormat;
            txtDiffOldOriginalPath.Text = Properties.Settings.Default.OldOriginalPath;
            cmbDiffOldOriginalFormat.Text = Properties.Settings.Default.OldOriginalFormat;
            txtDiffOldTranslationPath.Text = Properties.Settings.Default.OldTranslationPath;
            cmbDiffOldTranslationFormat.Text = Properties.Settings.Default.OldTranslationFormat;
            txtDiffOutputPath.Text = Properties.Settings.Default.DiffOutputPath;
            cmbDiffOutputFormat.Text = Properties.Settings.Default.DiffOutputFormat;
            txtDiffDiffFilePath.Text = Properties.Settings.Default.DiffFilePath;
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

        private void btnDiff_Click(object sender, EventArgs e)
        {
            string newOriginalPath = txtDiffNewOriginalPath.Text;
            string newOriginalFormat = cmbDiffNewOriginalFormat.Text;
            string oldOriginalPath = txtDiffOldOriginalPath.Text;
            string oldOriginalFormat = cmbDiffOldOriginalFormat.Text;
            string oldTranslationPath = txtDiffOldTranslationPath.Text;
            string oldTranslationFormat = cmbDiffOldTranslationFormat.Text;
            string diffOutputPath = txtDiffOutputPath.Text;
            string diffOutputFormat = cmbDiffOutputFormat.Text;
            string diffFilePath = txtDiffDiffFilePath.Text;
            string language = Properties.Settings.Default.Language;

            Properties.Settings.Default.NewOriginalPath = newOriginalPath;
            Properties.Settings.Default.NewOriginalFormat = newOriginalFormat;
            Properties.Settings.Default.OldOriginalPath = oldOriginalPath;
            Properties.Settings.Default.OldOriginalFormat = oldOriginalFormat;
            Properties.Settings.Default.OldTranslationPath = oldTranslationPath;
            Properties.Settings.Default.OldTranslationFormat = oldTranslationFormat;
            Properties.Settings.Default.DiffOutputPath = diffOutputPath;
            Properties.Settings.Default.DiffOutputFormat = diffOutputFormat;
            Properties.Settings.Default.DiffFilePath = diffFilePath;
            Properties.Settings.Default.Save();
            updateTextBoxFromSettings();

            try
            {
                if (diffOutputPath == "")
                    diffOutputPath = null;
                Commands.DoDiff(newOriginalPath, newOriginalFormat, oldOriginalPath, oldOriginalFormat,
                    oldTranslationPath, oldTranslationFormat, diffOutputPath, diffOutputFormat, diffFilePath, language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            string path = folderBrowserDialog1.SelectedPath;
            if (string.IsNullOrEmpty(path))
                folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory();
            
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                if (sender == btnSelectDiffDiffFilePath)
                    txtDiffDiffFilePath.Text = path;
                else if (sender == btnSelectDiffNewOriginalPath)
                    txtDiffNewOriginalPath.Text = path;
                else if (sender == btnSelectDiffOldOriginalPath)
                    txtDiffOldOriginalPath.Text = path;
                else if (sender == btnSelectDiffOldTranslationPath)
                    txtDiffOldTranslationPath.Text = path;
                else if (sender == btnSelectDiffOutputPath)
                    txtDiffOutputPath.Text = path;
            }

        }
    }
}
