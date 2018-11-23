using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source
{
    public class Entity : IUpdate
    {
        public Entity Owner { get; set; }
        public bool Enabled { get; set; } = true;
        public Vector2 Position { get; set; }
        public Entity()
        {
            Position = Vector2.Zero;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
        public virtual void SetOwner(Entity owner)
        {
            Owner = owner;
        }

    }
}
