using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace ParadoxLocalisationAssistant
{
    public static class Commands
    {
        private static readonly string LOCALISATION_DIR_NAME = "localisation";
        private static readonly string DLC_DIR_NAME = "dlc";


        static string GetLanguageTag(string language)
        {
            return "l_" + language;
        }

        static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        public static bool DoBackup(string gameDirPath, string backupDirPath, string backupForBackupPath, string language)
        {
            string languageTag = GetLanguageTag(language);

            // Backup the original backup folder
            if (Directory.Exists(backupForBackupPath))
                Directory.Delete(backupForBackupPath, true);
            Directory.CreateDirectory(backupForBackupPath);
            CopyFilesRecursively(new DirectoryInfo(backupDirPath), new DirectoryInfo(backupForBackupPath));

            // Clean backup folder
            foreach (string filePath in Directory.GetFiles(backupDirPath))
                File.Delete(filePath);
            foreach (string dirPath in Directory.GetDirectories(backupDirPath))
                Directory.Delete(dirPath, true);

            // Backup localisation folder
            string localisationDir = Path.Combine(gameDirPath, LOCALISATION_DIR_NAME);
            string backupLocalDir = backupDirPath; // Path.Combine(backupDirPath, LOCALISATION_DIR_NAME);
            Directory.CreateDirectory(backupLocalDir);
            foreach (string filePath in Directory.GetFiles(localisationDir))
            {
                if (filePath.Contains(languageTag))
                {
                    string destFilePath = Path.Combine(backupLocalDir, Path.GetFileName(filePath));
                    File.Copy(filePath, destFilePath);
                }
            }

            // Backup DLC's localisation folder
            string dlcDir = Path.Combine(gameDirPath, DLC_DIR_NAME);
            foreach (string dlcPath in Directory.GetDirectories(dlcDir))
            {
                foreach (string filePath in Directory.GetFiles(dlcPath))
                {
                    if (Path.GetExtension(filePath) == ".zip")
                    {
                        using (ZipArchive archive = ZipFile.OpenRead(filePath))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                string fullname = entry.FullName;
                                if (fullname.StartsWith(LOCALISATION_DIR_NAME) && fullname.Contains(languageTag))
                                {
                                    entry.ExtractToFile(Path.Combine(backupLocalDir, entry.Name));
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static bool DoDiff(string newOriginalPath, string newOriginalFormat, string oldOriginalPath, string oldOriginalFormat,
            string oldTranslationPath, string oldTranslationFormat, string outputPath, string outputFormat, string diffFilePath, string language)
        {
            SingleLanguageDB oldOriginal = new SingleLanguageDB(language);
            SingleLanguageDB newOriginal = new SingleLanguageDB(language);
            SingleLanguageDB oldTranslation = new SingleLanguageDB(language);

            Localization.BatchImportToSingleLanguageDB(newOriginal, newOriginalPath, newOriginalFormat);
            Localization.BatchImportToSingleLanguageDB(oldOriginal, oldOriginalPath, oldOriginalFormat);
            Localization.BatchImportToSingleLanguageDB(oldTranslation, oldTranslationPath, oldTranslationFormat);

            var diff = Localization.Compare(oldOriginal, newOriginal, false);
            YMLFile diffyml = new YMLFile();
            diffyml.AppendLine(null, -1, GetLanguageTag(language) + ":", null);
            foreach (var entry in diff)
            {
                string chitext = oldTranslation.LookupText(entry.Tag, entry.Version);
                diffyml.AppendLine(null, -1, "# new: " + entry.NewText, null);
                diffyml.AppendLine(null, -1, "# old: " + entry.OldText, null);

                if (chitext != null)
                {
                    diffyml.AppendLine(entry.Tag, entry.Version, chitext, null);
                }
                else
                {
                    var lastestText = oldTranslation.LookupLatestText(entry.Tag);
                    if (lastestText != null)
                        diffyml.AppendLine(entry.Tag, entry.Version, lastestText.Item2, null);
                    else
                        diffyml.AppendLine(entry.Tag, entry.Version, entry.NewText, null);
                }

                // Remove trnaslation, prepare for export
                if (chitext != null)
                    oldTranslation.Remove(entry.Tag, entry.Version);
            }

            diffyml.Write(diffFilePath);

            if (outputPath != null && outputFormat != null)
                return Localization.BatchExportLocalization(oldTranslation, newOriginalPath, newOriginalFormat, null, outputPath, outputFormat);

            return true;
        }

        public static bool DoMerge(string newOriginalPath, string newOriginalFormat, string oldOriginalPath, string oldOriginalFormat,
            string oldTranslationPath, string oldTranslationFormat, string inputPath, string inputFormat, string outputPath, string outputFormat,
            string diffFilePath, string language, bool checkSpecialChar, bool ignoreSame, string checkFilePath)
        {
            SingleLanguageDB input = new SingleLanguageDB(language);
            SingleLanguageDB newOriginal = new SingleLanguageDB(language);
            Localization.BatchImportToSingleLanguageDB(input, inputPath, inputFormat);
            Localization.BatchImportToSingleLanguageDB(newOriginal, newOriginalPath, newOriginalFormat);

            // optional
            SingleLanguageDB oldOriginal = null;
            SingleLanguageDB oldTranslation = null;
            if (oldOriginalPath != null && oldOriginalFormat != null)
            {
                oldOriginal = new SingleLanguageDB(language);
                Localization.BatchImportToSingleLanguageDB(oldOriginal, oldOriginalPath, oldOriginalFormat);
            }
            if (oldTranslationPath != null && oldTranslationFormat != null)
            {
                oldTranslation = new SingleLanguageDB(language);
                Localization.BatchImportToSingleLanguageDB(oldTranslation, oldTranslationPath, oldTranslationFormat);
            }

            Dictionary<string, string> RemovedDiffChi = new Dictionary<string, string>();
            Dictionary<string, string> RemovedDiffEng = new Dictionary<string, string>();
            // 1. Remove diff from old translation (but allow them if they are in new original)
            if (oldOriginal != null && oldTranslation != null)
            {
                var diff = Localization.Compare(oldOriginal, newOriginal, false);
                foreach (var entry in diff)
                {
                    string chitext = oldTranslation.LookupText(entry.Tag, entry.Version);
                    string newtext = newOriginal.LookupText(entry.Tag, entry.Version);
                    if (chitext != null && newtext == null)
                    {
                        RemovedDiffChi[entry.Tag] = chitext;
                        RemovedDiffEng[entry.Tag] = entry.OldText;
                        oldTranslation.Remove(entry.Tag, entry.Version);
                    }
                }

            }

            // 2. Merge in old translation to input 
            if (oldTranslation != null)
            {
                Localization.MergeIn(input, oldTranslation, LocalizationDB.ImportMode.kIgnore);
            }

            // 3. Find diff entires 
            YMLSafeFile diffyml = new YMLSafeFile();
            diffyml.AppendLine(null, -1, GetLanguageTag(language) + ":", null);
            var missing = Localization.GetMissingEntries(newOriginal, input, false);
            foreach (var entry in missing)
            {
                string chi = null;
                if (RemovedDiffChi.ContainsKey(entry.Tag))
                    chi = RemovedDiffChi[entry.Tag];
                string oldeng = null;
                if (RemovedDiffChi.ContainsKey(entry.Tag))
                    oldeng = RemovedDiffEng[entry.Tag];
                diffyml.AppendLine(null, -1, "# Missing. Original: " + entry.NewText, null);
                if (oldeng != null)
                    diffyml.AppendLine(null, -1, "#      old Original: " + oldeng, null);
                diffyml.AppendLine(entry.Tag, entry.Version, chi != null ? chi : entry.OldText, null);
            }
            diffyml.Write(diffFilePath);

            // 3. Checks
            if (checkSpecialChar)
            {
                // check missing entries first as we will remove entries failed the check as well.

                var check = Localization.CheckTranslation(newOriginal, input, ignoreSame);
                YMLSafeFile checkyml = new YMLSafeFile();
                checkyml.AppendLine(null, -1, GetLanguageTag(language) + ":", null);

                foreach (var entry in check)
                {
                    if (entry.NewText != null)
                    {
                        checkyml.AppendLine(null, -1, "# Check Fail, Original: " + entry.NewText, null);
                        checkyml.AppendLine(entry.Tag, entry.Version, entry.OldText, null);
                    }
                    // Remove trnaslation, prepare for export
                    input.Remove(entry.Tag, entry.Version);
                }
                checkyml.Write(checkFilePath);
            }

            // 4. Export the merged translation
            return Localization.BatchExportLocalization(input, newOriginalPath, newOriginalFormat, null, outputPath, outputFormat);
        }

        public static bool DoConvert(string inputPath, string inputFormat, string outputPath, string outputFormat, int splitLine)
        {
            return Localization.BatchExportLocalization(null, inputPath, inputFormat, null, outputPath, outputFormat, splitLine);
        }
    } 
}
