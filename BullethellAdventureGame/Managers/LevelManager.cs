using CoreGame.GameLevels;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

        public Viewport viewport;
        public GameLevel currentLevel;

        /// <summary>
        /// Changes the current level
        /// </summary>
        /// <param name="level">the level we want to change to</param>
        public void ChangeLevel(GameLevel level)
        {
            currentLevel = level;
            currentLevel.Initialize();
            GameLevel temp = (GameLevel)currentLevel;
            temp.InitializeCam(viewport);
            currentLevel.LoadContent();
        }
    }
}
