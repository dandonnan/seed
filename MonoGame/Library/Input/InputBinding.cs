namespace Seed.MonoGame.Input
{
    using Microsoft.Xna.Framework.Input;

    public class InputBinding
    {
        public string Name { get; set; }

        public Keys Key { get; set; }

        public Buttons Button { get; set; }

        public Keys AltKey { get; set; }

        public Buttons AltButton { get; set; }

        public JoystickBinding Joystick { get; set; }
    }
}
