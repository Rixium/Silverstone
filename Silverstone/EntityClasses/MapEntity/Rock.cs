using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.Constants;
using Silverstone.ScreenClasses;
using Silverstone.Map;
using Silverstone.Util;
using System.Collections.Generic;

namespace Silverstone.EntityClasses.MapEntity {

    class Rock : Entity {

        public Rock(Vector2 position, GameScreen game, Tile tile) {
            this.type = EntityType.ROCK;
            this.position = position;
            this.game = game;
            this.texture = ContentChest.Instance.rock;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            this.tile = tile;
            tile.occupied = true;
            collidable = true;
        }

        public override void Update(GameTime gameTime, List<Entity> entities) {
            rectangle = new Rectangle((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X + game.xOffset, position.Y + game.yOffset), Color.White);
        }

    }
}
