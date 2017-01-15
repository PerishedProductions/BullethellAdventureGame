using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.UI
{
    public enum Alignment { Left, Center, Right }
    public enum TextSize { Small, Medium, Big, Huge }

    public class UIText : UIElement
    {

        public string text;
        public Vector2 position;
        private Rectangle container;
        private SpriteFont font;
        private Alignment alignment = Alignment.Left;
        private TextSize textSize = TextSize.Medium;

        public UIText(Vector2 pos, string text)
        {
            this.position = pos;
            this.text = text;
        }

        public UIText(Rectangle container, string text, Alignment alignment)
        {
            this.text = text;
            this.alignment = alignment;
            this.container = container;
        }

        public UIText(Rectangle container, string text, Alignment alignment, TextSize textSize)
        {
            this.text = text;
            this.alignment = alignment;
            this.container = container;
            this.textSize = textSize;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            switch (textSize)
            {
                case TextSize.Small:
                    ResourceManager.Instance.Fonts.TryGetValue("FontSmall", out font);
                    break;
                case TextSize.Medium:
                    ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);
                    break;
                case TextSize.Big:
                    ResourceManager.Instance.Fonts.TryGetValue("FontBig", out font);
                    break;
                case TextSize.Huge:
                    ResourceManager.Instance.Fonts.TryGetValue("FontHuge", out font);
                    break;
            }

            if (container != null)
            {
                switch (alignment)
                {
                    case Alignment.Left:
                        break;
                    case Alignment.Center:
                        position = new Vector2(container.X + container.Width / 2 - font.MeasureString(text).X / 2, container.Y + container.Height / 2 - font.MeasureString(text).Y / 2);
                        break;
                    case Alignment.Right:
                        break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (font != null)
            {
                spriteBatch.DrawString(font, text, position, Color.White);
            }
        }

    }
}
