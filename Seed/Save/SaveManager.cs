namespace Seed.Save
{
    public class SaveManager
    {
        private static SaveManager instance;

        private IGameSaveData gameData;

        private Action save;

        private Func<IGameSaveData> load;

        private SaveManager(Action save, Func<IGameSaveData> load)
        {
            instance = this;

            this.save = save;

            this.load = load;

            Load();
        }

        public static void Initialise(Action save, Func<IGameSaveData> load)
        {
            if (instance == null)
            {
                new SaveManager(save, load);
            }
        }

        public static IGameSaveData GameData => instance.gameData;

        public static void Save()
        {
            instance.save?.Invoke();
        }

        public static void Load()
        {
            if (instance.load != null)
            {
                instance.gameData = instance.load.Invoke();
            }
        }
    }
}