namespace Seed.MonoGame.Cameras
{
    using Seed.MonoGame.Extensions;
    using Microsoft.Xna.Framework;

    public class FollowCamera2D : ICamera
    {
        public Matrix Transform { get; set; }

        public Vector2 Position
        {
            get => position;
            set { }
        }

        public Vector2 Origin
        {
            get => origin;
            set { }
        }

        private float speed;

        private ICameraTarget objectToFollow;

        private Vector2 position;

        private Vector2 origin;

        private Vector2 center;

        private bool followingObject;

        private float scaleX;

        private float scaleY;

        public FollowCamera2D()
        {
            followingObject = false;
            speed = 1f;
            scaleX = 1;
            scaleY = 1;

            UpdateViewport();
        }

        public string CameraType()
        {
            return "Follow";
        }

        public void SetTarget(ICameraTarget target, bool snap = false)
        {
            objectToFollow = target;

            followingObject = target != null;

            if (snap)
            {
                position = target.Position;
            }

            UpdateViewport();
        }

        public void SetTarget(Vector2 position, bool snap = false)
        {
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void UpdateViewport()
        {
            if (objectToFollow != null)
            {
                center = new Vector2((GameManager.BaseResolutionWidth - objectToFollow.Origin.X) / 2,
                                    (GameManager.BaseResolutionHeight - objectToFollow.Origin.Y) / 2);
            }
        }

        public void Update(GameTime gameTime)
        {
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-position.X, -position.Y, 0) *
                        Matrix.CreateRotationZ(0) *
                        Matrix.CreateTranslation(origin.X / scaleX, origin.Y / scaleY, 0) *
                        Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));

            origin = center;

            if (followingObject)
            {
                if (position != objectToFollow.Position)
                {
                    position = position.MoveToTarget(objectToFollow.Position, speed, (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
        }
    }
}