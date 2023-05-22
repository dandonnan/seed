namespace Seed.MonoGame.Graphics
{
    using Seed.MonoGame.Extensions;
    using Seed.MonoGame.Resources.Extensions;
    using Seed.MonoGame.Resources.Graphics;
    using Seed.MonoGame.Resources.Shared;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using System.Linq;

    public class Sprite : AbstractSprite
    {
        private readonly Resources.Shared.Rectangle frame;

        private readonly Microsoft.Xna.Framework.Rectangle sourceRectangle;

        private float depthOffset;

        public Sprite(SpritePart definition)
            : base()
        {
            id = definition.Id;
            texture = GameManager.LoadTexture(definition.Texture);
            frames = definition.Frames;
            frame = frames.First();
            depthOffset = 0;
            sourceRectangle = frame.ToRectangle();
        }

        public Sprite(string texture)
            : base()
        {
            this.texture = GameManager.LoadTexture(texture);
            frame = new Resources.Shared.Rectangle { X = 0, Y = 0, Width = this.texture.Width, Height = this.texture.Height };
            frames = new List<Resources.Shared.Rectangle> { frame };
            depthOffset = 0;
            sourceRectangle = frame.ToRectangle();
        }

        public Sprite(Sprite sprite)
        {
            texture = sprite.texture;
            frame = sprite.frame.Copy();
            rotation = sprite.rotation;
            scale = sprite.scale;
            origin = sprite.origin;
            depthOffset = sprite.depthOffset;
            sourceRectangle = sprite.sourceRectangle;

            position = Vector2.Zero;
            colour = Color.White;
        }

        public override int GetWidth()
        {
            return frame.Width;
        }

        public override int GetHeight()
        {
            return frame.Height;
        }

        public override void SetDepth(float depth)
        {
            this.depth = depth + depthOffset;

            if (this.depth > 1)
            {
                this.depth = 1;
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw()
        {
            GameManager.SpriteBatch.Draw(texture, position, sourceRectangle,
                colour, rotation, origin, scale, SpriteEffects.None, depth);
        }
    }
}