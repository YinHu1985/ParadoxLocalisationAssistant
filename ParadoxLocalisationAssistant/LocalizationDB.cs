using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ParadoxLocalisationAssistant
{
    /// <summary>
    /// Localization data collection for a single language
    /// </summary>
    public class SingleLanguageDB
    {
        string language;
        Dictionary<string, SortedDictionary<int, string>> data = new Dictionary<string, SortedDictionary<int, string>>();

        public SingleLanguageDB(string language) { this.language = language; }

        public string Language
        {
            get;
        }

        internal bool Load(string languageName, string dbPath)
        {
            language = languageName;
            string fullpath = dbPath + "\\" + languageName;
            data = new Dictionary<string, SortedDictionary<int, string>>();

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(data.GetType());
                using (var stream = File.OpenRead(fullpath))
                {
                    data = (Dictionary<string, SortedDictionary<int, string>>)ser.ReadObject(stream);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal bool Dump(string dbPath)
        {
            string fullpath = dbPath + "\\" + language;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(data.GetType());
                using (var stream = File.OpenWrite(fullpath))
                {
                    ser.WriteObject(stream, data);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Import(string tag, int ver, string text, LocalizationDB.ImportMode mode)
        {
            if (!data.ContainsKey(tag))
                data[tag] = new SortedDictionary<int, string>();

            if (mode == LocalizationDB.ImportMode.kReplace)
            {
                data[tag][ver] = text;
            }
            else
            {
                if (!data[tag].ContainsKey(ver))
                    data[tag][ver] = text;
                else
                    return false;
            }
            return true;
        }

        public void Remove(string tag, int ver)
        {
            if (!data.ContainsKey(tag))
                return;

            if (ver != -1 && !data[tag].ContainsKey(ver))
                return;

            if (ver != -1)
                data[tag].Remove(ver);
            if (ver == -1 || data[tag].Count == 0)
                data.Remove(tag);
        }

        public Tuple<int, string> LookupLatestText(string tag)
        {
            if (!data.ContainsKey(tag))
                return null;
            return new Tuple<int, string>(data[tag].Last().Key, data[tag].Last().Value);
        }

        public string LookupText(string tag, int ver)
        {
            if (!data.ContainsKey(tag))
                return null;
            if (!data[tag].ContainsKey(ver))
                return null;
            else
                return data[tag][ver];
        }

        public Dictionary<string, SortedDictionary<int, string>>.Enumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public string[] GetTagArray()
        {
            return data.Keys.ToArray();
        }
    }


    /// <summary>
    /// Collection of SingleLanguageDB of data for multiple languages.
    /// Not used for now.
    /// </summary>
    public class LocalizationDB
    {
        string name;
        string rootPath;
        Dictionary<string, SingleLanguageDB> data = new Dictionary<string, SingleLanguageDB>();

        public string Name
        {
            get { return name; }
        }

        public LocalizationDB(string dbname, string root)
        {
            if (dbname == null || root == null)
                throw new ArgumentNullException();

            rootPath = root;
            name = dbname;
        }

        public bool Load()
        {
            string dbPath = rootPath;
            dbPath += "\\" + name;
            if (!Directory.Exists(dbPath))
            {
                return false;
            }
            // Load;
            foreach (var fname in Directory.EnumerateFiles(dbPath))
            {
                string filename = Path.GetFileName(fname);
                SingleLanguageDB sldb = new SingleLanguageDB(filename);
                if (sldb.Load(filename, dbPath))
                    data[filename] = sldb;
            }
            return true;
        }

        public bool Dump(string language)
        {
            string dbPath = rootPath;
            dbPath += "\\" + name;
            if (!Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);
            if (language == null)
            {
                foreach (var kvpair in data)
                {
                    kvpair.Value.Dump(dbPath);
                }
                return true;
            }
            else
            {
                if (data.ContainsKey(language))
                    return data[language].Dump(dbPath);
                return false;
            }
        }

        public enum ImportMode
        {
            kIgnore,
            kReplace,
        }

        public bool Import(string language, string tag, int ver, string text, ImportMode mode)
        {
            if (!data.ContainsKey(language))
                data[language] = new SingleLanguageDB(language);

            return data[language].Import(tag, ver, text, mode);
        }

        public SingleLanguageDB LookupSingleLanguageDB(string language)
        {
            if (!data.ContainsKey(language))
                return null;
            else
                return data[language];
        }

        public bool ImportSingleLanguageDB(SingleLanguageDB sldb, bool overwrite = false)
        {
            if (data.ContainsKey(sldb.Language) && !overwrite)
                return false;
            data[sldb.Language] = sldb;
            return true;
        }

        public List<string> ListAllLanguages()
        {
            List<string> result = new List<string>();
            foreach (var kv in data)
                result.Add(kv.Key);
            return result;
        }
    }


}
