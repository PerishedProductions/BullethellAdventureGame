using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures
{
    public interface IBulletProcedure
    {
        bool IsFinished { get; set; }

        void PerformCommand(Bullet bullet, GameTime gameTime);
    }
}
