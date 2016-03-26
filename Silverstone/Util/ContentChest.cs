using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Silverstone.Util {

    public class ContentChest {

        // All assets that are loaded should be public so they can be accessed from other classes that require them.

        public ContentManager content { get; set; }


        // Main Menu

        public Texture2D newGame;
        public Texture2D quitGame;

        public List<Texture2D> clouds = new List<Texture2D>();

        public Texture2D blueSky;
        public Texture2D menuGrass;
        public Texture2D backMountains;

        public Texture2D gameTitle;


        public SoundEffect menuSelect;
        public Song menuMusic;

        public Texture2D fullScreen;

        public Texture2D tileSelector;

        public Texture2D options;
        public Texture2D windowed;
        public Texture2D backButton;

        public Texture2D menuTrees;
        public Texture2D loadGame;

        // Fonts

        public SpriteFont debugFont;

        // Tiles

        public List<Texture2D> TileTextures = new List<Texture2D>();

        // Entities

        public Texture2D rock;
        public Texture2D tree;

        // Objects

        public Texture2D log;
        public Texture2D stump;
        public Texture2D treeLeaves;

        // Player

        public Texture2D player;
        public Texture2D walkRightSheet;
        public Texture2D walkLeftSheet;
        public Texture2D walkUpSheet;
        public Texture2D walkDownSheet;
        public Texture2D idleSheet;

        // Collectables

        public Texture2D coin;

        // UI

        public Texture2D itemBar;

        //Singleton
        private static ContentChest instance;

        public static ContentChest Instance {
            get {
                if (instance == null) {
                    instance = new ContentChest();
                }
                return instance;
            }
        }

        public void LoadContent() {

            newGame = content.Load<Texture2D>("Menu/newGame.png");
            quitGame = content.Load<Texture2D>("Menu/quitGame.png");

            clouds.Add(content.Load<Texture2D>("Menu/menuCloud1.png"));
            clouds.Add(content.Load<Texture2D>("Menu/menuCloud2.png"));

            blueSky = content.Load<Texture2D>("Menu/blueSky.png");
            menuGrass = content.Load<Texture2D>("Menu/menuGrass.png");
            backMountains = content.Load<Texture2D>("Menu/backMountains.png");
            gameTitle = content.Load<Texture2D>("Menu/gameTitle.png");
            
            options = content.Load<Texture2D>("Menu/options.png");
            backButton = content.Load<Texture2D>("Menu/backButton.png");
            fullScreen = content.Load<Texture2D>("Menu/fullscreenToggle.png");
            windowed = content.Load<Texture2D>("Menu/windowed.png");
            loadGame = content.Load<Texture2D>("Menu/loadGame.png");
            menuTrees = content.Load<Texture2D>("Menu/menuTrees.png");
            rock = content.Load<Texture2D>("Entities/rock.png");
            tree = content.Load<Texture2D>("Entities/tree.png");
            menuMusic = content.Load<Song>("Menu/Sounds/menuMusic");
            menuSelect = content.Load<SoundEffect>("Menu/Sounds/menuSelect");
            debugFont = content.Load<SpriteFont>("Fonts/debugFont");

            // Tiles

            tileSelector = content.Load<Texture2D>("Tiles/tileSelector.png");
            TileTextures.Add(content.Load<Texture2D>("Tiles/grass.png"));

            // Objects

            log = content.Load<Texture2D>("Entities/Tree/log.png");
            stump = content.Load<Texture2D>("Entities/Tree/stump.png");
            treeLeaves = content.Load<Texture2D>("Entities/Tree/treeLeaves.png");

            // UI

            itemBar = content.Load<Texture2D>("UI/itemBar.png");

            // Player

            player = content.Load<Texture2D>("Entities/Player/player.png");
            idleSheet = player;

            walkLeftSheet = content.Load<Texture2D>("Entities/Player/walkLeftSheet.png");
            walkRightSheet = content.Load<Texture2D>("Entities/Player/walkRightSheet.png");
            walkUpSheet = content.Load<Texture2D>("Entities/Player/walkLeftSheet.png");
            walkDownSheet = content.Load<Texture2D>("Entities/Player/walkRightSheet.png");

            // Collectables

            coin = content.Load<Texture2D>("Entities/coin.png");
        }

    }
}
