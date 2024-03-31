using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI.Elements.Inputs
{
    internal class Slider : UIElement
    {
        private Range _range;
        private float _value;

        public void Initialize(
            Vector2 position,
            Vector2 dimensions,
            Icon icon,
            Label label,
            Range range,
            float initialValue)
        {
            base.Initialize(position, dimensions, icon, label);
            _range = range;
            _value = initialValue;
        }
        public override void LoadContent(ContentManager content, string[] assetNames)
        {
            base.LoadContent(content, assetNames[..2]);
        }
        public void Update(GameTime gameTime)
        {

        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);

            throw new NotImplementedException();
            //TODO: draw the slider in the correct position
        }
    }
}
