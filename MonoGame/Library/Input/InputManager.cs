namespace Seed.MonoGame.Input
{
    using Seed.MonoGame.Extensions;
    using Seed.MonoGame.Platforms;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    public class InputManager
    {
        private static InputManager instance;

        private readonly List<Keys> capturedKeys;

        private readonly List<Buttons> capturedButtons;

        private KeyboardState keyState;

        private KeyboardState lastKeyState;

        private GamePadState[] padState;

        private GamePadState[] lastPadState;

        private MouseState mouseState;

        private MouseState lastMouseState;

        private JoystickState joystickState;

        private JoystickState lastJoystickState;

        private InputMethod inputMethod;

        private string controllerId;

        public delegate void InputChanged(string controllerId);

        public event InputChanged OnInputChanged;

        private InputManager()
        {
            instance = this;

            padState = new GamePadState[GamePad.MaximumGamePadCount];

            capturedKeys = new List<Keys>();
            capturedButtons = new List<Buttons>();

            if (PlatformManager.Platform.IsPC())
            {
                inputMethod = InputMethod.Keyboard;
            }
            else
            {
                inputMethod = InputMethod.Gamepad;
            }
        }

        public static InputManager Initialise()
        {
            if (instance == null)
            {
                new InputManager();
            }

            return instance;
        }

        public void Update()
        {
            lastKeyState = keyState;
            lastPadState = padState;
            lastMouseState = mouseState;
            lastJoystickState = joystickState;

            capturedKeys.Clear();
            capturedButtons.Clear();

            keyState = Keyboard.GetState();

            for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
            {
                padState[i] = GamePad.GetState(i);
            }

            joystickState = Joystick.GetState(0);

            if (keyState != lastKeyState)
            {
                ChangeInput(InputMethod.Keyboard, "pc");
            }
            else if (padState != lastPadState)
            {
                ChangeInput(InputMethod.Gamepad, GamePad.GetCapabilities(PlayerIndex.One).Identifier);
            }
            else if (joystickState != lastJoystickState)
            {
                ChangeInput(InputMethod.Gamepad, Joystick.GetCapabilities(0).Identifier);
            }
        }

        public static InputMethod LastInputMethod()
        {
            return instance.inputMethod;
        }

        public static string GetInputIconFile()
        {
            string inputPlatform = PlatformManager.Platform.GetIconFile();

            if (instance.controllerId != null &&
                Controllers.Definitions.TryGetValue(instance.controllerId, out string platform))
            {
                inputPlatform = platform;
            }

            return inputPlatform;
        }

        public static bool IsBindingPressed(InputBinding binding, int index = 0, bool capture = false)
        {
            bool isPressed = IsKeyDown(binding) || IsButtonDown(binding, index) || IsJoystickDown(binding);

            if (isPressed && capture)
            {
                instance.capturedKeys.Add(binding.Key);
                instance.capturedKeys.Add(binding.AltKey);
                instance.capturedButtons.Add(binding.Button);
                instance.capturedButtons.Add(binding.AltButton);
            }

            return isPressed;
        }

        public static bool IsBindingHeld(InputBinding binding, int index = 0)
        {
            return IsKeyHeld(binding) || IsButtonHeld(binding, index) || IsJoystickHeld(binding);
        }

        public static bool IsLeftMousePressed()
        {
            return instance.mouseState.LeftButton == ButtonState.Pressed
                && instance.lastMouseState.LeftButton != ButtonState.Pressed;
        }

        public static bool IsLeftMouseHeld()
        {
            return instance.mouseState.LeftButton == ButtonState.Pressed
                && instance.lastMouseState.LeftButton == ButtonState.Pressed;
        }

        public static Point GetMousePosition()
        {
            return instance.mouseState.Position;
        }

        private static bool IsKeyDown(InputBinding binding)
        {
            return (instance.keyState.IsKeyDown(binding.Key)
                    || instance.keyState.IsKeyDown(binding.AltKey))
                    && instance.capturedKeys.Contains(binding.Key) == false
                    && instance.capturedKeys.Contains(binding.AltKey) == false
                    && instance.lastKeyState.IsKeyDown(binding.Key) == false
                    && instance.lastKeyState.IsKeyDown(binding.AltKey) == false;
        }

        private static bool IsKeyHeld(InputBinding binding)
        {
            return (instance.keyState.IsKeyDown(binding.Key)
                    || instance.keyState.IsKeyDown(binding.AltKey))
                    && (instance.lastKeyState.IsKeyDown(binding.Key)
                    || instance.lastKeyState.IsKeyDown(binding.AltKey));
        }

        private static bool IsButtonDown(InputBinding binding, int index)
        {
            return (instance.padState[index].IsButtonDown(binding.Button)
                    || instance.padState[index].IsButtonDown(binding.AltButton))
                    && instance.capturedButtons.Contains(binding.Button) == false
                    && instance.capturedButtons.Contains(binding.AltButton) == false
                    && instance.lastPadState[index].IsButtonDown(binding.Button) == false
                    && instance.lastPadState[index].IsButtonDown(binding.AltButton) == false;
        }

        private static bool IsButtonHeld(InputBinding binding, int index)
        {
            return (instance.padState[index].IsButtonDown(binding.Button)
                    || instance.padState[index].IsButtonDown(binding.AltButton))
                    && (instance.lastPadState[index].IsButtonDown(binding.Button)
                    || instance.lastPadState[index].IsButtonDown(binding.AltButton));
        }

        private static bool IsJoystickDown(InputBinding binding)
        {
            return instance.joystickState.IsPressed(binding.Joystick)
                    && instance.lastJoystickState.IsPressed(binding.Joystick) == false;
        }

        private static bool IsJoystickHeld(InputBinding binding)
        {
            return instance.joystickState.IsPressed(binding.Joystick)
                    && instance.lastJoystickState.IsPressed(binding.Joystick);
        }

        private void ChangeInput(InputMethod inputMethod, string controllerId)
        {
            instance.controllerId = controllerId;

            instance.inputMethod = inputMethod;

            OnInputChanged?.Invoke(controllerId);
        }
    }
}