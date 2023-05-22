namespace Seed.Unity.Files
{
    using Newtonsoft.Json;
    using UnityEngine;

    public class FileParser
    {
        public static T ReadAllDataFromFileAsType<T>(string file)
        {
            string data = ReadAllDataFromFile(file);

            return JsonConvert.DeserializeObject<T>(data);
        }

        internal static string ReadAllDataFromFile(string file)
        {
            TextAsset asset = Resources.Load<TextAsset>(file);

            return asset.text;
        }
    }
}