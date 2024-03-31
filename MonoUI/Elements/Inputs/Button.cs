using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoUI;
using MonoUI.Elements;
using MonoUI.Elements.Outputs;
using System;

namespace JDoddsUI
{
    public class Button : UIElement
    {
        #region Fields
        private Action _onClick;
        private Icon _icon;
        private Label _label;
        private Color _fadeColor;
        private MonoTimer _fadeTimer;
        private int _padding;
        private NineSlice _background;
        private bool IsHovering = false;

        public Color CurrentColor => Color.Lerp(Color, _fadeColor, IsHovering ? (float)_fadeTimer.ElapsedRange : (float)_fadeTimer.RemainingRange);
        #endregion

        #region Properties

        #endregion

        #region Monogame Methods
        internal void Initialize(Vector2 position, Vector2 dimensions, NineSlice background, Color defaultColor, Color? fadeColor, Action onClick)
        {
            base.Initialize(position, dimensions, background, defaultColor, fadeColor, onClick);
        }
        internal void LoadContent(ContentManager content, string assetName, Point slice1, Point? slice2)
        {
            _background = slice2 is null ?
                new NineSlice(content.Load<Texture2D>(assetName), slice1) :
                new NineSlice(content.Load<Texture2D>(assetName), slice1, (Point)slice2);
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Methods

        public void CheckClick()
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
