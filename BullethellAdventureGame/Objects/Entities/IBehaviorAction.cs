using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities
{
    public interface IBehaviorAction
    {
        bool IsFinished { get; set; }

        void PerformBehaviorAction(Entity entity, GameTime gameTime);
    }
}
