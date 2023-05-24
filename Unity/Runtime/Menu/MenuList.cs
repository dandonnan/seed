namespace Seed.Unity.Menu
{
    using System.Collections.Generic;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using UnityEngine;

    public class MenuList
    {
        private List<MenuOption> options;

        private int highlightedOption;

        public MenuList()
        {
            options = new List<MenuOption>();
        }

        public void Add(MenuOption option)
        {
            options.Add(option);
        }

        public void Update()
        {
            options[highlightedOption].Update();

            if (InputManager.Menu.LeftStickMove.WasPressedThisFrame(out Vector2 move))
            {
                if (move.y < 0)
                {
                    highlightedOption = highlightedOption == options.Count - 1 ? 0 : highlightedOption + 1;
                }
                else if (move.y > 0)
                {
                    highlightedOption = highlightedOption == 0 ? options.Count - 1 : highlightedOption - 1;
                }
            }
        }

        public void Show()
        {
            options.ForEach(o => o.Show());
        }

        public void Hide()
        {
            options.ForEach(o => o.Hide());
        }
    }
}