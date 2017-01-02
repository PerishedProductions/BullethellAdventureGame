using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Graphics
{
    public class Animation
    {

        Texture2D sprite;

        int elapsedTime;
        int frameTime;
        int frameCount;
        int frameRow;
        int currentFrame;

        Rectangle soureceRect;
        public Rectangle destinationRect;

        int frameHeight;
        int frameWidth;
        int scale = 1;

        public bool active = true;
        public bool looping;

        public Animation(Texture2D sprite, int frameWidth, int frameHeight, int frameRow, int frameCount, int frametime, bool looping)
        {
            this.sprite = sprite;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.looping = looping;
            this.frameRow = frameRow;
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            if (active == false)
            {
                return;
            }

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frameTime)
            {
                currentFrame++;

                if (currentFrame == frameCount)
                {
                    currentFrame = 0;

                    if (looping == false)
                    {
                        active = false;
                    }
                }

                elapsedTime = 0;
            }

            soureceRect = new Rectangle(currentFrame * frameWidth, frameRow * frameHeight, frameWidth, frameHeight);

            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2, (int)position.Y - (int)(frameHeight * scale) / 2, (int)(frameWidth * scale), (int)(frameHeight * scale));
        }

        public void Draw(SpriteBatch spriteBatch, float rotation, Vector2 origin, bool flipped)
        {
            if (active)
            {
                if (flipped)
                {
                    spriteBatch.Draw(sprite, destinationRect, soureceRect, Color.White, rotation, origin, SpriteEffects.FlipHorizontally, 0);
                }
                else
                {
                    spriteBatch.Draw(sprite, destinationRect, soureceRect, Color.White, rotation, origin, SpriteEffects.None, 0);
                }

            }
        }
    }
}
