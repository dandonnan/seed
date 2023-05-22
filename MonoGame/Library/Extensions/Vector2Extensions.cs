namespace Seed.MonoGame.Extensions
{
    using Microsoft.Xna.Framework;
    using System;

    public static class Vector2Extensions
    {
        public static Vector2 MoveToTarget(this Vector2 source, Vector2 targetPosition, float speed, float delta)
        {
            float moveX = (targetPosition.X - source.X) * speed * delta;
            float moveY = (targetPosition.Y - source.Y) * speed * delta;

            moveX = moveX > 1 || moveX < -1 ? moveX : Math.Sign(moveX) * 1;
            moveY = moveY > 1 || moveY < -1 ? moveY : Math.Sign(moveY) * 1;

            source.X += moveX;
            source.Y += moveY;

            if (source.X <= targetPosition.X + speed
                && source.X >= targetPosition.X - speed
                && source.Y <= targetPosition.Y + speed
                && source.Y >= targetPosition.Y - speed)
            {
                source = targetPosition;
            }

            return source;
        }
    }
}
