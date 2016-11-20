using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Objects
{
    public class Player : Entity
    {

        public int moveSpeed = 5;

        //Sets the spriteName so we know what to load
        public override void Initialize()
        {
            spriteName = "BasicTile";
            base.Initialize();
        }

        //Handles movement
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1 * moveSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 1 * moveSpeed;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, Color.Blue);
            spriteBatch.End();
        }

    }
}
