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

        public WindowTheme windowTheme = WindowTheme.Dark;

        public bool mouseOver;

        public UIButton(String text, Rectangle size)
        {
            this.size = size;
            this.text = new UIText(new Vector2(size.X, size.Y), text);
        }

        public UIButton(String text, Rectangle size, WindowTheme theme)
        {
            this.size = size;
            this.text = new UIText(new Vector2(size.X, size.Y), text, Alignment.Center);
            this.windowTheme = theme;
        }

        public override void Initialize()
        {
            switch (windowTheme)
            {
                case WindowTheme.Dark:
                    textureName = "Window";
                    break;
                case WindowTheme.Light:
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
