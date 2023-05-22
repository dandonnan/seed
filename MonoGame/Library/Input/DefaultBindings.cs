namespace Seed.MonoGame.Input
{
    using Microsoft.Xna.Framework.Input;

    public class DefaultBindings
    {
        public static InputBinding Up = new InputBinding
        {
            Key = Keys.W,
            Button = Buttons.LeftThumbstickUp,
            AltKey = Keys.Up,
            AltButton = Buttons.DPadUp,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.AxisNegative,
                Index = 1,
                AltType = JoystickType.Hat,
                AltIndex = 1,
            }
        };

        public static InputBinding Down = new InputBinding
        {
            Key = Keys.S,
            Button = Buttons.LeftThumbstickDown,
            AltKey = Keys.Down,
            AltButton = Buttons.DPadDown,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.AxisPositive,
                Index = 1,
                AltType = JoystickType.Hat,
                AltIndex = 4,
            }
        };

        public static InputBinding Left = new InputBinding
        {
            Key = Keys.A,
            Button = Buttons.LeftThumbstickLeft,
            AltKey = Keys.Left,
            AltButton = Buttons.DPadLeft,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.AxisNegative,
                Index = 0,
                AltType = JoystickType.Hat,
                AltIndex = 8,
            }
        };

        public static InputBinding Right = new InputBinding
        {
            Key = Keys.D,
            Button = Buttons.LeftThumbstickRight,
            AltKey = Keys.Right,
            AltButton = Buttons.DPadRight,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.AxisPositive,
                Index = 0,
                AltType = JoystickType.Hat,
                AltIndex = 2,
            }
        };

        public static InputBinding Accept = new InputBinding
        {
            Key = Keys.Z,
            Button = Buttons.A,
            AltKey = Keys.Space,
            AltButton = Buttons.A,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.Button,
                Index = 1,
                AltType = JoystickType.Button,
                AltIndex = 1,
            }
        };

        public static InputBinding Decline = new InputBinding
        {
            Key = Keys.X,
            Button = Buttons.B,
            AltKey = Keys.Back,
            AltButton = Buttons.B,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.Button,
                Index = 2,
                AltType = JoystickType.Button,
                AltIndex = 2,
            }
        };

        public static InputBinding Pause = new InputBinding
        {
            Key = Keys.Escape,
            Button = Buttons.Start,
            AltKey = Keys.Escape,
            AltButton = Buttons.Start,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.Button,
                Index = 13,
                AltType = JoystickType.Button,
                AltIndex = 13,
            }
        };

        public static InputBinding LeftBumper = new InputBinding
        {
            Key = Keys.D1,
            Button = Buttons.LeftShoulder,
            AltKey = Keys.D1,
            AltButton = Buttons.LeftShoulder,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.Button,
                Index = 14,
                AltType = JoystickType.Button,
                AltIndex = 14,
            }
        };

        public static InputBinding RightBumper = new InputBinding
        {
            Key = Keys.D2,
            Button = Buttons.RightShoulder,
            AltKey = Keys.D2,
            AltButton = Buttons.RightShoulder,
            Joystick = new JoystickBinding
            {
                Type = JoystickType.Button,
                Index = 5,
                AltType = JoystickType.Button,
                AltIndex = 5,
            }
        };

        public static InputBinding LeftTrigger = new InputBinding
        {
            Key = Keys.Q,
            Button = Buttons.LeftTrigger,
            AltKey = Keys.Q,
            AltButton = Buttons.LeftTrigger,
            Joystick = new JoystickBinding
            {
            }
        };

        public static InputBinding RightTrigger = new InputBinding
        {
            Key = Keys.E,
            Button = Buttons.RightTrigger,
            AltKey = Keys.E,
            AltButton = Buttons.RightTrigger,
            Joystick = new JoystickBinding
            {
            }
        };

        public static InputBinding RightStickClick = new InputBinding
        {
            Key = Keys.C,
            Button = Buttons.RightStick,
            AltKey = Keys.C,
            AltButton = Buttons.RightStick,
            Joystick = new JoystickBinding
            {
            }
        };

        public static InputBinding RightStickLeft = new InputBinding
        {
            Key = Keys.O,
            Button = Buttons.RightThumbstickLeft,
            AltKey = Keys.O,
            AltButton = Buttons.RightThumbstickLeft,
            Joystick = new JoystickBinding
            {
            }
        };

        public static InputBinding RightStickRight = new InputBinding
        {
            Key = Keys.P,
            Button = Buttons.RightThumbstickRight,
            AltKey = Keys.P,
            AltButton = Buttons.RightThumbstickRight,
            Joystick = new JoystickBinding
            {
            }
        };

        public static InputBinding RightStickUp = new InputBinding
        {
            Key = Keys.I,
            Button = Buttons.RightThumbstickUp,
            AltKey = Keys.I,
            AltButton = Buttons.RightThumbstickUp,
            Joystick = new JoystickBinding
            {
            }
        };

        public static InputBinding RightStickDown = new InputBinding
        {
            Key = Keys.K,
            Button = Buttons.RightThumbstickDown,
            AltKey = Keys.K,
            AltButton = Buttons.RightThumbstickDown,
            Joystick = new JoystickBinding
            {
            }
        };
    }
}