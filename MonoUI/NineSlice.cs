using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoUI
{
    /// <summary>
    /// Divides a <see cref="Texture2D"/> into 9 cells. Used for scaling, the size of the corner cells will remain the same while the edge and center cells may stretch or tile to match the new dimensions.
    /// </summary>
    public struct NineSlice
    {
        #region Members
        // The slices[0] will always be {0,0}. slices[3] will always be the texture bounds.
        private readonly Point[] _slices = new Point[4];
        private readonly Rectangle[,] _sourceRectangles = new Rectangle[3, 3];

        public Texture2D Texture { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a <see cref="NineSlice"/> from a texture and two points. Each point represents the location of a vertical and horizontal slice, or size of either the top-left or bottom-right corner cells.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="slice1">Location of the first vertical and horizontal slice, or size of the top-left corner cell.</param>
        /// <param name="slice2">Location of the second vertical and horizontal slice, or size of the bottom-right corner cell.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NineSlice(Texture2D texture, Point slice1, Point slice2)
        {
            Texture = texture;
            _slices[0] = new Point();
            _slices[1] = slice1;
            _slices[2] = slice2;
            _slices[3] = Texture.Bounds.Size;
            SetRectangles(_sourceRectangles, _slices);
        }
        /// <summary>
        /// Creates a <see cref="NineSlice"/> from a texture and a point. <paramref name="slice"/> is the size of all corners cells.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="slice">The size of each corner cell of the <see cref="NineSlice"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NineSlice(Texture2D texture, Point slice)
        {
            Texture = texture;
            _slices[0] = new Point();
            _slices[1] = slice;
            _slices[2] = Texture.Bounds.Size - slice;
            _slices[3] = Texture.Bounds.Size;
            SetRectangles(_sourceRectangles, _slices);
        }
        /// <summary>
        /// Creates a <see cref="NineSlice"/> from a texture. Slices are evenly spaced.
        /// </summary>
        /// <param name="texture"></param>
        public NineSlice(Texture2D texture)
        {
            Texture = texture;
            for (int i = 0; i < _slices.Length; i++)
            {
                _slices[i] = new Point(
                    Texture.Bounds.Width * (i / _slices.Length - 1),
                    Texture.Bounds.Height * (i / _slices.Length - 1));
            }
            SetRectangles(_sourceRectangles, _slices);
        }
        #endregion
        #region Methods
        private static void SetRectangles(Rectangle[,] rectangles, Point[] points)
        {
            for (int r = 0; r < rectangles.GetLength(0); r++)
            {
                for (int c = 0; c < rectangles.GetLength(1); c++)
                {
                    rectangles[r, c] = new(
                        points[c].X,
                        points[r].Y,
                        points[c + 1].X - points[c].X,
                        points[r + 1].Y - points[r].Y);
                }
            }
        }
        internal void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            Point[] slices = new Point[4];
            slices[0] = destinationRectangle.Location;
            slices[3] = destinationRectangle.Location + destinationRectangle.Size;

            slices[1] = slices[0] + _slices[1];
            slices[2] = slices[3] - (_slices[3] - _slices[2]);

            Rectangle[,] destinationRectangles = new Rectangle[3, 3];
            SetRectangles(destinationRectangles, slices);
            for (int r = 0; r < destinationRectangles.GetLength(0); r++)
            {
                for (int c = 0; c < destinationRectangles.GetLength(1); c++)
                {
                    spriteBatch.Draw(Texture, destinationRectangles[r, c], _sourceRectangles[r, c], color);
                }
            }
        }
        internal void Draw(SpriteBatch sprite, Rectangle destinationRectangle) => Draw(sprite, destinationRectangle, Color.White);
        #endregion
    }
}
