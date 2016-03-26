using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Silverstone.ScreenClasses;
using Silverstone.Util;
using Silverstone.Constants;

namespace Silverstone.Map {

    public class Tile {

        private GameScreen game;

        private int type;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        public bool occupied;
        private bool hovering;

        public int tileX;
        public int tileY;

        public Tile(Vector2 position, int type, GameScreen game, int tileX, int tileY) {
            this.game = game;
            this.position = position;
            this.type = type;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, TileConstants.TILE_SIZE, TileConstants.TILE_SIZE);

            this.texture = ContentChest.Instance.TileTextures[type];

            this.tileX = tileX;
            this.tileY = tileY;
        }

        public void Update(GameTime gameTime) {
            rectangle = new Rectangle((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset, rectangle.Height, rectangle.Width);
        }

        public void Draw(SpriteBatch spriteBatch) {
          
            spriteBatch.Draw(texture, new Rectangle((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset, rectangle.Height, rectangle.Width),
            Color.White);

            if (game.game.showDebug) {
                spriteBatch.DrawString(ContentChest.Instance.debugFont, tileX.ToString(), new Vector2((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset), Color.White);
            }

        }

        public Vector2 GetPosition() {
            return this.position;
        }
    }
}
