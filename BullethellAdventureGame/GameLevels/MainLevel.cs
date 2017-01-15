using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.UI;
using CoreGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CoreGame.GameLevels
{
    public class MainLevel : GameLevel
    {
        private Camera cam;
        public static Map map;

        private Texture2D backdrop;

        public override void Initialize()
        {
            ReadJson reader = new ReadJson();
            map = new Map(reader.ReadData("Data/New Map.json"));

            ResourceManager.Instance.Sprites.TryGetValue("Backdrop", out backdrop);

            //UIManager.Instance.ChangeCanvas(new PauseMenuCanvas());
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
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
                    UIManager.Instance.ChangeCanvas(new PlayerHudCanvas());
                }
            }

            if (!GameManager.Instance.Paused)
            {
                List<Entity> temp = new List<Entity>();

                if (InputManager.Instance.isDown(Keys.Q))
                {
                    cam.zoom += .1f;
                }

                if (InputManager.Instance.isDown(Keys.E))
                {
                    cam.zoom -= .1f;
                }

                map.Update(gameTime);
                cam.LookAtSmooth(map.player.Position);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var viewMatrix = cam.GetViewMatrix();
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, transformMatrix: viewMatrix);
            spriteBatch.Draw(backdrop, new Vector2(map.player.Position.X / 10 - 100, -50), null, Color.White * 0.5f);
            map.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}