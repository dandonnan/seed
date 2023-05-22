namespace Seed.MonoGame.Resources.Graphics
{
    using System.Collections.Generic;

    public class SpriteParts
    {
        public string Id { get; set; }

        public string Texture { get; set; }

        public List<SpritePart> Sprites { get; set; }

        public List<SpriteAnimation> Animations { get; set; }
    }
}
