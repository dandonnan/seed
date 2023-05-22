namespace Seed.MonoGame.Graphics
{
    using Microsoft.Xna.Framework;
    using System;

    internal class Line
    {
        public float Length { get; private set; }

        public float Rotation { get; private set; }

        public Vector2 Start { get; private set; }

        public Vector2 Scale { get; private set; }

        public Line(Vector2 start, Vector2 end)
        {
            Length = (end - start).Length();
            Rotation = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            Start = start;
            Scale = new Vector2(Length, 1);
        }
    }
}
