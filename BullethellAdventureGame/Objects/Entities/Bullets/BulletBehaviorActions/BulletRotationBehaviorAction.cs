using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures
{
    public class BulletRotationBehaviorAction : IBehaviorAction
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

        public void PerformBehaviorAction(Entity entity, GameTime gameTime)
        {
            if (RotationSpeedAcceleration > 0)
            {
                if (entity.RotationSpeed >= TargetRotationSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    entity.RotationSpeed += RotationSpeedAcceleration;
                }
            }
            else
            {
                if (entity.RotationSpeed <= TargetRotationSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    entity.RotationSpeed += RotationSpeedAcceleration;
                }
            }
        }
    }
}
