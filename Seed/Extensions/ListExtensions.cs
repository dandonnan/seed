namespace Seed.Extensions
{
    public static class ListExtensions
    {
        public static void Move<T>(this List<T> source, int fromIndex, int toIndex)
        {
            if (fromIndex < source.Count && toIndex < source.Count)
            {
                T obj = source[fromIndex];
                source.RemoveAt(fromIndex);
                source.Insert(toIndex, obj);
            }
        }
    }
}