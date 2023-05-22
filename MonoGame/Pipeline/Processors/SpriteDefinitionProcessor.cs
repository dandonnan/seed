namespace Seed.MonoGame.Pipeline.Processors
{
    using Seed.MonoGame.Resources.Graphics;
    using Microsoft.Xna.Framework.Content.Pipeline;

    [ContentProcessor(DisplayName = "Sprite Processor")]
    public class SpriteDefinitionProcessor : BaseListProcessor<SpriteDefinition>
    {
    }
}
