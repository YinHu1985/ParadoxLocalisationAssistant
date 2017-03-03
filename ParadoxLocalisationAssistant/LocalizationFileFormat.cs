using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadoxLocalisationAssistant
{
    public class LocalizationFileFormat
    {
        private static Dictionary<string, LocalizationFileFormat> _formats;
        static LocalizationFileFormat()
        {
            LocalizationFileFormat[] formats = {
                new LocalizationFileFormat("pml", () => new YMLFile()),
                new LocalizationFileFormat("pml-safe", () => new YMLSafeFile()),
                new LocalizationFileFormat("csv", () => new CSVFile()),
                new LocalizationFileFormat("csv-gbk", () => new CSVGBKFile()),
                new LocalizationFileFormat("csv-safe", () => new CSVSafeFile()),
                new LocalizationFileFormat("csv-safe-gbk", () => new CSVSafeGBKFile()),
                new LocalizationFileFormat("eu4pml", () => new YMLEu4File()),
                new LocalizationFileFormat("eu4pml-sp", () => new YMLEu4SPFile()),
                new LocalizationFileFormat("eu4pml-safe", () => new YMLEu4SafeFile()),
            };

            _formats = new Dictionary<string, LocalizationFileFormat>();
            foreach (LocalizationFileFormat f in formats)
                _formats.Add(f.Name, f);
        }

        public static bool IsFileFormatSupported(string fileFormat)
        {
            return _formats.ContainsKey(fileFormat);
        }

        public static LocalizationFileFormat GetFileFormat(string fileFormat)
        {
            if (!IsFileFormatSupported(fileFormat))
                throw new InvalidCastException(fileFormat + "is not a valid file format");

            return _formats[fileFormat];
        }

        public static List<string> GetAllFileFormats()
        {
            return _formats.Keys.ToList();
        }

        // non-static //
        private Func<ILocalizationFile> _getInstanceMethod;
        public string Name { private set; get; }

        private LocalizationFileFormat(string name, Func<ILocalizationFile> getInstanceMethod)
        {
            _getInstanceMethod = getInstanceMethod;
            Name = name;
        }

        public ILocalizationFile GetLocalizationFileInstance()
        {
            return _getInstanceMethod();
        }
    }
}
