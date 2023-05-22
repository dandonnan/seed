namespace Seed.MonoGame.Extensions
{
    using Seed.MonoGame.Resources.Shared;
    using Microsoft.Xna.Framework;

    internal static class FrameExtensions
    {
        public static Rectangle ToRectangle(this Frame source)
        {
            return new Rectangle(source.X, source.Y, source.Width, source.Height);
        }
    }
}
