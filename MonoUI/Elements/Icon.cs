﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoUI.Elements
{
    public class Icon
    {
        private Texture2D _sprite;
        private Vector2 _position;
        private Vector2 _dimensions;

        public Texture2D Sprite { get => _sprite; set => _sprite = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public Rectangle BoundingBox
        {
            get => new(Position.ToPoint(), _dimensions.ToPoint());
            set
            {
                _position = value.Location.ToVector2();
                _dimensions = value.Size.ToVector2();
            }
        }
        public Vector2 Center
        {
            get => BoundingBox.Size.ToVector2() / 2;
            set => _position = value - Center;
        }

        public void Initialize(Vector2 position, Vector2 size)
        {
            BoundingBox = new(position.ToPoint(), size.ToPoint());
            Center = position;
        }
        public void LoadContent(ContentManager content, string assetName)
        {
            Sprite = content.Load<Texture2D>(assetName);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(Sprite, BoundingBox, color);
        }
    }
}
