namespace Seed.MonoGame.Localisation
{
    using Seed.MonoGame.Resources.Localisation;
    using System.Collections.Generic;

    public class StringLibrary
    {
        private const string common = "Data\\Text\\common";

        private static StringLibrary instance;

        private Dictionary<string, Dictionary<string, string>> stringDictionaries;

        private string caseCommon;

        private StringLibrary()
        {
            stringDictionaries = PopulateDictionaries(new List<string> { common });

            instance = this;
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                new StringLibrary();
            }
        }

        public static void LoadForArea(string areaFile)
        {
            if (instance.stringDictionaries.ContainsKey(areaFile) == false)
            {
                instance.stringDictionaries = PopulateDictionaries(new List<string> { common, instance.caseCommon, areaFile });
            }
        }

        public static string GetString(string id)
        {
            string value = null;

            int indexOfSeparator = id.IndexOf('.');

            if (indexOfSeparator > -1)
            {
                value = GetString(id.Substring(0, indexOfSeparator), id.Substring(indexOfSeparator + 1));
            }
            else
            {
                foreach (string file in instance.stringDictionaries.Keys)
                {
                    value = GetString(file, id);

                    if (value != null)
                    {
                        break;
                    }
                }
            }

            return value;
        }

        public static string GetString(string file, string id)
        {
            string value = null;

            instance.stringDictionaries.TryGetValue(file, out Dictionary<string, string> fileDictionary);

            if (fileDictionary != null)
            {
                fileDictionary.TryGetValue(id, out value);
            }

            return value;
        }

        private static Dictionary<string, Dictionary<string, string>> PopulateDictionaries(List<string> files)
        {
            Dictionary<string, Dictionary<string, string>> dictionaries = new Dictionary<string, Dictionary<string, string>>();

            foreach (string file in files)
            {
                if (string.IsNullOrWhiteSpace(file) == false)
                {
                    dictionaries.Add(file, GetDictionaryFromFile(file));
                }
            }

            return dictionaries;
        }

        private static Dictionary<string, string> GetDictionaryFromFile(string file)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            List<LocalisedText> strings = GameManager.ContentManager.LoadLocalized<List<LocalisedText>>(file);

            foreach (LocalisedText localisedText in strings)
            {
                dictionary.Add(localisedText.Id, localisedText.Value);
            }

            return dictionary;
        }
    }
}