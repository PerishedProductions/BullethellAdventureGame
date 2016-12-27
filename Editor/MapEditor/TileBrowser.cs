using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CoreGame.Managers;
using WinFormsGraphicsDevice;

namespace Editor
{
    class TileBrowser : GraphicsDeviceControl
    {
        private ContentManager content;
        private SpriteBatch spriteBatch;

        protected override void Initialize()
        {
            content = new ContentManager(Services, "Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.Instance.LoadAllContent(content);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
