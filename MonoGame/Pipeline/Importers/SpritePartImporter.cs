namespace Seed.MonoGame.Pipeline.Importers
{
    using Seed.MonoGame.Pipeline.Processors;
    using Microsoft.Xna.Framework.Content.Pipeline;
    using System;
    using System.IO;

    public class SpritePartImporter : ContentImporter<String>
    {
        [ContentImporter(".spt", DisplayName = "Sprite Importer", DefaultProcessor = nameof(SpritePartProcessor))]
        public override string Import(string filename, ContentImporterContext context)
        {
            return File.ReadAllText(filename);
        }
    }
}
