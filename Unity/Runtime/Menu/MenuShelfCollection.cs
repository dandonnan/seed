namespace Seed.Unity.Menu
{
    using System.Collections.Generic;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using UnityEngine;

    public class MenuShelfCollection
    {
        private List<MenuShelf> shelves;

        private int currentShelf;

        public MenuShelfCollection()
        {
            shelves = new List<MenuShelf>();
        }

        public void Add(MenuShelf shelf)
        {
            shelves.Add(shelf);
        }

        public void Update()
        {
            shelves[currentShelf].Update();

            /* if (shelves.Count > 1 && InputManager.Menu.Move.WasPressedThisFrame(out Vector2 move))
            {
                if (move.y > 0)
                {
                    currentShelf = currentShelf == 0 ? shelves.Count - 1 : currentShelf - 1;
                }
                else if (move.y < 0)
                {
                    currentShelf = currentShelf == shelves.Count - 1 ? 0 : currentShelf + 1;
                }
            } */
        }
    }
}