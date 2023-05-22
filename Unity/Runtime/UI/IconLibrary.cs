namespace Seed.Unity.UI
{
    using Seed.Input;
    using Seed.Platforms;
    using Seed.Unity.Input;
    using TMPro;
    using UnityEngine;

    public class IconLibrary : MonoBehaviour
    {
        private static IconLibrary instance;

        [Header("Playstation")]
        public Sprite PS_South;

        public Sprite PS_East;

        public Sprite PS_North;

        public Sprite PS_West;

        public Sprite PS_LeftStick;

        public Sprite PS_RightStick;

        public Sprite PS_LeftBumper;

        public Sprite PS_RightBumper;

        public Sprite PS_LeftTrigger;

        public Sprite PS_RightTrigger;

        public Sprite PS_DPadLeft;

        public Sprite PS_DPadRight;

        public Sprite PS_DPadUp;

        public Sprite PS_DPadDown;

        public Sprite PS_Pause;

        public TMP_SpriteAsset PS_SpriteAsset;

        [Header("Xbox")]
        public Sprite XB_South;

        public Sprite XB_East;

        public Sprite XB_North;

        public Sprite XB_West;

        public Sprite XB_LeftStick;

        public Sprite XB_RightStick;

        public Sprite XB_LeftBumper;

        public Sprite XB_RightBumper;

        public Sprite XB_LeftTrigger;

        public Sprite XB_RightTrigger;

        public Sprite XB_DPadLeft;

        public Sprite XB_DPadRight;

        public Sprite XB_DPadUp;

        public Sprite XB_DPadDown;

        public Sprite XB_Pause;

        public TMP_SpriteAsset XB_SpriteAsset;

        [Header("Switch")]
        public Sprite NX_South;

        public Sprite NX_East;

        public Sprite NX_North;

        public Sprite NX_West;

        public Sprite NX_LeftStick;

        public Sprite NX_RightStick;

        public Sprite NX_LeftBumper;

        public Sprite NX_RightBumper;

        public Sprite NX_LeftTrigger;

        public Sprite NX_RightTrigger;

        public Sprite NX_DPadLeft;

        public Sprite NX_DPadRight;

        public Sprite NX_DPadUp;

        public Sprite NX_DPadDown;

        public Sprite NX_Pause;

        public TMP_SpriteAsset NX_SpriteAsset;

        [Header("PC")]
        public Sprite PC_South;

        public Sprite PC_East;

        public Sprite PC_North;

        public Sprite PC_West;

        public Sprite PC_LeftStick;

        public Sprite PC_RightStick;

        public Sprite PC_LeftBumper;

        public Sprite PC_RightBumper;

        public Sprite PC_LeftTrigger;

        public Sprite PC_RightTrigger;

        public Sprite PC_DPadLeft;

        public Sprite PC_DPadRight;

        public Sprite PC_DPadUp;

        public Sprite PC_DPadDown;

        public Sprite PC_Pause;

        public TMP_SpriteAsset PC_SpriteAsset;

        [Header("League")]
        public Sprite LeaguePositionUp;

        public Sprite LeaguePositionDown;

        public Sprite LeaguePositionSame;

        private void Start()
        {
            instance = this;
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

        public static string GetIcon(string iconName)
        {
            string controllerPrefix = GetControllerPrefix();
            string iconSuffix = GetSuffixFromName(iconName);

            return string.Format("{0}_icons_{1}", controllerPrefix, iconSuffix);
        }

        public static Sprite GetLeaguePositionIcon(int value)
        {
            if (value > 0)
            {
                return instance.LeaguePositionUp;
            }
            else if (value < 0)
            {
                return instance.LeaguePositionDown;
            }

            return instance.LeaguePositionSame;
        }

        private static string GetControllerPrefix()
        {
            switch (InputManager.ControllerType)
            {
                case Platforms.PlayStation5:
                    return "playstation";

                case Platforms.XboxSeries:
                    return "xbox";

                case Platforms.Switch:
                    return "switch";

                case Platforms.Itch:
                    return "pc";

                default:
                    return "xbox";
            }
        }

        private static string GetSuffixFromName(string iconName)
        {
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
        }

        private static Sprite GetSouth(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_South;

                case Platforms.XboxSeries:
                    return instance.XB_South;

                case Platforms.Switch:
                    return instance.NX_South;

                case Platforms.Itch:
                    return instance.PC_South;

                default:
                    return instance.XB_South;
            }
        }

        private static Sprite GetEast(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_East;

                case Platforms.XboxSeries:
                    return instance.XB_East;

                case Platforms.Switch:
                    return instance.NX_East;

                case Platforms.Itch:
                    return instance.PC_East;

                default:
                    return instance.XB_East;
            }
        }

        private static Sprite GetNorth(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_North;

                case Platforms.XboxSeries:
                    return instance.XB_North;

                case Platforms.Switch:
                    return instance.NX_North;

                case Platforms.Itch:
                    return instance.PC_North;

                default:
                    return instance.XB_North;
            }
        }

        private static Sprite GetWest(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_West;

                case Platforms.XboxSeries:
                    return instance.XB_West;

                case Platforms.Switch:
                    return instance.NX_West;

                case Platforms.Itch:
                    return instance.PC_West;

                default:
                    return instance.XB_West;
            }
        }

        private static Sprite GetLeftStick(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_LeftStick;

                case Platforms.XboxSeries:
                    return instance.XB_LeftStick;

                case Platforms.Switch:
                    return instance.NX_LeftStick;

                case Platforms.Itch:
                    return instance.PC_LeftStick;

                default:
                    return instance.XB_LeftStick;
            }
        }

        private static Sprite GetRightStick(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_RightStick;

                case Platforms.XboxSeries:
                    return instance.XB_RightStick;

                case Platforms.Switch:
                    return instance.NX_RightStick;

                case Platforms.Itch:
                    return instance.PC_RightStick;

                default:
                    return instance.XB_RightStick;
            }
        }

        private static Sprite GetLeftBumper(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_LeftBumper;

                case Platforms.XboxSeries:
                    return instance.XB_LeftBumper;

                case Platforms.Switch:
                    return instance.NX_LeftBumper;

                case Platforms.Itch:
                    return instance.PC_LeftBumper;

                default:
                    return instance.XB_LeftBumper;
            }
        }

        private static Sprite GetRightBumper(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_RightBumper;

                case Platforms.XboxSeries:
                    return instance.XB_RightBumper;

                case Platforms.Switch:
                    return instance.NX_RightBumper;

                case Platforms.Itch:
                    return instance.PC_RightBumper;

                default:
                    return instance.XB_RightBumper;
            }
        }

        private static Sprite GetLeftTrigger(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_LeftTrigger;

                case Platforms.XboxSeries:
                    return instance.XB_LeftTrigger;

                case Platforms.Switch:
                    return instance.NX_LeftTrigger;

                case Platforms.Itch:
                    return instance.PC_LeftTrigger;

                default:
                    return instance.XB_LeftTrigger;
            }
        }

        private static Sprite GetRightTrigger(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_RightTrigger;

                case Platforms.XboxSeries:
                    return instance.XB_RightTrigger;

                case Platforms.Switch:
                    return instance.NX_RightTrigger;

                case Platforms.Itch:
                    return instance.PC_RightTrigger;

                default:
                    return instance.XB_RightTrigger;
            }
        }

        private static Sprite GetDPadLeft(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_DPadLeft;

                case Platforms.XboxSeries:
                    return instance.XB_DPadLeft;

                case Platforms.Switch:
                    return instance.NX_DPadLeft;

                case Platforms.Itch:
                    return instance.PC_DPadLeft;

                default:
                    return instance.XB_DPadLeft;
            }
        }

        private static Sprite GetDPadRight(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_DPadRight;

                case Platforms.XboxSeries:
                    return instance.XB_DPadRight;

                case Platforms.Switch:
                    return instance.NX_DPadRight;

                case Platforms.Itch:
                    return instance.PC_DPadRight;

                default:
                    return instance.XB_DPadRight;
            }
        }

        private static Sprite GetDPadUp(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_DPadUp;

                case Platforms.XboxSeries:
                    return instance.XB_DPadUp;

                case Platforms.Switch:
                    return instance.NX_DPadUp;

                case Platforms.Itch:
                    return instance.PC_DPadUp;

                default:
                    return instance.XB_DPadUp;
            }
        }

        private static Sprite GetDPadDown(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_DPadDown;

                case Platforms.XboxSeries:
                    return instance.XB_DPadDown;

                case Platforms.Switch:
                    return instance.NX_DPadDown;

                case Platforms.Itch:
                    return instance.PC_DPadDown;

                default:
                    return instance.XB_DPadDown;
            }
        }

        private static Sprite GetPause(Platforms platform)
        {
            switch (platform)
            {
                case Platforms.PlayStation5:
                    return instance.PS_Pause;

                case Platforms.XboxSeries:
                    return instance.XB_Pause;

                case Platforms.Switch:
                    return instance.NX_Pause;

                case Platforms.Itch:
                    return instance.PC_Pause;

                default:
                    return instance.XB_Pause;
            }
        }
    }
}