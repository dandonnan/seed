namespace Seed.Unity.Menu
{
    using System;
    using Seed.Platforms;
    using UnityEngine;

    public class MenuListBuilder
    {
        private readonly MenuList list;

        private readonly string prefabId;

        private readonly Transform parent;

        private readonly float yOffset;

        private Vector3 position;

        private MenuListBuilder(string prefabId, Vector3 initialPosition, Transform parent, float yOffset)
        {
            list = new MenuList();

            this.prefabId = prefabId;

            position = initialPosition;

            this.parent = parent;

            this.yOffset = yOffset;
        }

        public static MenuListBuilder Create(string prefabId, Vector3 initialPosition, Transform parent, float yOffset)
        {
            return new MenuListBuilder(prefabId, initialPosition, parent, yOffset);
        }

        public MenuListBuilder Add(string id, Action onSelect)
        {
            list.Add(new MenuOption(prefabId, id, position, parent)
            {
                OnSelect = onSelect
            });

            IncrementPositionOffset();

            return this;
        }

        public MenuListBuilder Add(string id, Action onLeft, Action onRight)
        {
            list.Add(new MenuOption(prefabId, id, position, parent)
            {
                OnLeft = onLeft,
                OnRight = onRight,
            });

            IncrementPositionOffset();

            return this;
        }

        public MenuListBuilder Add(MenuOption option)
        {
            list.Add(option);

            return this;
        }

        public MenuListBuilder AddOnCondition(string id, Action onSelect, bool condition)
        {
            if (condition)
            {
                Add(id, onSelect);
            }

            return this;
        }

        public MenuListBuilder AddOnCondition(string id, Action onLeft, Action onRight, bool condition)
        {
            if (condition)
            {
                Add(id, onLeft, onRight);
            }

            return this;
        }

        public MenuListBuilder AddOnCondition(MenuOption option, bool condition)
        {
            if (condition)
            {
                Add(option);
            }

            return this;
        }

        public MenuList Build()
        {
            return list;
        }

        private void IncrementPositionOffset()
        {
            Vector3 position = this.position;

            position.y += yOffset;

            this.position = position;
        }
    }
}