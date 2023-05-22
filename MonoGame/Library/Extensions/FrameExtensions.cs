namespace Seed.MonoGame.Extensions
{
    using Seed.MonoGame.Resources.Shared;
    using Microsoft.Xna.Framework;

    internal static class FrameExtensions
    {
        public static Microsoft.Xna.Framework.Rectangle ToRectangle(this Resources.Shared.Rectangle source)
        {
            return new Microsoft.Xna.Framework.Rectangle(source.X, source.Y, source.Width, source.Height);
        }
    }
}
