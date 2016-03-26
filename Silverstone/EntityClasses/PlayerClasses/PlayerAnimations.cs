using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverstone.ScreenClasses;
using Silverstone.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Silverstone.EntityClasses.PlayerClasses {

    class PlayerAnimations {

        public Animation currentAnimation;

        public Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        public PlayerAnimations(GameScreen game) {
            animations.Add("walkLeft", new Animation(ContentChest.Instance.walkLeftSheet, 8, 24, game));
            animations.Add("walkRight", new Animation(ContentChest.Instance.walkRightSheet, 8, 24, game));
            animations.Add("walkUp", new Animation(ContentChest.Instance.walkUpSheet, 8, 24, game));
            animations.Add("walkDown", new Animation(ContentChest.Instance.walkDownSheet, 8, 24, game));
            animations.Add("idle", new Animation(ContentChest.Instance.idleSheet, 8, 24, game));

            currentAnimation = animations["walkLeft"];
        }


    }
}
