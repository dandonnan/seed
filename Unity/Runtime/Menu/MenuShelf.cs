namespace Seed.Unity.Menu
{
    using System.Collections.Generic;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using UnityEngine;

    public class MenuShelf
    {
        private List<MenuOption> options;

        private int highlightedOption;

        public MenuShelf()
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

            /* if (InputManager.Menu.Move.WasPressedThisFrame(out Vector2 move))
            {
                if (move.x > 0)
                {
                    highlightedOption = highlightedOption == options.Count - 1 ? 0 : highlightedOption + 1;
                }
                else if (move.x < 0)
                {
                    highlightedOption = highlightedOption == 0 ? options.Count - 1 : highlightedOption - 1;
                }
            } */
        }
    }
}