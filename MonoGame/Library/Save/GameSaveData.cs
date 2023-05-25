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

        public BaseAudioOptions Audio { get; set; }

        public BaseGraphicsOptions Graphics { get; set; }

        public BaseControlsOptions Controls { get; set; }

        public GameSaveData()
        {
            SetToDefault();
        }

        private void SetToDefault()
        {
            //Language = SupportedLanguages.GetCultureLanguageCodeOrDefault();

            Audio = new BaseAudioOptions();
            Graphics = new BaseGraphicsOptions();
            Controls = new BaseControlsOptions();

            Audio.SetToDefault();
            Graphics.SetToDefault();
            Controls.SetToDefault();

            SetupAchievements();
        }

        private void SetupAchievements()
        {
            // todo: achievements
            //Achievements[0] = new Achievement(KnownAchievements.BuyCostume);
        }
    }
}
