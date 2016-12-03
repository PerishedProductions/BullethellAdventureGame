using System;

using CoreGame.GameLevels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Editor.GameLevels
{
    public class EditorLevel : GameLevel
    {

        SpriteFont font;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("FontBig");
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Editor Mode!!!!", Vector2.One, Color.White);
        }

    }
}
