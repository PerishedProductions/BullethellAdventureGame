using CoreGame.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Objects.Entities.NPCS.Monsters
{
    class Slime : Monster
    {

        public override void Initialize(string spriteName)
        {
            base.Initialize(spriteName);
            idle = new Animation(sprite, 25, 20, 0, 6, 100, true);
            animator = new Animator(idle);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
