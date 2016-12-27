using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using CoreGame.Managers;

namespace CoreGame.UI
{

    public enum Alignment { Left, Center, Right }

    public class UIText : UIElement
    {

        public string text;
        public Vector2 position;
        private SpriteFont font;
        private Alignment alignment = Alignment.Left;

        public UIText(Vector2 pos, string text)
        {
            this.position = pos;
            this.text = text;
        }

        public UIText(Vector2 pos, string text, Alignment alignment)
        {
            this.position = pos;
            this.text = text;
            this.alignment = alignment;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);

            switch (alignment)
            {
                case Alignment.Left:
                    break;
                case Alignment.Center:
                    position += new Vector2(font.MeasureString(text).X / 2, 0);
                    break;
                case Alignment.Right:
                    position += new Vector2(font.MeasureString(text).X, 0);
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {

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
