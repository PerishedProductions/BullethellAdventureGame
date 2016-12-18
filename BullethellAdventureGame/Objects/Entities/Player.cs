using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreGame.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;

namespace CoreGame.Objects
{
    public class Player : Entity
    {

        private Vector2 velocity;
        private Animation animation;

        private Vector2 oldPosition;

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

        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public override void Initialize()
        {
            spriteName = "Player";
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            animation = new Animation(sprite, 32, 32, 3, 100, true);
            collisionBoxGraphic = content.Load<Texture2D>("Window");
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = Position;

            Velocity = Vector2.Zero;

            Velocity += new Vector2(0, .5f);

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

            Position += Velocity;

            animation.Update(gameTime, Position);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(sprite, Position, Color.White);
            spriteBatch.Draw(collisionBoxGraphic, BoundingBox, Color.White);
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (BoundingBox.Bottom > otherEntity.BoundingBox.Top)
            {
                velocity.Y = 0;
                Position = new Vector2(Position.X, oldPosition.Y);
            }
        }
    }
}