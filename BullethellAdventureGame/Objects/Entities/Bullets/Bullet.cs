using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CoreGame.Objects.Entities.Bullets
{
    public class Bullet : Entity
    {
        public Color BulletColor { get; set; } = Color.White;

        public BulletBehaviorManager ProcedureManager { get; set; } = null;

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X - sprite.Width / 2,
                    (int)Position.Y - sprite.Height / 2,
                    sprite.Width,
                    sprite.Height);
            }
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Player)
            {
                Active = false;
            }
        }

        public Bullet()
        {
            this.Position = new Vector2(600, 300);
            RotationAngle = MathHelper.ToRadians(0);
            Speed = 0;
            ProcedureManager = new BulletBehaviorManager();
            this.Initialize("Bullet");
        }

        public Bullet(Vector2 position, float speed, float rotation, float rotationSpeed, BulletBehaviorManager procedureManager, Color color)
        {
            this.Initialize("Bullet");
            this.Position = position;
            Speed = speed;
            RotationAngle = rotation;
            RotationSpeed = rotationSpeed;
            ProcedureManager = procedureManager;
            BulletColor = color;
        }

        public override void Initialize(string spriteName)
        {
            base.Initialize(spriteName);
        }

        public void Move()
        {
            Vector2 direction = new Vector2((float)Math.Cos(RotationAngle),
                                            (float)Math.Sin(RotationAngle));
            direction.Normalize();
            Position += direction * Speed;

            RotationAngle += MathHelper.ToRadians(RotationSpeed);
            float circle = MathHelper.TwoPi;
            RotationAngle = RotationAngle % circle;
        }

        public override void Update(GameTime gameTime)
        {
            Move();

            if (ProcedureManager != null)
            {
                ProcedureManager.PerformBehavior(this, gameTime, "Spawn");
            }
        }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)Position.X, (int)Position.Y, sprite.Width, sprite.Height), null, BulletColor, RotationAngle, Origin, SpriteEffects.None, 0);
            //spriteBatch.DrawString(font, RotationSpeed.ToString(), new Vector2(Position.X + 10, Position.Y + 10), Color.White);
        }

    }
}
