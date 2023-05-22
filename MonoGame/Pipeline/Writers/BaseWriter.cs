namespace Seed.MonoGame.Pipeline.Writers
{
    using Microsoft.Xna.Framework.Content.Pipeline;
    using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
    using Newtonsoft.Json;

    public class BaseWriter<TWrite> : ContentTypeWriter<TWrite>
    {
        private readonly string mainNamespace;

        public BaseWriter(string mainProjectNamespace)
        {
            mainNamespace = string.Format("Seed.MonoGame.Pipeline.{0}, Seed.MonoGame", mainProjectNamespace);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return mainNamespace;
        }

        protected override void Write(ContentWriter output, TWrite value)
        {
            output.Write(JsonConvert.SerializeObject(value));
        }
    }
}
