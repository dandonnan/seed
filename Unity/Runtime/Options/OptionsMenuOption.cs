namespace Seed.Unity.Options
{
    using Seed.Unity.Addressables;
    using Seed.Unity.Menu;
    using Seed.Unity.Text;
    using UnityEngine;

    public class OptionsMenuOption : MenuOption
    {
        private const string hintFormat = "{0}Hint";

        protected EditableOption option;

        protected string hint;

        public OptionsMenuOption(string prefabId, string id, string value, Vector3 position, Transform parent)
            : base(prefabId, id, position, parent)
        {
            option = UI.GetComponent<EditableOption>();

            hint = Translations.Get(string.Format(hintFormat, id));

            option.Setup(name, value);
        }

        public void SetValue(string value)
        {
            option.SetValue(value);
        }

        public string GetHint()
        {
            return hint;
        }
    }
}