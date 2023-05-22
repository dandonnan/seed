namespace Seed.MonoGame.Resources.Extensions
{
    using Seed.MonoGame.Resources.Shared;

    public static class FrameExtensions
    {
        public static Frame Copy(this Frame source)
        {
            return new Frame
            {
                X = source.X,
                Y = source.Y,
                Width = source.Width,
                Height = source.Height
            };
        }
    }
}
