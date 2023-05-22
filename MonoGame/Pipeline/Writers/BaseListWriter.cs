namespace Seed.MonoGame.Pipeline.Writers
{
    using Microsoft.Xna.Framework.Content.Pipeline;
    using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BaseListWriter<TWrite> : ContentTypeWriter<List<TWrite>>
    {
        private readonly string mainNamespace;

        public BaseListWriter(string mainProjectNamespace)
        {
            mainNamespace = string.Format("Seed.MonoGame.Pipeline.{0}, Seed.MonoGame", mainProjectNamespace);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return mainNamespace;
        }

        protected override void Write(ContentWriter output, List<TWrite> value)
        {
            output.Write(JsonConvert.SerializeObject(value));
        }
    }
}
