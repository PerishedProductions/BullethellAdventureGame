using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoreGame.Managers;

namespace CoreGame.UI
{
    class UIButton : UIElement
    {

        UIText text;
        Rectangle size;
        Texture2D sprite;
        public string textureName;

        public ColorTheme windowTheme = ColorTheme.Dark;

        public bool mouseOver;

        public UIButton(String text, Rectangle size, UICanvas canvas)
        {
            this.size = size;
            this.text = (UIText)canvas.CreateUIElement(new UIText(size, text, Alignment.Center), UILayer.Front);
        }

        public UIButton(String text, Rectangle size, ColorTheme theme, UICanvas canvas)
        {
            this.size = size;
            this.text = (UIText)canvas.CreateUIElement(new UIText(size, text, Alignment.Center), UILayer.Front);
            this.windowTheme = theme;
        }

        public override void Initialize()
        {
            switch (windowTheme)
            {
                case ColorTheme.Dark:
                    textureName = "Window";
                    break;
                case ColorTheme.Light:
                    textureName = "LightWindow";
                    break;
            }
        }

        public override void LoadContent()
        {
            ResourceManager.Instance.Sprites.TryGetValue(textureName, out sprite);
            text.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            mouseOver = size.Contains(InputManager.Instance.getMousePos());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, size, Color.White);
            text.Draw(spriteBatch);
        }

    }
}
