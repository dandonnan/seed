namespace Seed.MonoGame.Pipeline.Writers
{
    using Seed.MonoGame.Resources.Graphics;

    public class SpritePartWriter : BaseListWriter<SpritePart>
    {
        public SpritePartWriter()
            : base("SpritePartReader")
        {
        }
    }
}
