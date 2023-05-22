namespace Seed.MonoGame.Extensions
{
    using Microsoft.Xna.Framework.Graphics;
    using System.Text;

    public static class SpriteFontExtensions
    {
        public static float CenterHorizontally(this SpriteFont source, string text)
        {
            return (GameManager.UiResolutionWidth - source.MeasureString(text).X) / 2;
        }

        public static string Wrap(this SpriteFont source, string text, int maxWidth)
        {
            string wrappedText = text;
            string fullText = text;

            if (source.MeasureString(fullText).X > maxWidth)
            {
                StringBuilder stringBuilder = new StringBuilder();

                while (source.MeasureString(fullText).X > maxWidth)
                {
                    wrappedText = fullText.Substring(0, wrappedText.Length - 1);

                    if (source.MeasureString(wrappedText).X <= maxWidth)
                    {
                        int lastSpace = wrappedText.LastIndexOf(' ');

                        if (lastSpace >= 0)
                        {
                            wrappedText = wrappedText.Substring(0, lastSpace);
                        }

                        stringBuilder.AppendLine(wrappedText);

                        fullText = fullText.Substring(wrappedText.Length + 1);
                        wrappedText = fullText;
                    }
                }

                stringBuilder.Append(fullText);

                wrappedText = stringBuilder.ToString();
            }

            return wrappedText;
        }
    }
}
