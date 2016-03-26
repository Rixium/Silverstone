using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Silverstone.ScreenClasses;

namespace Silverstone.Util {

    class Animation {

        GameScreen game;

        Texture2D spritesheet;
        float time;
        float frameTime = 0.1f;
        int frameIndex;
        int totalFrames;

        int frameWidth;
        int frameHeight;

        Rectangle source;
        Vector2 position;
        Vector2 origin;

        public Animation(Texture2D spriteSheet, int frameWidth, int frameHeight, GameScreen game) {
            this.game = game;

            this.spritesheet = spriteSheet;

            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            totalFrames = spritesheet.Width / frameWidth * spritesheet.Height / frameHeight;
        }

        public void Update(GameTime gameTime, Vector2 position) {

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (time > frameTime) {
                frameIndex++;
                time = 0f;
            }

            if (frameIndex > totalFrames - 1) {
                frameIndex = 0;
            }

            source = new Rectangle(frameIndex * frameWidth,

                           0, frameWidth, frameHeight);

            this.position = new Vector2(position.X + game.xOffset, position.Y + game.yOffset);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spritesheet, position, source, Color.White);
        }

    }
}
