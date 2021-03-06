﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ParadoxLocalisationAssistant
{
    public static class Localization
    {
        public class DiffResultEntry
        {
            public string Tag { get; set; }
            public int Version { get; set; }
            public string NewText { get; set; }
            public string OldText { get; set; }

            public DiffResultEntry(string tag, int version, string newText, string oldText)
            {
                Tag = tag;
                Version = version;
                NewText = newText;
                OldText = oldText;
            }
        }

        static public int BatchImportToSingleLanguageDB(SingleLanguageDB db, string path, string fileFormatString,
            string overridePattern = null, LocalizationDB.ImportMode mode = LocalizationDB.ImportMode.kReplace)
        {
            return BatchImportToSingleLanguageDB(db, path, LocalizationFileFormat.GetFileFormat(fileFormatString), overridePattern, mode);
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
        static public int BatchImportToSingleLanguageDB(SingleLanguageDB db, string path, LocalizationFileFormat fileFormat,
            string overridePattern = null, LocalizationDB.ImportMode mode = LocalizationDB.ImportMode.kReplace)
        {
            if (!Directory.Exists(path))
                return 0;

            string pattern = overridePattern != null ? overridePattern : fileFormat.GetLocalizationFileInstance().DefaultNamePattern();
            int totalCount = 0;
            foreach (var filename in Directory.EnumerateFiles(path, pattern))
            {
                ILocalizationFile file = fileFormat.GetLocalizationFileInstance();
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

        static public bool BatchExportLocalization(SingleLanguageDB db,
            string refPath, string refFileFormatString, string overrideRefPattern,
            string outPath, string outFileFormatString, int splitLine = 0)
        {
            return BatchExportLocalization(db, refPath, LocalizationFileFormat.GetFileFormat(refFileFormatString),
                overrideRefPattern, outPath, LocalizationFileFormat.GetFileFormat(outFileFormatString), splitLine);
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
        /// <param name="splitLine"></param>
        /// <returns></returns>
        static public bool BatchExportLocalization(SingleLanguageDB db,
            string refPath, LocalizationFileFormat refFileFormat, string overrideRefPattern,
            string outPath, LocalizationFileFormat outFileFormat, int splitLine = 0)
        {
            if (!Directory.Exists(refPath))
                return false;

            string refpattern = overrideRefPattern != null ? overrideRefPattern : refFileFormat.GetLocalizationFileInstance().DefaultNamePattern();
            foreach (var filename in Directory.EnumerateFiles(refPath, refpattern))
            {
                ILocalizationFile reffile = refFileFormat.GetLocalizationFileInstance();
                reffile.Read(filename);

                ILocalizationFile outfile = outFileFormat.GetLocalizationFileInstance();
                if (!outfile.CanWrite())
                    continue;
                if (!ExportLocalization(db, reffile, outfile))
                    continue;
                string newName = Path.GetFileNameWithoutExtension(filename);
                Directory.CreateDirectory(outPath);
                if (splitLine <= 0)
                {       
                    outfile.Write(outPath + "\\" + newName + "." + outfile.DefaultExtension());
                }
                else
                {
                    int count = outfile.CountLines();
                    if (count > 0)
                    {
                        ILocalizationFile splitFile = outFileFormat.GetLocalizationFileInstance();
                        splitFile.GenHeader("english");
                        int contentCount = 0;
                        int fileCount = 1;
                        for (int i = outfile.HeaderLines(); i < count; ++i)
                        {
                            if (contentCount >= splitLine)
                            {
                                splitFile.Write(outPath + "\\" + newName + "-" + fileCount.ToString() + "." + splitFile.DefaultExtension());
                                fileCount++;
                                contentCount = 0;
                                if (i != count -1)
                                {
                                    splitFile = outFileFormat.GetLocalizationFileInstance();
                                    splitFile.GenHeader("english");
                                }
                            }
                            if (outfile.IsLineLocalizationData(i))
                            {
                                string tag = "";
                                int ver = 0;
                                string data = "";
                                string rest = "";
                                outfile.GetData(i, ref tag, ref ver, ref data, ref rest);
                                splitFile.AppendLine(tag, ver, data, rest);
                                contentCount++;
                            }
                            else
                            {
                                string data = "";
                                outfile.GetNonLocalizationData(i, ref data);
                                splitFile.AppendLine(null, 0, data, null);
                            }
                        }
                        splitFile.Write(outPath + "\\" + newName + "-" + fileCount.ToString() + "." + splitFile.DefaultExtension());
                    }
                }
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
        static public List<DiffResultEntry> GetMissingEntries(SingleLanguageDB src, SingleLanguageDB target, bool onlyLatest)
        {
            List<DiffResultEntry> result = new List<DiffResultEntry>();
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
                        result.Add(new DiffResultEntry(tag, ver, refText, text));
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
                            result.Add(new DiffResultEntry(tag, ver, refText, text));
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
        static public List<DiffResultEntry> Compare(SingleLanguageDB oldDb, SingleLanguageDB newDb, bool lowercase = false)
        {
            List<DiffResultEntry> result = new List<DiffResultEntry>();
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
                        result.Add(new DiffResultEntry(tag, ver, refText, text));
                    }
                    else
                    {
                        // check if string are same
                        if (lowercase)
                        {
                            if (refText.ToLower() != text.ToLower())
                            {
                                result.Add(new DiffResultEntry(tag, ver, refText, text));
                            }
                        }
                        else
                        {
                            if (refText != text)
                            {
                                result.Add(new DiffResultEntry(tag, ver, refText, text));
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Merge input into target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="input"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        static public int MergeIn(SingleLanguageDB target, SingleLanguageDB input, LocalizationDB.ImportMode mode = LocalizationDB.ImportMode.kReplace)
        {
            int count = 0;
            foreach (var entry in input)
            {
                foreach (var kv in entry.Value)
                {
                    if (target.Import(entry.Key, kv.Key, kv.Value, mode))
                        ++count;
                }

            }
            return count;
        }

        static bool IsCJK(string input)
        {
            var Regex = new Regex(@"\p{IsCJKUnifiedIdeographs}");

            if (Regex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string ScanExtraSpace(string input)
        {
            var Regex = new Regex(@"(\p{IsCJKUnifiedIdeographs}) +(§[^!]\p{IsCJKUnifiedIdeographs})");
            string replacement = "$1$2";
            string result = Regex.Replace(input, replacement);
            Regex = new Regex(@"(\p{IsCJKUnifiedIdeographs}§!) +(\p{IsCJKUnifiedIdeographs})");
            replacement = "$1$2";
            result = Regex.Replace(result, replacement);
            return result;
        }

        static void ScanSpecialToken(string str, out Dictionary<string, int> dollar, out Dictionary<string, int> bracket,
            out Dictionary<string, int> color, out Dictionary<string, int> pic, out int currency, out Dictionary<string, int> escape)
        {
            dollar = new Dictionary<string, int>();
            bracket = new Dictionary<string, int>();
            color = new Dictionary<string, int>();
            pic = new Dictionary<string, int>();
            currency = 0;
            escape = new Dictionary<string, int>();
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == '$')
                {
                    string token = "";
                    while (++i < str.Length)
                    {

                        if (str[i] != '$')
                            token += str[i];
                        else
                            break;
                    }
                    if (token == "")
                        token = "EOL";
                    if (dollar.ContainsKey(token))
                        dollar[token]++;
                    else
                        dollar[token] = 1;
                    continue;
                }
                else if (str[i] == '[')
                {
                    string token = "";
                    while (++i < str.Length)
                    {
                        if (str[i] != ']')
                            token += str[i];
                        else
                            break;
                    }
                    if (token == "")
                        token = "EOL";
                    if (bracket.ContainsKey(token))
                        bracket[token]++;
                    else
                        bracket[token] = 1;
                    continue;
                }
                else if (str[i] == '§')
                {
                    string token = "";
                    if (++i < str.Length)
                    {
                        token += str[i];
                    }
                    else
                    {
                        token = "EOL"; // just in case...
                    }
                    if (color.ContainsKey(token))
                        color[token]++;
                    else
                        color[token] = 1;
                    continue;
                }
                else if (str[i] == '£')
                {
                    string token = "";
                    while (++i < str.Length)
                    {
                        if (str[i] != ' ' && str[i] != '|' && str[i] != '£')
                            token += str[i];
                        else
                            break;
                    }
                    if (token == "")
                        token = "EOL";
                    if (pic.ContainsKey(token))
                        pic[token]++;
                    else
                        pic[token] = 1;
                    continue;
                }
                else if (str[i] == '¤')
                {
                    currency++;
                }
                else if (str[i] == '\\')
                {
                    string token;
                    if (++i < str.Length)
                        token = str[i].ToString();
                    else
                        token = "EOL";
                    if (escape.ContainsKey(token))
                        escape[token]++;
                    else
                        escape[token] = 1;
                    continue;
                }
            }
        }

        static bool CompareDic(Dictionary<string, int> left, Dictionary<string, int> right)
        {
            if (left == null || right == null)
                return false;
            if (left.Count != right.Count)
                return false;
            foreach (var kv in left)
            {
                if (!right.ContainsKey(kv.Key))
                    return false;
                if (kv.Value != right[kv.Key])
                    return false;
            }
            return true;
        }

        static bool SameSpecialCharacters(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;
            Dictionary<string, int> dollar1, dollar2;
            Dictionary<string, int> color1, color2;
            Dictionary<string, int> bracket1, bracket2;
            Dictionary<string, int> pic1, pic2;
            int currency1, currency2;
            Dictionary<string, int> escape1, escape2;

            ScanSpecialToken(str1, out dollar1, out bracket1, out color1, out pic1, out currency1, out escape1);
            ScanSpecialToken(str2, out dollar2, out bracket2, out color2, out pic2, out currency2, out escape2);

            if (!CompareDic(dollar1, dollar2) || !CompareDic(bracket1, bracket2) || !CompareDic(color1, color2) 
                || !CompareDic(pic1, pic2) || currency1 != currency2 || !CompareDic(escape1, escape2))
                return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="translation"></param>
        /// <param name="removeRedundant"></param>
        /// <returns></returns>
        static public List<DiffResultEntry> CheckTranslation(SingleLanguageDB original, SingleLanguageDB translation, bool ignoreSame)
        {
            List<DiffResultEntry> check = new List<DiffResultEntry>();
            foreach (var entry in translation)
            {
                foreach (var kv in entry.Value)
                {
                    string engText = original.LookupText(entry.Key, kv.Key);
                    if (engText == null || engText == kv.Value)
                    {
                        if (ignoreSame && engText == kv.Value)
                            continue;
                        check.Add(new DiffResultEntry(entry.Key, kv.Key, engText, kv.Value));
                    }
                    else if (!SameSpecialCharacters(engText, kv.Value))
                    {
                        check.Add(new DiffResultEntry(entry.Key, kv.Key, engText, kv.Value));
                    }
                }

            }
            return check;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        static public void ScanExtraSpace(SingleLanguageDB translation)
        {
            List<Tuple<string, int, string>> toModify = new List<Tuple<string, int, string>>();
            foreach (var entry in translation)
            {
                foreach (var key in entry.Value.Keys)
                {
                    string newstr = ScanExtraSpace(entry.Value[key]);
                    if (newstr != entry.Value[key])
                        toModify.Add(new Tuple<string, int, string>(entry.Key, key, newstr));
                }
            }

            foreach (var it in toModify)
                translation.Import(it.Item1, it.Item2, it.Item3, LocalizationDB.ImportMode.kReplace);
        }


        static public string UnicodeToDummyLatin1(string input, int encoding)
        {
            if (encoding == 1252)
                return input;

            // TODO: do not go througth safe string...
            return ToUnsafeString(Encoding.GetEncoding(1252).GetString(Encoding.GetEncoding(encoding).GetBytes(ToSafeString(input))));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        static public string DummyLatin1ToUnicode(string input, int encoding)
        {
            if (encoding == 1252)
                return input;
            string result = "";

            var bytes = Encoding.GetEncoding(1252).GetBytes(input);

            for (int i = 0; i < bytes.Length; ++i)
            {
                if (bytes[i] == 0xa3)
                {
                    // Assuming the file is valid, characters followed by a3 should all be Latin1 characters.
                    // So it's fine to do this.
                    if (i == bytes.Length - 1)
                    {
                        result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                    }
                    else
                    {
                        // byte is unsinged ...
                        if (bytes[i + 1] < 128)
                        {
                            result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                        }
                        else
                        {
                            // Treat as normal character
                            string resultChar = null;
                            try
                            {
                                resultChar = Encoding.GetEncoding(encoding).GetString(bytes, i, 2);
                            }
                            catch (Exception) { }
                            if (resultChar != null)
                            {
                                result += resultChar;
                                ++i;
                            }
                            else
                            {
                                result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                            }
                        }
                    }
                }
                else if (bytes[i] == 0xa4)
                {
                    result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                }
                else if (bytes[i] == 0xa7)
                {
                    // Always assume a7 is not part of chinese character
                    result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                }
                else
                {
                    if (i == bytes.Length - 1)
                    {
                        result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                    }
                    else
                    {
                        string resultChar = null;
                        try
                        {
                            resultChar = Encoding.GetEncoding(encoding).GetString(bytes, i, 2);
                        }
                        catch (Exception) { }
                        if (resultChar != null)
                        {
                            if (resultChar.Length == 1)
                            {
                                result += resultChar;
                                ++i;
                            }
                            else
                            {
                                result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                            }
                        }
                        else
                        {
                            result += Encoding.GetEncoding(1252).GetString(bytes, i, 1);
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Convert unsafe UNICODE string to safe ones.
        /// </summary>
        /// <param name="input">UNICODE string to convert.</param>
        /// <returns></returns>
        static public string ToSafeString(string input)
        {
            StringBuilder safeString = new StringBuilder("");
            if (input == null)
                return "";
            for (int i = 0; i < input.Count(); ++i)
            {
                if (input[i] == '£')
                {
                    safeString.Append("<A3-");
                    while (++i < input.Count() && input[i] != ' ' && input[i] != '£')
                    {
                        if (input[i] == 0)
                            break;
                        safeString.Append(input[i]);
                    }
                    if (i < input.Count() && input[i] == '£')
                        safeString.Append("-A3");
                    safeString.Append(">");
                    continue;
                }
                if (input[i] == '¤')
                {
                    safeString.Append("<A4>");
                    continue;
                }
                if (input[i] == '§')
                {
                    if (i + 1 < input.Count())
                    {
                        safeString.Append("<A7-");
                        safeString.Append(input[i + 1]);
                        safeString.Append(">");
                        ++i;
                    }
                    else
                    {
                        safeString.Append("<A7>");
                    }
                    continue;
                }
                safeString.Append(input[i]);
            }


            var Regex = new Regex("\\$([^\\$]+)\\$");
            string replacement = "<VAR-$1>";

            return Regex.Replace(safeString.ToString(), replacement);

        }


        /// <summary>
        /// Convert safe UNICODE string to unsafe ones.
        /// </summary>
        /// <param name="input">UNICODE string to convert.</param>
        /// <returns></returns>
        static public string ToUnsafeString(string input)
        {
            StringBuilder unsafeString = new StringBuilder("");

            for (int i = 0; i < input.Count(); ++i)
            {
                if (input[i] == '<' && i + 3 < input.Count() && input[i + 1] == 'A' && input[i + 2] == '3' && input[i + 3] == '-')
                {
                    StringBuilder buf = new StringBuilder("£");
                    int j = 4;
                    bool ended = false;
                    while (input[i + j] != '>')
                    {
                        if (input[i + j] == 0)
                            break;
                        if (input[i + j] == '-' && i + j + 3 < input.Count())
                        {
                            if (input[i + j + 1] == 'A' && input[i + j + 2] == '3' && input[i + j + 3] == '>')
                            {
                                buf.Append("£");
                                ended = true;
                                j += 3;
                                break;
                            }
                        }
                        buf.Append(input[i + j]);
                        ++j;
                    }
                    if (input[i + j] == '>' && !ended)
                    {
                        buf.Append(' ');
                        unsafeString.Append(buf.ToString());
                        i += j;
                        continue;
                    }
                }
                else if (input[i] == '<' && i + 3 < input.Count() && input[i + 1] == 'A' && input[i + 2] == '4')
                {
                    if (input[i + 3] == '>')
                    {
                        unsafeString.Append('¤');
                        i += 3;
                        continue;
                    }
                }
                else if (input[i] == '<' && i + 5 < input.Count() && input[i + 1] == 'A' && input[i + 2] == '7')
                {
                    if (input[i + 3] == '>')
                    {
                        unsafeString.Append('§');
                        i += 3;
                        continue;
                    }
                    else if (input[i + 3] == '-' && input[i + 4] != 0 && input[i + 5] == '>')
                    {
                        unsafeString.Append('§');
                        unsafeString.Append(input[i + 4]);
                        i += 5;
                        continue;
                    }
                }
                unsafeString.Append(input[i]);

            }

            var Regex = new Regex("<VAR-([^>]+)>");
            string replacement = "$$$1$$";
            return Regex.Replace(unsafeString.ToString(), replacement);
        }


        static public string EscapeQuote(string input)
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < input.Count(); ++i)
            {
                if (input[i] == '\"')
                {
                    result.Append("\\\"");
                }
                else if (input[i] == '\\')
                {
                    result.Append("\\\\");
                }
                else
                {
                    result.Append(input[i]);
                }
            }
            return result.ToString();
        }

        static public string UnescapeQuote(string input)
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < input.Count(); ++i)
            {
                if (input[i] == '\\' && i != input.Count() - 1)
                {
                    if (input[i + 1] == '\\')
                    {
                        result.Append("\\");
                        ++i;
                    }
                    else if (input[i + 1] == '\"')
                    {
                        result.Append("\"");
                        ++i;
                    }
                    else
                    {
                        result.Append(input[i]);
                    }
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }
    }
}