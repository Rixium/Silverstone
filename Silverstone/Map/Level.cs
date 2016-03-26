using System.Collections.Generic;
using Silverstone.EntityClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Silverstone.Constants;
using Silverstone.EntityClasses.MapEntity;
using Silverstone.EntityClasses.Player;
using Silverstone.ScreenClasses;
using Silverstone.Util;
using Silverstone.EntityClasses.CollectableEntities;

namespace Silverstone.Map {

    public class Level {

        private GameScreen game;
        public Tile[,] tiles;

        private List<Entity> entities = new List<Entity>();
        private List<Entity> sortedEntities = new List<Entity>();

        public Level(GameScreen game, int mapSize) {
            this.game = game;
            tiles = new Tile[mapSize, mapSize];
            Generate();
        }

        public void Update(GameTime gameTime) {
            sortedEntities = entities.OrderBy(o => o.position.Y).ToList();
            for (int i = 0; i < tiles.GetLength(0); i++) {
                for (int j = 0; j < tiles.GetLength(1); j++) {
                    tiles[i, j].Update(gameTime);
                }
            }

            foreach (Entity entity in entities) {
                entity.Update(gameTime, entities);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < tiles.GetLength(0); i++) {
                for (int j = 0; j < tiles.GetLength(1); j++) {
                    tiles[i, j].Draw(spriteBatch);
                }
            }

            foreach (Entity entity in sortedEntities) {
                entity.Draw(spriteBatch);
            }
        }

        public void Generate() {
            for (int i = 0; i < tiles.GetLength(0); i++) {
                for (int j = 0; j < tiles.GetLength(1); j++) {
                    tiles[i, j] = new Tile(new Vector2(i * TileConstants.TILE_SIZE, j * TileConstants.TILE_SIZE), TileType.DIRT, game, i, j);
                }
            }

            for (int i = 0; i < tiles.GetLength(0); i++) {
                for (int j = 0; j < tiles.GetLength(1); j++) {
                    if (i != 32 && j != 32) {
                        if (!tiles[i, j].occupied) {
                            if (Random.GetRandomInt(100) < GameConstants.ROCK_RARITY) {
                                entities.Add(new Rock(tiles[i, j].GetPosition(), game, tiles[i, j]));
                            } else if (Random.GetRandomInt(100) < GameConstants.TREE_RARITY) {
                                entities.Add(new Tree(tiles[i, j].GetPosition(), game, tiles[i, j]));
                            } else if (Random.GetRandomInt(100) < GameConstants.COIN_RARITY) {
                                entities.Add(new Coin(tiles[i, j].GetPosition(), game, tiles[i, j]));
                            }
                        }

                    }
                }
            }

            Player player = new Player(tiles[32, 32].GetPosition(), game);
            entities.Add(player);

            game.yOffset = -player.position.Y + Resolution.ScreenHeight / 3;
            game.xOffset = -player.position.X + Resolution.ScreenWidth / 3;


        }

    }
}
