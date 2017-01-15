using CoreGame.GameLevels;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.UI
{
    public class MainMenuCanvas : UICanvas
    {

        UIText title;

        UIButton startGameButton;
        UIButton settingsButton;
        UIButton exitButton;

        Texture2D backdrop;

        public override void LoadContent()
        {
            ResourceManager.Instance.Sprites.TryGetValue("Window", out backdrop);

            title = (UIText)CreateUIElement(new UIText(new Rectangle(0, 0, 1280, 300), "GAME TITLE!!!", Alignment.Center, TextSize.Huge), UILayer.Middle);
            startGameButton = (UIButton)CreateUIElement(new UIButton("Start Game", new Rectangle(1280 / 2 - 300 / 2, 300, 300, 50), this), UILayer.Middle);
            startGameButton.onButtonClicked += () =>
            {
                LevelManager.Instance.ChangeLevel(new MainLevel());
                UIManager.Instance.ChangeCanvas(new PlayerHudCanvas());
            };

            settingsButton = (UIButton)CreateUIElement(new UIButton("Settings", new Rectangle(1280 / 2 - 300 / 2, 355, 300, 50), this), UILayer.Middle);
            exitButton = (UIButton)CreateUIElement(new UIButton("Exit Game", new Rectangle(1280 / 2 - 300 / 2, 410, 300, 50), this), UILayer.Middle);
            exitButton.onButtonClicked += () =>
            {
                GameManager.Instance.CloseGame();
            };

            base.LoadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.Draw(backdrop, new Rectangle(0, 0, 1280, 720), Color.Black * 0.7f);
            spriteBatch.End();

            base.Draw(spriteBatch);
        }

    }
}
