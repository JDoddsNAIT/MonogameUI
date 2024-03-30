using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace JDoddsUI
{
    public class TextObject
    {
        #region Fields
        private string _text;
        private SpriteFont _font;
        private float _fontSize;
        private Color _fontColor;
        private Vector2 _position;
        #endregion

        #region Properties
        public Rectangle StringDimensions => new(
            location: _position.ToPoint(), 
            size: (_font.MeasureString(_text) * _fontSize).ToPoint());
        public Vector2 Position { get => _position; set => _position = value; }
        public string Text { get => _text; set => _text = value; }
        #endregion

        #region Methods
        #region Monogame Methods
        internal void Initialize(
            Vector2 position,
            string text,
            SpriteFont font,
            float fontSize,
            Color fontColor)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new System.ArgumentException($"'{nameof(text)}' cannot be null or empty.", nameof(text));
            }

            _position = position;
            _text = text;
            _font = font ?? throw new System.ArgumentNullException(nameof(font));
            _fontSize = fontSize;
            _fontColor = fontColor;
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            if (spriteBatch is null)
            {
                throw new ArgumentNullException(nameof(spriteBatch));
            }

            spriteBatch.DrawString(_font, _text, _position, _fontColor, 0, Vector2.Zero, _fontSize, SpriteEffects.None, 1);
        }
        #endregion
        #endregion
    }
}
