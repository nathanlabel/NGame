using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.Graphics
{
    public class Sprite : Entity, IDraw
    {
        protected Texture2D Texture { get; set; }
        protected Rectangle SourceRectangle { get; set; }
        public bool Visible { get; set; } = true;

        public Sprite(string texturePath)
        {
            LoadTexture(texturePath);
            SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
        }
        public Sprite(string texturePath, Rectangle sourceRectangle)
        {
            LoadTexture(texturePath);
            SourceRectangle = sourceRectangle;
        }

        protected virtual void LoadTexture(string path)
        {
            if (Globals.Content != null)
            {
                Globals.Content.Load<Texture2D>(path);
            }
            else
                throw new Exception("Unable to load content, ContentManager is null");
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (Visible && Texture != null)
            {
                Globals.spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White, Rotation, Origin,
                    SpriteEffects.None, 0f);
            }
        }
    }
}
