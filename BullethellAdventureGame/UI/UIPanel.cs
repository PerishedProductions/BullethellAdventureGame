using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CoreGame.UI
{
    public class UIPanel : UIElement
    {
        public Rectangle size;

        String textureName;
        Texture2D sprite;

        public WindowTheme windowTheme = WindowTheme.Dark;
        public bool visible = true;

        ContentManager content;

        public List<UIElement> elements = new List<UIElement>();

        public UIPanel(Rectangle size)
        {
            this.size = size;
        }

        public UIPanel(Rectangle size, WindowTheme theme)
        {
            this.size = size;
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

        public override void LoadContent(ContentManager content)
        {
            this.content = content;
            sprite = content.Load<Texture2D>(textureName);
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
            element.LoadContent(content);
            return element;
        }

    }
}
