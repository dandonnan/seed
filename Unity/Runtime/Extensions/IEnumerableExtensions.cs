namespace Seed.Unity.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class IEnumerableExtensions
    {
        public static T GetRandom<T>(this IEnumerable<T> source)
        {
            if (source != null)
            {
                int random = Random.Range(0, source.Count());

                return source.ElementAt(random);
            }

            return default(T);
        }
    }
}