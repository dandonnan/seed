namespace Seed.Platforms
{
    using Seed.Input;
    using Seed.Save;
    using System.Collections.Generic;

    public interface IPlatform
    {
        void Update();

        void Stop();

        string GetPlatformName();

        string GetPlatformVersion();

        bool IsPC();

        bool IsConsole();

        string GetSaveFileName();

        void SaveData(string serialisedData);

        IGameSaveData LoadGameData();

        void UnlockAchievement(string achievementId);

        void SetAchievementProgress(string achievementId, int progress);

        void ResetAchievements();

        bool HasAchievement(string achievementId);

        float GetAchievementProgress(string achievementId);

        void OpenStore();

        void OpenStoreOnAppPage();

        void SetRichPresence(string richPresence);

        void ClearRichPresence();

        void SetControllerColour(ControllerColours colour);

        void SetControllerColourToDefault();

        string GetDefaultResolution();

        List<string> GetPlatformResolutions();
    }
}
