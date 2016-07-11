using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ParadoxLocalisationAssistant
{
    class YMLLine
    {
        public string tag;
        public string data;
        public int ver;
        public string rest;
    }

    public class YMLEu4SafeFile : YMLFileBase, ILocalizationFile
    {
        protected override string ProcessInput(string input)
        {
            return Localization.ToUnsafeString(Localization.UnescapeQuote(input));
        }

        protected override string ProcessOutput(string output)
        {
            return Localization.ToSafeString(Localization.EscapeQuote(output));
        }
    }

    public class YMLEu4SPFile : YMLFileBase, ILocalizationFile
    {
        protected override string ProcessInput(string input)
        {
            return Localization.DummyLatin1ToUnicode(Localization.UnescapeQuote(input), 936);
        }

        protected override string ProcessOutput(string output)
        {
            return Localization.EscapeQuote(Localization.UnicodeToDummyLatin1(output, 936));
        }
    }

    public class YMLEu4File : YMLFileBase, ILocalizationFile
    {
        protected override string ProcessInput(string input)
        {
            return Localization.UnescapeQuote(input);
        }

        protected override string ProcessOutput(string output)
        {
            return Localization.EscapeQuote(output);
        }
    }

    public class YMLSafeFile : YMLFileBase, ILocalizationFile
    {
        protected override string ProcessInput(string input)
        {
            return Localization.ToUnsafeString(input);
        }

        protected override string ProcessOutput(string output)
        {
            return Localization.ToSafeString(output);
        }
    }

    public class YMLFile : YMLFileBase, ILocalizationFile
    {
        protected override string ProcessInput(string input)
        {
            return input;
        }

        protected override string ProcessOutput(string output)
        {
            return output;
        }
    }

    public abstract class YMLFileBase : ILocalizationFile
    {
        List<YMLLine> lines = new List<YMLLine>();

        public bool CanWrite()
        {
            return true;
        }

        public int GenHeader(string dummyLanguage)
        {
            if (lines.Count != 0)
                return -1;

            YMLLine firstline = new YMLLine();
            firstline.data = "l_" + dummyLanguage + ":";
            lines.Add(firstline);
            return 1;
        }

        public bool VerifyHeader(string dummyLanguage)
        {
            if (lines.Count == 0)
                return false;
            if (IsLineLocalizationData(0))
                return false;
            string firstline = "l_" + dummyLanguage + ":";
            
            return lines[0].data == firstline;
        }

        public string DefaultNamePattern()
        {
            return "*.yml";
        }

        public int HeaderLines()
        {
            return 1;
        }

        public string DefaultExtension()
        {
            return "yml";
        }

        public void Read(string path)
        {
            var utf8NoBom = new UTF8Encoding(false);
            using (var reader = new StreamReader(File.OpenRead(path), utf8NoBom))
            {
                reader.Read();
                if (Equals(reader.CurrentEncoding, utf8NoBom))
                {
                    Console.WriteLine("No BOM: {0}", path);
                }
            }

            // ignore encoding
            var raw = File.ReadLines(path, Encoding.GetEncoding(65001));
            Regex re = new Regex("^ (?<tag>[^#\\:]+):(?<ver>\\d+)? (?<data>.+\"|.+)(?<rest>.+)?");

            foreach (var rawline in raw)
            {
                YMLLine newline = new YMLLine();
                Match m = re.Match(rawline);
                if (m.Success)
                {
                    if (m.Groups["ver"].Success)
                    {
                        string strVer = m.Groups["ver"].Value;
                        if (!int.TryParse(strVer, out newline.ver))
                            newline.ver = 0;
                    }
                    else
                    {
                        newline.ver = -1;
                    }

                    newline.tag = m.Groups["tag"].Value;
                    newline.data = m.Groups["data"].Value;
                    if (newline.data.StartsWith("\"") && newline.data.EndsWith("\""))
                    {
                        newline.data = newline.data.Substring(1, newline.data.Length - 2);
                    }
                    if (m.Groups["rest"].Success)
                    {
                        newline.rest = m.Groups["rest"].Value;
                    }
                    newline.data = ProcessInput(newline.data);
                }
                else
                {
                    newline.data = rawline;
                }
                lines.Add(newline);
            }
        }

        public void Write(string path)
        {
            string output = "";

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line.tag))
                    output += " " + line.tag + ":" + (line.ver == -1 ? "" : line.ver.ToString()) + " \"" + ProcessOutput(line.data) + "\"" + (line.rest != null?line.rest :"") + "\n";
                else
                    output += ProcessOutput(line.data) + "\n";

            }
            // ignore encoding
            File.WriteAllText(path, output, Encoding.GetEncoding(65001));
        }

        protected abstract string ProcessInput(string input);

        protected abstract string ProcessOutput(string output);

        public int CountLines()
        {
            return lines.Count;
        }

        // line is 0 based
        public bool IsLineLocalizationData(int line)
        {
            if (line < 0 || line >= lines.Count)
                return false;
            return !string.IsNullOrEmpty(lines[line].tag);
        }

        public bool SetData(int line, string tag, int version, string data, string rest)
        {
            if (!IsLineLocalizationData(line))
                return false;
            lines[line].tag = tag;
            lines[line].ver = version;
            lines[line].data = data;
            lines[line].rest = rest;
            return true;
        }

        public bool GetData(int line, ref string tag, ref int version, ref string data, ref string rest)
        {
            if (!IsLineLocalizationData(line))
                return false;
            tag = lines[line].tag;
            version = lines[line].ver;
            data = lines[line].data;
            rest = lines[line].rest;
            return true;
        }

        public bool GetNonLocalizationData(int line, ref string data)
        {
            if (IsLineLocalizationData(line))
                return false;
            data = lines[line].data;
            return true;
        }

        public bool SetNonLocalizationData(int line, string data)
        {
            if (IsLineLocalizationData(line))
                return false;
            lines[line].data = data;
            return true;
        }

        public void AppendLine(string tag, int ver, string data, string rest)
        {
            var newLine = new YMLLine();
            newLine.tag = tag;
            newLine.ver = ver;
            newLine.data = data;
            newLine.rest = rest;
            lines.Add(newLine);
        }
    }
}
