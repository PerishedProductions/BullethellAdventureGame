using CoreGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.UI
{
    public enum Alignment { Left, Center, Right }

    public class UIText : UIElement
    {

        public string text;
        public Vector2 position;
        private Rectangle container;
        private SpriteFont font;
        private Alignment alignment = Alignment.Left;

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

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);

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
