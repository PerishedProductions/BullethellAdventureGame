using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CoreGame.UI
{
    public class UIPanel : UIElement
    {
        public Rectangle size;

        String textureName;
        Texture2D sprite;

        public ColorTheme windowTheme = ColorTheme.Dark;
        public bool visible = true;

        private int TopPadding = 5;
        private int LeftPadding = 5;
        private int BottomPadding = 5;
        private int RightPadding = 5;

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

        private Rectangle[] CreatePatches(Rectangle rectangle)
        {
            var x = rectangle.X;
            var y = rectangle.Y;
            var w = rectangle.Width;
            var h = rectangle.Height;
            var middleWidth = w - LeftPadding - RightPadding;
            var middleHeight = h - TopPadding - BottomPadding;
            var bottomY = y + h - BottomPadding;
            var rightX = x + w - RightPadding;
            var leftX = x + LeftPadding;
            var topY = y + TopPadding;
            var patches = new[]
            {
                new Rectangle(x,      y,        LeftPadding,  TopPadding),      // top left
                new Rectangle(leftX,  y,        middleWidth,  TopPadding),      // top middle
                new Rectangle(rightX, y,        RightPadding, TopPadding),      // top right
                new Rectangle(x,      topY,     LeftPadding,  middleHeight),    // left middle
                new Rectangle(leftX,  topY,     middleWidth,  middleHeight),    // middle
                new Rectangle(rightX, topY,     RightPadding, middleHeight),    // right middle
                new Rectangle(x,      bottomY,  LeftPadding,  BottomPadding),   // bottom left
                new Rectangle(leftX,  bottomY,  middleWidth,  BottomPadding),   // bottom middle
                new Rectangle(rightX, bottomY,  RightPadding, BottomPadding)    // bottom right
            };
            return patches;
        }
    }
}
