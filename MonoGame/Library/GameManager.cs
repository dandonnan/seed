namespace Seed.MonoGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Seed.Achievements;
    using Seed.Events;
    using Seed.Graphics;
    using Seed.MonoGame.Input;
    using Seed.MonoGame.Localisation;
    using Seed.MonoGame.Resources.Graphics;
    using Seed.MonoGame.Resources.Localisation;
    using Seed.MonoGame.Scenes;
    using Seed.Platforms;
    using Seed.Save;
    using Seed.State;
    using System.Collections.Generic;
    using System.Globalization;

    public class GameManager
    {
        public static int BaseResolutionWidth => instance.baseResolutionWidth;

        public static int BaseResolutionHeight => instance.baseResolutionHeight;

        public static int UiResolutionWidth => instance.uiResolutionWidth;

        public static int UiResolutionHeight = instance.uiResolutionHeight;

        private static GameManager instance;

        private readonly int baseResolutionWidth;

        private readonly int baseResolutionHeight;

        private readonly int uiResolutionWidth;

        private readonly int uiResolutionHeight;

        private readonly Game game;

        private readonly ContentManager contentManager;

        private readonly GraphicsDevice graphicsDevice;

        private readonly GraphicsDeviceManager graphicsDeviceManager;

        private readonly SpriteBatch spriteBatch;

        private readonly InputManager inputManager;

        private readonly CheckpointManager checkpointManager;

        private IScene currentScene;

        private RenderTarget2D renderTarget;

        private Rectangle renderWindow;

        private Matrix renderMatrix;

        private Matrix uiMatrix;

        private Vector2 uiScale;

        public GameManager(Game game,
                            ContentManager contentManager,
                            GraphicsDevice graphicsDevice,
                            GraphicsDeviceManager graphicsDeviceManager,
                            SpriteBatch spriteBatch,
                            int resolutionWidth = 1920,
                            int resolutionHeight = 1080,
                            int uiResolutionWidth = 1920,
                            int uiResolutionHeight = 1080)
        {
            this.game = game;
            this.contentManager = contentManager;
            this.graphicsDevice = graphicsDevice;
            this.graphicsDeviceManager = graphicsDeviceManager;
            this.spriteBatch = spriteBatch;

            instance = this;

            checkpointManager = CheckpointManager.Initialise();

            SaveManager.Initialise();
            ChangeScreenSettings();

            CultureInfo.CurrentCulture = new CultureInfo(SaveManager.GameData.Language);

            inputManager = InputManager.Initialise();
            EventManager.Initialise();

            StringLibrary.Initialise();
            AchievementManager.Initialise();

            SetupRenderTarget();

            EventManager.Instance.EventFired += EventManager_OnEventFired;
        }

        public static ContentManager ContentManager => instance.contentManager;

        public static GraphicsDeviceManager GraphicsDeviceManager => instance.graphicsDeviceManager;

        public static SpriteBatch SpriteBatch => instance.spriteBatch;

        public static CheckpointManager CheckpointManager => instance.checkpointManager;

        public static InputManager InputManager => instance.inputManager;

        public static Vector2 UiScale => instance.uiScale;

        public static SpriteFont LoadFont(string fontName)
        {
            return Load<SpriteFont>($"Fonts\\{fontName}");
        }

        public static Texture2D LoadTexture(string texture)
        {
            return Load<Texture2D>(texture);
        }

        public static List<LocalisedText> LoadLocalisedText(string localisedText)
        {
            return LoadAll<LocalisedText>(localisedText);
        }

        public static List<SpritePart> LoadSpritePart(string spriteDefinition)
        {
            return LoadAll<SpritePart>(spriteDefinition);
        }

        public static T Load<T>(string fileName)
        {
            return ContentManager.Load<T>(fileName);
        }

        public static List<T> LoadAll<T>(string fileName)
        {
            return ContentManager.Load<List<T>>(fileName);
        }

        public static Vector2 MatrixScale()
        {
            return new Vector2(instance.renderMatrix.M11, instance.renderMatrix.M22);
        }

        public static void ChangeScreenSettings()
        {
            GraphicsDeviceManager.HardwareModeSwitch = SaveManager.GameData.Graphics.ScreenMode != WindowMode.Borderless;

            instance.game.Window.IsBorderless = SaveManager.GameData.Graphics.ScreenMode == WindowMode.Borderless;

            GraphicsDeviceManager.IsFullScreen = SaveManager.GameData.Graphics.ScreenMode == WindowMode.Borderless || SaveManager.GameData.Graphics.ScreenMode == WindowMode.Fullscreen;

            if (SaveManager.GameData.Graphics.ScreenMode == WindowMode.Borderless)
            {
                GraphicsDeviceManager.PreferredBackBufferWidth = SpriteBatch.GraphicsDevice.DisplayMode.Width;
                GraphicsDeviceManager.PreferredBackBufferHeight = SpriteBatch.GraphicsDevice.DisplayMode.Height;
            }
            else
            {
                GraphicsDeviceManager.PreferredBackBufferWidth = SaveManager.GameData.Graphics.ResolutionWidth;
                GraphicsDeviceManager.PreferredBackBufferHeight = SaveManager.GameData.Graphics.ResolutionHeight;
            }

            GraphicsDeviceManager.ApplyChanges();

            instance.ScaleRenderTarget();
        }

        public void Update(GameTime gameTime)
        {
            PlatformManager.Platform.Update();

            inputManager.Update();

            currentScene.Update(gameTime);
        }

        public void Draw()
        {
            DrawToRenderTarget();
            DrawToScreen();
        }

        private void SetupRenderTarget()
        {
            renderTarget = new RenderTarget2D(
                                    graphicsDevice,
                                    BaseResolutionWidth,
                                    BaseResolutionHeight,
                                    false,
                                    graphicsDevice.PresentationParameters.BackBufferFormat,
                                    DepthFormat.Depth24,
                                    2,
                                    RenderTargetUsage.DiscardContents);

            ScaleRenderTarget();
        }

        private void ScaleRenderTarget()
        {
            float scaleX = game.Window.ClientBounds.Width / (float)BaseResolutionWidth;
            float scaleY = game.Window.ClientBounds.Height / (float)BaseResolutionHeight;

            renderWindow = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);

            renderMatrix = Matrix.CreateScale(scaleX, scaleY, 1);

            scaleX = game.Window.ClientBounds.Width / (float)UiResolutionWidth;
            scaleY = game.Window.ClientBounds.Height / (float)UiResolutionHeight;

            uiMatrix = Matrix.CreateScale(scaleX, scaleY, 1);
            uiScale = new Vector2(scaleX, scaleY);
        }

        private void DrawToRenderTarget()
        {
            graphicsDevice.SetRenderTarget(renderTarget);

            graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            currentScene.Draw();

            spriteBatch.End();

            graphicsDevice.SetRenderTarget(null);
        }

        private void DrawToScreen()
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: renderMatrix);

            spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);

            spriteBatch.End();

            spriteBatch.Begin(transformMatrix: uiMatrix);

            currentScene.DrawUI();

            spriteBatch.End();
        }

        private void ChangeSceneFromEvent(GameEvent gameEvent)
        {
            if (gameEvent.Value != null && gameEvent.Value.GetType().GetInterface(nameof(IScene)) != null)
            {
                currentScene.Dispose();
                currentScene = (IScene)gameEvent.Value;
            }
        }

        private void EventManager_OnEventFired(GameEvent gameEvent)
        {
            switch (gameEvent.EventId)
            {
                case SeedEvents.CloseGame:
                    PlatformManager.Platform.Stop();
                    game.Exit();
                    break;

                case SeedEvents.ChangeScene:
                    ChangeSceneFromEvent(gameEvent);
                    break;

                default:
                    break;
            }
        }
    }
}
