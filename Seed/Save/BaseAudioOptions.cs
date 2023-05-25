namespace Seed.Save
{
    public class BaseAudioOptions
    {
        public int SoundVolume { get; set; }

        public int MusicVolume { get; set; }

        public virtual void SetToDefault()
        {
            SoundVolume = 5;
            MusicVolume = 5;
        }
    }
}
