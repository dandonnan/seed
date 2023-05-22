namespace Seed.MonoGame.Save
{
    using Seed.MonoGame.Platforms;

    public class MachineSaveData
    {
        public GraphicsSettings Graphics { get; set; }

        public string MappedInputs { get; set; }

        public MachineSaveData()
        {
            SetToDefault();
        }

        private void SetToDefault()
        {
            Graphics = new GraphicsSettings
            {
                Resolution = PlatformManager.Platform.GetDefaultResolution(),
                ScreenSize = (int)PlatformManager.Platform.GetDefaultScreenSize(),
            };
        }
    }
}
