using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

// modes: 
// diff:    Compare [new-original] and [old-original], export different entires or entries missing in [old-original]
//          in a [diff-file]. If [output-path] is specified, export the translation organized in the same way as the 
//          [new-original] with entries in the diff file remaining un-translated.
// convert: Convert each input file in [input-path] to a new format. If [output-format] is not specified, [input-format] 
//          will be used for output. Split the file to multiple files each with at most [split-lines] if the option is set. 
//          Export to [output-path].
// split:   Same as convert. Except that the method will fail if [split-lines] is not set.
// merge:   Read files in [input-path] as translation, export the translation organized in the same way as the 
//          [new-original]. If [old-translation-path] is specified, the translation there will serve as fall backs. If 
//          [old-original-path] is specified together with [old-translation-path], an extra check will be performed so that only 
//          old translation entries with same old and new original will be used. 
//
// file formats:
// pml:         The paradox version of yml format used in latest games. Pml and all its variants use utf-8 with BOM.
// pml-safe:    The pml format with special characters converted to <> enclosed tokens.
// eu4pml:      The older pml format used in older games such as Eu4.
// eu4pml-sp:   The eu4pml format with gbk characters treated as latin1 characters when converting to utf-8.
// eu4pml-safe: The eu4pml format with special characters converted to <> enclosed tokens.
// csv:         The ; seperated csv file encoding in Latin1 (cp1252). 
// csv-gbk:     The csv format encoding in gbk. 
// csv-safe:    The csv format with special characters converted to <> enclosed tokens encoding in Latin1 (cp1252). 
// csv-safe-gbk:The csv-safe format encoding in gbk.
// 
// flags:
// --check-special-characters:  Can only work in [merge] mode for now! Perform checks on special characters in the coresponding entries
//                              in [new-original] and the translation to be exported. Discard the translation if check failed. 
//                              Record the results in a [check-file] if path is specified.
//


namespace ParadoxLocalisationAssistant
{
    class Program
    {
        static Dictionary<string, string> optionList = new Dictionary<string, string>()
        {
            { "-l", "log-path" }, { "--log-path", "log-path" },
            { "-i", "input-path" }, { "--input-path", "input-path" },
            { "--input-format", "input-format" },
            { "-o", "output-path" }, { "--output-path", "output-path" },
            { "--output-format", "output-format" },
            { "-N", "new-original-path" }, { "--new-original-path", "new-original-path" },
            { "--new-original-format", "new-original-format" },      
            { "-O", "old-original-path" }, { "--old-original-path", "old-original-path" },
            { "--old-original-format", "old-original-format" },
            { "-T", "old-translation-path" }, { "--old-translation-path", "old-translation-path" },
            { "--old-translation-format", "old-translation-format" },

            { "-d", "diff-file-path" }, { "--diff-file-path", "diff-file-path" },
            { "-s", "split-lines" }, { "--split-lines", "split-lines" },

            { "--check-file-path", "check-file-path" },
            { "--dump-options-path", "dump-options-path" }
        };

        static Dictionary<string, string> flagList = new Dictionary<string, string>()
        {
            { "-c", "check-special-characters" }, { "--check-special-characters", "check-special-characters" },
            { "--ignore-potential-untranslated", "ignore-potential-untranslated" },
        };

        static Dictionary<string, string> ParseArgs(string[] args)
        {
            Dictionary<string, string> options = new Dictionary<string, string>();

            if (args.Length == 2 && args[0] == "--config-file")
            {
                var lines = File.ReadLines(args[1], Encoding.GetEncoding(65001));
                string current = null;
                foreach (var line in lines)
                {
                    
                    if (current != null)
                    {
                        options[current] = line;
                        current = null;
                    }
                    else if (line.StartsWith("#"))
                    {
                        // ignore comment
                    }
                    else if (line.StartsWith("["))
                    {
                        current = line.Substring(1, line.Length - 2);
                    }
                    // else ignore
                }
                return options;
            }
            for (int i = 0; i < args.Length; ++i)
            {
                if (i == 0)
                {
                    options["mode"] = args[i];
                }
                else
                {
                    if (optionList.ContainsKey(args[i]) && i < args.Length - 1)
                    {
                        options[optionList[args[i]]] = args[i + 1];
                        ++i;
                    }
                    else if (flagList.ContainsKey(args[i]))
                    {
                        options[flagList[args[i]]] = "1";
                    }
                    else
                        throw new ArgumentException(args[i]);             
                }
            }
            if (options.ContainsKey("dump-options-path"))
            {
                try
                {
                    StringBuilder output = new StringBuilder();
                    foreach (var kv in options)
                    {
                        output.AppendFormat("[{0}]\r\n{1}\r\n\r\n", kv.Key, kv.Value);
                    }
                    File.WriteAllText(options["dump-options-path"], output.ToString(), Encoding.GetEncoding(65001));
                }
                catch (Exception)
                {
                }
            }
            return options;
        }

        static bool DoDiff(Dictionary<string, string> options)
        {
            string outputPath = null;
            string newOriginalPath = null;
            string oldOriginalPath = null;
            string oldTranslationPath = null;

            string outputFormat = null;
            string newOriginalFormat = null;
            string oldOriginalFormat = null;
            string oldTranslationFormat = null;

            string diffFilePath = null;
            string language = Properties.Settings.Default.Language;

            if (!options.TryGetValue("new-original-path", out newOriginalPath))
                throw new ArgumentException("Missing new-original-path.");
            if (!options.TryGetValue("new-original-format", out newOriginalFormat))
                throw new ArgumentException("Missing new-original-format.");

            if (!options.TryGetValue("old-original-path", out oldOriginalPath))
                throw new ArgumentException("Missing old-original-path.");
            if (!options.TryGetValue("old-original-format", out oldOriginalFormat))
                throw new ArgumentException("Missing old-original-format.");

            if (!options.TryGetValue("old-translation-path", out oldTranslationPath))
                throw new ArgumentException("Missing old-translation-path.");
            if (!options.TryGetValue("old-translation-format", out oldTranslationFormat))
                throw new ArgumentException("Missing old-translation-format.");

            options.TryGetValue("output-path", out outputPath);
            options.TryGetValue("output-format", out outputFormat);

            if (!options.TryGetValue("diff-file-path", out diffFilePath))
                throw new ArgumentException("Missing diff-file-path.");
            
            return Commands.DoDiff(newOriginalPath, newOriginalFormat, oldOriginalPath, oldOriginalFormat,
                oldTranslationPath, oldTranslationFormat, outputPath, outputFormat, diffFilePath, language);
        }
        
        static bool DoConvert(Dictionary<string, string> options)
        {
            // Split not implemented yet...
            string inputPath = null;
            string outputPath = null;

            string inputFormat = null;
            string outputFormat = null;

            int splitLine = 0;
            string strSplitLine = null;

            if (!options.TryGetValue("input-path", out inputPath))
                throw new ArgumentException("Missing input-path.");
            if (!options.TryGetValue("input-format", out inputFormat))
                throw new ArgumentException("Missing input-format.");

            if (!options.TryGetValue("output-path", out outputPath))
                throw new ArgumentException("Missing output-path.");
            if (!options.TryGetValue("output-format", out outputFormat))
                throw new ArgumentException("Missing output-format.");

            if (options.TryGetValue("split-lines", out strSplitLine))
            {
                splitLine = Convert.ToInt32(strSplitLine);
            };

            return Commands.DoConvert(inputPath, inputFormat, outputPath, outputFormat, splitLine);
        }

        static bool DoSplit(Dictionary<string, string> options)
        {
            if (!options.ContainsKey("split-lines"))
                throw new ArgumentException("split-lines is not set.");
            string inputFormat = null;
            if (!options.TryGetValue("input-format", out inputFormat))
                throw new ArgumentException("Missing input-format.");
            if (!options.ContainsKey("output-format"))
            {
                options["output-format"] = inputFormat;
            }
            return DoConvert(options);
        }

        static bool DoMerge(Dictionary<string, string> options)
        {
            string inputPath = null;
            string outputPath = null;
            string newOriginalPath = null;
            string oldOriginalPath = null;
            string oldTranslationPath = null;

            string inputFormat = null;
            string outputFormat = null;
            string newOriginalFormat = null;
            string oldOriginalFormat = null;
            string oldTranslationFormat = null;

            string diffFilePath = ".\\diff.yml";
            string language = Properties.Settings.Default.Language;

            if (!options.TryGetValue("input-path", out inputPath))
                throw new ArgumentException("Missing input-path.");
            if (!options.TryGetValue("input-format", out inputFormat))
                throw new ArgumentException("Missing input-format.");

            if (!options.TryGetValue("output-path", out outputPath))
                throw new ArgumentException("Missing output-path.");
            if (!options.TryGetValue("output-format", out outputFormat))
                throw new ArgumentException("Missing output-format.");

            if (!options.TryGetValue("new-original-path", out newOriginalPath))
                throw new ArgumentException("Missing new-original-path.");
            if (!options.TryGetValue("new-original-format", out newOriginalFormat))
                throw new ArgumentException("Missing new-original-format.");
        
            options.TryGetValue("old-original-path", out oldOriginalPath);
            options.TryGetValue("old-original-format", out oldOriginalFormat);

            options.TryGetValue("old-translation-path", out oldTranslationPath);
            options.TryGetValue("old-translation-format", out oldTranslationFormat);

            options.TryGetValue("diff-file-path", out diffFilePath);

            bool checkSpecialChar = options.ContainsKey("check-special-characters");
            bool ignoreSame = options.ContainsKey("ignore-potential-untranslated");
            string checkFilePath = ".\\check.yml";
            options.TryGetValue("check-file-path", out checkFilePath);

            return Commands.DoMerge(newOriginalPath, newOriginalFormat, oldOriginalPath, oldOriginalFormat,
                oldTranslationPath, oldTranslationFormat, inputPath, inputFormat, outputPath, outputFormat, 
                diffFilePath, language, checkSpecialChar, ignoreSame, checkFilePath);
        }

        static bool DoRefine(Dictionary<string, string> options)
        {
            string outputPath = null;
            string outputFormat = null;
            string oldOriginPath = null;
            string oldTranslationPath = null;
            string oldOriginFormat = null;
            string oldTranslationFormat = null;
            

            if (!options.TryGetValue("output-path", out outputPath))
                throw new ArgumentException("Missing output-path.");
            if (!options.TryGetValue("output-format", out outputFormat))
                throw new ArgumentException("Missing output-format.");

            if (!options.TryGetValue("old-original-path", out oldOriginPath))
                throw new ArgumentException("Missing old-original-path.");
            if (!options.TryGetValue("old-original-format", out oldOriginFormat))
                throw new ArgumentException("Missing old-original-format.");

            if (!options.TryGetValue("old-translation-path", out oldTranslationPath))
                throw new ArgumentException("Missing old-translation-path.");
            if (!options.TryGetValue("old-translation-format", out oldTranslationFormat))
                throw new ArgumentException("Missing old-translation-format.");


            // all dummy english for now..
            SingleLanguageDB oldEng = new SingleLanguageDB("english");
            SingleLanguageDB oldTranslate = new SingleLanguageDB("english");
            Localization.BatchImportToSingleLanguageDB(oldEng, oldOriginPath, oldOriginFormat);
            Localization.BatchImportToSingleLanguageDB(oldTranslate, oldTranslationPath, oldTranslationFormat);

            Dictionary<string,string> dict1 = new Dictionary<string, string>();
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            foreach (var kv in oldEng)
            {
                string tag = kv.Key;
                if ((tag.Length > 2 && tag[1] == '_') || tag.StartsWith("PROV"))
                    continue;

                string value = kv.Value.Last().Value;
                
                if (tag.ToLowerInvariant().Replace("_", "").Contains(value.ToLowerInvariant().Replace(" ", "")))
                {
                    dict1[tag] = value;
                }
                else
                {
                    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                    if (value == ti.ToTitleCase(value))
                        dict2[tag] = value;
                }
            }

            YMLSafeFile dict1file = new YMLSafeFile();
            YMLSafeFile dict2file = new YMLSafeFile();
            dict1file.AppendLine(null, -1, "l_english:", null);
            dict2file.AppendLine(null, -1, "l_english:", null);


            foreach (var entry in dict1)
            {
                dict1file.AppendLine(null, -1, "# Potential Term, origin: " + entry.Value, null);
                string trans = oldTranslate.LookupLatestText(entry.Key)?.Item2;
                dict1file.AppendLine(entry.Key, 0, trans != null? trans : entry.Value, null);
            }
            foreach (var entry in dict2)
            {
                dict2file.AppendLine(null, -1, "# Potential Term, origin: " + entry.Value, null);
                string trans = oldTranslate.LookupLatestText(entry.Key)?.Item2;
                dict2file.AppendLine(entry.Key, 0, trans != null ? trans : entry.Value, null);
            }
            dict1file.Write(outputPath + "\\dict1." + dict1file.DefaultExtension());
            dict2file.Write(outputPath + "\\dict2." + dict1file.DefaultExtension());
            return true;
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // Window Mode
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                return;
            }

            // Console Mode
            try
            {
                Dictionary<string, string> options = ParseArgs(args);

                using (LogWriter logWriter = new LogWriter())
                {
                    if (options.ContainsKey("log-path"))
                    {
                        logWriter.AddWriter(File.CreateText(options["log-path"]));
                    }
                    logWriter.AddWriter(Console.Out);
                    Console.SetOut(logWriter);
                }

                string mode = null;
                if (!options.TryGetValue("mode", out mode))
                    throw new ArgumentException("No mode is set.");

                switch (mode)
                {
                    case "diff": DoDiff(options); break;
                    case "convert": DoConvert(options); break;
                    case "split": DoConvert(options); break;
                    case "merge": DoMerge(options); break;
                    case "refine": DoRefine(options); break;
                    default: throw new ArgumentException(string.Format("Invalid mode: {0}.", mode));
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
