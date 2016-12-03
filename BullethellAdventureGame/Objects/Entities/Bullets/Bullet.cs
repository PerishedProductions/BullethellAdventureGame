using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CoreGame.Objects.Entities.Bullets
{
    public class Bullet : Entity
    {
        public bool Active { get; set; } = true;
        public float RotationAngle { get; set; }
        public float RotationSpeed { get; set; }
        public float Speed { get; set; }

        public Vector2 Origin { get; set; }
        public Color BulletColor { get; set; } = Color.White;

        public BulletProcedureManager ProcedureManager { get; set; } = null;

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X - sprite.Width / 2,
                    (int)position.Y - sprite.Height / 2,
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
            spriteName = "Bullet";
            this.Initialize();
        }

        public Bullet(Vector2 position, float speed, float rotation, float rotationSpeed, BulletProcedureManager procedureManager, Color color)
        {
            spriteName = "Bullet";
            this.position = position;
            Speed = speed;
            RotationAngle = rotation;
            RotationSpeed = rotationSpeed;
            ProcedureManager = procedureManager;
            BulletColor = color;
        }

        public override void Initialize()
        {
            this.position = new Vector2(600, 300);
            RotationAngle = MathHelper.ToRadians(0);
            Speed = 0;
            ProcedureManager = new BulletProcedureManager();
        }

        public void Move()
        {
            Vector2 direction = new Vector2((float)Math.Cos(RotationAngle),
                                            (float)Math.Sin(RotationAngle));
            direction.Normalize();
            position += direction * Speed;

            RotationAngle += MathHelper.ToRadians(RotationSpeed);
            float circle = MathHelper.TwoPi;
            RotationAngle = RotationAngle % circle;
        }

        //Loads the sprite
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            Move();

            if (ProcedureManager != null)
            {
                ProcedureManager.PerformProcedure(this, gameTime);
            }
        }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height), null, BulletColor, RotationAngle, Origin, SpriteEffects.None, 0);
            //spriteBatch.DrawString(font, RotationSpeed.ToString(), new Vector2(Position.X + 10, Position.Y + 10), Color.White);
        }

    }
}
