namespace Seed.MonoGame.Resources.Extensions
{
    using Seed.MonoGame.Resources.Shared;

    public static class RectangleExtensions
    {
        public static Rectangle Copy(this Rectangle source)
        {
            return new Rectangle
            {
                X = source.X,
                Y = source.Y,
                Width = source.Width,
                Height = source.Height
            };
        }
    }
}
