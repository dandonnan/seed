namespace Seed.Extensions
{
    public static class StringExtensions
    {
        public static string GetStringAfterPoint(this string source, string point)
        {
            string newString = source;

            int index = source.ToLower().IndexOf(point.ToLower());

            if (index >= 0)
            {
                index += point.Length;

                newString = source.Substring(index);
            }

            return newString;
        }

        public static string GetStringUpToPoint(this string source, string point)
        {
            int position = source.ToLower().IndexOf(point.ToLower());

            if (position >= 0)
            {
                source = source.Substring(0, position);
            }

            return source;
        }

        public static string GetStringBetweenPoints(this string source, string points)
        {
            return source.GetStringBetweenPoints(points, points);
        }

        public static string GetStringBetweenPoints(this string source, string pointA, string pointB)
        {
            string newString = string.Empty;

            int index = source.IndexOf(pointA);

            if (index >= 0)
            {
                newString = source.Substring(index + pointA.Length);

                index = newString.IndexOf(pointB);

                if (index >= 0)
                {
                    newString = newString.Substring(0, index);
                }
            }

            return newString;
        }

        public static List<string> GetStringsAfterPoint(this string source, string point, char separator)
        {
            List<string> allStrings = new List<string>();
            string startingString = source;
            string[] strings;

            source = GetStringAfterPoint(source, point);

            if (source != startingString)
            {
                strings = source.Split(separator);

                for (int i = 0; i < strings.Length; i++)
                {
                    allStrings.Add(strings[i]);
                }
            }

            return allStrings;
        }
    }
}