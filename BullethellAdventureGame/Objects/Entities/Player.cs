using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreGame.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using CoreGame.Managers;

namespace CoreGame.Objects
{
    public class Player : PhysicsEntity
    {
        private Animation animation;

        private Texture2D collisionBoxGraphic;

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X,
                                     (int)Position.Y,
                                     16,
                                     16);
            }
        }

        public override void Initialize()
        {
            spriteName = "Player";
            base.Initialize();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            animation = new Animation(sprite, 32, 32, 3, 100, true);
            ResourceManager.Instance.Sprites.TryGetValue("Window", out collisionBoxGraphic);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Velocity = (new Vector2(0, -1));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Velocity += (new Vector2(0, 1));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Velocity += (new Vector2(1, 0));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Velocity += (new Vector2(-1, 0));
            }

            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(sprite, Position, Color.White);
            spriteBatch.Draw(collisionBoxGraphic, BoundingBox, Color.White);
        }
    }
}