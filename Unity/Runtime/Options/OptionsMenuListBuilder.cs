namespace Seed.Unity.Options
{
    using System;
    using Seed.Platforms;
    using UnityEngine;

    public class OptionsMenuListBuilder
    {
        private readonly OptionsMenuList list;

        private Transform parent;

        private Vector3 position;

        private int offset;

        private OptionsMenuListBuilder(OptionsMenu menu, Vector3 position, int yOffset)
        {
            list = new OptionsMenuList(menu);

            parent = menu.transform;

            this.position = position;

            offset = yOffset;
        }

        public static OptionsMenuListBuilder Create(OptionsMenu menu, Vector3 position, int yOffset)
        {
            return new OptionsMenuListBuilder(menu, position, yOffset);
        }

        public OptionsMenuListBuilder Add(string id, int value, Action onLeft, Action onRight)
        {
            return Add(id, value.ToString(), onLeft, onRight);
        }

        public OptionsMenuListBuilder Add(string id, string value, Action onLeft, Action onRight)
        {
            list.Add(new OptionsMenuOption(id, value, position, parent)
            {
                OnLeft = onLeft,
                OnRight = onRight,
            });

            position.y += offset;

            return this;
        }

        public OptionsMenuListBuilder AddIfPC(string id, string value, Action onLeft, Action onRight)
        {
            if (PlatformManager.IsPC())
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