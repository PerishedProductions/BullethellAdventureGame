using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures
{
    public class BulletSpeedProcedure : IBulletProcedure
    {
        public float TargetSpeed { get; set; }
        public float Acceleration { get; set; }

        private bool _isFinished;

        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }

            set
            {
                _isFinished = value;
            }
        }

        public void PerformCommand(Bullet bullet, GameTime gameTime)
        {
            if (Acceleration > 0)
            {
                if (bullet.Speed >= TargetSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    bullet.Speed += Acceleration;
                }
            }
            else
            {
                if (bullet.Speed <= TargetSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    bullet.Speed += Acceleration;
                }
            }
        }
    }
}
