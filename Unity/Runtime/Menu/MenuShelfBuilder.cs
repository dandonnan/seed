namespace Seed.Unity.Menu
{
    using System;

    public class MenuShelfBuilder
    {
        private readonly MenuShelf shelf;

        private MenuShelfBuilder()
        {
            shelf = new MenuShelf();
        }

        public static MenuShelfBuilder Create()
        {
            return new MenuShelfBuilder();
        }

        public MenuShelfBuilder Add(string id, Action onSelected)
        {
            shelf.Add(new MenuOption(id)
            {
                OnSelect = onSelected
            });

            return this;
        }

        public MenuShelf Build()
        {
            return shelf;
        }
    }
}