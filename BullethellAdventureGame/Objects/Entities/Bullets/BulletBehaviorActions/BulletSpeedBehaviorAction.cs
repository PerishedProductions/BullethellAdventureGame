using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures
{
    public class BulletSpeedBehaviorAction : IBehaviorAction
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

        public void PerformBehaviorAction(Entity entity, GameTime gameTime)
        {
            if (Acceleration > 0)
            {
                if (entity.Speed >= TargetSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    entity.Speed += Acceleration;
                }
            }
            else
            {
                if (entity.Speed <= TargetSpeed)
                {
                    _isFinished = true;
                }
                else
                {
                    entity.Speed += Acceleration;
                }
            }
        }
    }
}
