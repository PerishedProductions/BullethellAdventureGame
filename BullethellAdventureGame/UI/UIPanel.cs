using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CoreGame.Managers;

namespace CoreGame.UI
{
    public class UIPanel : UIElement
    {
        public Rectangle size;

        String textureName;
        Texture2D sprite;

        public ColorTheme windowTheme = ColorTheme.Dark;
        public bool visible = true;

        public List<UIElement> elements = new List<UIElement>();

        public UIPanel(Rectangle size)
        {
            this.size = size;
        }

        public UIPanel(Rectangle size, ColorTheme theme)
        {
            this.size = size;
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
                case ColorTheme.None:
                    textureName = null;
                    break;
            }
        }

        public override void LoadContent()
        {
            if (textureName != null)
            {
                ResourceManager.Instance.Sprites.TryGetValue(textureName, out sprite);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].Update(gameTime);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(sprite, size, Color.White);

                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].Draw(spriteBatch);
                }
            }
        }

        public UIElement CreateUIElement(UIElement element)
        {
            elements.Add(element);
            element.Initialize();
            element.LoadContent();
            return element;
        }
    }
}
