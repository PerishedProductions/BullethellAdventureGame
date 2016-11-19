using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.GameLevels
{
    public class MenuLevel : GameLevel
    {

        SpriteFont font;
        Vector2 titlePosition;

        public override void Initialize()
        {
            titlePosition = new Vector2(200, 100);
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                //TODO: Add logic for switching scenes
                
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Bullet Hell Adventure Game", titlePosition, Color.White);

            spriteBatch.End();
        }
    }
}
