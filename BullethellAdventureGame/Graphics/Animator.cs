using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Graphics
{
    public class Animator
    {
        private Animation currentAnimation;

        public Animator(Animation startingAnimation)
        {
            currentAnimation = startingAnimation;
        }

        public void ChangeAnimation(Animation animation)
        {
            currentAnimation = animation;
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            currentAnimation.Update(gameTime, position);
        }

        public void Draw(SpriteBatch spriteBatch, float rotation, Vector2 origin, bool flipped)
        {
            currentAnimation.Draw(spriteBatch, rotation, origin, flipped);
        }

    }
}