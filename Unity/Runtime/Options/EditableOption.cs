namespace Seed.Unity.Options
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class EditableOption : MonoBehaviour
    {
        [Header("UI")]
        public Image Background;

        public TMP_Text Name;

        public TMP_Text Value;

        public void Setup(string name, string value)
        {
            Name.text = name;

            Value.text = value;
        }

        public void SetValue(string value)
        {
            Value.text = value;
        }
    }
}