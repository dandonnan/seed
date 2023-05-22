namespace Seed.MonoGame.Pipeline.Processors
{
    using Microsoft.Xna.Framework.Content.Pipeline;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    using TInput = System.String;

    public class BaseListProcessor<TOutput> : ContentProcessor<TInput, List<TOutput>>
    {
        public override List<TOutput> Process(TInput input, ContentProcessorContext context)
        {
            return JsonConvert.DeserializeObject<List<TOutput>>(input);
        }
    }
}
