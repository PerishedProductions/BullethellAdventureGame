using CoreGame.Objects.Entities.Bullets.BulletProcedures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CoreGame.Objects.Entities.Bullets
{
    public class BulletProcedureManager
    {
        public List<IBulletProcedure> procedureList { get; } = new List<IBulletProcedure>();

        public BulletProcedureManager()
        {
            BulletSpawnProcedure spawn = new BulletSpawnProcedure();
            spawn.SpawnPatternDegreeSteps = 360 / 12;
            spawn.SpawnPatternCount = 12;
            spawn.SingleStepEachWave = false;
            spawn.BulletWaves = 2;
            spawn.BulletInterval = 1000;
            spawn.Initialize();
            procedureList.Add(spawn);

            //BulletSpeedProcedure command = new BulletSpeedProcedure();
            //command.TargetSpeed = 5;
            //command.Acceleration = 0.5f;
            //procedureList.Add(command);

            //BulletRotationProcedure rotation = new BulletRotationProcedure();
            //rotation.TargetRotationSpeed = -30;
            //rotation.RotationSpeedAcceleration = -0.1f;
            //procedureList.Add(rotation);
        }


        public void PerformProcedure(Bullet bullet, GameTime gameTime)
        {
            for (int i = 0; i < procedureList.Count; i++)
            {
                if (!procedureList[i].IsFinished)
                {
                    procedureList[i].PerformCommand(bullet, gameTime);
                    return;
                }
            }
        }
    }
}
