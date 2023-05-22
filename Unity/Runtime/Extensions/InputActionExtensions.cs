namespace Seed.Unity.Extensions
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public static class InputActionExtensions
    {
        public static bool WasCapturedThisFrame(this InputAction source)
        {
            bool captured = source.WasPressedThisFrame();

            if (captured)
            {
                source.Reset();
            }

            return captured;
        }

        public static bool WasPressedThisFrame(this InputAction source, out Vector2 value)
        {
            bool pressed = source.WasPressedThisFrame();

            value = Vector2.zero;

            if (pressed)
            {
                value = source.ReadValue<Vector2>();
            }

            return pressed;
        }
    }
}