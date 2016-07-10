using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParadoxLocalisationKit
{
    public static class Localization
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        static ILocalizationFile GetLocalizationFileInstance(string fileFormat)
        {
            switch (fileFormat)
            {
                case "pml": return new YMLFile();
                case "csv": return new CSVFile();
                case "csv-gbk": return new CSVGBKFile();
                case "pml-safe":    
                case "eu4pml":
                case "eu4pml-sp":   
                case "eu4pml-safe":                              
                case "csv-safe":    
                case "csv-safe-gbk":
                default: return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        static bool IsFileFormatSupported(string fileFormat)
        {
            switch (fileFormat)
            {
                case "pml": 
                case "csv": 
                case "csv-gbk": return true;
                case "pml-safe":
                case "eu4pml":
                case "eu4pml-sp":
                case "eu4pml-safe":
                case "csv-safe":
                case "csv-safe-gbk":
                default: return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="path"></param>
        /// <param name="fileFormat"></param>
        /// <param name="overridePattern"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        static public int BatchImportToSingleLanguageDB(SingleLanguageDB db, string path, string fileFormat, 
            string overridePattern = null, LocalizationDB.ImportMode mode = LocalizationDB.ImportMode.kReplace)
        {
            if (!Directory.Exists(path))
                return 0;

            string pattern = overridePattern != null ? overridePattern: GetLocalizationFileInstance(fileFormat).DefaultNamePattern();
            int totalCount = 0;
            foreach (var filename in Directory.EnumerateFiles(path, pattern))
            {
                ILocalizationFile file = GetLocalizationFileInstance(fileFormat);
                file.Read(filename);
                totalCount += ImportToSingleLanguageDBFromFile(db, file, mode);
            }
            return totalCount;
        }   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        static public int ImportToSingleLanguageDBFromFile(SingleLanguageDB db, ILocalizationFile input, 
            LocalizationDB.ImportMode mode = LocalizationDB.ImportMode.kReplace)
        {
            // for now, all input file will be marked as english...
            if (!input.VerifyHeader("english"))
                return 0;
            int importCount = 0;
            int count = input.CountLines();
            if (count > 0)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (input.IsLineLocalizationData(i))
                    {
                        string tag = "";
                        int ver = 0;
                        string data = "";
                        string rest = "";
                        input.GetData(i, ref tag, ref ver, ref data, ref rest);
                        if (db.Import(tag, ver, data, mode))
                            ++importCount;
                    }
                }
            }
            return importCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="reference"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        static public bool ExportLocalization(SingleLanguageDB db, ILocalizationFile reference, ILocalizationFile output)
        {
            // for now, all input file will be marked as english...  
            if (!reference.VerifyHeader("english"))
                return false;
            output.GenHeader("english");

            int count = reference.CountLines();
            if (count > 0)
            {
                for (int i = reference.HeaderLines(); i < count; ++i)
                {
                    if (reference.IsLineLocalizationData(i))
                    {
                        string tag = "";
                        int ver = 0;
                        string data = "";
                        string rest = "";
                        reference.GetData(i, ref tag, ref ver, ref data, ref rest);
                        if (db != null)
                        {
                            string localizeddata = db.LookupText(tag, ver);
                            if (localizeddata != null)
                            {
                                output.AppendLine(tag, ver, localizeddata, rest);
                                continue;
                            }
                        }
                        output.AppendLine(tag, ver, data, rest);
                    }
                    else
                    {
                        string data = "";
                        reference.GetNonLocalizationData(i, ref data);
                        output.AppendLine(null, 0, data, null);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="refPath"></param>
        /// <param name="refFileFormat"></param>
        /// <param name="overrideRefPattern"></param>
        /// <param name="outPath"></param>
        /// <param name="outFileFormat"></param>
        /// <returns></returns>
        static public bool BatchExportLocalization(SingleLanguageDB db, 
            string refPath, string refFileFormat, string overrideRefPattern,
            string outPath, string outFileFormat)
        {
            if (!Directory.Exists(refPath) )
                return false;

            string refpattern = overrideRefPattern != null ? overrideRefPattern : GetLocalizationFileInstance(refFileFormat).DefaultNamePattern();
            foreach (var filename in Directory.EnumerateFiles(refPath, refpattern))
            {
                ILocalizationFile reffile = GetLocalizationFileInstance(refFileFormat);
                reffile.Read(filename);

                ILocalizationFile outfile = GetLocalizationFileInstance(outFileFormat);
                if (!outfile.CanWrite())
                    return false;
                if (!ExportLocalization(db, reffile, outfile))
                    return false;

                string newName = Path.GetFileNameWithoutExtension(filename);
                Directory.CreateDirectory(outPath);
                outfile.Write(outPath + "\\" + newName + "." + outfile.DefaultExtension());              
            }
            return true;
        }

        /// <summary>
        /// Find missing entries in target that are in src.
        /// Can be used to detect missing translation.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="target"></param>
        /// <returns>tag, ver, missing text, potential text</returns>
        static public List<Tuple<string, int, string, string>> GetMissingEntries(SingleLanguageDB src, SingleLanguageDB target, bool onlyLatest)
        {
            List<Tuple<string, int, string, string>> result = new List<Tuple<string, int, string, string>>();
            foreach (var entry in src)
            {
                string tag = entry.Key;
                if (onlyLatest)
                {
                    int ver = entry.Value.Last().Key;
                    string text = target.LookupText(tag, ver);

                    if (text == null)
                    {
                        string refText = entry.Value.Last().Value;
                        var potential = target.LookupLatestText(tag);
                        if (potential != null)
                            text = potential.Item2;
                        result.Add(new Tuple<string, int, string, string>(tag, ver, refText, text));
                    }
                }
                else
                {
                    foreach (var kv in entry.Value)
                    {
                        int ver = kv.Key;
                        string text = target.LookupText(tag, ver);
                        if (text == null)
                        {
                            string refText = entry.Value.Last().Value;
                            var potential = target.LookupLatestText(tag);
                            if (potential != null)
                                text = potential.Item2;
                            result.Add(new Tuple<string, int, string, string>(tag, ver, refText, text));
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check if newdb has anything new, will ignore extra entries in old db.
        /// Can be used to detect difference between versions.
        /// </summary>
        /// <param name="oldDb"></param>
        /// <param name="newDb"></param>
        /// <returns>tag, ver, new string, old text</returns>
        static public List<Tuple<string, int, string, string>> Compare(SingleLanguageDB oldDb, SingleLanguageDB newDb, bool lowercase = false)
        {
            List<Tuple<string, int, string, string>> result = new List<Tuple<string, int, string, string>>();
            foreach (var entry in newDb)
            {
                string tag = entry.Key;
                foreach (var kv in entry.Value)
                {
                    int ver = kv.Key;
                    string refText = kv.Value;
                    string text = oldDb.LookupText(tag, ver);
                    if (text == null)
                    {
                        var potential = oldDb.LookupLatestText(tag);
                        if (potential != null)
                            text = potential.Item2;
                        result.Add(new Tuple<string, int, string, string>(tag, ver, refText, text));
                    }
                    else
                    {
                        // check if string are same
                        if (lowercase)
                        {
                            if (refText.ToLower() != text.ToLower())
                            {
                                result.Add(new Tuple<string, int, string, string>(tag, ver, refText, text));
                            }
                        }
                        else
                        {
                            if (refText != text)
                            {
                                result.Add(new Tuple<string, int, string, string>(tag, ver, refText, text));
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}