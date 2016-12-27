using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Objects
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public bool IsCollisionActive { get; set; }

        public bool Active { get; set; } = true;
        public float RotationAngle { get; set; }
        public float RotationSpeed { get; set; }
        public float Speed { get; set; }
        public Vector2 Origin { get; set; }

        protected Texture2D sprite;

        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X - sprite.Width / 2,
                    (int)Position.Y - sprite.Height / 2,
                    sprite.Width,
                    sprite.Height);
            }
        }

        public virtual void Initialize(string spriteName)
        {
            ResourceManager.Instance.Sprites.TryGetValue(spriteName, out sprite);
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public abstract void Update(GameTime gameTime);

        //Draws the sprite at its position
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Position);
        }

        public virtual bool CheckCollision(Entity otherEntity)
        {
            return this.BoundingBox.Intersects(otherEntity.BoundingBox);
        }

        public abstract void HandleCollision(Entity otherEntity);
    }
}