using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoUI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoUI
{
    public abstract class UIElement
    {
        private Vector2 _position;
        private Vector2 _dimensions;
        private Texture2D _texture;
        private Color _color;

        public Texture2D Texture { get => _texture; set => _texture = value; }
        public Color Color { get => _color; set => _color = value; }

        public Vector2 Position { get => _position; set => _position = value; }
        public virtual Rectangle BoundingBox => new Rectangle(Position.ToPoint(), _dimensions.ToPoint());
        public Vector2 Center
        {
            get => BoundingBox.Size.ToVector2() / 2;
            set
            {
                _position = value - Center;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch, Color color);
    }
}