namespace Seed.MonoGame.Resources.Graphics
{
    using Seed.MonoGame.Resources.Shared;
    using System.Collections.Generic;

    public class SpriteDefinition
    {
        public string Id { get; set; }

        public string Texture { get; set; }

        public List<Frame> Frames { get; set; }
    }
}
