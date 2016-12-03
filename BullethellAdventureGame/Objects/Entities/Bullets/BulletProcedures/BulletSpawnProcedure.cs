using CoreGame.Objects.Entities.Bullets.BulletProcedures.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures
{
    public class BulletSpawnProcedure : IBulletProcedure
    {
        private static BulletFactory factory = BulletFactory.Instance;
        public int SpawnPatternDegreeSteps { get; set; }
        public int SpawnPatternCount { get; set; }
        public bool SingleStepEachWave { get; set; }
        public int BulletWaves { get; set; }
        public int BulletInterval { get; set; }
        private int currentWave = 0;
        private int currentInterval = 0;
        private bool _isFinished;

        public List<SpawnPoint> SpawnPoints { get; set; } = new List<SpawnPoint>();

        public BulletSpawnProcedure()
        {
            SpawnPoint spawn = new SpawnPoint();
            spawn.Position = new Vector2(100, 0);
            spawn.Rotation = 0;
            spawn.RotationSpeed = 0.0f;
            spawn.Speed = 0.5f;
            spawn.BulletColor = Color.Purple;
            SpawnPoints.Add(spawn);

            spawn = new SpawnPoint();
            spawn.Position = new Vector2(50, 50);
            spawn.Rotation = 0;
            spawn.RotationSpeed = -0.1f;
            spawn.Speed = 0.75f;
            spawn.BulletColor = Color.Green;
            SpawnPoints.Add(spawn);

            spawn = new SpawnPoint();
            spawn.Position = new Vector2(50, -50);
            spawn.Rotation = 0;
            spawn.RotationSpeed = 0.1f;
            spawn.Speed = 0.75f;
            spawn.BulletColor = Color.Yellow;
            SpawnPoints.Add(spawn);
        }

        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }

            set
            {
                _isFinished = value;
            }
        }

        public void Initialize()
        {
            if (SingleStepEachWave)
            {
                BulletWaves = SpawnPatternCount;
            }
        }

        public void PerformCommand(Bullet bullet, GameTime gameTime)
        {
            currentInterval += gameTime.ElapsedGameTime.Milliseconds;

            if (currentInterval > BulletInterval)
            {
                if (currentWave < BulletWaves)
                {
                    if (SingleStepEachWave)
                    {
                        float degrees = currentWave * SpawnPatternDegreeSteps;

                        SpawnBullet(bullet, degrees);
                    }
                    else
                    {
                        for (int i = 0; i < SpawnPatternCount; i++)
                        {
                            float degrees = i * SpawnPatternDegreeSteps;

                            SpawnBullet(bullet, degrees);
                        }
                    }

                    currentWave++;
                }
                else
                {
                    _isFinished = true;
                }

                currentInterval = 0;
            }
        }

        private void SpawnBullet(Bullet bullet, float degrees)
        {
            for (int j = 0; j < SpawnPoints.Count; j++)
            {
                Vector2 AddedPosition = SpawnPoints[j].Position;

                Vector2 newPosition = new Vector2();
                newPosition.X = AddedPosition.X * (float)Math.Cos(MathHelper.ToRadians(degrees)) - AddedPosition.Y * (float)Math.Sin(MathHelper.ToRadians(degrees));
                newPosition.Y = AddedPosition.X * (float)Math.Sin(MathHelper.ToRadians(degrees)) + AddedPosition.Y * (float)Math.Cos(MathHelper.ToRadians(degrees));
                newPosition = newPosition + bullet.position;

                float newRotation = (degrees + SpawnPoints[j].Rotation) % 360;
                newRotation = MathHelper.ToRadians(newRotation);

                factory.CreateBullet(newPosition, SpawnPoints[j].Speed, newRotation, SpawnPoints[j].RotationSpeed, SpawnPoints[j].BulletColor, null);
            }
        }
    }
}
