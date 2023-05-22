namespace Seed.Unity.Menu
{
    using System;
    using Seed.Platforms;

    public class MenuListBuilder
    {
        private readonly MenuList list;

        private MenuListBuilder()
        {
            list = new MenuList();
        }

        public static MenuListBuilder Create()
        {
            return new MenuListBuilder();
        }

        public MenuListBuilder Add(string id, Action onLeft, Action onRight)
        {
            list.Add(new MenuOption(id)
            {
                OnLeft = onLeft,
                OnRight = onRight,
            });

            return this;
        }

        public MenuListBuilder AddIfPC(string id, Action onLeft, Action onRight)
        {
            if (PlatformManager.IsPC())
            {
                Add(id, onLeft, onRight);
            }

            return this;
        }

        public MenuList Build()
        {
            return list;
        }
    }
}