using CoreGame.Graphics;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Objects.Entities.NPCS.Monsters
{
    public class Slime : Monster
    {
        public override void Initialize(string spriteName, string collisionSprite)
        {
            base.Initialize(spriteName, collisionSprite);
            idle = new Animation(sprite, 25, 20, 0, 6, 100, true);
            animator = new Animator(idle);
        }

        public override void Update(GameTime gameTime)
        {
            Velocity = Vector2.Zero;
            if (InputManager.Instance.isDown(Keys.B))
            {
                Velocity -= new Vector2(0, 10);
            }
            base.Update(gameTime);
        }

    }
}
