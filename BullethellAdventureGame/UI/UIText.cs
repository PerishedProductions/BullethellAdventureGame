using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

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

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("FontMedium");
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
