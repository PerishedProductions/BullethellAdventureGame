using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Objects
{
    public class Tile : Entity
    {

        public int Id { get; set; } = 0;

        public Tile(int id)
        {
            this.Id = id;
        }

        public override void Initialize(string spriteName)
        {
            base.Initialize(spriteName);
        }

        public override void Update(GameTime gameTime) { }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)Position.X, (int)Position.Y, sprite.Width, sprite.Height), null, Color.White, RotationAngle, Origin, SpriteEffects.None, 0);
        }

        public override void HandleCollision(Entity otherEntity)
        {

        }
    }
}
