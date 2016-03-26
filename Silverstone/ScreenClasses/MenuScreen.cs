using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Silverstone.UI;
using Silverstone.Constants;
using Silverstone.Util;
using Silverstone.EntityClasses.MenuEntity;

namespace Silverstone.ScreenClasses {

    public class MenuScreen : Screen 
    {
        // Allows for access to important game objects, such as the content chest for asset use.
        public Main game;

        private List<Button> menuButtons;
        private List<Button> optionsButtons;

        private Vector2 foregroundGrassPosition = new Vector2(0, 200);
        private Vector2 backgroundMountainPosition = new Vector2(0, 0);

        private Vector2 treesPosition = new Vector2(0, 500);

        private bool musicActive = false;

        private List<Cloud> backClouds = new List<Cloud>();
        private List<Cloud> frontClouds = new List<Cloud>();

        private int currentScreen = 0;

        private MouseState lastState;

        public MenuScreen(Main game) {
            this.game = game;

            MediaPlayer.Volume = .1f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(game.contentChest.menuMusic);

            musicActive = true;

            menuButtons = new List<Button>();
            optionsButtons = new List<Button>();

            menuButtons.Add(new Button(game.contentChest.newGame, new Vector2(game.width / 2 - game.contentChest.newGame.Width / 2,
                game.height / 2 - game.contentChest.newGame.Height * 5), ButtonTags.PLAY));

            menuButtons.Add(new Button(game.contentChest.loadGame, new Vector2(game.width / 2 - game.contentChest.loadGame.Width / 2,
                game.height / 2 - game.contentChest.loadGame.Height * 4 + 20), ButtonTags.LOAD));

            menuButtons.Add(new Button(game.contentChest.options, new Vector2(game.width / 2 - game.contentChest.options.Width / 2,
                game.height / 2 - game.contentChest.options.Height * 3 + 40), ButtonTags.OPTIONS));

            menuButtons.Add(new Button(game.contentChest.quitGame, new Vector2(game.width / 2 - game.contentChest.quitGame.Width / 2,
                game.height / 2 - game.contentChest.quitGame.Height * 2 + 60), ButtonTags.EXIT));

            optionsButtons.Add(new Button(game.contentChest.fullScreen, new Vector2(game.width / 2 - game.contentChest.fullScreen.Width / 2,
                game.height / 2 - game.contentChest.fullScreen.Height * 5), ButtonTags.FULLSCREEN));

            optionsButtons.Add(new Button(game.contentChest.backButton, new Vector2(game.width / 2 - game.contentChest.backButton.Width / 2,
                game.height / 2 - game.contentChest.backButton.Height * 2 + 60), ButtonTags.BACK));

            
        }


        public void Initialize() { }

        public void Update(GameTime gameTime) {

            LeftClick();
            RightClick();
            MouseMove();
            UpdateKeys();

            if (!musicActive) {
                MediaPlayer.Resume();
                musicActive = true;
            }

            if (Random.GetRandomInt(200) == 1) {
                
                if (Random.GetRandomInt(2) == 0) {
                    Cloud cloud = new Cloud(game, 0);
                    frontClouds.Add(cloud);
                } else {
                    Cloud cloud = new Cloud(game, 1);
                    backClouds.Add(cloud);
                }
            }

            foreach (Cloud cloud in backClouds) {
                cloud.Update();
                if (cloud.OutOfBounds()) {
                    backClouds.Remove(cloud);
                    break;
                }
            }

            foreach (Cloud cloud in frontClouds) {
                cloud.Update();
                if (cloud.OutOfBounds()) {
                    frontClouds.Remove(cloud);
                    break;
                }
            }

            if (foregroundGrassPosition.X > 0 - game.contentChest.menuGrass.Width + 1285) {
                foregroundGrassPosition.X -= 3;
            } else {
                foregroundGrassPosition.X = 0;
            }

            if (treesPosition.X > 0 - game.contentChest.menuTrees.Width + 1305) {
                treesPosition.X -= 3;
            } else {
                treesPosition.X = 0;
            }

            if (backgroundMountainPosition.X > 0 - game.contentChest.backMountains.Width + 1280) {
                backgroundMountainPosition.X --;
            } else {
                backgroundMountainPosition.X = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(game.contentChest.blueSky, new Rectangle(0, 0, game.width, game.height), Color.White);

            foreach (Cloud cloud in backClouds) {
                cloud.Draw(spriteBatch);
            }

            spriteBatch.Draw(game.contentChest.gameTitle, new Vector2(game.width / 2 - game.contentChest.gameTitle.Width / 2, 10 + game.contentChest.gameTitle.Height), Color.White);

            spriteBatch.Draw(game.contentChest.backMountains, backgroundMountainPosition, Color.White);

            foreach (Cloud cloud in frontClouds) {
                cloud.Draw(spriteBatch);
            }


            spriteBatch.Draw(game.contentChest.menuGrass, foregroundGrassPosition, Color.White);

            spriteBatch.Draw(game.contentChest.menuTrees, treesPosition, Color.White);


            if (currentScreen == 0) {
                foreach (Button button in menuButtons) {
                    button.Draw(spriteBatch);
                }
            } else if (currentScreen == 1) {
                foreach (Button button in optionsButtons) {
                    button.Draw(spriteBatch);
                }
            }



        }

        public void LeftClick() {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released) {
                Vector2 mousePos = Vector2.Transform(new Vector2(ms.X, ms.Y), Matrix.Invert(Resolution.ScaleMatrix));
                Rectangle rect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);
                if (currentScreen == 0) {
                    foreach (Button button in menuButtons) {
                        if (rect.Intersects(button.GetBounds())) {
                            game.contentChest.menuSelect.Play();
                            if (button.GetTag() == ButtonTags.EXIT) {
                                game.ForceExit();
                            } else if (button.GetTag() == ButtonTags.FULLSCREEN) {
                                game.ForceFullScreen();
                            } else if (button.GetTag() == ButtonTags.OPTIONS) {
                                currentScreen = 1;
                            } else if (button.GetTag() == ButtonTags.PLAY) {
                                musicActive = false;
                                MediaPlayer.Pause();
                                game.currentScreen = new GameScreen(game);
                            }
                        }
                    }

                } else if (currentScreen == 1) {
                    foreach (Button button in optionsButtons) {
                        if (rect.Intersects(button.GetBounds())) {
                            game.contentChest.menuSelect.Play();
                            if (button.GetTag() == ButtonTags.BACK) {
                                currentScreen = 0;
                            } else if (button.GetTag() == ButtonTags.FULLSCREEN) {
                                if (!game.isFullScreen) {
                                    button.SetTexture(game.contentChest.windowed);
                                } else {
                                    button.SetTexture(game.contentChest.fullScreen);
                                }
                                game.ForceFullScreen();
                            }
                        }
                    }
                }
            }
            lastState = ms;
        }

        public void RightClick() {
            MouseState ms = Mouse.GetState();
            if (ms.RightButton == ButtonState.Pressed && lastState.RightButton == ButtonState.Released) {
                Vector2 mousePos = Vector2.Transform(new Vector2(ms.X, ms.Y), Matrix.Invert(Resolution.ScaleMatrix));
                Rectangle rect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);
            }
            lastState = ms;
        }

        public void MouseMove() {
            MouseState ms = Mouse.GetState();
            Vector2 mousePos = Vector2.Transform(new Vector2(ms.X, ms.Y), Matrix.Invert(Resolution.ScaleMatrix));
            Rectangle rect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);
            if (currentScreen == 0) {
                foreach (Button button in menuButtons) {
                    if (rect.Intersects(button.GetBounds())) {
                        button.HoverOn();
                    } else {
                        button.HoverOff();
                    }
                }
            } else if (currentScreen == 1) {
                foreach (Button button in optionsButtons) {
                    if (rect.Intersects(button.GetBounds())) {
                        button.HoverOn();
                    } else {
                        button.HoverOff();
                    }
                }
            }
        }

        public void UpdateKeys() {
            KeyboardState ks = Keyboard.GetState();
        }
    }
}