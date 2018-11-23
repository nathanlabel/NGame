using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.GUI
{
    public class MenuManager : Entity, IUpdate, IDraw
    {
        private Stack<Menu> _MenuStack;
        public Menu ActiveMenu
        {
            get
            {
                if (_MenuStack.Count > 0)
                    return _MenuStack.Peek();
                else
                    return null;
            }
        }
        public bool Visible { get; set; } = true;

        public MenuManager()
        {
            _MenuStack = new Stack<Menu>();
        }

        public void Draw(GameTime gameTime)
        {
            if (Visible && ActiveMenu != null)
            {
                ActiveMenu.Draw(gameTime);
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (Enabled && _MenuStack.Count > 0)
                foreach (Menu menu in _MenuStack)
                    menu.Update(gameTime);

            base.Update(gameTime);
        }

        public void AddMenu(Menu menu)
        {
            _MenuStack.Push(menu);
        }
        public void PopMenu()
        {
            if (_MenuStack.Count > 0)
                _MenuStack.Pop();
        }
    }
}
