namespace Seed.MonoGame.Platforms
{
    using Seed.MonoGame.Graphics;

    public interface IMonoGamePlatform
    {
        ScreenSizes GetDefaultScreenSize();

        string GetIconFile();
    }
}
