namespace Seed.Unity.Input
{
    using Seed.Events;
    using Seed.Platforms;
    using Seed.Save;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class InputManager
    {
        private static InputManager instance;

        private readonly InputActions inputActions;

        private string lastInputDeviceName;

        private Platforms controllerType;

        private float rumbleTime;

        private InputManager()
        {
            instance = this;

            inputActions = new InputActions();
            inputActions.Enable();

            SetControllerType(SystemInfo.deviceName);

            if (Application.isConsolePlatform == false)
            {
                inputActions.Menu.Get().actionTriggered += OnInputActionTriggered;
            }
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                new InputManager();
            }
        }

        public static InputActions.MenuActions Menu => instance.inputActions.Menu;

        public static InputActions.PlayerActions Player => instance.inputActions.Player;

        public static Platforms ControllerType => instance.controllerType;

        public static string DeviceName => instance.lastInputDeviceName;

        public static void Rumble(float time = 0.5f)
        {
            if (SaveManager.GameData.Controls.AllowRumble)
            {
                instance.rumbleTime = time;

                Gamepad.current?.SetMotorSpeeds(0.25f, 0.25f);
            }
        }

        public static void Update()
        {
            instance.UpdateRumble();
        }

        private void UpdateRumble()
        {
            if (rumbleTime > 0)
            {
                rumbleTime -= Time.deltaTime;

                if (rumbleTime <= 0)
                {
                    Gamepad.current?.ResetHaptics();
                }
            }
        }

        private void OnInputActionTriggered(InputAction.CallbackContext context)
        {
            string deviceName = context.control.device.name;

            if (deviceName != lastInputDeviceName)
            {
                lastInputDeviceName = deviceName;

                SetControllerType(lastInputDeviceName);

                EventManager.FireEvent(SeedEvents.InputDeviceChanged);
            }
        }

        private void SetControllerType(string device)
        {
            switch (device)
            {
                case "PS5":
                case "DualSenseGamepadHID":
                case "DualShock4GamepadHID":
                    controllerType = Platforms.PlayStation5;
                    break;

                case "XInputControllerWindows":
                    controllerType = Platforms.XboxSeries;
                    break;

                case "Keyboard":
                case "Mouse":
                    controllerType = Platforms.Itch;
                    break;

                default:
                    Debug.Log($"Unknown device {device}");
                    controllerType = Platforms.Itch;
                    break;
            }
        }
    }
}