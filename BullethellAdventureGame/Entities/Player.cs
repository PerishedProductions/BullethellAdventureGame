using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Entities
{
    public class Player : Entity
    {

        public int moveSpeed = 5;

        public override void Initialize()
        {
            spriteName = "Tree";
            base.Initialize();
        }

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

    }
}
