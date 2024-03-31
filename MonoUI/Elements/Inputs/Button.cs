using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoUI.Elements.Outputs;
using System;

namespace MonoUI.Elements.Inputs
{
    public class Button : UIElement
    {
        #region Fields
        private readonly MonoTimer _fadeTimer = new(100, TimeUnits.Milliseconds);
        private Action _onClick;
        private Color _color;
        private Color _fadeColor;
        private NineSlice _background;

        public Color CurrentColor => Color.Lerp(_color, _fadeColor, IsHovering ? (float)_fadeTimer.ElapsedRange : (float)_fadeTimer.RemainingRange);
        #endregion

        #region Properties
        public bool IsHovering { get; private set; }
        public bool WasHovering { get; private set; }
        #endregion

        #region Monogame Methods
        internal void Initialize(Vector2 position, Vector2 dimensions, Color color, Color? fadeColor, Action onClick, Icon icon, Label label)
        {
            base.Initialize(position, dimensions, icon, label);
            _color = color;
            _fadeColor = fadeColor ?? color;
            _onClick = onClick;
        }
        internal void LoadContent(ContentManager content, string assetName)
        {
            _background = new NineSlice(content.Load<Texture2D>(assetName));
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            _background.Draw(spriteBatch, BoundingBox, CurrentColor);
            base.Draw(spriteBatch, color);
        }

        public void Update(GameTime gameTime, MouseState currentMouseState, MouseState previousMouseState)
        {
            IsHovering = BoundingBox.Contains(currentMouseState.Position);
            WasHovering = BoundingBox.Contains(previousMouseState.Position);
            
            _fadeTimer.Start();
            if (IsHovering && !WasHovering ||
                !IsHovering && WasHovering)
            {
                _fadeTimer.Reset();
            }
            _fadeTimer.Update(gameTime);
            CheckClick(currentMouseState, previousMouseState);
        }
        #endregion

        #region Methods
        private bool CheckClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            bool value = BoundingBox.Contains(currentMouseState.Position)
                && currentMouseState.LeftButton == ButtonState.Pressed
                && BoundingBox.Contains(previousMouseState.Position)
                && previousMouseState.LeftButton == ButtonState.Released;
            if (value)
            {
                _onClick();
            }
            return value;
        }
        #endregion

    }
}
