using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using CoreGame.Managers;

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

            paused = (UIText)CreateUIElement(new UIText(new Vector2(10, 10), "Paused!!"));
            continueButton = (UIButton)CreateUIElement(new UIButton("Continue", new Rectangle(10, 50, 300, 50)));

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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
