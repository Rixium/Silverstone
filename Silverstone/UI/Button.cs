using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Silverstone.UI {

    class Button {

        private Texture2D image;
        private Vector2 position;
        private Rectangle rectangle;
        private int tag;

        private Vector2 startPos;
        private Vector2 endPos;

        public Button(Texture2D image, Vector2 position) {
            this.image = image;
            this.position = position;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);

            this.startPos = new Vector2(position.X, position.Y);
            this.endPos = new Vector2(startPos.X, startPos.Y - 5);
        }

        public Button(Texture2D image, Vector2 position, int tag) {
            this.image = image;
            this.position = position;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            this.tag = tag;

            this.startPos = new Vector2(position.X, position.Y);
            this.endPos = new Vector2(startPos.X, startPos.Y - 5);
        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(image, position, Color.White);
        }

        public Rectangle GetBounds() {
            return rectangle;
        }

        public int GetTag() {
            return tag;
        }

        public void SetTag(int tag) {
            this.tag = tag;
        }

        public void HoverOn() {
            this.position.Y = endPos.Y;
        }

        public void HoverOff() {
            this.position.Y = startPos.Y;
        }

        public void SetTexture(Texture2D texture) {
            this.image = texture;
        }

    }
}
