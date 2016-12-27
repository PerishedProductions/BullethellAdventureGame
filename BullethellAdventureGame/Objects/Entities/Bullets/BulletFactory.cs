using CoreGame.GameLevels;
using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets
{
    public class BulletFactory
    {
        public static BulletFactory Instance { get; } = new BulletFactory();
        public BulletTestingEnvironment LevelInstance { get; set; }

        private BulletFactory()
        {

        }

        public Bullet CreateBullet(Vector2 position, float speed, float rotation, float rotationSpeed, Color bulletColor, BulletBehaviorManager procedureManager)
        {
            Bullet newBullet = new Bullet(position, speed, rotation, rotationSpeed, procedureManager, bulletColor);
            LevelInstance.bulletList.Add(newBullet);

            return newBullet;
        }

    }
}
