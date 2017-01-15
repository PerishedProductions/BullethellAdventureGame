using CoreGame.GameLevels;
using Microsoft.Xna.Framework;

namespace CoreGame.Objects
{
    public class DynamicEntity : Entity
    {

        public Vector2 Velocity { get; set; }
        public int gravity { get; set; } = 2;

        public override void Update(GameTime gameTime)
        {
            Velocity += new Vector2(0, gravity);

            for (int i = 0; i < MainLevel.map.tiles.Count; i++)
            {
                HandleCollision(MainLevel.map.tiles[i]);
            }

            Position += Velocity;
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
