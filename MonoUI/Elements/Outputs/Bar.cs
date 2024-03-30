using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI.Elements.Outputs
{
    internal class Bar : ElementUI
    {
        #region Fields
        private NineSlice _barTexture;
        private Vector2 _padding;

        private Range _range;
        private double _value;
        #endregion

        #region Methods
        internal void Initialize(Vector2 position, Vector2 dimensions, Vector2 padding, Range range)
        {
            Position = position;
            Dimensions = dimensions;
            _padding = padding;
            _range = range;
        }

        internal void LoadContent(ContentManager content, string textureName, string barTextureName)
        {
            throw new NotImplementedException();
        }
        internal override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        internal override void Draw(SpriteBatch spriteBatch, Color color)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
