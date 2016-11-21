﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CoreGame.Managers;

namespace CoreGame.GameLevels
{
    public class MenuLevel : GameLevel
    {

        SpriteFont font;
        Vector2 titlePosition;

        int menuIndex;
        string[] menuItems = new string[3];

        public override void Initialize()
        {
            titlePosition = new Vector2(200, 100);
            menuItems[0] = "Play";
            menuItems[1] = "Options";
            menuItems[2] = "Exit";
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                LevelManager.Instance.ChangeLevel(new MainLevel());

            if (Keyboard.GetState().IsKeyUp(Keys.Up))
                if (menuIndex < 0)
                {
                    menuIndex = 2;
                }
                else
                {
                    menuIndex -= 1;
                }

            if (Keyboard.GetState().IsKeyUp(Keys.Down))
                if (menuIndex > 2)
                {
                    menuIndex = 0;
                }
                else
                {
                    menuIndex += 1;
                }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Bullet Hell Adventure Game", titlePosition, Color.White);

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (menuIndex == i)
                {
                    spriteBatch.DrawString(font, "- " + menuItems[i], titlePosition + new Vector2(titlePosition.X, titlePosition.Y + i * 50), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(font, menuItems[i], titlePosition + new Vector2(titlePosition.X, titlePosition.Y + i * 50), Color.White);
                }
            }

            spriteBatch.End();
        }
    }
}
