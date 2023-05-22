namespace Seed.MonoGame.Pipeline.Processors
{
    using Microsoft.Xna.Framework.Content.Pipeline;
    using Newtonsoft.Json;

    using TInput = System.String;

    public class BaseProcessor<TOutput> : ContentProcessor<TInput, TOutput>
    {
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            return JsonConvert.DeserializeObject<TOutput>(input);
        }
    }
}
