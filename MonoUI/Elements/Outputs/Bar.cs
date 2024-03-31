using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI.Elements.Outputs
{
    internal class Bar : UIElement
    {
        #region Fields
        private NineSlice _background;

        private Range _range;
        private float _value;

        #region Bar variables
        private NineSlice _barTexture;
        private Vector2 _barSize;
        private Vector2 _barPosition;
        private Rectangle _barRect;
        #endregion
        public float Value { get => _value; set => _value = value; }
        #endregion

        #region Methods
        public void Initialize(
            Vector2 position,
            Vector2 dimensions,
            Vector2 padding,
            Range range)
        {
            BoundingBox = new Rectangle(position.ToPoint(), dimensions.ToPoint());
            _range = range;

            _barPosition = padding;
            _barSize = BoundingBox.Size.ToVector2() - 2 * padding;
        }

        public void LoadContent(ContentManager content, string textureName, string barTextureName)
        {
            _background = new(content.Load<Texture2D>(textureName));
            _barTexture = new(content.Load<Texture2D>(barTextureName));
        }
        public void Update(GameTime gameTime)
        {
            _barRect.Width = (int)(_barPosition.X + _barSize.X * _range.Lerp(_value));
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            _background.Draw(spriteBatch, BoundingBox, color);
            _barTexture.Draw(spriteBatch, _barRect, color);
        }

        #endregion
    }
}
