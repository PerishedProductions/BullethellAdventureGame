using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CoreGame.UI
{
    public class UICanvas
    {
        public string name;
        public List<UIElement> frontLayer = new List<UIElement>();
        public List<UIElement> middleLayer = new List<UIElement>();
        public List<UIElement> bottomLayer = new List<UIElement>();

        public List<UIButton> menuButtons = new List<UIButton>();
        public int menuIndex = 0;

        public virtual void Initialize()
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].Initialize();
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].Initialize();
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].Initialize();
            }
        }

        public virtual void LoadContent()
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].LoadContent();
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].LoadContent();
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].LoadContent();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].Update(gameTime);
            }

            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].Update(gameTime);
            }

            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].Update(gameTime);
            }

            if (menuButtons.Count != 0)
            {
                if (InputManager.Instance.isPressed(Keys.Up) || InputManager.Instance.controllerIsPressed(Buttons.DPadUp))
                {
                    if (menuIndex == 0)
                        menuIndex = menuButtons.Count - 1;
                    else
                        menuIndex--;
                }

                if (InputManager.Instance.isPressed(Keys.Down) || InputManager.Instance.controllerIsPressed(Buttons.DPadDown))
                {
                    if (menuIndex == menuButtons.Count - 1)
                        menuIndex = 0;
                    else
                        menuIndex++;
                }

                if (InputManager.Instance.isPressed(Keys.Enter) || InputManager.Instance.controllerIsPressed(Buttons.A))
                {
                    menuButtons[menuIndex].OnButtonClicked();
                }

                menuButtons[menuIndex].Selected = true;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            for (int i = 0; i < bottomLayer.Count; i++)
            {
                bottomLayer[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            for (int i = 0; i < middleLayer.Count; i++)
            {
                middleLayer[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            for (int i = 0; i < frontLayer.Count; i++)
            {
                frontLayer[i].Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public UIElement CreateUIElement(UIElement element, UILayer layer)
        {
            switch (layer)
            {
                case UILayer.Front:
                    frontLayer.Add(element);
                    break;
                case UILayer.Middle:
                    middleLayer.Add(element);
                    break;
                case UILayer.Bottom:
                    bottomLayer.Add(element);
                    break;
            }

            if (element is UIButton)
            {
                menuButtons.Add((UIButton)element);
            }

            element.Initialize();
            element.LoadContent();
            return element;
        }
    }
}
