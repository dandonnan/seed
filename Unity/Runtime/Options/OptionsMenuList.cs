namespace Seed.Unity.Options
{
    using System.Collections.Generic;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using UnityEngine;

    public class OptionsMenuList
    {
        protected List<OptionsMenuOption> options;

        protected int highlightedOption;

        public OptionsMenuList()
        {
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

        public virtual void Show()
        {
            options.ForEach(o => o.Show());
        }

        public virtual void Hide()
        {
            options.ForEach(o => o.Hide());
        }

        public virtual void Update()
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
    }
}