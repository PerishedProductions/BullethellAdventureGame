﻿using CoreGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreGame.Objects.Entities.NPCS
{
    public class NPC : DynamicEntity
    {
        public Animator animator;
        public Animation idle;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            animator.Update(gameTime, Position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animator.Draw(spriteBatch, RotationAngle, Origin, true);
        }
    }
}
