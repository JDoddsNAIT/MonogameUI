using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoUI.Elements.Outputs;

namespace MonoUI.Elements
{
    public abstract class UIElement
    {
        private Vector2 _position;
        private Vector2 _dimensions;
        private NineSlice _background;

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

        public NineSlice Background { get => _background; set => _background = value; }
        public Icon Icon { get; set; }
        public Label Label { get; set; }

        public void Initialize(Vector2 position, Vector2 dimensions, Icon icon, Label label)
        {
            BoundingBox = new((position - dimensions / 2).ToPoint(), dimensions.ToPoint());
            Icon = icon;
            Label = label;
        }
        public virtual void LoadContent(ContentManager content, string[] assetNames)
        {
            if (assetNames.Length != 3)
            {
                throw new System.ArgumentException("Parameter must contain 3 values.", nameof(assetNames));
            }
            Background = new(content.Load<Texture2D>(assetNames[0]));
            Icon.LoadContent(content, assetNames[1]);
            Label.LoadContent(content, assetNames[2]);
        }
        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            Background.Draw(spriteBatch, BoundingBox, color);
            Icon.Draw(spriteBatch, color);
            Label.Draw(spriteBatch, color);
        }
        public virtual void Update(GameTime gameTime, MouseState mouseState, MouseState pMouseState)
        {
            ;
        }
    }
}