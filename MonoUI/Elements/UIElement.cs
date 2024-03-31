using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoUI.Elements.Outputs;

namespace MonoUI.Elements
{
    public abstract class UIElement
    {
        private Vector2 _position;
        private Vector2 _dimensions;

        public Vector2 Position { get => _position; set => _position = value; }
        public virtual Rectangle BoundingBox
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

        public Icon Icon { get; set; }
        public Label Label { get; set; }

        public void Initialize(Vector2 position, Vector2 dimensions, Icon icon, Label label)
        {
            BoundingBox = new((position - dimensions / 2).ToPoint(), dimensions.ToPoint());
            Icon = icon;
            Label = label;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            Icon.Draw(spriteBatch, color);
            Label.Draw(spriteBatch, color);
        }
    }
}