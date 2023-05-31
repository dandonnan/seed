namespace Seed.Unity.Options
{
    using System;
    using Seed.Platforms;
    using UnityEngine;

    public class OptionsMenuListBuilder
    {
        private readonly OptionsMenuList list;

        private readonly string prefabId;

        private readonly Transform parent;

        private float offset;

        private Vector3 position;

        private OptionsMenuListBuilder(string prefabId, Transform parent, Vector3 position, float yOffset)
        {
            list = new OptionsMenuList();

            this.prefabId = prefabId;

            this.parent = parent;

            this.position = position;

            offset = yOffset;
        }

        public static OptionsMenuListBuilder Create(string prefabId, Transform parent, Vector3 position, float yOffset)
        {
            return new OptionsMenuListBuilder(prefabId, parent, position, yOffset);
        }

        public OptionsMenuListBuilder Add(string id, int value, Action onLeft, Action onRight)
        {
            return Add(id, value.ToString(), onLeft, onRight);
        }

        public OptionsMenuListBuilder Add(string id, string value, Action onLeft, Action onRight)
        {
            list.Add(new OptionsMenuOption(prefabId, id, value, position, parent)
            {
                OnLeft = onLeft,
                OnRight = onRight,
            });

            position.y += offset;

            return this;
        }

        public OptionsMenuListBuilder AddOnCondition(string id, string value, Action onLeft, Action onRight, bool condition)
        {
            if (condition)
            {
                Add(id, value, onLeft, onRight);
            }

            return this;
        }

        public OptionsMenuList Build()
        {
            return list;
        }
    }
}