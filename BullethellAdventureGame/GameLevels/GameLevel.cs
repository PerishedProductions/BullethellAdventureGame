using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using CoreGame.Managers;

namespace CoreGame.GameLevels
{
    public class GameLevel
    {
        public virtual void Initialize()
        {

        }

        public virtual void InitializeCam(Viewport viewport) { }

        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}