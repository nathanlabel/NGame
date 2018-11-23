using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NGame.Source.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source
{
    public class Globals
    {
        public static SpriteBatch spriteBatch;
        public static ContentManager Content;
        public static GraphicsDeviceManager graphicsDevice;
        public static NAMouse Mouse = new NAMouse();

        public static int ScreenWidth
        {
            get
            {
                return graphicsDevice.GraphicsDevice.Viewport.Width;
            }
        }
        public static int ScreenHeight
        {
            get
            {
                return graphicsDevice.GraphicsDevice.Viewport.Height;
            }
        }

        public static void Update(GameTime gameTime)
        {
            Mouse.Update(gameTime);
        }
    }
}
