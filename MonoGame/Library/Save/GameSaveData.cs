namespace Seed.MonoGame.Save
{
    using Seed.Achievements;
    using Seed.Save;

    public class GameSaveData : IGameSaveData
    {
        private const int numberOfAchievements = 0;

        public string Language { get; set; }

        public List<Achievement> Achievements
        {
            get { return achievements.ToList(); }
            set { achievements = value.ToArray(); }
        }

        private Achievement[] achievements { get; set; }
            = new Achievement[numberOfAchievements];

        public AudioSettings Audio { get; set; }

        public GameSaveData()
        {
            SetToDefault();
        }

        public bool AllowRumble()
        {
            return false;
        }

        private void SetToDefault()
        {
            //Language = SupportedLanguages.GetCultureLanguageCodeOrDefault();

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
