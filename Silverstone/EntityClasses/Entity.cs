using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.Map;
using Silverstone.ScreenClasses;
using System.Collections.Generic;

namespace Silverstone.EntityClasses {

    class Entity {

        public GameScreen game;
        public Vector2 position;
        public int type;
        public Texture2D texture;
        public Rectangle rectangle;
        public Tile tile;
        public bool collidable;

        public virtual void Draw(SpriteBatch spriteBatch) {
        }


        public virtual void Update(GameTime gameTime, List<Entity> entities) {

        }

    }

}
