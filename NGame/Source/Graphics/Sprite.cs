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
        public Texture2D Texture { get; protected set; }
        protected Rectangle SourceRectangle { get; set; }
        protected Rectangle DestinationRectangle { get; set; }
        public bool Visible { get; set; } = true;
        protected Vector2 Origin
        {
            get
            {
                return new Vector2(Texture.Width / 2, Texture.Height / 2);
            }
        }
        public float Rotation { get; set; } = 0f;

        public Sprite(string texturePath)
        {
            LoadTexture(texturePath);
            SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
        public Sprite(string texturePath, Rectangle destinationRectangle)
        {
            LoadTexture(texturePath);
            SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            DestinationRectangle = destinationRectangle;
        }
        public Sprite(string texturePath, Rectangle destinationRectangle, Rectangle sourceRectangle)
        {
            LoadTexture(texturePath);
            SourceRectangle = sourceRectangle;
            DestinationRectangle = destinationRectangle;
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
