using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source
{
    public interface IUpdate
    {
        bool Enabled { get; }
        void Update(GameTime gameTime);

    }
}
