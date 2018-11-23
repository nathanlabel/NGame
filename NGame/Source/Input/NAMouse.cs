using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.Input
{
    public class NAMouse : IUpdate
    {
        public MouseState OldState;
        public MouseState NewState;

        public bool Enabled { get; set; } = true;
        public Vector2 Position
        {
            get { return new Vector2(NewState.Position.X, NewState.Position.Y); }
        }

        public NAMouse()
        {
            OldState = Mouse.GetState();
            NewState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                OldState = NewState;
                NewState = Mouse.GetState();
            }
        }
    }
}
