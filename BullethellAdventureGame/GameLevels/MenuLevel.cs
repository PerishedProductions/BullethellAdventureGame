using CoreGame.Managers;
using CoreGame.UI;

namespace CoreGame.GameLevels
{
    public class MenuLevel : GameLevel
    {
        public override void LoadContent()
        {
            UIManager.Instance.ChangeCanvas(new MainMenuCanvas());
        }
    }
}
