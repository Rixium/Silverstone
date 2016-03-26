using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silverstone.UI {

    class ItemBar {

        private ItemBar itemBar;

        public ItemBar() {

        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentChest.Instance.itemBar, new Vector2(Resolution.GameWidth / 2 - ContentChest.Instance.itemBar.Width / 2, 10), Color.White);
        }

    }
}
