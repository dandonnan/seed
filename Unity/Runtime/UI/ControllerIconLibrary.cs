namespace Seed.Unity.UI
{
    using System.Collections.Generic;
    using Seed.Input;
    using Seed.Platforms;
    using Seed.Unity.Input;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.TextCore;

    [DefaultExecutionOrder(-1)]
    public class ControllerIconLibrary : MonoBehaviour
    {
        private static ControllerIconLibrary instance;

        private Dictionary<string, Sprite> sprites;

        [Header("Playstation")]

        public TMP_SpriteAsset PS_SpriteAsset;

        [Header("Xbox")]
        public TMP_SpriteAsset XB_SpriteAsset;

        [Header("Switch")]

        public TMP_SpriteAsset NX_SpriteAsset;

        [Header("PC")]

        public TMP_SpriteAsset PC_SpriteAsset;

        private void Start()
        {
            instance = this;

            sprites = new Dictionary<string, Sprite>();
        }

        public static TMP_SpriteAsset GetSpriteAsset()
        {
            return GetSpriteAsset(InputManager.ControllerType);
        }

        public static TMP_SpriteAsset GetSpriteAsset(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_SpriteAsset;

                case Platforms.XboxSeries:
                    return instance.XB_SpriteAsset;

                case Platforms.Switch:
                    return instance.NX_SpriteAsset;

                case Platforms.Itch:
                    return instance.PC_SpriteAsset;

                default:
                    return instance.XB_SpriteAsset;
            }
        }

        public static Sprite GetIcon(ButtonType button)
        {
            return GetIcon(button, InputManager.ControllerType);
        }

        public static Sprite GetIcon(ButtonType button, Platforms platform)
        {
            switch (button)
            {
                case ButtonType.FaceSouth:
                    return GetSouth(platform);

                case ButtonType.FaceEast:
                    return GetEast(platform);

                case ButtonType.FaceNorth:
                    return GetNorth(platform);

                case ButtonType.FaceWest:
                    return GetWest(platform);

                case ButtonType.LeftStick:
                    return GetLeftStick(platform);

                case ButtonType.RightStick:
                    return GetRightStick(platform);

                case ButtonType.LeftBumper:
                    return GetLeftBumper(platform);

                case ButtonType.RightBumper:
                    return GetRightBumper(platform);

                case ButtonType.LeftTrigger:
                    return GetLeftTrigger(platform);

                case ButtonType.RightTrigger:
                    return GetRightTrigger(platform);

                case ButtonType.DPadLeft:
                    return GetDPadLeft(platform);

                case ButtonType.DPadRight:
                    return GetDPadRight(platform);

                case ButtonType.DPadUp:
                    return GetDPadUp(platform);

                case ButtonType.DPadDown:
                    return GetDPadDown(platform);

                case ButtonType.Pause:
                    return GetPause(platform);

                default:
                    return null;
            }
        }

        // TODO: Sort this out
        public static string GetIcon(string iconName)
        {
            iconName = iconName.ToUpper();

            switch (iconName)
            {
                case "ICON_EAST":
                    return "east";

                case "ICON_NORTH":
                    return "north";

                case "ICON_SOUTH":
                    return "south";

                case "ICON_WEST":
                    return "west";

                case "ICON_LEFT_STICK":
                    return "left_stick";

                case "ICON_RIGHT_STICK":
                    return "right_stick";

                case "ICON_DPAD_LEFT":
                    return "dpad_left";

                case "ICON_DPAD_RIGHT":
                    return "dpad_right";

                case "ICON_DPAD_UP":
                    return "dpad_up";

                case "ICON_DPAD_DOWN":
                    return "dpad_down";

                case "ICON_PAUSE":
                    return "pause";

                default:
                    return null;
            }

            //return string.Format("{0}_icons_{1}", controllerPrefix, iconSuffix);
        }

        private static Sprite GetSouth(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 0);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 0);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 0);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 5);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 0);
            }
        }

        private static Sprite GetEast(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 1);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 1);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 1);

                //case Platforms.Itch:
                //return GetSprite(instance.PC_SpriteAsset, platform, 1);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 1);
            }
        }

        private static Sprite GetNorth(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 2);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 2);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 2);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 4);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 2);
            }
        }

        private static Sprite GetWest(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 3);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 3);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 3);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 3);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 3);
            }
        }

        private static Sprite GetLeftStick(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 14);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 14);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 14);

                //case Platforms.Itch:
                //    return GetSprite(instance.PC_SpriteAsset, platform, 1);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 14);
            }
        }

        private static Sprite GetRightStick(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 15);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 15);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 15);

                //case Platforms.Itch:
                //    return GetSprite(instance.PC_SpriteAsset, platform, 1);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 15);
            }
        }

        private static Sprite GetLeftBumper(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 8);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 8);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 8);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 7);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 8);
            }
        }

        private static Sprite GetRightBumper(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 9);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 9);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 9);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 8);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 9);
            }
        }

        private static Sprite GetLeftTrigger(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 11);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 10);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 10);

                //case Platforms.Itch:
                //return GetSprite(instance.PC_SpriteAsset, platform, 1);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 10);
            }
        }

        private static Sprite GetRightTrigger(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 10);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 11);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 11);

                //case Platforms.Itch:
                //    return GetSprite(instance.PC_SpriteAsset, platform, 1);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 11);
            }
        }

        private static Sprite GetDPadLeft(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 4);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 5);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 4);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 10);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 5);
            }
        }

        private static Sprite GetDPadRight(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 6);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 7);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 7);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 11);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 7);
            }
        }

        private static Sprite GetDPadUp(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 7);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 4);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 5);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 6);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 4);
            }
        }

        private static Sprite GetDPadDown(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 4);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 5);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 4);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 10);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 5);
            }
        }

        private static Sprite GetPause(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return GetSprite(instance.PS_SpriteAsset, platform, 12);

                case Platforms.XboxSeries:
                    return GetSprite(instance.XB_SpriteAsset, platform, 12);

                case Platforms.Switch:
                    return GetSprite(instance.NX_SpriteAsset, platform, 13);

                case Platforms.Itch:
                    return GetSprite(instance.PC_SpriteAsset, platform, 2);

                default:
                    return GetSprite(instance.XB_SpriteAsset, platform, 12);
            }
        }

        private static Sprite GetSprite(TMP_SpriteAsset asset, Platforms platform, int glpyhIndex)
        {
            string iconId = GetIconId(platform, glpyhIndex);

            if (instance.sprites.TryGetValue(iconId, out Sprite sprite) == false)
            {
                sprite = Create(iconId, asset, glpyhIndex);
            }

            return sprite;
        }

        private static Sprite Create(string iconId, TMP_SpriteAsset asset, int glyphIndex)
        {
            GlyphRect glyph = asset.spriteCharacterTable[glyphIndex].glyph.glyphRect;

            Rect bounds = new Rect(glyph.x, glyph.y, glyph.width, glyph.height);

            Sprite sprite = Sprite.Create(asset.material.mainTexture as Texture2D, bounds, Vector2.zero);

            instance.sprites.Add(iconId, sprite);

            return sprite;
        }

        private static string GetIconId(Platforms platform, int glyphIndex)
        {
            return string.Format("{0}.{1}", (int)platform, glyphIndex);
        }
    }
}