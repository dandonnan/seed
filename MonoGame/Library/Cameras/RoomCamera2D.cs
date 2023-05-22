namespace Seed.MonoGame.Cameras
{
    using Microsoft.Xna.Framework;

    public class RoomCamera2D : ICamera
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

        private readonly Vector2 origin;

        private Vector2 targetPosition;

        private Vector2 position;

        private float scaleX;

        private float scaleY;

        private bool transitioning;

        public RoomCamera2D()
        {
            position = Vector2.Zero;
            targetPosition = position;
            transitioning = false;
            speed = 50f;
            scaleX = 1;
            scaleY = 1;

            origin = Vector2.Zero;
        }

        public bool Transitioning => transitioning;

        public string CameraType()
        {
            return "Room";
        }

        public void SetTarget(Vector2 target, bool snap = false)
        {
            targetPosition = target;

            if (snap)
            {
                position = targetPosition;
            }
        }

        public void SetTarget(ICameraTarget target, bool snap = false)
        {
            targetPosition = target.Position;

            if (snap)
            {
                position = targetPosition;
            }
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-position.X, -position.Y, 0) *
                        Matrix.CreateRotationZ(0) *
                        Matrix.CreateTranslation(origin.X / scaleX, origin.Y / scaleY, 0) *
                        Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));

            if (position != targetPosition)
            {
                transitioning = true;

                MoveToPosition();
            }
        }

        internal void MoveToPosition()
        {
            if (position.X > targetPosition.X + 1)
            {
                position.X -= speed;
            }

            if (position.X < targetPosition.X - 1)
            {
                position.X += speed;
            }

            if (position.Y > targetPosition.Y + 1)
            {
                position.Y -= speed;
            }

            if (position.Y < targetPosition.Y - 1)
            {
                position.Y += speed;
            }

            if (position.X >= targetPosition.X - speed && position.X <= targetPosition.X + speed
                && position.Y >= targetPosition.Y - speed && position.Y <= targetPosition.Y + speed)
            {
                transitioning = false;
                position = targetPosition;
            }
        }
    }
}
