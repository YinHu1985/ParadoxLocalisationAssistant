using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        };

        static Dictionary<string, string> flagList = new Dictionary<string, string>()
        {
            { "-c", "check-special-characters" }, { "--check-special-characters", "check-special-characters" },          
        };

        static Dictionary<string, string> ParseArgs(string[] args)
        {
            Dictionary<string, string> options = new Dictionary<string, string>();

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

            return options;
        }

        static bool DoDiff(Dictionary<string, string> options)
        {
            string outputPath = null;
            string newOriginPath = null;
            string oldOriginPath = null;
            string oldTranslationPath = null;

            string outputFormat = null;
            string newOriginFormat = null;
            string oldOriginFormat = null;
            string oldTranslationFormat = null;

            string diffPath = null;

            if (!options.TryGetValue("new-original-path", out newOriginPath))
                throw new ArgumentException("Missing new-original-path.");
            if (!options.TryGetValue("new-original-format", out newOriginFormat))
                throw new ArgumentException("Missing new-original-format.");

            if (!options.TryGetValue("old-original-path", out oldOriginPath))
                throw new ArgumentException("Missing old-original-path.");
            if (!options.TryGetValue("old-original-format", out oldOriginFormat))
                throw new ArgumentException("Missing old-original-format.");

            if (!options.TryGetValue("old-translation-path", out oldTranslationPath))
                throw new ArgumentException("Missing old-translation-path.");
            if (!options.TryGetValue("old-translation-format", out oldTranslationFormat))
                throw new ArgumentException("Missing old-translation-format.");

            options.TryGetValue("output-path", out outputPath);
            options.TryGetValue("output-format", out outputFormat);

            if (!options.TryGetValue("diff-file-path", out diffPath))
                throw new ArgumentException("Missing diff-file-path.");

            // all dummy english for now..
            SingleLanguageDB oldOrigin = new SingleLanguageDB("english");
            SingleLanguageDB newOrigin = new SingleLanguageDB("english");
            SingleLanguageDB oldTranslation = new SingleLanguageDB("english");

            Localization.BatchImportToSingleLanguageDB(newOrigin, newOriginPath, newOriginFormat);
            Localization.BatchImportToSingleLanguageDB(oldOrigin, oldOriginPath, oldOriginFormat);  
            Localization.BatchImportToSingleLanguageDB(oldTranslation, oldTranslationPath, oldTranslationFormat);


            var diff = Localization.Compare(oldOrigin, newOrigin, false);
            YMLFile diffyml = new YMLFile();
            diffyml.AppendLine(null, -1, "l_english:", null);
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

            diffyml.Write(diffPath);

            if (outputPath != null && outputFormat != null)
                return Localization.BatchExportLocalization(oldTranslation, newOriginPath, newOriginFormat, null, outputPath, outputFormat);
            return true;
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

            return Localization.BatchExportLocalization(null, inputPath, inputFormat, null, outputPath, outputFormat, splitLine);
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
            string newOriginPath = null;
            string oldOriginPath = null;
            string oldTranslationPath = null;

            string inputFormat = null;
            string outputFormat = null;
            string newOriginFormat = null;
            string oldOriginFormat = null;
            string oldTranslationFormat = null; 

            if (!options.TryGetValue("input-path", out inputPath))
                throw new ArgumentException("Missing input-path.");
            if (!options.TryGetValue("input-format", out inputFormat))
                throw new ArgumentException("Missing input-format.");

            if (!options.TryGetValue("output-path", out outputPath))
                throw new ArgumentException("Missing output-path.");
            if (!options.TryGetValue("output-format", out outputFormat))
                throw new ArgumentException("Missing output-format.");

            if (!options.TryGetValue("new-original-path", out newOriginPath))
                throw new ArgumentException("Missing new-original-path.");
            if (!options.TryGetValue("new-original-format", out newOriginFormat))
                throw new ArgumentException("Missing new-original-format.");
        
            options.TryGetValue("old-original-path", out oldOriginPath);
            options.TryGetValue("old-original-format", out oldOriginFormat);

            options.TryGetValue("old-translation-path", out oldTranslationPath);
            options.TryGetValue("old-translation-format", out oldTranslationFormat);

            // all dummy english for now..
            SingleLanguageDB input = new SingleLanguageDB("english");
            SingleLanguageDB newOrigin = new SingleLanguageDB("english");
            Localization.BatchImportToSingleLanguageDB(input, inputPath, inputFormat);
            Localization.BatchImportToSingleLanguageDB(newOrigin, newOriginPath, newOriginFormat);


            // optional
            SingleLanguageDB oldOrigin = null;
            SingleLanguageDB oldTranslation = null;
            if (oldOriginPath != null && oldOriginFormat != null)
            {
                oldOrigin = new SingleLanguageDB("english");
                Localization.BatchImportToSingleLanguageDB(oldOrigin, oldOriginPath, oldOriginFormat);
            }
            if (oldTranslationPath != null && oldTranslationFormat != null)
            {
                oldTranslation = new SingleLanguageDB("english");
                Localization.BatchImportToSingleLanguageDB(oldTranslation, oldTranslationPath, oldTranslationFormat);
            }

            // 1. Merge in old translation
            if (oldTranslation != null)
            {
                Localization.MergeIn(input, oldTranslation, LocalizationDB.ImportMode.kIgnore);
            }

            // 2. Remove diff
            if (oldOrigin != null)
            {
                var diff = Localization.Compare(oldOrigin, newOrigin, false);
                foreach (var entry in diff)
                {
                    string chitext = input.LookupText(entry.Item1, entry.Item2);
                    if (chitext != null)
                        input.Remove(entry.Item1, entry.Item2);
                }
            }

            // 3. Checks
            if (options.ContainsKey("check-special-characters"))
            {
                // check missing entries first as we will remove entries failed the check as well.
                var missing = Localization.GetMissingEntries(newOrigin, input, false);
                var check = Localization.CheckTranslation(newOrigin, input);
                YMLSafeFile checkyml = new YMLSafeFile();
                checkyml.AppendLine(null, -1, "l_english:", null);
                foreach (var entry in check)
                {
                    if (entry.Item3 != null)
                    {
                        checkyml.AppendLine(null, -1, "# Check Fail, origin: " + entry.Item3, null);
                        checkyml.AppendLine(entry.Item1, entry.Item2, entry.Item4, null);
                    }
                    // Remove trnaslation, prepare for export
                    input.Remove(entry.Item1, entry.Item2);
                }
               
                foreach (var entry in missing)
                {
                    checkyml.AppendLine(null, -1, "# Missing. origin: " + entry.Item3, null);
                    checkyml.AppendLine(entry.Item1, entry.Item2, entry.Item4, null);
                }

                string checkPath = null;
                if (options.TryGetValue("check-file-path", out checkPath))
                    checkyml.Write(checkPath);
            }

            // 4. Export the merged translation
            return Localization.BatchExportLocalization(input, newOriginPath, newOriginFormat, null, outputPath, outputFormat);
        }

        static void Main(string[] args)
        {
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
