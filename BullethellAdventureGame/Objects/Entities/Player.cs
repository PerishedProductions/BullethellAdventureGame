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
                return new Rectangle((int)Position.X + 28,
                                     (int)Position.Y + 15,
                                     7,
                                     27);
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
            if (InputManager.Instance.isDown(Keys.Up) || InputManager.Instance.controllerIsDown(Buttons.DPadUp))
            {
                Velocity = (new Vector2(0, -1));
            }

            if (InputManager.Instance.isDown(Keys.Down) || InputManager.Instance.controllerIsDown(Buttons.DPadDown))
            {
                Velocity += (new Vector2(0, 1));
            }

            if (InputManager.Instance.isDown(Keys.Right) || InputManager.Instance.controllerIsDown(Buttons.DPadRight))
            {
                Velocity += (new Vector2(1, 0));
            }

            if (InputManager.Instance.isDown(Keys.Left) || InputManager.Instance.controllerIsDown(Buttons.DPadLeft))
            {
                Velocity += (new Vector2(-1, 0));
            }

            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(collisionBoxGraphic, BoundingBox, Color.White);
            spriteBatch.Draw(sprite, Position, Color.White);
        }
    }
}