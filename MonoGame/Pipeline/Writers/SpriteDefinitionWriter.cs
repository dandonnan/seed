namespace Seed.MonoGame.Pipeline.Writers
{
    using Seed.MonoGame.Resources.Graphics;

    public class SpriteDefinitionWriter : BaseListWriter<SpriteDefinition>
    {
        public SpriteDefinitionWriter()
            : base("SpriteDefinitionReader")
        {
        }
    }
}
