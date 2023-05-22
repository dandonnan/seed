namespace Seed.MonoGame.Save
{
    using Seed.Achievements;
    using Newtonsoft.Json;
    using System.IO;
    using Seed.Platforms;

    public class SaveManager
    {
        private const string MachineFile = "[[NamespaceToLower]].lcl";

        private static SaveManager instance;

        private GameSaveData gameData;

        private MachineSaveData machineData;

        private MappedInputs mappedInputs;

        private SaveManager()
        {
            instance = this;

            Load();
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                new SaveManager();
            }
        }

        public static GameSaveData GameData => instance.gameData;

        public static MachineSaveData MachineData => instance.machineData;

        public static void Save()
        {
            try
            {
                Achievement[] achievements = AchievementManager.GetAchievements();

                if (achievements.Length > 1)
                {
                    instance.gameData.Achievements = achievements.ToList();
                }

                string gameData = JsonConvert.SerializeObject(instance.gameData);

                instance.machineData.MappedInputs = instance.mappedInputs.Serialise();

                string machineData = JsonConvert.SerializeObject(instance.machineData);

                PlatformManager.Platform.SaveData(gameData);

                using (StreamWriter streamWriter = new StreamWriter(MachineFile))
                {
                    streamWriter.Write(machineData);
                }
            }
            catch
            {
                // todo: display message
            }
        }

        public static void Load()
        {
            instance.gameData = (GameSaveData)PlatformManager.Platform.LoadGameData();

            if (File.Exists(MachineFile))
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(MachineFile))
                    {
                        instance.machineData = JsonConvert.DeserializeObject<MachineSaveData>(streamReader.ReadToEnd());
                    }
                }
                catch
                {
                    // todo: display message
                }
            }
            else
            {
                instance.machineData = new MachineSaveData();
            }

            instance.mappedInputs = new MappedInputs();
            instance.mappedInputs.Deserialise(instance.machineData.MappedInputs);
        }
    }
}