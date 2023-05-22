namespace Seed.Unity.Options
{
    using Seed.Unity.Addressables;
    using Seed.Unity.Menu;
    using Seed.Unity.Text;
    using UnityEngine;

    public class OptionsMenuOption : MenuOption
    {
        private const string hintFormat = "{0}Hint";

        protected GameObject UI;

        protected EditableOption option;

        protected string name;

        protected string hint;

        public OptionsMenuOption(string id, string value, Vector3 position, Transform parent)
            : base(id)
        {
            UI = AddressableCatalogue.CreateObject("Option", position, parent);

            option = UI.GetComponent<EditableOption>();

            name = Translations.Get(id);

            hint = Translations.Get(string.Format(hintFormat, id));

            option.Setup(name, value);

            Hide();
        }

        public void SetValue(string value)
        {
            option.SetValue(value);
        }

        public void SetHint(OptionsMenu menu)
        {
            menu.SetHint(name, hint);
        }

        public void Show()
        {
            UI.SetActive(true);
        }

        public void Hide()
        {
            UI.SetActive(false);
        }
    }
}