namespace Seed.Save
{
    using Seed.Graphics;

    public class BaseGraphicsOptions
    {
        public const string DefaultResolutionFormat = "{0}x{1}";

        public int ResolutionWidth { get; set; }

        public int ResolutionHeight { get; set; }

        public int WindowMode { get; set; }

        public WindowMode ScreenMode
        {
            get { return (WindowMode)WindowMode; }
            set { WindowMode = (int)value; }
        }

        public virtual void SetToDefault()
        {
            ResolutionWidth = 1280;
            ResolutionHeight = 720;
            ScreenMode = Graphics.WindowMode.Windowed;
        }

        public virtual string GetResolution(string format = "")
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = DefaultResolutionFormat;
            }

            return string.Format(format, ResolutionWidth, ResolutionHeight);
        }
    }
}
