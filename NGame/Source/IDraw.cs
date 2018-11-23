using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source
{
    public interface IDraw
    {
        bool Visible { get; }
        void Draw(GameTime gameTime);
    }
}
