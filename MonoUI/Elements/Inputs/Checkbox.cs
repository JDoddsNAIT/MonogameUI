using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI.Elements.Inputs
{
    public class Checkbox : UIElement
    {
        private bool _isChecked;
        private Button _box;

        public bool IsChecked { get => _isChecked; set => _isChecked = value; }

        public void Toggle()
        {
            throw new System.NotImplementedException();
        }

        public void Initialize(
            Vector2 position,
            Vector2 dimensions,
            Icon icon,
            Label label,
            Button box,
            bool initialValue)
        {
            base.Initialize(position, dimensions, icon, label);
            _box = box;
            _isChecked = initialValue;
            throw new System.NotImplementedException();
        }

        public override void LoadContent(ContentManager content, string[] assetNames)
        {
            if (assetNames.Length != 6)
            {
                throw new ArgumentException("Paramater must contain 6 values.", nameof(assetNames));
            }
            base.LoadContent(content, assetNames[..2]);
            _box.LoadContent(content, assetNames[2..5]);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);
            _box.Draw(spriteBatch, color);
            throw new System.NotImplementedException();
            //TODO: set the box's icon to a checkmark or X based on the value
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
