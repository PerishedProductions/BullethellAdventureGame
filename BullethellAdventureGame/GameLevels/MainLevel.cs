using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CoreGame.Entities;

namespace CoreGame.GameLevels
{
    public class MainLevel : GameLevel
    {

        Player player;

        public override void Initialize()
        {
            player = new Player();
            player.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            player.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
