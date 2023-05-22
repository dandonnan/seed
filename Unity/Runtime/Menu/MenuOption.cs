namespace Seed.Unity.Menu
{
    using System;
    using Seed.Unity.Input;
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

        public MenuOption(string id)
        {
            Id = id;
        }

        public void Update()
        {
            //PerformActionIfBinding(InputManager.Menu.Move, OnUp, Vector2.up);
            //PerformActionIfBinding(InputManager.Menu.Move, OnDown, Vector2.down);
            //PerformActionIfBinding(InputManager.Menu.Move, OnLeft, Vector2.left);
            //PerformActionIfBinding(InputManager.Menu.Move, OnRight, Vector2.right);
            //PerformActionIfBinding(InputManager.Menu.Select, OnSelect);
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
    }
}