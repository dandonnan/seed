namespace Seed.Unity.Platforms
{
    using Seed.Input;
    using Seed.Platforms;
    using Seed.Save;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlatformStandalonePC : IPlatform
    {
        public void Update()
        {
        }

        public void Stop()
        {
        }

        public string GetPlatformName()
        {
            return "PC";
        }

        public string GetPlatformVersion()
        {
            return Application.version;
        }

        public bool IsPC()
        {
            return true;
        }

        public bool IsConsole()
        {
            return false;
        }

        public string GetSaveFileName()
        {
            return string.Empty;
        }

        public void SaveData(string serialisedData)
        {
        }

        public IGameSaveData LoadGameData()
        {
            return null;
        }

        public void UnlockAchievement(string achievementId)
        {
        }

        public void SetAchievementProgress(string achievementId, int progress)
        {
        }

        public void ResetAchievements()
        {
        }

        public bool HasAchievement(string achievementId)
        {
            return false;
        }

        public float GetAchievementProgress(string achievementId)
        {
            return 0;
        }

        public void OpenStore()
        {
        }

        public void OpenStoreOnAppPage()
        {
        }

        public void SetRichPresence(string richPresence)
        {
        }

        public void ClearRichPresence()
        {
        }

        public void SetControllerColour(ControllerColours colour)
        {
        }

        public void SetControllerColourToDefault()
        {
        }

        public string GetDefaultResolution()
        {
            return "1280x720";
        }

        public List<string> GetPlatformResolutions()
        {
            return null;
        }
    }
}