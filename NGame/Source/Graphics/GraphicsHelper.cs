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
        private static Camera _TempCam = new Camera();
        private static Texture2D _Texture = new Texture2D(Globals.graphicsDevice.GraphicsDevice, 1, 1);
        public static void DrawRectangle(float x, float y, float width, float height, Color color)
        {
            _Texture.SetData<Color>(new Color[1] { color });
            Globals.spriteBatch.Draw(_Texture, new Rectangle((int)x, (int)y, (int)width, (int)height), color);
        }
        /// <summary>
        /// This helper methods calculates X value based on the position of the camera, position of
        /// the entity (Including its relation to an owner), and the offset value
        /// </summary>
        /// <param name="camera">The Camera Entity</param>
        /// <param name="entity">The Entity to be drawn</param>
        /// <returns></returns>
        public static float DrawnAbsoluteX(Camera camera, Entity entity)
        {
            float xval = ((entity.Position.X * Globals.Scale) - (camera.Position.X * Globals.Scale))
                + GetOffSet(camera).X;
            return xval;
        }
        public static float DrawnAbsoluteY(Camera camera, Entity entity)
        {
            float xval = ((entity.Position.Y * Globals.Scale) - (camera.Position.Y * Globals.Scale))
                + (GetOffSet(camera).Y * Globals.Scale);
            return xval;
        }
        public static float DrawnAbsoluteX(Entity entity)
        {
            
            float xval = ((entity.Position.X * Globals.Scale) - (_TempCam.Position.X * Globals.Scale))
                + GetOffSet(_TempCam).X;
            return xval;
        }
        public static float DrawnAbsoluteY(Entity entity)
        {
            float xval = ((entity.Position.Y * Globals.Scale) - (_TempCam.Position.Y * Globals.Scale))
                + (GetOffSet(_TempCam).Y * Globals.Scale);
            return xval;
        }
        public static Vector2 GetOffSet(Entity entity)
        {
            return new Vector2(entity.Dimension.X / 2, entity.Dimension.Y / 2);
        }
    }
}
