using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Silverstone.Util {

    static class Resolution {
        static public Matrix ScaleMatrix { get; set; }
        static public Vector2 Scale { get; set; }
        static public int GameWidth { get; set; }
        static public int GameHeight { get; set; }
#if WINDOWS
        static public int ScreenWidth { get; set; }
        static public int ScreenHeight { get; set; }
        static public Boolean WasResized { get; set; }
        static private int PreviousWindowWidth;
        static private int PreviousWindowHeight;
#endif


        static public void Initialize(GraphicsDeviceManager graphics) {
#if WINDOWS
            ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            PreviousWindowWidth = graphics.PreferredBackBufferWidth;
            PreviousWindowHeight = graphics.PreferredBackBufferHeight;
            WasResized = false;
#endif
            GameWidth = 1280;
            GameHeight = 720;
            CalculateMatrix(graphics);
        }


#if WINDOWS
        static public void Update(Game game, GraphicsDeviceManager graphics) {
            if (WasResized) {
                if (graphics.PreferredBackBufferWidth < Resolution.GameWidth / 4) {
                    if (graphics.PreferredBackBufferWidth == 0)
                        graphics.PreferredBackBufferWidth = PreviousWindowWidth;
                    else
                        graphics.PreferredBackBufferWidth = Resolution.GameWidth / 4;
                }
                if (graphics.PreferredBackBufferHeight < Resolution.GameHeight / 4) {
                    if (graphics.PreferredBackBufferHeight == 0)
                        graphics.PreferredBackBufferHeight = PreviousWindowHeight;
                    else
                        graphics.PreferredBackBufferHeight = Resolution.GameHeight / 4;
                }
                graphics.ApplyChanges();
                CalculateMatrix(graphics);
                PreviousWindowWidth = graphics.PreferredBackBufferWidth;
                PreviousWindowHeight = graphics.PreferredBackBufferHeight;
                WasResized = false;
            }
        }
#endif


        static void CalculateMatrix(GraphicsDeviceManager graphics) {
            ScaleMatrix = Matrix.CreateScale((float)graphics.PreferredBackBufferWidth / GameWidth, (float)graphics.PreferredBackBufferHeight / GameHeight, 1f);
            Scale = new Vector2(ScaleMatrix.M11, ScaleMatrix.M22);
        }
    }
}