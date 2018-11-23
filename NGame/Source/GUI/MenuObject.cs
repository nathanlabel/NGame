using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.GUI
{
    public abstract class MenuObject : Entity, IUpdate, IDraw
    {
        public abstract float Width { get; protected set; }
        public abstract float Height { get; protected set; }
        protected Vector2 AbsolutePosition
        {
            get
            {
                if (Owner != null)
                {
                    Vector2 absPos = new Vector2(Position.X + Owner.Position.X - (Width / 2), Position.Y + Owner.Position.Y - (Height / 2));
                    return absPos;
                }
                else return Position;
            }
        }
        public bool Visible { get; set; } = true;

        public MenuObject()
        {

        }
        public MenuObject(Vector2 position)
        {
            Position = position;
        }

        public abstract void Draw(GameTime gameTime);

    }
}
