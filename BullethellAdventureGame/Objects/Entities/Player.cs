using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
                //Check if bottom has a collision
                if (LineIntersectsRect(new Point(otherEntity.BoundingBox.Left, otherEntity.BoundingBox.Top), new Point(otherEntity.BoundingBox.Right, otherEntity.BoundingBox.Top), BoundingBox))
                {
                    position.Y = otherEntity.BoundingBox.Top - sprite.Height;
                    return;
                }

                //Check if right has a collision
                if (LineIntersectsRect(new Point(otherEntity.BoundingBox.Right, otherEntity.BoundingBox.Top), new Point(otherEntity.BoundingBox.Right, otherEntity.BoundingBox.Bottom), BoundingBox))
                {
                    position.X = otherEntity.BoundingBox.Right;
                    return;
                }

                //Check if left has a collision
                if (LineIntersectsRect(new Point(otherEntity.BoundingBox.Left, otherEntity.BoundingBox.Top), new Point(otherEntity.BoundingBox.Left, otherEntity.BoundingBox.Bottom), BoundingBox))
                {
                    position.X = otherEntity.BoundingBox.Left - sprite.Width;
                    return;
                }

                //Check if top has a collision
                if (LineIntersectsRect(new Point(otherEntity.BoundingBox.Left, otherEntity.BoundingBox.Bottom), new Point(otherEntity.BoundingBox.Right, otherEntity.BoundingBox.Bottom), BoundingBox))
                {
                    position.Y = otherEntity.BoundingBox.Bottom;
                    return;
                }

            }
        }

        private bool LineIntersectsRect(Point p1, Point p2, Rectangle r)
        {
            return LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) ||
                   (r.Contains(p1) || r.Contains(p2));
        }

        private bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

            if (d == 0)
            {
                return false;
            }

            float r = q / d;

            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }

            return true;
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