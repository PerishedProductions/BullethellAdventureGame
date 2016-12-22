﻿using CoreGame.Managers;
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
        Camera cam;
        Player player;
        Map map;

        UICanvas canvas = new UICanvas();

        public override void Initialize()
        {
            ReadJson reader = new ReadJson();
            map = new Map(reader.ReadData("Data/Map.json"));
            player = new Player();
            player.Initialize();
            player.Position = new Vector2(100, 50);
            canvas.Initialize();
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
        }

        public override void LoadContent()
        {
            map.LoadContent();
            player.LoadContent();
            canvas.LoadContent();
            canvas.CreateUIElement(new UIPanel(new Rectangle(109, 100, 500, 100)));
        }

        public override void Update(GameTime gameTime)
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

            cam.LookAt(player.Position);
            player.Update(gameTime);
            canvas.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var viewMatrix = cam.GetViewMatrix();
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, transformMatrix: viewMatrix);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();

            canvas.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}