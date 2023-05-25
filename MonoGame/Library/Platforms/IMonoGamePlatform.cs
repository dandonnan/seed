namespace Seed.MonoGame.Platforms
{
    using Seed.Graphics;

    public interface IMonoGamePlatform
    {
        WindowMode GetDefaultScreenSize();

        string GetIconFile();
    }
}
