using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using CoreGame.Managers;

namespace CoreGame.UI
{
    public class UIText : UIElement
    {

        public string text;

        public Vector2 position;
        SpriteFont font;

        public UIText(Vector2 pos, string text)
        {
            this.position = pos;
            this.text = text;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);
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
