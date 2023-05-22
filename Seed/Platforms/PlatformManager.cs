namespace Seed.Platforms
{
    public class PlatformManager
    {
        private static PlatformManager instance;

        private readonly IPlatform platform;

        private PlatformManager(IPlatform platform)
        {
            this.platform = platform;

            instance = this;
        }

        public static void Initialise(IPlatform platform)
        {
            if (instance == null)
            {
                new PlatformManager(platform);
            }
        }

        public static bool IsPC()
        {
            return instance.platform.IsPC();
        }

        public static IPlatform Platform => instance.platform;
    }
}
