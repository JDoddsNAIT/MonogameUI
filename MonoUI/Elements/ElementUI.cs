using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoUI.Elements
{
    public abstract class ElementUI
    {
        #region Fields
        private Vector2 _position;
        private Vector2 _dimensions;
        private NineSlice _bgTexture;
        private Color _color;
        private Color _fadeColor;

        private MonoTimer _fadeTimer = new(100, TimeUnits.Milliseconds);
        private bool IsHovering = false;
        private bool WasHovering = false;

        private MouseState _previousMouseState;
        private Action _onClick;
        #endregion

        #region Properties
        protected bool IsLeftClicked { get; set; }
        protected bool IsRightClicked { get; set; }
        protected NineSlice BgTexture { get => _bgTexture; set => _bgTexture = (NineSlice)value; }
        protected Color DefaultColor { get => _color; set => _color = value; }
        protected Color? FadeColor
        {
            get => _fadeColor;
            set => _fadeColor = value ?? this.DefaultColor;
        }

        protected Rectangle BoundingBox
        {
            get => new(_position.ToPoint(), _dimensions.ToPoint());
            private set
            {
                _position = value.Location.ToVector2();
                _dimensions = value.Size.ToVector2();
            }
        }

        private Color CurrentColor => Color.Lerp(_color, _fadeColor, IsHovering ? (float)_fadeTimer.ElapsedRange : (float)_fadeTimer.RemainingRange);
        #endregion

        #region Monogame Methods
        internal virtual void Initialize(
            Vector2 position,
            Vector2 dimensions,
            NineSlice background,
            Color defaultColor,
            Color? fadeColor,
            Action onClick)
        {
            BoundingBox = new(position.ToPoint() - (dimensions / 2).ToPoint(), dimensions.ToPoint());
            BgTexture = background;
            DefaultColor = defaultColor;
            FadeColor = fadeColor;
            _onClick = onClick;

            _previousMouseState = Mouse.GetState();
        }

        internal virtual void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();

            IsHovering = BoundingBox.Contains(currentMouseState.Position);
            WasHovering = BoundingBox.Contains(_previousMouseState.Position);
            _fadeTimer.Start();

            if (IsHovering && !WasHovering ||
                !IsHovering && WasHovering)
            {
                _fadeTimer.Reset();
            }
            _fadeTimer.Update(gameTime);

            if (CheckClick(currentMouseState, _previousMouseState))
            {
                _onClick();
            }
            _previousMouseState = currentMouseState;
        }

        internal virtual void Draw(SpriteBatch spriteBatch)
        {
            _bgTexture.Draw(spriteBatch, BoundingBox, CurrentColor);
        }
        #endregion

        #region Methods
        private bool CheckClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            return BoundingBox.Contains(currentMouseState.Position)
                && currentMouseState.LeftButton == ButtonState.Pressed
                && BoundingBox.Contains(previousMouseState.Position)
                && previousMouseState.LeftButton == ButtonState.Released;
        }
        #endregion
    }
}
