namespace Seed.Achievements
{
    using Seed.Platforms;
    using Seed.Save;
    using System.Collections.Generic;
    using System.Linq;

    public class AchievementManager
    {
        private static AchievementManager instance;

        private readonly Dictionary<string, Achievement> achievements;

        private AchievementManager()
        {
            instance = this;

            achievements = SaveManager.GameData.Achievements.ToDictionary(a => a.Id);
        }

        public static void Initialise()
        {
            new AchievementManager();
        }

        public static Achievement[] GetAchievements()
        {
            Achievement[] achievements;

            if (instance != null)
            {
                achievements = instance.achievements.Values.ToArray();
            }
            else
            {
                achievements = new Achievement[0];
            }

            return achievements;
        }

        public static void SetProgress(string achievementId, int progress)
        {
            UpdateProgress(achievementId, progress, increment: false);
        }

        public static void AddProgress(string achievementId, int progress)
        {
            UpdateProgress(achievementId, progress, increment: true);
        }

        public static void Unlock(string achievementId)
        {
            if (instance.achievements.TryGetValue(achievementId, out Achievement achievement))
            {
                achievement.Completed = true;

                PlatformManager.Platform.UnlockAchievement(achievementId);
            }
        }

        private static void UpdateProgress(string achievementId, int progress, bool increment = false)
        {
            if (instance.achievements.TryGetValue(achievementId, out Achievement achievement))
            {
                if (achievement.Completed == false)
                {
                    if (increment)
                    {
                        achievement.CurrentProgress += progress;
                    }
                    else
                    {
                        achievement.CurrentProgress = progress;
                    }

                    PlatformManager.Platform.SetAchievementProgress(achievementId, achievement.CurrentProgress);

                    if (achievement.CurrentProgress >= achievement.Target)
                    {
                        achievement.Completed = true;

                        PlatformManager.Platform.UnlockAchievement(achievementId);
                    }
                }
            }
        }
    }
}
