namespace Seed.MonoGame.Save
{
    using Seed.MonoGame.Graphics;

    public class GraphicsSettings
    {
        public bool Fullscreen => ScreenSize == (int)ScreenSizes.Fullscreen;

        public bool Bordered => ScreenSize == (int)ScreenSizes.Borderless;

        public int ResolutionWidth => int.Parse(Resolution.Substring(0, Resolution.IndexOf('x')));

        public int ResolutionHeight => int.Parse(Resolution.Substring(Resolution.IndexOf('x') + 1));

        public string Resolution { get; set; }

        public int ScreenSize { get; set; }
    }
}
