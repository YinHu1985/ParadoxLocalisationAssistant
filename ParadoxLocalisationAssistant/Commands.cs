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
                string chitext = oldTranslation.LookupText(entry.Item1, entry.Item2);
                diffyml.AppendLine(null, -1, "# new: " + entry.Item3, null);
                diffyml.AppendLine(null, -1, "# old: " + entry.Item4, null);

                if (chitext != null)
                    diffyml.AppendLine(entry.Item1, entry.Item2, chitext, null);
                else
                    diffyml.AppendLine(entry.Item1, entry.Item2, entry.Item3, null);

                // Remove trnaslation, prepare for export
                if (chitext != null)
                    oldTranslation.Remove(entry.Item1, entry.Item2);
            }

            diffyml.Write(diffFilePath);

            if (outputPath != null && outputFormat != null)
                return Localization.BatchExportLocalization(oldTranslation, newOriginalPath, newOriginalFormat, null, outputPath, outputFormat);

            return true;
        }
    }
}
