namespace Seed.MonoGame.Pipeline.Writers
{
    using Seed.MonoGame.Resources.Localisation;

    public class LocalisedTextWriter : BaseListWriter<LocalisedText>
    {
        public LocalisedTextWriter()
            : base("LocalisedTextReader")
        {
        }
    }
}
