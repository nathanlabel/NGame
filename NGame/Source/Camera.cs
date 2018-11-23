using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NGame.Source
{
    public class Camera : Entity
    {
        public override Vector2 Dimension
        {
            get
            {
                return new Vector2(Globals.graphicsDevice.GraphicsDevice.Viewport.Width,
                    Globals.graphicsDevice.GraphicsDevice.Viewport.Height);
            }
        }
        public Entity Target
        {
            get;
            private set;
        }
        public override Vector2 Position
        {
            get
            {
                if (Target != null && Enabled)
                    return Target.Position;
                else
                    return base.Position;
            }
            set => base.Position = value;
        }

        public void SetTarget (Entity target)
        {
            Target = target;
        }
        public void UnsetTarget()
        {
            Target = null;
        }

        
    }
}
