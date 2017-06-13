using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ParadoxLocalisationAssistant
{
    public class CSVLine
    {
        public string tag;
        public string data;
        public string rest;
    }  

    public class CSVSafeFile : CSVFile, ILocalizationFile
    {
        protected override string ProcessInput(string input)
        {
            return Localization.ToUnsafeString(Localization.DummyLatin1ToUnicode(input, encoding));
        }

        protected override string ProcessOutput(string output)
        {
            return Localization.ToSafeString(Localization.UnicodeToDummyLatin1(output, encoding));
        }
    }

    public class CSVGBKFile : CSVFile, ILocalizationFile
    {
        protected override int encoding { get { return 936; } }
    }

    public class CSVSafeGBKFile : CSVSafeFile, ILocalizationFile
    {
        protected override int encoding { get { return 936; } }
    }

    public class CSVFile : CSVFileBase, ILocalizationFile
    {
        protected override int encoding { get { return 1252; } }

        protected override string ProcessInput(string input)
        {
            return Localization.DummyLatin1ToUnicode(input, encoding);
        }

        protected override string ProcessOutput(string output)
        {
            return Localization.UnicodeToDummyLatin1(output, encoding);
        }

    }

    public abstract class CSVFileBase : ILocalizationFile
    {
        protected List<CSVLine> lines = new List<CSVLine>();

        protected virtual int encoding { get { return 1252; } }

        public bool CanWrite()
        {
            return true;
        }

        public int GenHeader(string dummyLanguage)
        {
            // csv does not have header
            return 0;
        }

        public bool VerifyHeader(string dummyLanguage)
        {
            return true;
        }

        public string DefaultNamePattern()
        {
            return "*.csv";
        }

        public int HeaderLines()
        {
            return 0;
        }

        public string DefaultExtension()
        {
            return "csv";
        }

        public virtual void Read(string path)
        {
            // first read as Latin1
            var raw = File.ReadLines(path, Encoding.GetEncoding(1252));
            Regex re = new Regex("^(?<tag>[^#;]+);(?<data>[^#;]+);(?<rest>.+)");

            foreach (var rawline in raw)
            {
                CSVLine newline = new CSVLine();
                Match m = re.Match(rawline);
                if (m.Success)
                {     
                    newline.tag = m.Groups["tag"].Value;
                    newline.data = ProcessInput(m.Groups["data"].Value);
                    newline.rest = ProcessInput(m.Groups["rest"].Value);
                }
                else
                {
                    newline.data = rawline;
                }
                lines.Add(newline);
            }
        }

        public virtual void Write(string path)
        {
            StringBuilder output = new StringBuilder();

            foreach (var line in lines)
            {
                if (line.tag != "")
                {
                    output.AppendFormat("{0};{1};{2}\n", line.tag, ProcessOutput(line.data), line.rest);
                }
                else
                {
                    output.AppendFormat("{0}\n", ProcessOutput(line.data));
                }
            }
            File.WriteAllText(path, output.ToString(), Encoding.GetEncoding(1252));
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
            lines[line].data = data;
            lines[line].rest = rest;
            return true;
        }

        public bool GetData(int line, ref string tag, ref int version, ref string data, ref string rest)
        {
            if (!IsLineLocalizationData(line))
                return false;
            tag = lines[line].tag;
            version = -1;
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
            var newLine = new CSVLine();
            newLine.tag = tag;
            newLine.data = data;
            newLine.rest = rest;
            lines.Add(newLine);
        }
    }

}
