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

        public ContentManager content;
        public Viewport viewport;

        public GameLevel currentLevel;

        public void ChangeLevel(GameLevel level)
        {
            currentLevel = level;
            currentLevel.Initialize();
            MainLevel temp = (MainLevel)currentLevel;
            temp.InitializeCam(viewport);
            currentLevel.LoadContent(content);
        }
    }
}
