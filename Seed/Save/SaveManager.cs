namespace Seed.Save
{
    public class SaveManager
    {
        private static SaveManager instance;

        private IGameSaveData gameData;

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

        public static IGameSaveData GameData => instance.gameData;

        public static void Save()
        {
        }

        public static void Load()
        {
        }
    }
}