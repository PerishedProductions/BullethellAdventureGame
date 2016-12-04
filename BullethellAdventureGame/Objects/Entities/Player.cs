using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Diagnostics;

namespace CoreGame.Objects
{
    public class Player : Entity
    {

        public int moveSpeed = 5;

        float gravity = 1;

        //Sets the spriteName so we know what to load
        public override void Initialize()
        {
            spriteName = "Player";
            base.Initialize();
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Tile)
            {
                if (BoundingBox.Right > otherEntity.BoundingBox.Left && BoundingBox.Bottom - 8 < otherEntity.BoundingBox.Top && BoundingBox.Bottom - 8 > otherEntity.BoundingBox.Bottom)
                {
                    position.X = otherEntity.BoundingBox.Left - sprite.Width;
                }

                if (BoundingBox.Bottom > otherEntity.BoundingBox.Top)
                {
                    position.Y = otherEntity.BoundingBox.Top - sprite.Height;
                }
            }
        }

        //Handles movement
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 1;
            }


            position.Y += gravity;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position);
        }

    }
}