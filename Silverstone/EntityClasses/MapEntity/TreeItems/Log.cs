using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.Util;
using Silverstone.ScreenClasses;

namespace Silverstone.EntityClasses.MapEntity.TreeItems {

    public class Log {

        private Vector2 position;

        private GameScreen game;

        public Log(Vector2 position, GameScreen game) {
            this.position = position;
            this.game = game;
        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentChest.Instance.log, new Vector2(position.X + (int)game.xOffset, position.Y + (int)game.yOffset), Color.White);
        }

    }

}
