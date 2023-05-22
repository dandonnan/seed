namespace Seed.Unity.Text
{
    using UnityEngine.Localization.Settings;

    public class Translations
    {
        public static string Get(string id)
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString(id);
        }

        public static string Get(string table, string id)
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString(table, id);
        }
    }
}