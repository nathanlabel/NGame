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
        public virtual Vector2 Position { get; set; } = Vector2.Zero;
        public virtual Vector2 Dimension { get; protected set; } = new Vector2(1, 1);
        public float Rotation { get; set; } = 0f;

        public virtual void Update(GameTime gameTime)
        {
            
        }
        public virtual void SetOwner(Entity owner)
        {
            Owner = owner;
        }

    }
}
