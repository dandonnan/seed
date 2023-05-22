namespace Seed.MonoGame.Extensions
{
    using Seed.MonoGame.Graphics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public static class SpriteBatchExtensions
    {
        private static Texture2D blankTexture;

        public static void DrawLine(this SpriteBatch source, Vector2 start, Vector2 end, Color colour)
        {
            float length = (end - start).Length();
            float rotation = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            source.Draw(GetBlankTexture(Color.White), start, null, colour, rotation, Vector2.Zero, new Vector2(length, 1), SpriteEffects.None, 0);
        }

        public static void DrawLine(this SpriteBatch source, Line line, Color colour)
        {
            source.Draw(GetBlankTexture(Color.White), line.Start, null, colour, line.Rotation, Vector2.Zero, line.Scale, SpriteEffects.None, 0);
        }

        public static void DrawRectangle(this SpriteBatch source, Rectangle rectangle, Color colour)
        {
            source.Draw(GetBlankTexture(Color.White), new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), colour);
            source.Draw(GetBlankTexture(Color.White), new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), colour);
            source.Draw(GetBlankTexture(Color.White), new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), colour);
            source.Draw(GetBlankTexture(Color.White), new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height + 1), colour);
        }

        public static void FillRectangle(this SpriteBatch source, Rectangle rectangle, Color colour)
        {
            source.Draw(GetBlankTexture(Color.White), rectangle, rectangle, colour, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        private static Texture2D GetBlankTexture(Color colour)
        {
            if (blankTexture == null)
            {
                blankTexture = new Texture2D(GameManager.SpriteBatch.GraphicsDevice, 1, 1);
                blankTexture.SetData(new Color[] { colour });
            }

            return blankTexture;
        }
    }
}
