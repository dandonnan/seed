namespace Seed.Unity.Options
{
    using Seed.Unity.Text;
    using UnityEngine;

    public abstract class AbstractOptionsMenu
    {
        protected const string onId = "OptionOn";

        protected const string offId = "OptionOff";

        protected const string yesId = "OptionYes";

        protected const string noId = "OptionNo";

        protected const int defaultYOffset = -110;

        protected Vector3 defaultPosition;

        protected OptionsMenuList menu;

        public AbstractOptionsMenu(OptionsMenu options)
        {
            defaultPosition = new Vector3(300, 450, 0);

            PopulateMenu(options);
        }

        public virtual void Show()
        {
            menu.Show();
        }

        public virtual void Hide()
        {
            menu.Hide();
        }

        public virtual void Update()
        {
            menu.Update();
        }

        protected string GetYesOrNoFromBool(bool value)
        {
            return value ? Translations.Get(yesId) : Translations.Get(noId);
        }

        protected string GetOnOrOffFromBool(bool value)
        {
            return value ? Translations.Get(onId) : Translations.Get(offId);
        }

        protected abstract void PopulateMenu(OptionsMenu parent);
    }
}