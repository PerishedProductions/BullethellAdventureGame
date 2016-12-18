using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Objects
{
    public class Tile : Entity
    {

        public override void Initialize()
        {
            spriteName = "BasicTile";
            base.Initialize();
        }

        //Loads the sprite
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }

        public override void Update(GameTime gameTime) { }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Position);
        }

    }
}
