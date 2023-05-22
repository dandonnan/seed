namespace Seed.MonoGame.Pipeline.Processors
{
    using Seed.MonoGame.Resources.Localisation;
    using Microsoft.Xna.Framework.Content.Pipeline;

    [ContentProcessor(DisplayName = "Localised Text Processor")]
    public class LocalisedTextProcessor : BaseListProcessor<LocalisedText>
    {
    }
}
