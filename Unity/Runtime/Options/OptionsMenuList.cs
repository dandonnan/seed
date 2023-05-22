namespace Seed.Unity.Options
{
    using System.Collections.Generic;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using UnityEngine;

    public class OptionsMenuList
    {
        private List<OptionsMenuOption> options;

        private int highlightedOption;

        private OptionsMenu menu;

        public OptionsMenuList(OptionsMenu menu)
        {
            this.menu = menu;

            options = new List<OptionsMenuOption>();
        }

        public void Add(OptionsMenuOption option)
        {
            options.Add(option);
        }

        public void SetValue(int value)
        {
            SetValue(value.ToString());
        }

        public void SetValue(string value)
        {
            options[highlightedOption].SetValue(value);
        }

        public void Show()
        {
            options.ForEach(o => o.Show());

            options[highlightedOption].SetHint(menu);
        }

        public void Hide()
        {
            options.ForEach(o => o.Hide());
        }

        public void Update()
        {
            options[highlightedOption].Update();

            /*if (InputManager.Menu.Move.WasPressedThisFrame(out Vector2 move))
            {
                if (move.y < 0)
                {
                    highlightedOption = highlightedOption == options.Count - 1 ? 0 : highlightedOption + 1;

                    options[highlightedOption].SetHint(menu);
                }
                else if (move.y > 0)
                {
                    highlightedOption = highlightedOption == 0 ? options.Count - 1 : highlightedOption - 1;

                    options[highlightedOption].SetHint(menu);
                }
            } */
        }
    }
}