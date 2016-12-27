using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CoreGame.Objects.Entities
{
    public interface IBehaviorManager
    {
        Dictionary<string, List<IBehaviorAction>> Behaviors { get; set; }

        void PerformBehavior(Entity entity, GameTime gameTime, string behaviour);
    }

}
