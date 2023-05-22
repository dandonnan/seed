namespace Seed.MonoGame.Pipeline
{
    using Microsoft.Xna.Framework.Content;
    using Newtonsoft.Json;

    public class BaseReader<TRead> : ContentTypeReader<TRead>
    {
        protected override TRead Read(ContentReader input, TRead existingInstance)
        {
            return JsonConvert.DeserializeObject<TRead>(input.ReadString());
        }
    }
}