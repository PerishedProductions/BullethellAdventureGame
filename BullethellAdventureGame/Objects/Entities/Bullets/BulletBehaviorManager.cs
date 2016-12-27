using CoreGame.Objects.Entities.Bullets.BulletProcedures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CoreGame.Objects.Entities.Bullets
{
    public class BulletBehaviorManager : IBehaviorManager
    {
        private Dictionary<string, List<IBehaviorAction>> behaviors = new Dictionary<string, List<IBehaviorAction>>();


        public Dictionary<string, List<IBehaviorAction>> Behaviors
        {
            get
            {
                return behaviors;
            }

            set
            {
                behaviors = value;
            }
        }

        public BulletBehaviorManager()
        {
            List<IBehaviorAction> spawnBehavior = new List<IBehaviorAction>();

            BulletSpawnBehaviorAction spawn = new BulletSpawnBehaviorAction();
            spawn.SpawnPatternDegreeSteps = 360 / 12;
            spawn.SpawnPatternCount = 12;
            spawn.SingleStepEachWave = false;
            spawn.BulletWaves = 2;
            spawn.BulletInterval = 1000;
            spawn.Initialize();
            spawnBehavior.Add(spawn);

            behaviors.Add("Spawn", spawnBehavior);

            //BulletSpeedProcedure command = new BulletSpeedProcedure();
            //command.TargetSpeed = 5;
            //command.Acceleration = 0.5f;
            //procedureList.Add(command);

            //BulletRotationProcedure rotation = new BulletRotationProcedure();
            //rotation.TargetRotationSpeed = -30;
            //rotation.RotationSpeedAcceleration = -0.1f;
            //procedureList.Add(rotation);
        }

        public void PerformBehavior(Entity entity, GameTime gameTime, string behaviour)
        {
            List<IBehaviorAction> behaviorList = behaviors[behaviour];

            for (int i = 0; i < behaviorList.Count; i++)
            {
                if (!behaviorList[i].IsFinished)
                {
                    behaviorList[i].PerformBehaviorAction(entity, gameTime);
                    return;
                }
            }
        }
    }
}
