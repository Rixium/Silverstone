using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Silverstone.Constants;
using Silverstone.Map;
using Silverstone.UI;

namespace Silverstone.ScreenClasses
{
    public class GameScreen : Screen
    {

        private KeyState lastState;

        public Main game;

        public Level map;

        public GameInterface gameInterface;

        public float xOffset = 0;
        public float yOffset = 0;

        public void Initialize() {
        }

        public GameScreen(Main game) {
            this.game = game;
            map = new Level(this, GameConstants.MAP_SIZE);

            gameInterface = new GameInterface();
        }

        public void Update(GameTime gameTime) {
            CheckInput();
            map.Update(gameTime);
            gameInterface.Update();
        }

        public void Draw(SpriteBatch spriteBatch) {
            map.Draw(spriteBatch);
            gameInterface.Draw(spriteBatch);
        }

        public void CheckInput() {
            LeftClick();
            RightClick();
            MouseMove();
            UpdateKeys();
        }

        public void LeftClick() {
            
        }

        public void RightClick() {
            
        }

        public void MouseMove() {
            
        }

        public void UpdateKeys() {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Escape)) {
                game.currentScreen = new MenuScreen(game);
            }
        }

    }
}
