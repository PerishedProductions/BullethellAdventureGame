using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using CoreGame.GameLevels;

namespace CoreGame.Managers
{
    public class LevelManager
    {

        private static LevelManager instance;

        private LevelManager() { }

        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelManager();
                }
                return instance;
            }
        }

        public ContentManager content;

        public GameLevel currentLevel;

        public void ChangeLevel(GameLevel level)
        {
            currentLevel = level;
            currentLevel.Initialize();
            currentLevel.LoadContent(content);
        }
    }
}
