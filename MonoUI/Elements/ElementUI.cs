using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoUI.Utils;

namespace MonoUI.Elements
{
    public abstract class ElementUI
    {
        protected Vector2 _position;
        protected Vector2 _dimensions;

        protected NineSlice _texture;

        public Rectangle BoundingBox
        {
            get { return new(_position.ToPoint(), _dimensions.ToPoint()); }
            set
            {
                _position = value.Location.ToVector2();
                _dimensions = value.Size.ToVector2();
            }
        }
        
        internal abstract void Initialize(Vector2 position, Vector2 dimensions);
        internal abstract void LoadContent(ContentManager content);
        internal abstract void Update(GameTime gameTime);
        internal abstract void Draw(SpriteBatch spriteBatch);
    }
}
