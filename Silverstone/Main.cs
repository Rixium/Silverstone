using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Silverstone.ScreenClasses;
using Silverstone.Util;
using Silverstone.Constants.Options;

namespace Silverstone {

    public class Main : Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MouseState mouseState;
        private bool hasClicked;

        public KeyInput keyInput;
        public KeyboardState lastState;

        public ContentChest contentChest = ContentChest.Instance;

        public Screen currentScreen;

        public int width;
        public int height;

        public string versionNumber = "0.1";
        private string gameTitle = "Silverstone";

        public bool isFullScreen = false;
        public bool showDebug = false;

        private static Main instance;

        public static Main Instance {
            get {
                if (instance == null) {
                    instance = new Main();
                }
                return instance;
            }
        }

        public Main() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.ClientSizeChanged += delegate { Resolution.WasResized = true; };
        }

        protected override void Initialize() {
            Resolution.Initialize(graphics);

            // Create assets here and load them into the chest using load content, this allows for the assets to be loaded across all classes.
            ContentChest.Instance.content = this.Content;
            ContentChest.Instance.LoadContent();

            keyInput = new KeyInput();

            Window.Position = new Point((Resolution.ScreenWidth - Resolution.GameWidth) / 2, ((Resolution.ScreenHeight - Resolution.GameHeight) / 2) - 40);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            graphics.ApplyChanges();

            graphics.PreferMultiSampling = false;

            Window.Title = gameTitle + " v" + versionNumber;

            IsMouseVisible = true;

            // Update height and width so they can be used with determining positions of several UI elements.
            height = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;

            // Set the starting screen.
            currentScreen = new MenuScreen(this);
            base.Initialize();

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            
            if (Keyboard.GetState().IsKeyDown(Keys.F1) && lastState.IsKeyUp(Keys.F1)) {
                showDebug = !showDebug;
            }

            Resolution.Update(this, graphics);

            currentScreen.Update(gameTime);

            lastState = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Resolution.ScaleMatrix);

            currentScreen.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ForceExit() {
            Exit();
        }

        public void ForceFullScreen() {
            if (isFullScreen) {
                Window.Position = new Point((Resolution.ScreenWidth - Resolution.GameWidth) / 2, ((Resolution.ScreenHeight - Resolution.GameHeight) / 2) - 40);
                Window.IsBorderless = false;
                graphics.PreferredBackBufferWidth = Resolution.GameWidth;
                graphics.PreferredBackBufferHeight = Resolution.GameHeight;
                graphics.ApplyChanges();
                isFullScreen = false;
            } else {
                Window.Position = new Point(0, 0);
                Window.IsBorderless = true;
                graphics.PreferredBackBufferWidth = Resolution.ScreenWidth;
                graphics.PreferredBackBufferHeight = Resolution.ScreenHeight;
                graphics.ApplyChanges();
                isFullScreen = true;
            }
        }
    }
}
