using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoUI
{
    public class Label : UIElement
    {
        private SpriteFont _font;
        private string _text;
        private float _fontSize;

        public string Text { get => _text; set => _text = value; }
        public override Rectangle BoundingBox => new(
            Position.ToPoint(),
            (_font.MeasureString(Text) * _fontSize).ToPoint());

        public void LoadContent()
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            throw new System.NotImplementedException();
        }
    }
}