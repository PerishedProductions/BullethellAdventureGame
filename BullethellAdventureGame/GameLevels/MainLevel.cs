using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CoreGame.Entities;
using CoreGame.Utilities;

namespace CoreGame.GameLevels
{
    public class MainLevel : GameLevel
    {

        Player player;

        public override void Initialize()
        {
            player = new Player();
            player.Initialize();

            ReadJson jsonReader = new ReadJson();
            Debug.WriteLine(jsonReader.ReadData("Data/Data.json")["name"]);
            Debug.WriteLine(jsonReader.ReadData("Data/Data.json")["age"]);
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
