using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Objects
{
    public class Entity
    {
        public String name;
        public Vector2 position;
        public Texture2D sprite;

        public String spriteName;

        public virtual void Initialize() { }

        //Loads the sprite
        public virtual void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }

        public virtual void Update(GameTime gameTime) { }

        //Draws the sprite at its position
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position);
            spriteBatch.End();
        }
    }
}