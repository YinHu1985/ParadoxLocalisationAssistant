using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ParadoxLocalisationKit
{
    class CSVLine
    {
        public string tag;
        public string data;
        public string rest;
    }

    public class CSVGBKFile : CSVFile, ILocalizationFile
    {
        protected override int encoding { get { return 936; } }
    }

    public class CSVFile : ILocalizationFile
    {
        List<CSVLine> lines = new List<CSVLine>();

        protected virtual int encoding { get { return 1252; } }


        string ProcessEncoding(string input, int encoding)
        {
            if (encoding == 1252)
                return input;
            string result = "";

            var bytes = Encoding.GetEncoding(1252).GetBytes(input);

            for (int i = 0; i < bytes.Length; ++ i)
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

        public void Read(string path)
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
                    newline.data = ProcessEncoding(m.Groups["data"].Value, encoding);
                    newline.rest = ProcessEncoding(m.Groups["rest"].Value, encoding);
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
                if (line.tag != "")
                    output += line.tag + ";" + line.data + ";" + line.rest + "\n";
                else
                    output += line.data + "\n";

            }
            File.WriteAllText(path, output, Encoding.GetEncoding(encoding));
        }

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
