namespace Seed.MonoGame.Resources.Graphics
{
    using Seed.MonoGame.Resources.Shared;
    using System.Collections.Generic;

    public class SpritePart
    {
        public string Id { get; set; }

        public string Texture { get; set; }

        public List<Rectangle> Frames { get; set; }
    }
}
