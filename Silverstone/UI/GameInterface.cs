using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silverstone.UI {

    public class GameInterface {

        private ItemBar itemBar;

        public GameInterface() {
            itemBar = new ItemBar();
        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch) {
            itemBar.Draw(spriteBatch);
        }
    }
}
