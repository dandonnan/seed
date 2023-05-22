namespace Seed.MonoGame.Save
{
    public class AudioSettings
    {
        public const int DefaultVolume = 7;

        public const int MinVolume = 0;

        public const int MaxVolume = 10;

        public int MusicVolume { get; set; }

        public int SoundVolume { get; set; }
    }
}
