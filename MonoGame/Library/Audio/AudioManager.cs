namespace Seed.MonoGame.Audio
{
    using Seed.MonoGame.Save;
    using Microsoft.Xna.Framework.Audio;
    using System.Collections.Generic;

    public class AudioManager
    {
        private static AudioManager instance;

        private Dictionary<string, SoundEffectInstance> loopingSounds;

        private AudioManager()
        {
            loopingSounds = new Dictionary<string, SoundEffectInstance>();

            instance = this;
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                new AudioManager();
            }
        }

        public static void PlaySoundEffect(string id)
        {
            SoundEffect soundEffect = AudioLibrary.GetSoundEffect(id);

            if (soundEffect != null)
            {
                soundEffect.Play(GetSoundVolume(), 0, 0);
            }
        }

        public static void PlaySoundEffect(SoundEffect soundEffect)
        {
            soundEffect.Play(GetSoundVolume(), 0, 0);
        }

        public static void PlayLoopingSoundEffect(string id)
        {
            SoundEffect soundEffect = AudioLibrary.GetSoundEffect(id);

            if (soundEffect != null && instance.loopingSounds.ContainsKey(id) == false)
            {
                SoundEffectInstance instance = soundEffect.CreateInstance();
                instance.IsLooped = true;
                instance.Volume = GetSoundVolume();
                instance.Play();

                AudioManager.instance.loopingSounds.Add(id, instance);
            }
        }

        public static bool IsLoopingSoundPlaying(string id)
        {
            return instance.loopingSounds.ContainsKey(id);
        }

        public static void StopLoopingSoundEffect(string id)
        {
            instance.loopingSounds.TryGetValue(id, out SoundEffectInstance soundEffect);

            if (soundEffect != null)
            {
                soundEffect.Stop();
                instance.loopingSounds.Remove(id);
            }
        }

        public static void ChangeVolume()
        {
            foreach (SoundEffectInstance sound in instance.loopingSounds.Values)
            {
                sound.Volume = GetSoundVolume();
            }
        }

        private static float GetMusicVolume()
        {
            return (float)SaveManager.GameData.Audio.MusicVolume / 10;
        }

        private static float GetSoundVolume()
        {
            return (float)SaveManager.GameData.Audio.SoundVolume / 10;
        }
    }
}