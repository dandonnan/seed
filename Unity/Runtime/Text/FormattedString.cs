namespace Seed.Unity.Text
{
    using TMPro;
    using UnityEngine;

    public class FormattedString : MonoBehaviour
    {
        public string StringId;

        public TMP_Text Text;

        public void SetValue(string value)
        {
            string localisedText = Translations.Get(StringId);

            Text.text = string.Format(localisedText, value);
        }

        public void SetValues(params string[] values)
        {
            string localisedText = Translations.Get(StringId);

            Text.text = string.Format(localisedText, values);
        }
    }
}