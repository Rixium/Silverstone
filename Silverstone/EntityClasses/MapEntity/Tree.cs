using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.Constants;
using Silverstone.ScreenClasses;
using Silverstone.Map;
using Silverstone.Util;
using Silverstone.EntityClasses.MapEntity.TreeItems;

using System.Collections.Generic;

namespace Silverstone.EntityClasses.MapEntity {

    class Tree : Entity {


        private List<Log> logs = new List<Log>();
        private int logCount;
        private int logSize = 16;

        public Tree(Vector2 position, GameScreen game, Tile tile) {
            this.type = EntityType.TREE;
            this.position = new Vector2(position.X, position.Y);
            this.game = game;

            this.tile = tile;
            this.tile.occupied = true;
            collidable = true;

            logCount = Random.GetRandom(GameConstants.MIN_TREE_HEIGHT, GameConstants.MAX_TREE_HEIGHT);

            for (int i = 1; i < logCount; i++) {
                logs.Add(new Log(new Vector2(tile.GetPosition().X, tile.GetPosition().Y - i * ContentChest.Instance.log.Height), game));
            }

            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, ContentChest.Instance.stump.Width, ContentChest.Instance.stump.Height);

        }

        public override void Update(GameTime gameTime, List<Entity> entities) {
            

            foreach(Log log in logs) {
                log.Update(gameTime);
            }

            rectangle = new Rectangle((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset, rectangle.Width, rectangle.Height);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentChest.Instance.stump, new Vector2(position.X + game.xOffset, position.Y + game.yOffset), Color.White);

            foreach (Log log in logs) {
                log.Draw(spriteBatch);
            }

            spriteBatch.Draw(ContentChest.Instance.treeLeaves, new Vector2((int)position.X + (int)game.xOffset, (int)position.Y - logCount * logSize + (int)game.yOffset), Color.White);
        }


    }

}
