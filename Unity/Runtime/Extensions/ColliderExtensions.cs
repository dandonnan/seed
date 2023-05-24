namespace Seed.Unity.Extensions
{
    using UnityEngine;

    public static class ColliderExtensions
    {
        public static bool CollidedWithPlayer(this Collider source)
        {
            return source.CompareTag("Player");
        }
    }
}