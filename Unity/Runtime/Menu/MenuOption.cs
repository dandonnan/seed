namespace Seed.Unity.Menu
{
    using System;
    using Seed.Unity.Addressables;
    using Seed.Unity.Input;
    using Seed.Unity.Text;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class MenuOption
    {
        public string Id { get; private set; }

        public Action OnUp { get; set; }

        public Action OnDown { get; set; }

        public Action OnLeft { get; set; }

        public Action OnRight { get; set; }

        public Action OnHighlight { get; set; }

        public Action OnSelect { get; set; }

        protected GameObject UI;

        protected IMenuOptionUI UIComponent;

        protected string name;

        public MenuOption(string prefabId, string stringId, Vector3 position, Transform parent)
        {
            Id = stringId;

            UI = AddressableCatalogue.CreateObject(prefabId, position, parent);

            UIComponent = UI.GetComponent<IMenuOptionUI>();

            SetText();
        }

        public virtual void Update()
        {
            PerformActionIfBinding(InputManager.Menu.LeftStickMove, OnUp, Vector2.up);
            PerformActionIfBinding(InputManager.Menu.LeftStickMove, OnDown, Vector2.down);
            PerformActionIfBinding(InputManager.Menu.LeftStickMove, OnLeft, Vector2.left);
            PerformActionIfBinding(InputManager.Menu.LeftStickMove, OnRight, Vector2.right);
            PerformActionIfBinding(InputManager.Menu.South, OnSelect);
        }

        public virtual void Show()
        {
            UI.SetActive(true);
        }

        public virtual void Hide()
        {
            UI.SetActive(false);
        }

        private void PerformActionIfBinding(InputAction binding, Action action)
        {
            if (action != null && binding.WasReleasedThisFrame())
            {
                action();
            }
        }

        private void PerformActionIfBinding(InputAction binding, Action action, Vector2 vector)
        {
            if (action != null && binding.WasPressedThisFrame())
            {
                if (binding.ReadValue<Vector2>() == vector)
                {
                    action();
                }
            }
        }

        private void SetText()
        {
            name = Translations.Get(Id);

            UIComponent.SetText(name);
        }
    }
}