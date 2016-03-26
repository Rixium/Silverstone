using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.Constants;
using Silverstone.Map;
using Silverstone.ScreenClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Silverstone.Util;

namespace Silverstone.EntityClasses.CollectableEntities {

    class Coin : Entity {

        public int type;

        private Tile tile;
        GameScreen game;
        Vector2 position;
        Texture2D texture;

        Rectangle rectangle;

        public Coin(Vector2 position, GameScreen game, Tile tile) {
            this.position = position;
            this.game = game;

            this.texture = ContentChest.Instance.coin;
            this.type = EntityType.COIN;
            this.tile = tile;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            tile.occupied = true;
            collidable = false;
        }

        public override void Update(GameTime gameTime, List<Entity> entities) {
            this.rectangle = new Rectangle((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X + game.xOffset, position.Y + game.yOffset), Color.White);
        }
    }
}
