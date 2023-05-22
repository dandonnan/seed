namespace Seed.MonoGame.Audio
{
    using Microsoft.Xna.Framework.Audio;
    using System.Collections.Generic;

    public class AudioLibrary
    {
        private static AudioLibrary instance;

        private readonly Dictionary<string, SoundEffect> soundEffects;

        private AudioLibrary()
        {
            soundEffects = new Dictionary<string, SoundEffect>();

            instance = this;
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                new AudioLibrary();
            }
        }

        public static SoundEffect GetSoundEffect(string id)
        {
            instance.soundEffects.TryGetValue(id, out SoundEffect soundEffect);

            return soundEffect;
        }
    }
}
