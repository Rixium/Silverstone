using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Silverstone.ScreenClasses
{
    public interface Screen
    {

        void Initialize();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        void LeftClick();

        void RightClick();

        void MouseMove();

        void UpdateKeys();
    }
}
