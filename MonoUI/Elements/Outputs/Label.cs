using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoUI
{
    public class Label
    {
        private SpriteFont _font;
        private string _text;
        private float _fontSize;
        private Vector2 _position;
        private Vector2 _dimensions;
        private Texture2D _texture;
        private Color _color;

        public Texture2D Texture { get => _texture; set => _texture = value; }
        public Color Color { get => _color; set => _color = value; }

        public Vector2 Position { get => _position; set => _position = value; }
        public string Text { get => _text; set => _text = value; }
        public Rectangle BoundingBox => new(
            Position.ToPoint(),
            (_font.MeasureString(Text) * _fontSize).ToPoint());
        public Vector2 Center
        {
            get => BoundingBox.Size.ToVector2() / 2;
            set => _position = value - Center;
        }

        public void Initialize(Vector2 position, string text, float fontSize)
        {
            Center = position;
            Text = text;
            _fontSize = fontSize;
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(_font, Text, BoundingBox.Location.ToVector2(), color, 0, Center, _fontSize, SpriteEffects.None, 0);
        }

        public void LoadContent(ContentManager content, string assetName)
        {
            _font = content.Load<SpriteFont>(assetName);
        }
    }
}