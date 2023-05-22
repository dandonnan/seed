namespace Seed.MonoGame.Cameras
{
    using Microsoft.Xna.Framework;

    public interface ICameraTarget
    {
        Vector2 Position { get; }

        Vector2 Origin { get; }
    }
}
