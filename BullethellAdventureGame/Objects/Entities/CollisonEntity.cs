using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreGame.Objects
{
    public class PhysicsEntity : Entity
    {

        public struct CorrectionVector2
        {
            public DirectionX DirectionX;
            public DirectionY DirectionY;
            public float X;
            public float Y;
        }

        public enum DirectionX
        {
            Left = -1,
            None = 0,
            Right = 1
        }

        public enum DirectionY
        {
            Up = -1,
            None = 0,
            Down = 1
        }

        private Vector2 velocity;

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

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public override bool CheckCollision(Entity otherEntity)
        {
            return base.CheckCollision(otherEntity);
        }

        public override void HandleCollision(Entity otherEntity)
        {

        }

        public CorrectionVector2 GetCorrectionVector(Entity target)
        {
            CorrectionVector2 ret = new CorrectionVector2();

            float x1 = Math.Abs(BoundingBox.Right - target.BoundingBox.Left);
            float x2 = Math.Abs(BoundingBox.Left - target.BoundingBox.Right);
            float y1 = Math.Abs(BoundingBox.Bottom - target.BoundingBox.Top);
            float y2 = Math.Abs(BoundingBox.Top - target.BoundingBox.Bottom);

            // calculate displacement along X-axis
            if (x1 < x2)
            {
                ret.X = x1;
                ret.DirectionX = DirectionX.Left;
            }
            else if (x1 > x2)
            {
                ret.X = x2;
                ret.DirectionX = DirectionX.Right;
            }

            // calculate displacement along Y-axis
            if (y1 < y2)
            {
                ret.Y = y1;
                ret.DirectionY = DirectionY.Up;
            }
            else if (y1 > y2)
            {
                ret.Y = y2;
                ret.DirectionY = DirectionY.Down;
            }

            return ret;
        }

        public int SumHorizontal(List<CorrectionVector2> correctionVectors)
        {
            int sum = 0;

            for (int i = 0; i < correctionVectors.Count; i++)
            {
                sum += (int)correctionVectors[i].DirectionX;
            }

            return sum;
        }

        public int SumVertical(List<CorrectionVector2> correctionVectors)
        {
            int sum = 0;

            for (int i = 0; i < correctionVectors.Count; i++)
            {
                sum += (int)correctionVectors[i].DirectionY;
            }

            return sum;
        }

    }
}
