namespace Seed.Unity.Options
{
    using Seed.Unity.Menu;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class EditableOption : MonoBehaviour, IMenuOptionUI
    {
        [Header("UI")]
        public Image Background;

        public TMP_Text Name;

        public TMP_Text Value;

        public void SetText(string text)
        {
            Name.text = text;
        }

        public void SetText(string text, Color colour)
        {
            SetText(text);
            SetTextColour(colour);
        }

        public void SetTextColour(Color colour)
        {
            Name.color = colour;
        }

        public void SetValue(string value)
        {
            Value.text = value;
        }
    }
}