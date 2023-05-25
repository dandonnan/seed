namespace Seed.MonoGame.Scenes
{
    using Microsoft.Xna.Framework;

    public interface IScene
    {
        void Dispose();

        void Update(GameTime gameTime);

        void Draw();

        void DrawUI();
    }
}
