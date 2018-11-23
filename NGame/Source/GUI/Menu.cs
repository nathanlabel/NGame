using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.GUI
{
    public class Menu : Entity, IUpdate, IDraw
    {
        private List<MenuObject> _MenuObjectCollection;

        public bool Visible { get; set; } = true;

        public Menu()
        {
            _MenuObjectCollection = new List<MenuObject>();
        }
        public Menu(Vector2 position)
        {
            Position = position;
            _MenuObjectCollection = new List<MenuObject>();
        }

        public void Draw(GameTime gameTime)
        {
            if (Visible)
                if (_MenuObjectCollection.Count > 0)
                    foreach (MenuObject menuObject in _MenuObjectCollection)
                        menuObject.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            if (Enabled)
                if (_MenuObjectCollection.Count > 0)
                    foreach (MenuObject menuObject in _MenuObjectCollection)
                        menuObject.Update(gameTime);
        }

        public void AddMenuObject(MenuObject menuObject)
        {
            if (!_MenuObjectCollection.Contains(menuObject))
            {
                _MenuObjectCollection.Add(menuObject);
                menuObject.SetOwner(this);
            }
        }
    }
}
