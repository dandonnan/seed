namespace Seed.MonoGame.Pipeline.Importers
{
    using Seed.MonoGame.Pipeline.Processors;
    using Microsoft.Xna.Framework.Content.Pipeline;
    using System;
    using System.IO;

    public class LocalisedTextImporter : ContentImporter<String>
    {
        [ContentImporter(".loc", DisplayName = "Localised Text Importer", DefaultProcessor = nameof(LocalisedTextProcessor))]
        public override string Import(string filename, ContentImporterContext context)
        {
            return File.ReadAllText(filename);
        }
    }
}
