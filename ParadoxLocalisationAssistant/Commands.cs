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

        static bool DoBackup(string gameDirPath, string backupDirPath, string backupForBackupPath, string language)
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
            string backupLocalDir = Path.Combine(backupDirPath, LOCALISATION_DIR_NAME);
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
    }
}
