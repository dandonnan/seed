namespace Seed.Unity.Options
{
    using System.Collections.Generic;
    using Seed.Events;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using TMPro;
    using UnityEngine;

    public class OptionsMenu : MonoBehaviour
    {
        [Header("HintBox")]
        public TMP_Text HintTitle;

        public TMP_Text HintText;

        private List<AbstractOptionsMenu> tabs;

        private int currentTab;

        private void Start()
        {
            PopulateTabs();
        }

        private void LateUpdate()
        {
            /* if (InputManager.Menu.TabLeft.WasPressedThisFrame())
            {
                tabs[currentTab].Hide();
                currentTab = currentTab == 0 ? tabs.Count - 1 : currentTab - 1;
                tabs[currentTab].Show();
            }

            if (InputManager.Menu.TabRight.WasPressedThisFrame())
            {
                tabs[currentTab].Hide();
                currentTab = currentTab == tabs.Count - 1 ? 0 : currentTab + 1;
                tabs[currentTab].Show();
            }

            if (InputManager.Menu.Back.WasCapturedThisFrame())
            {
                EventManager.FireEvent(KnownEvents.CloseOptionsMenu);
            } */

            tabs[currentTab].Update();
        }

        public void SetHint(string title, string hint)
        {
            HintTitle.text = title;

            HintText.text = hint;
        }

        private void PopulateTabs()
        {
            tabs = new List<AbstractOptionsMenu>
            {
                //new AudioOptionsMenu(this),
                //new GraphicsOptionsMenu(this),
                //new AccessibilityOptionsMenu(this),
                //new ControlsOptionsMenu(this),
            };

            currentTab = 0;

            tabs[currentTab].Show();
        }
    }
}