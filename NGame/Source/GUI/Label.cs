using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NGame.Source.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source.GUI
{
    public class Label : MenuObject
    {
        public string Text { get; set; }
        public Color TextColor { get; set; } = Color.White;
        public bool MouseOver { get; protected set; } = false;
        public bool BackgroundEnabled { get; set; } = true;
        public Color BackgroundColor { get; set; } = Color.Black;
        public override float Width
        {
            get
            {
                if (_Font != null)
                    return _Font.MeasureString(Text).X;
                else
                    return 0;

            }
            protected set
            {
                throw new Exception("You cannot set this");
            }
        }
        public override float Height
        {
            get
            {
                if (_Font != null)
                    return _Font.MeasureString(Text).Y;
                else
                    return 0;
            }
            protected set
            {
                throw new Exception("You cannot set this");
            }
        }

        private SpriteFont _Font;
        protected Rectangle AbsDestinationRectangle
        {
            get
            {
                if (Owner != null && _Font != null)
                {

                    return new Rectangle((int)AbsolutePosition.X, (int)AbsolutePosition.Y, (int)Width, (int)Height);
                }
                else
                    throw new Exception("Unable to return a destination rectangle");
            }
        }

        public event EventHandler<EventArgs> LeftClick;
        public event EventHandler<EventArgs> RightClick;

        public Label(string text, Vector2 position, string font = "Default") : base(position)
        {
            Text = text;
            _Font = Globals.Content.Load<SpriteFont>(font);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                if (BackgroundEnabled)
                    GraphicsHelper.DrawRectangle(AbsDestinationRectangle.X, AbsDestinationRectangle.Y,
                        AbsDestinationRectangle.Width, AbsDestinationRectangle.Height, BackgroundColor);

                Globals.spriteBatch.DrawString(_Font, Text, AbsolutePosition, TextColor);
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                CheckForLeftClick();
                CheckForRightClick();
            }
            base.Update(gameTime);
        }

        private void CheckForLeftClick()
        {
            if (Globals.Mouse.Position.X >= AbsDestinationRectangle.X && Globals.Mouse.Position.Y >= AbsDestinationRectangle.Y)
                if (Globals.Mouse.Position.X <= AbsDestinationRectangle.X + AbsDestinationRectangle.Width &&
                    Globals.Mouse.Position.Y <= AbsDestinationRectangle.Y + AbsDestinationRectangle.Height)
                    if (Globals.Mouse.OldState.LeftButton == ButtonState.Pressed && Globals.Mouse.NewState.LeftButton == ButtonState.Released)
                        OnLeftClick(this, null);

        }
        private void CheckForRightClick()
        {
            if (Globals.Mouse.Position.X >= AbsDestinationRectangle.X && Globals.Mouse.Position.Y >= AbsDestinationRectangle.Y)
                if (Globals.Mouse.Position.X <= AbsDestinationRectangle.X + AbsDestinationRectangle.Width &&
                    Globals.Mouse.Position.Y <= AbsDestinationRectangle.Y + AbsDestinationRectangle.Height)
                    if (Globals.Mouse.OldState.RightButton == ButtonState.Pressed && Globals.Mouse.NewState.RightButton == ButtonState.Released)
                        OnRightClick(this, null);
        }

        protected virtual void OnRightClick(object sender, EventArgs e)
        {
            RightClick?.Invoke(sender, e);
        }
        protected virtual void OnLeftClick(object sender, EventArgs e)
        {
            LeftClick?.Invoke(sender, e);
        }

    }
}
