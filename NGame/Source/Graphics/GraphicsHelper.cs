using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.Graphics
{
    public static class GraphicsHelper
    {
        private static Texture2D _Texture = new Texture2D(Globals.graphicsDevice.GraphicsDevice, 1, 1);
        public static void DrawRectangle(float x, float y, float width, float height, Color color)
        {
            _Texture.SetData<Color>(new Color[1] { color });
            Globals.spriteBatch.Draw(_Texture, new Rectangle((int)x, (int)y, (int)width, (int)height), color);
        }
    }
}
