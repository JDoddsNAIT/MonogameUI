using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI.Elements.Inputs
{
    public class DDL : UIElement
    {
        private Checkbox _showOptions;
        private Enum _options;

        public void Initialize(
            Vector2 position,
            Vector2 dimensions,
            Icon icon,
            Label label,
            Checkbox checkbox,
            Enum @enum)
        {
            base.Initialize(position, dimensions, icon, label);
            _showOptions = checkbox;
            _options = @enum;
        }
        public override void LoadContent(ContentManager content, string[] assetNames)
        {
            if (assetNames.Length != 6)
            {
                throw new ArgumentException("Paramater must contain 6 values.", nameof(assetNames));
            }
            base.LoadContent(content, assetNames[..2]);

            _showOptions.LoadContent(content, assetNames[3..5]);
        }
        public void Update()
        {
            throw new System.NotImplementedException();
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);
            _showOptions.Draw(spriteBatch, color);
            throw new System.NotImplementedException();
            //TODO: draw all the options as labels is the checkbox is true
        }
    }
}
