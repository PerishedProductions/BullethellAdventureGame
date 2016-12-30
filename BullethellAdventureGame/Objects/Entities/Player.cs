using CoreGame.GameLevels;
using CoreGame.Graphics;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CoreGame.Objects
{
    public class Player : Entity
    {
        private Animation animation;

        public Vector2 Velocity { get; set; }
        private int gravity = 2;
        private bool flipped = false;

        public override void Initialize(string spriteName, string collisonSpriteName)
        {
            base.Initialize(spriteName, collisonSpriteName);
            animation = new Animation(sprite, 32, 32, 8, 100, true);
            Origin = new Vector2(animation.destinationRect.Width / 2, animation.destinationRect.Height / 2);
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

            Velocity += new Vector2(0, gravity);

            if (InputManager.Instance.isDown(Keys.X))
            {
                Velocity += new Vector2(0, -4);
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

            animation.Update(gameTime, Position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(collisionSprite, BoundingBox, Color.White);
            animation.Draw(spriteBatch, RotationAngle, Origin, flipped);
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (Velocity.X > 0)
            {
                if (PlaceMeeting(Position.X + BoundingBox.Width / 2 + Velocity.X, Position.Y + BoundingBox.Height / 2, otherEntity))
                {
                    while (!PlaceMeeting(Position.X + BoundingBox.Width / 2 + Math.Sign(Velocity.X), Position.Y + BoundingBox.Height / 2, otherEntity))
                    {
                        Position += new Vector2(Math.Sign(Velocity.X), 0);
                    }
                    Velocity = new Vector2(0, Velocity.Y);
                }
            }
            else if (Velocity.X < 0)
            {
                if (PlaceMeeting(Position.X - BoundingBox.Width / 2 + Velocity.X, Position.Y - BoundingBox.Height / 2, otherEntity))
                {
                    while (!PlaceMeeting(Position.X - BoundingBox.Width / 2 + Math.Sign(Velocity.X), Position.Y - BoundingBox.Height / 2, otherEntity))
                    {
                        Position += new Vector2(Math.Sign(Velocity.X), 0);
                    }
                    Velocity = new Vector2(0, Velocity.Y);
                }
            }

            if (Velocity.Y > 0)
            {
                if (PlaceMeeting(Position.X + BoundingBox.Width / 2, Position.Y + BoundingBox.Height / 2 + Velocity.Y, otherEntity))
                {
                    while (!PlaceMeeting(Position.X + BoundingBox.Width / 2, Position.Y + BoundingBox.Height / 2 + Math.Sign(Velocity.Y), otherEntity))
                    {
                        Position += new Vector2(0, Math.Sign(Velocity.Y));
                    }
                    Velocity = new Vector2(Velocity.X, 0);
                }
            }
            else if (Velocity.Y < 0)
            {
                if (PlaceMeeting(Position.X - BoundingBox.Width / 2, Position.Y - BoundingBox.Height / 2 + Velocity.Y, otherEntity))
                {
                    while (!PlaceMeeting(Position.X - BoundingBox.Width / 2, Position.Y - BoundingBox.Height / 2 + Math.Sign(Velocity.Y), otherEntity))
                    {
                        Position += new Vector2(0, Math.Sign(Velocity.Y));
                    }
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