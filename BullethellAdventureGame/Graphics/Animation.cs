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
        int currentFrame;

        Rectangle soureceRect;
        public Rectangle destinationRect;

        int frameHeight;
        int frameWidth;
        int scale = 1;

        bool active = true;
        bool looping;

        public Animation(Texture2D sprite, int frameWidth, int frameHeight, int frameCount, int frametime, bool looping)
        {
            this.sprite = sprite;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.looping = looping;
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

            soureceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2, (int)position.Y - (int)(frameHeight * scale) / 2, (int)(frameWidth * scale), (int)(frameHeight * scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(sprite, destinationRect, soureceRect, Color.White);
            }
        }
    }
}
