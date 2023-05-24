namespace Seed.Unity.Menu
{
    using System;
    using UnityEngine;

    public class MenuShelfBuilder
    {
        private readonly MenuShelf shelf;

        private readonly string prefabId;

        private readonly Transform parent;

        private readonly float xOffset;

        private Vector3 position;

        private MenuShelfBuilder(string prefabId, Vector3 initialPosition, Transform parent, float xOffset)
        {
            shelf = new MenuShelf();

            this.prefabId = prefabId;

            position = initialPosition;

            this.parent = parent;

            this.xOffset = xOffset;
        }

        public static MenuShelfBuilder Create(string prefabId, Vector3 initialPosition, Transform parent, float xOffset)
        {
            return new MenuShelfBuilder(prefabId, initialPosition, parent, xOffset);
        }

        public MenuShelfBuilder Add(string id, Action onSelected)
        {
            shelf.Add(new MenuOption(prefabId, id, position, parent)
            {
                OnSelect = onSelected
            });

            return this;
        }

        public MenuShelf Build()
        {
            return shelf;
        }

        private void IncrementPositionOffset()
        {
            Vector3 position = this.position;

            position.x += xOffset;

            this.position = position;
        }
    }
}