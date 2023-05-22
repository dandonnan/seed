namespace Seed.MonoGame.Graphics
{
    using Seed.MonoGame.Resources.Shared;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public abstract class AbstractSprite
    {
        public string Id => id;

        public Vector2 Position => position;

        public Vector2 Origin => origin;

        public float Rotation => MathHelper.ToDegrees(rotation);

        public Vector2 Scale => scale;

        protected string id;

        protected Texture2D texture;

        protected Vector2 position;

        protected float rotation;

        protected Vector2 scale;

        protected Vector2 origin;

        protected float depth;

        protected Color colour;

        protected List<Frame> frames;

        public AbstractSprite()
        {
            rotation = 0;
            depth = 0;
            scale = Vector2.One;
            origin = Vector2.Zero;
            colour = Color.White;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void Move(Vector2 position)
        {
            this.position += position;
        }

        public void Move(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }

        public void SetRotation(float rotation)
        {
            this.rotation = MathHelper.ToRadians(rotation);
        }

        public void Rotate(float rotation)
        {
            this.rotation += MathHelper.ToRadians(rotation);
        }

        public void SetScale(float scale)
        {
            this.scale.X = scale;
            this.scale.Y = scale;
        }

        public void SetScale(Vector2 scale)
        {
            this.scale = scale;
        }

        public void SetOrigin(Vector2 origin)
        {
            this.origin = origin;
        }

        public void SetColour(Color colour)
        {
            this.colour = colour;
        }

        public virtual void SetDepth(float depth)
        {
            this.depth = depth;
        }

        public abstract int GetWidth();

        public abstract int GetHeight();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw();
    }
}
