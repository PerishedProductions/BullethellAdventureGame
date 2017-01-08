using CoreGame.GameLevels;
using CoreGame.Graphics;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Objects
{
    public class Player : Entity
    {
        private Animator animator;
        private Animation idleAnimationSword;
        private Animation walkingAnimation;
        private Animation attackAnimation;

        public Vector2 Velocity { get; set; }
        private int gravity = 2;
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

            if (InputManager.Instance.isPressed(Keys.C))
            {
                animator.ChangeAnimation(attackAnimation);
            }

            //Velocity += new Vector2(0, gravity);

            if (InputManager.Instance.isPressed(Keys.Z))
            {
                Velocity += new Vector2(0, -10);
            }

            for (int i = 0; i < MainLevel.map.tiles.Count; i++)
            {
                HandleCollision(MainLevel.map.tiles[i]);
            }

            Position += Velocity;

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

        public override void HandleCollision(Entity otherEntity)
        {
            if (!otherEntity.IsCollisionActive)
            {
                return;
            }

            //Move Right
            if (Velocity.X > 0)
            {
                // Check if the top point or bottom point of the right wall are inside of the other entity
                if (PlaceMeeting(Position.X + BoundingBox.Width / 2 + Velocity.X, Position.Y + BoundingBox.Height / 2, otherEntity) ||
                    PlaceMeeting(Position.X + BoundingBox.Width / 2 + Velocity.X, Position.Y - BoundingBox.Height / 2, otherEntity))
                {
                    Velocity = new Vector2(0, Velocity.Y);
                }
            }
            //Move Left
            else if (Velocity.X < 0)
            {
                // Check if the top point or bottom point of the left wall are inside of the other entity
                if (PlaceMeeting(Position.X - BoundingBox.Width / 2 + Velocity.X, Position.Y + BoundingBox.Height / 2, otherEntity) ||
                    PlaceMeeting(Position.X - BoundingBox.Width / 2 + Velocity.X, Position.Y - BoundingBox.Height / 2, otherEntity))
                {
                    Velocity = new Vector2(0, Velocity.Y);
                }
            }
            //Move Down
            if (Velocity.Y > 0)
            {
                // Check if the left point or right point of the bottom wall are inside of the other entity
                if (PlaceMeeting(Position.X + BoundingBox.Width / 2, Position.Y + BoundingBox.Height / 2 + Velocity.Y, otherEntity) ||
                    PlaceMeeting(Position.X - BoundingBox.Width / 2, Position.Y + BoundingBox.Height / 2 + Velocity.Y, otherEntity))
                {
                    Velocity = new Vector2(Velocity.X, 0);
                }
            }
            //Move Up
            else if (Velocity.Y < 0)
            {
                // Check if the left point or right point of the top wall are inside of the other entity
                if (PlaceMeeting(Position.X + BoundingBox.Width / 2, Position.Y - BoundingBox.Height / 2 + Velocity.Y, otherEntity) ||
                    PlaceMeeting(Position.X - BoundingBox.Width / 2, Position.Y - BoundingBox.Height / 2 + Velocity.Y, otherEntity))
                {
                    Velocity = new Vector2(Velocity.X, 0);
                }
            }
        }

        bool PlaceMeeting(float x, float y, Entity otherEntity)
        {
            Vector2 point = new Vector2(x, y);

            if (otherEntity.BoundingBox.Contains(point))
            {
                return true;
            }
            return false;
        }

    }
}