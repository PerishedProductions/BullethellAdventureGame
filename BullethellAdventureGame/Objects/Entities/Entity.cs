using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CoreGame.Objects
{
    public class Entity
    {
        public String name;
        private Vector2 position;

        public Texture2D sprite;
        public String spriteName;

        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X,
                                     (int)Position.Y,
                                     sprite.Width,
                                     sprite.Height);
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public virtual void Initialize() { }

        //Loads the sprite
        public virtual void LoadContent()
        {
            ResourceManager.Instance.Sprites.TryGetValue(spriteName, out sprite);
        }

        public virtual void Update(GameTime gameTime) { }

        //Draws the sprite at its position
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position);
            spriteBatch.End();
        }

        public virtual bool CheckCollision(Entity otherEntity)
        {
            return this.BoundingBox.Intersects(otherEntity.BoundingBox);
        }

        public virtual void HandleCollision(Entity otherEntity)
        {

        }
    }
}