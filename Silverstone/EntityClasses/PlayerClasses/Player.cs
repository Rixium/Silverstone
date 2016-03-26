using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Silverstone.Constants;
using Silverstone.EntityClasses.PlayerClasses;
using Silverstone.ScreenClasses;
using Silverstone.Util;
using System.Collections.Generic;
using System.Diagnostics;

namespace Silverstone.EntityClasses.Player {

    class Player : Entity {

        Stats playerStats;
        Inventory playerInventory;
        PlayerAnimations playerAnimations;

        private bool moveLeft, moveRight, moveUp, moveDown;

        private Texture2D headTexture;
        private Texture2D bodyTexture;
        private Texture2D legTexture;

        private Texture2D texture;

        public Player(Vector2 position, GameScreen game) {
            playerStats = new Stats();

            this.type = EntityType.PLAYER;

            playerStats.speed = 1;

            this.game = game;

            this.texture = ContentChest.Instance.player;

            this.position = new Vector2(position.X, position.Y + texture.Height - texture.Height / 3);

            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, 8);

            playerAnimations = new PlayerAnimations(game);
        }

        public override void Update(GameTime gameTime, List<Entity> entities) {

            

            this.rectangle = new Rectangle((int)position.X + (int)game.xOffset, (int)position.Y + (int)game.yOffset, rectangle.Width, rectangle.Height);

            CheckMovement(entities);
            UpdateMovement(entities);

            if (-position.Y + Resolution.GameHeight / 2 < 0 && -position.Y + Resolution.GameHeight / 2 > -(TileConstants.TILE_SIZE * GameConstants.MAP_SIZE) + Resolution.GameHeight) {
                game.yOffset = -position.Y + Resolution.GameHeight / 2;
            }

            if (-position.X + Resolution.GameWidth / 2 < 0 && -position.X + Resolution.GameWidth / 2 > -(TileConstants.TILE_SIZE * GameConstants.MAP_SIZE) + Resolution.GameWidth) {
                game.xOffset = -position.X + Resolution.GameWidth / 2;
            }

            playerAnimations.currentAnimation.Update(gameTime, new Vector2(position.X, position.Y - texture.Height + texture.Height / 3));
        }

        public override void Draw(SpriteBatch spriteBatch) {
            playerAnimations.currentAnimation.Draw(spriteBatch);
        }

        public void CheckMovement(List<Entity> entities) {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(game.game.keyInput.moveLeft)) {
                playerAnimations.currentAnimation = playerAnimations.animations["walkLeft"];
                moveLeft = true;
                moveRight = false;
            } else if (keyState.IsKeyDown(game.game.keyInput.moveRight)) {
                playerAnimations.currentAnimation = playerAnimations.animations["walkRight"];
                moveRight = true;
                moveLeft = false;
            }

            if (keyState.IsKeyDown(game.game.keyInput.moveUp)) {
                moveUp = true;
                moveDown = false;
            } else if (keyState.IsKeyDown(game.game.keyInput.moveDown)) {
                moveDown = true;
                moveUp = false;
            }

            if (keyState.IsKeyUp(game.game.keyInput.moveLeft)) {
                moveLeft = false;
            }
            if (keyState.IsKeyUp(game.game.keyInput.moveRight)) {
                moveRight = false;
            }

            if (keyState.IsKeyUp(game.game.keyInput.moveUp)) {
                moveUp = false;
            }
            if (keyState.IsKeyUp(game.game.keyInput.moveDown)) {
                moveDown = false;
            }

            if (keyState.IsKeyUp(game.game.keyInput.moveRight) && keyState.IsKeyUp(game.game.keyInput.moveLeft)
                && keyState.IsKeyUp(game.game.keyInput.moveUp) && keyState.IsKeyUp(game.game.keyInput.moveDown)) {
                playerAnimations.currentAnimation = playerAnimations.animations["idle"];
            }
        }

        public void UpdateMovement(List<Entity> entities) {
            bool canMoveLeft = true;
            bool canMoveRight = true;
            bool canMoveUp = true;
            bool canMoveDown = true;

            Rectangle moveLeftRect = new Rectangle(rectangle.X - playerStats.speed, rectangle.Y, rectangle.Width, rectangle.Height);
            Rectangle moveRightRect = new Rectangle(rectangle.X + playerStats.speed, rectangle.Y, rectangle.Width, rectangle.Height);
            Rectangle moveUpRect = new Rectangle(rectangle.X, rectangle.Y - playerStats.speed, rectangle.Width, rectangle.Height);
            Rectangle moveDownRect = new Rectangle(rectangle.X, rectangle.Y + playerStats.speed, rectangle.Width, rectangle.Height);

            foreach (Entity e in entities) {
                if (e.collidable) {
                    if (e != this) {
                        if (moveLeft) {
                            if (moveLeftRect.Intersects(e.rectangle)) {
                                canMoveLeft = false;
                            }
                        } else if (moveRight) {
                            if (moveRightRect.Intersects(e.rectangle)) {
                                canMoveRight = false;
                            }
                        }

                        if (moveUp) {
                            if (moveUpRect.Intersects(e.rectangle)) {
                                canMoveUp = false;
                            }
                        } else if (moveDown) {
                            if (moveDownRect.Intersects(e.rectangle)) {
                                canMoveDown = false;
                            }
                        }
                    }
                }
            }

            if (moveLeft && canMoveLeft && moveLeftRect.X > 0) {
                this.position.X -= playerStats.speed;
            }

            if (moveRight && canMoveRight && moveRightRect.X < Resolution.GameWidth - texture.Width) {
                this.position.X += playerStats.speed;
            }

            if (moveUp && canMoveUp && moveDownRect.Y > 0) {
                this.position.Y -= playerStats.speed;
            }

            if (moveDown && canMoveDown && moveDownRect.Y < Resolution.GameHeight - texture.Height) {
                this.position.Y += playerStats.speed;
            }
        }


        public Inventory GetInventory() {
            return this.playerInventory;
        }
    }
}
