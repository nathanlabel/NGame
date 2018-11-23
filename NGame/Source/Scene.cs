using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source
{
    public class Scene : Entity, IUpdate, IDraw
    {
        private List<Entity> _EntityCollection;

        public bool Visible { get; set; } = true;
        public string Name { get; }

        public Scene(string name)
        {
            _EntityCollection = new List<Entity>();
            Name = name;
        }

        public void AddEntity(Entity entity)
        {
            if (!_EntityCollection.Contains(entity))
            {
                _EntityCollection.Add(entity);
                entity.SetOwner(this);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled && _EntityCollection.Count > 0)
            {
                foreach (Entity entity in _EntityCollection)
                    entity.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime)
        {
            if (Visible && _EntityCollection.Count > 0)
            {
                foreach (Entity entity in _EntityCollection)
                    if (entity is IDraw)
                        ((IDraw)entity).Draw(gameTime);
            }
        }
    }
}
