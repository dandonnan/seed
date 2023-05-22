namespace Seed.MonoGame.Pipeline
{
    using Microsoft.Xna.Framework.Content;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BaseListReader<TRead> : ContentTypeReader<List<TRead>>
    {
        protected override List<TRead> Read(ContentReader input, List<TRead> existingInstance)
        {
            return JsonConvert.DeserializeObject<List<TRead>>(input.ReadString());
        }
    }
}