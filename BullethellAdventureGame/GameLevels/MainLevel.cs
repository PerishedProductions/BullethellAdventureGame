using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CoreGame.Objects;
using CoreGame.Utilities;
using CoreGame.Managers;

namespace CoreGame.GameLevels
{
    public class MainLevel : GameLevel
    {
        Camera cam;
        Player player;
        Map map;

        public override void Initialize()
        {
            ReadJson reader = new ReadJson();
            map = new Map(reader.ReadData("Data/Map.json"));
            player = new Player();
            player.Initialize();
        }

        public void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
        }

        public override void LoadContent(ContentManager content)
        {
            map.LoadContent(content);
            player.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();

            // rotation
            if (keyboardState.IsKeyDown(Keys.Q))
                cam.rotation -= deltaTime;

            if (keyboardState.IsKeyDown(Keys.W))
                cam.rotation += deltaTime;

            // movement
            if (keyboardState.IsKeyDown(Keys.Up))
                cam.position -= new Vector2(0, 250) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.Down))
                cam.position += new Vector2(0, 250) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.Left))
                cam.position -= new Vector2(250, 0) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.Right))
                cam.position += new Vector2(250, 0) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.E))
                cam.zoom += deltaTime;

            if (keyboardState.IsKeyDown(Keys.R))
                cam.zoom -= deltaTime;

            player.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var viewMatrix = cam.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: viewMatrix);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
