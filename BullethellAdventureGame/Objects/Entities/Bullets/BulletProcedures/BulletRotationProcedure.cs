using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures
{
    public class BulletRotationProcedure : IBulletProcedure
    {
        public float TargetRotationSpeed { get; set; }
        public float RotationSpeedAcceleration { get; set; }

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
            if (RotationSpeedAcceleration > 0)
            {
                if (bullet.RotationSpeed >= TargetRotationSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    bullet.RotationSpeed += RotationSpeedAcceleration;
                }
            }
            else
            {
                if (bullet.RotationSpeed <= TargetRotationSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    bullet.RotationSpeed += RotationSpeedAcceleration;
                }
            }
        }
    }
}
