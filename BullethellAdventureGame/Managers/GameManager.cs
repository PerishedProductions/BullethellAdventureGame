using Microsoft.Xna.Framework;

namespace CoreGame.Managers
{
    public class GameManager
    {

        public static GameManager Instance { get; } = new GameManager();

        private GameManager() { }

        public bool Paused = false;
        public Game Game;

        public void CloseGame()
        {
            Game.Exit();
        }

    }
}
