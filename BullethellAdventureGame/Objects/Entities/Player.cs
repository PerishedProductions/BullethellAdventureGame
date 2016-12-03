using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Objects
{
    public class Player : Entity
    {

        public int moveSpeed = 5;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    sprite.Width,
                    sprite.Height);
            }
        }

        //Sets the spriteName so we know what to load
        public override void Initialize()
        {
            spriteName = "Player";
            base.Initialize();
        }

        //Handles movement
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1 * moveSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 1 * moveSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= 1 * moveSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += 1 * moveSpeed;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position);
        }

    }
}