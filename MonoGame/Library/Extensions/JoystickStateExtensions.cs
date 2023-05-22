namespace Seed.MonoGame.Extensions
{
    using Seed.MonoGame.Input;
    using Microsoft.Xna.Framework.Input;

    public static class JoystickStateExtensions
    {
        internal static bool IsPressed(this JoystickState source, JoystickBinding binding)
        {
            return source.IsPressed(binding.Type, binding.Index) || source.IsPressed(binding.AltType, binding.AltIndex);
        }

        private static bool IsPressed(this JoystickState source, JoystickType type, int index)
        {
            bool pressed = false;

            if (source.IsConnected == true)
            {
                switch (type)
                {
                    case JoystickType.Button:
                        if (index < source.Buttons.Length)
                        {
                            pressed = source.Buttons[index] == ButtonState.Pressed;
                        }
                        break;

                    case JoystickType.Hat:
                        pressed = source.IsHatPressed(index);
                        break;

                    case JoystickType.AxisPositive:
                        if (index < source.Axes.Length)
                        {
                            pressed = source.Axes[index] > 10000;
                        }
                        break;

                    case JoystickType.AxisNegative:
                        if (index < source.Axes.Length)
                        {
                            pressed = source.Axes[index] < -10000;
                        }
                        break;
                }
            }

            return pressed;
        }

        private static bool IsHatPressed(this JoystickState source, int index)
        {
            bool pressed = false;

            switch (index)
            {
                case 1:
                    pressed = source.Hats[0].Up == ButtonState.Pressed;
                    break;

                case 2:
                    pressed = source.Hats[0].Right == ButtonState.Pressed;
                    break;

                case 4:
                    pressed = source.Hats[0].Down == ButtonState.Pressed;
                    break;

                case 8:
                    pressed = source.Hats[0].Left == ButtonState.Pressed;
                    break;

                default:
                    break;
            }

            return pressed;
        }
    }
}
