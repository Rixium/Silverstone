using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Silverstone.Util;

namespace Silverstone.EntityClasses.MenuEntity {

    class Cloud {

        private List<Texture2D> textures = new List<Texture2D>();
        private Texture2D currentTexture;

        private float speed;
        private Vector2 position;
        private int size;

        public Cloud(Main game, int size) {

            currentTexture = ContentChest.Instance.clouds[Random.GetRandomInt(ContentChest.Instance.clouds.Count)];

            this.size = size;

            speed = Random.GetRandomInt(3) + 1;

            int randomStartHeight = Random.GetRandomInt(200) + 10;

            position = new Vector2(game.width + currentTexture.Width, randomStartHeight);

        }

        public void Update() {
            position.X -= speed;
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (size == 0) {
                spriteBatch.Draw(currentTexture, position, null, Color.White, 0, new Vector2(currentTexture.Width / 2, currentTexture.Height / 2), 1, SpriteEffects.None, 0);
            } else {
                spriteBatch.Draw(currentTexture, position, null, Color.White, 0, new Vector2(currentTexture.Width / 2, currentTexture.Height / 2), 0.5f, SpriteEffects.None, 0);
            }
        }

        public bool OutOfBounds() {
            return (this.position.X < 0 - currentTexture.Width);
        }

    }

}
