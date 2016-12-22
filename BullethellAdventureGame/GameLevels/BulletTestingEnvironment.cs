using CoreGame.Objects;
using CoreGame.Objects.Entities.Bullets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CoreGame.GameLevels
{
    public class BulletTestingEnvironment : GameLevel
    {
        public ContentManager Content { get; internal set; }
        public List<Bullet> bulletList { get; internal set; } = new List<Bullet>();
        private Bullet bullet;
        private Player player;

        public override void Initialize()
        {
            BulletFactory.Instance.LevelInstance = this;
            bullet = new Bullet();
            bullet.Initialize();
            player = new Player();
            player.Initialize();
            player.Position = new Vector2(600, 200);

        }

        public override void LoadContent()
        {
            bullet.LoadContent();
            player.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            bullet.Update(gameTime);
            for (int i = bulletList.Count - 1; i >= 0; i--)
            {
                bulletList[i].Update(gameTime);
                if (bulletList[i].CheckCollision(player))
                {
                    bulletList[i].HandleCollision(player);
                    if (bulletList[i].Active == false)
                    {
                        bulletList.Remove(bulletList[i]);
                    }
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            bullet.Draw(spriteBatch);
            foreach (var listItem in bulletList)
            {
                listItem.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
