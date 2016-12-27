using CoreGame.Graphics;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Objects
{
    public class Player : Entity
    {
        private Animation animation;

        private Texture2D collisionBoxGraphic;

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X - sprite.Width / 2 + 28,
                    (int)Position.Y - sprite.Height / 2 + 15,
                    7,
                    27);
            }
        }

        public override void Initialize(string spriteName)
        {
            base.Initialize(spriteName);
            animation = new Animation(sprite, 32, 32, 3, 100, true);
            ResourceManager.Instance.Sprites.TryGetValue("Window", out collisionBoxGraphic);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.isDown(Keys.Up) || InputManager.Instance.controllerIsDown(Buttons.DPadUp))
            {
                Position += new Vector2(0, -1);
            }

            if (InputManager.Instance.isDown(Keys.Down) || InputManager.Instance.controllerIsDown(Buttons.DPadDown))
            {
                Position += new Vector2(0, 1);
            }

            if (InputManager.Instance.isDown(Keys.Right) || InputManager.Instance.controllerIsDown(Buttons.DPadRight))
            {
                Position += new Vector2(1, 0);
            }

            if (InputManager.Instance.isDown(Keys.Left) || InputManager.Instance.controllerIsDown(Buttons.DPadLeft))
            {
                Position += new Vector2(-1, 0);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(collisionBoxGraphic, BoundingBox, Color.White);
            spriteBatch.Draw(sprite, new Rectangle((int)Position.X, (int)Position.Y, sprite.Width, sprite.Height), null, Color.White, RotationAngle, Origin, SpriteEffects.None, 0);
        }

        public override void HandleCollision(Entity otherEntity)
        {

        }
    }
}