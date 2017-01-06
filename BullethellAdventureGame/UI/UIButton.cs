using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CoreGame.UI
{
    public class UIButton : UIElement
    {

        UIText text;
        Rectangle size;
        Texture2D sprite;
        public string textureName;

        public bool Selected { get; set; } = false;

        public ColorTheme windowTheme = ColorTheme.Dark;

        int TopPadding = 5;
        int LeftPadding = 5;
        int BottomPadding = 5;
        int RightPadding = 5;

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

        public event Action onButtonClicked;

        public void OnButtonClicked()
        {
            if (onButtonClicked != null)
            {
                onButtonClicked.Invoke();
            }
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
            Selected = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Selected)
            {
                var sourcePathces = CreatePatches(sprite.Bounds);
                var destinationPatches = CreatePatches(size);

                for (var i = 0; i < sourcePathces.Length; i++)
                {
                    spriteBatch.Draw(sprite, sourceRectangle: sourcePathces[i], destinationRectangle: destinationPatches[i]);
                }
            }
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
