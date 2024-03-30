using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoUI.Elements;
using MonoUI.Utils;

namespace JDoddsUI
{
    /// <summary>
    /// A Button object for user interaction.
    /// </summary>
    internal class ElementButton : ElementUI
    {
        #region Fields
        private readonly TextObject _textObject = new();
        public readonly MonoTimer _fadeTimer = new(100, MonoTimer.Milliseconds);
        private Color _drawColor;
        private Color _hoverColor;

        private Vector2 _padding;

        private bool IsHovering = false;
        private bool WasHovering = false;
        #endregion

        #region Properties
        /// <summary>
        /// Is true on the frame this <see cref="ElementButton"/> is clicked.
        /// </summary>
        public bool IsClicked { get; set; }
        #endregion

        #region Methods
        #region Monogame Methods
        /// <summary>
        /// Initialize a new button.
        /// </summary>
        /// <param name="position">A <see cref="Vector2"/> representing the location of the button's center.</param>
        /// <param name="padding">A <see cref="Vector2"/> representing the space between the button edges and the text.</param>
        /// <param name="text">The text of the button's <see cref="TextObject"/>.</param>
        /// <param name="font">The SpriteFont that will be used to render the  <see cref="TextObject"/>.</param>
        /// <param name="fontSize">A <see cref="float"/> by which to multiply the dimensions of the <see cref="TextObject"/>.</param>
        /// <param name="fontColor">The font color of the <see cref="TextObject"/></param>
        /// <param name="drawColor">The color the button will be when the mouse is not hovering over the button.</param>
        /// <param name="hoverColor">The color the button will be when the mouse is hovering over the button.</param>
        internal void Initialize(
            Vector2 position,
            Vector2 padding,
            string text,
            SpriteFont font,
            float fontSize,
            Color fontColor,
            Color drawColor,
            Color hoverColor)
        {
            _dimensions = padding * 2 + font.MeasureString(text) * fontSize;
            _position = position - (_dimensions) / 2;
            _padding = padding;

            _drawColor = drawColor;
            _hoverColor = hoverColor;

            _fadeTimer.Reset();
            _fadeTimer.Stop();

            _textObject.Initialize(
                position: _position + _padding,
                text: text,
                font: font,
                fontSize: fontSize,
                fontColor: fontColor);
        }
        /// <summary>
        /// Initialize a new button.
        /// </summary>
        /// <param name="bounds">A <see cref="Rectangle"/> representing the size and dimensions of the button.</param>
        /// <param name="text">The text of the button's <see cref="TextObject"/>.</param>
        /// <param name="font">The SpriteFont that will be used to render the  <see cref="TextObject"/>.</param>
        /// <param name="fontSize">A <see cref="float"/> by which to multiply the dimensions of the <see cref="TextObject"/>.</param>
        /// <param name="fontColor">The font color of the <see cref="TextObject"/></param>
        /// <param name="drawColor">The color the button will be when the mouse is not hovering over the button.</param>
        /// <param name="hoverColor">The color the button will be when the mouse is hovering over the button.</param>
        internal void Initialize(
            Rectangle bounds,
            string text,
            SpriteFont font,
            float fontSize,
            Color fontColor,
            Color drawColor,
            Color hoverColor)
        {
            BoundingBox = bounds;
            _padding = (_dimensions - font.MeasureString(text) * fontSize) / 2;

            _drawColor = drawColor;
            _hoverColor = hoverColor;

            _fadeTimer.Reset();
            _fadeTimer.Start();

            _textObject.Initialize(
                position: _position + _padding,
                text: text,
                font: font,
                fontSize: fontSize,
                fontColor: fontColor);
        }
        internal void LoadContent(ContentManager content)
        {
            _texture = new(content.Load<Texture2D>("Button"), new Point(7, 7));
        }
        internal void Update(
            GameTime gameTime,
            MouseState currentMouseState,
            MouseState previousMouseState)
        {
            IsHovering = BoundingBox.Contains(currentMouseState.Position);
            WasHovering = BoundingBox.Contains(previousMouseState.Position);
            _fadeTimer.Start();

            if (IsHovering && !WasHovering ||
                !IsHovering && WasHovering)
            {
                _fadeTimer.Reset();
            }
            IsClicked = CheckClick(currentMouseState) && !CheckClick(previousMouseState);
            _fadeTimer.Update(gameTime);
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            double normal = IsHovering ?
                _fadeTimer.ElapsedRange : _fadeTimer.RemainingRange;
            _texture.Draw(spriteBatch, BoundingBox, Color.Lerp(_drawColor, _hoverColor, (float)normal));
            _textObject.Draw(spriteBatch);
        }
        #endregion

        private bool CheckClick(MouseState mouseState)
        {
            return BoundingBox.Contains(mouseState.Position)
                && mouseState.LeftButton == ButtonState.Pressed;
        }
        #endregion
    }
}
