namespace Seed.MonoGame.Extensions
{
    public static class StringExtensions
    {
        public static string GetIcon(this string source)
        {
            int brackets = 2;

            int index = source.IndexOf("[[ICON");

            if (index > -1)
            {
                source = source.Substring(index + brackets);

                index = source.IndexOf("]]");

                if (index > -1)
                {
                    source = source.Substring(0, index);
                }
            }

            return source;
        }
    }
}
