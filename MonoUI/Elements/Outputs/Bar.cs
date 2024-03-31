using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI.Elements.Outputs
{
    internal class Bar : UIElement
    {
        #region Fields
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

        public override void LoadContent(ContentManager content, string[] assetNames)
        {
            if (assetNames.Length != 4)
            {
                throw new ArgumentException("Paramater must contain 4 values.", nameof(assetNames));
            }
            base.LoadContent(content, assetNames[..2]);
            _barTexture = new(content.Load<Texture2D>(assetNames[3]));
        }
        public void Update()
        {
            _barRect.Width = (int)(_barPosition.X + _barSize.X * _range.Lerp(_value));
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);
            _barTexture.Draw(spriteBatch, _barRect, color);
        }
        #endregion
    }
}
