using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoUI.Elements.Outputs
{
    public class SegmentDisplay : UIElement
    {
        private int _digits;
        private int _value;
        private Rectangle[] _sourceRectangles = new Rectangle[10];
        private Texture2D _texture;

        public int Value { get => _value; set => _value = value; }

        public void Initialize(
            Vector2 position,
            Vector2 dimensions,
            Icon icon,
            Label label,
            int digits,
            int initialValue)
        {
            base.Initialize(position, dimensions, icon, label);
            _digits = digits;
            _value = initialValue;
            throw new System.NotImplementedException();
        }
        public override void LoadContent(ContentManager content, string[] assetNames)
        {
            if (assetNames.Length != 4)
            {
                throw new System.ArgumentException("Paramater must contain 4 values.", nameof(assetNames));
            }
            base.LoadContent(content, assetNames[..2]);
            _texture = content.Load<Texture2D>(assetNames[3]);
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);
            throw new System.NotImplementedException();
            //TODO: draw the correct number
        }
        public void Increment()
        {
            throw new System.NotImplementedException();
        }

    }
}
