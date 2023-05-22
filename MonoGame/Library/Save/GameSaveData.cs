namespace Seed.MonoGame.Save
{
    using Seed.MonoGame.Achievements;
    using Seed.MonoGame.Localisation;

    public class GameSaveData
    {
        private const int achievements = 0;

        public string Language { get; set; }

        public Achievement[] Achievements { get; set; }
            = new Achievement[achievements];

        public AudioSettings Audio { get; set; }

        public GameSaveData()
        {
            SetToDefault();
        }

        private void SetToDefault()
        {
            Language = SupportedLanguages.GetCultureLanguageCodeOrDefault();

            Audio = new AudioSettings
            {
                MusicVolume = AudioSettings.DefaultVolume,
                SoundVolume = AudioSettings.DefaultVolume,
            };

            SetupAchievements();
        }

        private void SetupAchievements()
        {
            // todo: achievements
            //Achievements[0] = new Achievement(KnownAchievements.BuyCostume);
        }
    }
}
