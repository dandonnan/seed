namespace Seed.Unity.Options
{
    using Seed.Unity.Text;
    using UnityEngine;

    public abstract class AbstractOptionsMenu
    {
        protected const int defaultYOffset = -110;

        protected Vector3 defaultPosition;

        protected OptionsMenuList menu;

        protected Transform parent;

        public AbstractOptionsMenu(Transform parent)
        {
            this.parent = parent;

            defaultPosition = new Vector3(300, 450, 0);

            PopulateMenu();
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

        protected abstract void PopulateMenu();
    }
}