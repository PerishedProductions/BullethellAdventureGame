using CoreGame.Graphics;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Objects
{
    public class Player : DynamicEntity
    {
        private Animator animator;
        private Animation idleAnimationSword;
        private Animation walkingAnimation;
        private Animation attackAnimation;

        private bool flipped = false;

        public override void Initialize(string spriteName, string collisonSpriteName)
        {
            base.Initialize(spriteName, collisonSpriteName);
            idleAnimationSword = new Animation(sprite, 64, 32, 2, 3, 200, true);
            walkingAnimation = new Animation(sprite, 64, 32, 1, 7, 100, true);
            attackAnimation = new Animation(sprite, 64, 32, 3, 5, 100, false);
            animator = new Animator(idleAnimationSword);
            Origin = new Vector2(idleAnimationSword.destinationRect.Width / 2, idleAnimationSword.destinationRect.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            Velocity = Vector2.Zero;

            if (InputManager.Instance.isDown(Keys.Up) || InputManager.Instance.controllerIsDown(Buttons.DPadUp))
            {
                Velocity += new Vector2(0, -1);
            }

            if (InputManager.Instance.isDown(Keys.Down) || InputManager.Instance.controllerIsDown(Buttons.DPadDown))
            {
                Velocity += new Vector2(0, 1);
            }

            if (InputManager.Instance.isDown(Keys.Right) || InputManager.Instance.controllerIsDown(Buttons.DPadRight))
            {
                Velocity += new Vector2(1, 0);
            }

            if (InputManager.Instance.isDown(Keys.Left) || InputManager.Instance.controllerIsDown(Buttons.DPadLeft))
            {
                Velocity += new Vector2(-1, 0);
            }

            if (InputManager.Instance.isPressed(Keys.C) || InputManager.Instance.controllerIsPressed(Buttons.X))
            {
                animator.ChangeAnimation(attackAnimation);
                if (!flipped)
                    Velocity += new Vector2(10, 0);
                else
                    Velocity += new Vector2(-10, 0);
            }

            base.Update(gameTime);

            if (InputManager.Instance.isPressed(Keys.Z) || InputManager.Instance.controllerIsPressed(Buttons.A))
            {
                Velocity += new Vector2(0, -20);
            }

            if (Velocity.X < 0 && !flipped)
                flipped = !flipped;
            else if (Velocity.X > 0 && flipped)
                flipped = !flipped;

            if (Velocity.X != 0)
            {
                animator.ChangeAnimation(walkingAnimation);
            }
            else
            {
                animator.ChangeAnimation(idleAnimationSword);
            }

            animator.Update(gameTime, Position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(collisionSprite, BoundingBox, Color.White);
            animator.Draw(spriteBatch, RotationAngle, Origin, flipped);
        }
    }
}