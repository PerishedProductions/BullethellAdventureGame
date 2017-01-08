using CoreGame.GameLevels;
using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.UI
{
    public class PauseMenuCanvas : UICanvas
    {

        UIText paused;

        UIButton continueButton;
        UIButton settingsButton;
        UIButton exitButton;

        Texture2D backdrop;

        public override void LoadContent()
        {
            ResourceManager.Instance.Sprites.TryGetValue("Window", out backdrop);

            paused = (UIText)CreateUIElement(new UIText(new Vector2(10, 5), "Paused!!"), UILayer.Middle);
            continueButton = (UIButton)CreateUIElement(new UIButton("Continue", new Rectangle(10, 50, 300, 50), this), UILayer.Middle);
            continueButton.onButtonClicked += () =>
            {
                UIManager.Instance.ChangeCanvas(null);
                GameManager.Instance.Paused = false;
            };
            settingsButton = (UIButton)CreateUIElement(new UIButton("Settings", new Rectangle(10, 105, 300, 50), this), UILayer.Middle);
            exitButton = (UIButton)CreateUIElement(new UIButton("Exit Game", new Rectangle(10, 160, 300, 50), this), UILayer.Middle);
            exitButton.onButtonClicked += () =>
            {
                LevelManager.Instance.ChangeLevel(new MenuLevel());
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
