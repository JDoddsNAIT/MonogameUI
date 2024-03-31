using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoUI.Elements.Inputs
{
    public class Carousel : UIElement
    {
        #region Fields and Properties
        private Button _leftButton;
        private Button _rightButton;
        private Label _title;
        private Enum _enum;

        private int _selectedIndex;
        #endregion

        #region Monogame Methods
        public void Initialize(
            Vector2 position,
            Vector2 dimensions,
            Label label,
            Icon icon,
            Button leftButton,
            Button rightButton,
            Label title,
            Enum @enum)
        {
            base.Initialize(position, dimensions, icon, label);

            _leftButton = leftButton;
            _rightButton = rightButton;
            _title = title;
            _enum = @enum;
        }
        public override void LoadContent(ContentManager content, string[] assetNames)
        {
            if (assetNames.Length != 7)
            {
                throw new ArgumentException("Paramater must contain 7 values.", nameof(assetNames));
            }
            _leftButton.LoadContent(content, assetNames[..2]);
            _rightButton.LoadContent(content, assetNames[2..5]);
            _title.LoadContent(content, assetNames[6]);
        }
        public void Update(GameTime gameTime, MouseState currentMouseState, MouseState previousMouseStaate)
        {
            _leftButton.Update(gameTime, currentMouseState, previousMouseStaate);
            _rightButton.Update(gameTime, currentMouseState, previousMouseStaate);
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);

            _leftButton.Draw(spriteBatch, color);
            _rightButton.Draw(spriteBatch, color);
            _title.Draw(spriteBatch, color);
            throw new NotImplementedException();
            //TODO: make the base label display the selected value
        }
        #endregion

        #region Methods
        public void IncrementEnum()
        {
            throw new NotImplementedException();
        }

        public void DecrementEnum()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
