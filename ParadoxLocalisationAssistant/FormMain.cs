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

            txtMergeNewOriginalPath.Text = Properties.Settings.Default.NewOriginalPath;
            cmbMergeNewOriginalFormat.Text = Properties.Settings.Default.NewOriginalFormat;
            txtMergeOldOriginalPath.Text = Properties.Settings.Default.OldOriginalPath;
            cmbMergeOldOriginalFormat.Text = Properties.Settings.Default.OldOriginalFormat;
            txtMergeOldTranslationPath.Text = Properties.Settings.Default.OldTranslationPath;
            cmbMergeOldTranslationFormat.Text = Properties.Settings.Default.OldTranslationFormat;
            txtMergeInputPath.Text = Properties.Settings.Default.MergeInputPath;
            cmbMergeInputFormat.Text = Properties.Settings.Default.MergeInputFormat;
            txtMergeOutputPath.Text = Properties.Settings.Default.MergeOutputPath;
            cmbMergeOutputFormat.Text = Properties.Settings.Default.MergeOutputFormat;
            txtMergeDiffFilePath.Text = Properties.Settings.Default.DiffFilePath;
            chkMergeCheckSpecialChar.Checked = Properties.Settings.Default.CheckSpecialChar;
            chkMergeIgnoreSame.Checked = Properties.Settings.Default.IgnorePotentialUntranslated;
            txtMergeCheckFilePath.Text = Properties.Settings.Default.CheckFilePath;
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
                {
                    diffOutputPath = null;
                    diffOutputFormat = null;
                }
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

        private void btnMerge_Click(object sender, EventArgs e)
        {
            string newOriginalPath = txtMergeNewOriginalPath.Text;
            string newOriginalFormat = cmbMergeNewOriginalFormat.Text;
            string oldOriginalPath = txtMergeOldOriginalPath.Text;
            string oldOriginalFormat = cmbMergeOldOriginalFormat.Text;
            string oldTranslationPath = txtMergeOldTranslationPath.Text;
            string oldTranslationFormat = cmbMergeOldTranslationFormat.Text;
            string mergeInputPath = txtMergeInputPath.Text;
            string mergeInputFormat = cmbMergeInputFormat.Text;
            string mergeOutputPath = txtMergeOutputPath.Text;
            string mergeOutputFormat = cmbMergeOutputFormat.Text;
            string diffFilePath = txtMergeDiffFilePath.Text;
            string language = Properties.Settings.Default.Language;
            bool checkSpecialChar = chkMergeCheckSpecialChar.Checked;
            bool ignoreSame = chkMergeIgnoreSame.Checked;
            string checkFilePath = txtMergeCheckFilePath.Text;

            Properties.Settings.Default.NewOriginalPath = newOriginalPath;
            Properties.Settings.Default.NewOriginalFormat = newOriginalFormat;
            Properties.Settings.Default.OldOriginalPath = oldOriginalPath;
            Properties.Settings.Default.OldOriginalFormat = oldOriginalFormat;
            Properties.Settings.Default.OldTranslationPath = oldTranslationPath;
            Properties.Settings.Default.OldTranslationFormat = oldTranslationFormat;
            Properties.Settings.Default.MergeInputPath = mergeInputPath;
            Properties.Settings.Default.MergeInputFormat = mergeInputFormat;
            Properties.Settings.Default.MergeOutputPath = mergeOutputPath;
            Properties.Settings.Default.MergeOutputFormat = mergeOutputFormat;
            Properties.Settings.Default.DiffFilePath = diffFilePath;
            Properties.Settings.Default.CheckSpecialChar = checkSpecialChar;
            Properties.Settings.Default.IgnorePotentialUntranslated = ignoreSame;
            Properties.Settings.Default.CheckFilePath = checkFilePath;
            Properties.Settings.Default.Save();
            updateTextBoxFromSettings();

            try
            {
                if (oldOriginalPath == "")
                {
                    oldOriginalPath = null;
                    oldOriginalFormat = null;
                }
                if (oldTranslationPath == "")
                {
                    oldTranslationPath = null;
                    oldTranslationFormat = null;
                }
                Commands.DoMerge(newOriginalPath, newOriginalFormat, oldOriginalPath, oldOriginalFormat,
                    oldTranslationPath, oldTranslationFormat, mergeInputPath, mergeInputFormat, mergeOutputPath, mergeOutputFormat, 
                    diffFilePath, language, checkSpecialChar, ignoreSame, checkFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }
    }
}
