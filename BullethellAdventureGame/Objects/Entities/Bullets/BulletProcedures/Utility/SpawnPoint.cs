using Microsoft.Xna.Framework;

namespace CoreGame.Objects.Entities.Bullets.BulletProcedures.Utility
{
    public class SpawnPoint
    {
        /// <summary>
        /// Position relative to the spawner
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Starting speed
        /// </summary>
        public float Speed { get; set; }


        /// <summary>
        /// Starting rotation in Radians ( 0 degrees is facing to the right )
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Starting rotationSpeed
        /// </summary>
        public float RotationSpeed { get; set; }


        public Color BulletColor { get; set; } = Color.White;
    }
}
