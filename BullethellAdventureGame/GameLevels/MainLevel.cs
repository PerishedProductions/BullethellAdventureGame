using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.Utilities;
using CoreGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Collections.Generic;

namespace CoreGame.GameLevels
{
    public class MainLevel : GameLevel
    {
        private Camera cam;
        private Player player;
        private Map map;

        public override void Initialize()
        {
            ReadJson reader = new ReadJson();
            map = new Map(reader.ReadData("Data/Map.json"));
            player = new Player();
            player.Initialize();
            player.Position = new Vector2(100, 50);

            //UIManager.Instance.ChangeCanvas(new PauseMenuCanvas());
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
        }

        public override void LoadContent()
        {
            map.LoadContent();
            player.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.isPressed(Keys.Escape) || InputManager.Instance.controllerIsDown(Buttons.Start))
            {
                GameManager.Instance.Paused = !GameManager.Instance.Paused;
                if (GameManager.Instance.Paused)
                {
                    UIManager.Instance.ChangeCanvas(new PauseMenuCanvas());
                }
                else
                {
                    UIManager.Instance.ChangeCanvas(new UICanvas());
                }
            }

            if (!GameManager.Instance.Paused)
            {
                List<Entity> temp = new List<Entity>();

                for (int i = 0; i < map.tiles.Count; i++)
                {
                    player.CheckCollision(map.tiles[i]);
                }

                if (InputManager.Instance.isDown(Keys.Q))
                {
                    cam.zoom += .1f;
                }

                if (InputManager.Instance.isDown(Keys.E))
                {
                    cam.zoom -= .1f;
                }

                cam.LookAtSmooth(player.Position);
                player.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var viewMatrix = cam.GetViewMatrix();
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, transformMatrix: viewMatrix);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}