using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadoxLocalisationAssistant
{
    public interface ILocalizationFile
    {
        bool CanWrite();
        int GenHeader(string dummyLanguage);
        bool VerifyHeader(string dummyLanguage);
        int HeaderLines();

        string DefaultNamePattern();
        string DefaultExtension();

        void Read(string path);
        void Write(string path);
        int CountLines();
        // line is 0 based
        bool IsLineLocalizationData(int line);
        bool SetData(int line, string tag, int version, string data, string rest);
        bool GetData(int line, ref string tag, ref int version, ref string data, ref string rest);
        void AppendLine(string tag, int ver, string data, string rest);
        bool SetNonLocalizationData(int line, string data);
        bool GetNonLocalizationData(int line, ref string data);
    }
}
