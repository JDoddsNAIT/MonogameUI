using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoUI.Elements
{
    public class Label
    {
        private SpriteFont _font;
        private Vector2 _position;
        private string _text;
        private float _fontSize;

        public SpriteFont Font { get => _font; set => _font = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public string Text { get => _text; set => _text = value; }
        public Rectangle BoundingBox => new(Position.ToPoint(), (_font.MeasureString(Text) * _fontSize).ToPoint());
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
        public void LoadContent(ContentManager content, string assetName)
        {
            _font = content.Load<SpriteFont>(assetName);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(_font, Text, BoundingBox.Location.ToVector2(), color, 0, Center, _fontSize, SpriteEffects.None, 0);
        }
    }
}