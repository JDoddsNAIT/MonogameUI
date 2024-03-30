using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoUI.Elements;
using MonoUI.Elements.Outputs;
using System;

namespace JDoddsUI
{
    internal class Button : ElementUI
    {
        #region Fields
        private Icon _icon;
        private Label _label;
        private Vector2 _padding;
        #endregion

        #region Properties

        #endregion

        #region Monogame Methods
        internal override void Initialize(Vector2 position, Vector2 dimensions, NineSlice background, Color defaultColor, Color? fadeColor, Action onClick)
        {
            base.Initialize(position, dimensions, background, defaultColor, fadeColor, onClick);
        }
        internal void LoadContent(ContentManager content, string assetName, Point slice1, Point? slice2)
        {
            BgTexture = slice2 is null ?
                new NineSlice(content.Load<Texture2D>(assetName), slice1) : 
                new NineSlice(content.Load<Texture2D>(assetName), slice1, (Point)slice2);
        }
        #endregion

        #region Methods

        #endregion
    }
}
