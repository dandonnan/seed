namespace Seed.MonoGame.Pipeline.Importers
{
    using Seed.MonoGame.Pipeline.Processors;
    using Microsoft.Xna.Framework.Content.Pipeline;
    using System;
    using System.IO;

    public class SpriteDefinitionImporter : ContentImporter<String>
    {
        [ContentImporter(".spd", DisplayName = "Sprite Importer", DefaultProcessor = nameof(SpriteDefinitionProcessor))]
        public override string Import(string filename, ContentImporterContext context)
        {
            return File.ReadAllText(filename);
        }
    }
}
