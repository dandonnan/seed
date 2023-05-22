namespace Seed.MonoGame.Cameras
{
    using Microsoft.Xna.Framework;

    public interface ICamera
    {
        Matrix Transform { get; set; }

        Vector2 Position { get; set; }

        Vector2 Origin { get; set; }

        string CameraType();

        void SetSpeed(float speed);

        void SetTarget(Vector2 position, bool snap = false);

        void SetTarget(ICameraTarget target, bool snap = false);

        void Update(GameTime gameTime);
    }
}
