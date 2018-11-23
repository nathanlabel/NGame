using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NGame.Source.GUI
{
    class Button : MenuObject
    {
        private Texture2D _NormalTexture;
        private Texture2D _MouseOverTexture;
        private bool _IsMouseOver
        {
            get
            {
                Vector2 mousePosition = Globals.Mouse.Position;
                if (_NormalTexture != null)
                    if (Width > 0 && Height > 0)
                    {
                        if (mousePosition.X >= AbsolutePosition.X && mousePosition.Y >= AbsolutePosition.Y)
                            if (mousePosition.X <= AbsolutePosition.X + Width && mousePosition.Y <= AbsolutePosition.Y + Height)
                                return true;
                    }
                return false;
            }
        }

        public override float Width { get; protected set; }
        public override float Height { get; protected set; }
        public bool MouseOverGraphicEnabled { get; set; } = true;

        public Button()
        {

        }
        public Button(Vector2 position) : base(position)
        {
            Visible = false;
        }
        public Button(Vector2 position, string normalTexturePath, string mouseOverTexturePath) : base(position)
        {
            SetTextures(normalTexturePath, mouseOverTexturePath);
        }
        public Button(Vector2 position, string normalTexturePath) : base(position)
        {
            LoadNormalTexturePath(normalTexturePath);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                if (_IsMouseOver && _MouseOverTexture != null)
                {
                    Globals.spriteBatch.Draw(_MouseOverTexture, new Rectangle((int)AbsolutePosition.X, (int)AbsolutePosition.Y, 
                        (int)Width, (int)Height), Color.White);
                }
                else if (_NormalTexture != null)
                {
                    Globals.spriteBatch.Draw(_NormalTexture, new Rectangle((int)AbsolutePosition.X, (int)AbsolutePosition.Y,
                        (int)Width, (int)Height), Color.White);
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {

            }
            base.Update(gameTime);
        }

        private void SetTextures(string normalTexturePath, string mouseOverTexturePath)
        {
            LoadNormalTexturePath(normalTexturePath);
            LoadMouseOverTexturePath(mouseOverTexturePath);
        }
        private void LoadNormalTexturePath(string path)
        {
            _NormalTexture = Globals.Content.Load<Texture2D>(path);
        }
        private void LoadMouseOverTexturePath(string path)
        {
            _MouseOverTexture = Globals.Content.Load<Texture2D>(path);
        }
    }
}
