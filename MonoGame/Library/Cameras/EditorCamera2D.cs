namespace Seed.MonoGame.Cameras
{
    using Seed.MonoGame.Input;
    using Microsoft.Xna.Framework;

    public class EditorCamera2D : ICamera
    {
        private const float minZoom = 0.25f;

        private const float maxZoom = 2f;

        private const float zoomSpeed = 0.05f;

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

        private Vector2 position;

        private Vector2 origin;

        private Vector2 center;

        private float speed;

        private float scaleX;

        private float scaleY;

        public EditorCamera2D()
        {
            speed = 1f;

            ResetViewport();
        }

        public string CameraType()
        {
            return "Editor";
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void SetTarget(Vector2 position, bool snap = false)
        {
        }

        public void SetTarget(ICameraTarget target, bool snap = false)
        {
        }

        public void Update(GameTime gameTime)
        {
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-position.X, -position.Y, 0) *
                        Matrix.CreateRotationZ(0) *
                        Matrix.CreateTranslation(origin.X / scaleX, origin.Y / scaleY, 0) *
                        Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));

            origin = center;

            HandleInput();
        }

        private void ResetViewport()
        {
            center = new Vector2(GameManager.BaseResolutionWidth / 2, GameManager.BaseResolutionHeight / 2);
            scaleX = 1;
            scaleY = 1;
        }

        private void HandleInput()
        {
            if (InputManager.IsBindingHeld(DefaultBindings.Up))
            {
                position.Y--;
            }

            if (InputManager.IsBindingHeld(DefaultBindings.Down))
            {
                position.Y++;
            }

            if (InputManager.IsBindingHeld(DefaultBindings.Left))
            {
                position.X--;
            }

            if (InputManager.IsBindingHeld(DefaultBindings.Right))
            {
                position.X++;
            }

            if (InputManager.IsBindingHeld(DefaultBindings.LeftTrigger))
            {
                ZoomOut();
            }

            if (InputManager.IsBindingHeld(DefaultBindings.RightTrigger))
            {
                ZoomIn();
            }

            if (InputManager.IsBindingPressed(DefaultBindings.RightStickClick))
            {
                ResetViewport();
            }
        }

        private void ZoomOut()
        {
            if (scaleX > minZoom)
            {
                scaleX -= zoomSpeed;
            }

            if (scaleY > minZoom)
            {
                scaleY -= zoomSpeed;
            }
        }

        private void ZoomIn()
        {
            if (scaleX < maxZoom)
            {
                scaleX += zoomSpeed;
            }

            if (scaleY < maxZoom)
            {
                scaleY += zoomSpeed;
            }
        }
    }
}
