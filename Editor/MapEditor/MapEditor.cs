using Microsoft.Xna.Framework;
using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using WinFormsGraphicsDevice;

namespace Editor
{
    public class MapEditor : GraphicsDeviceControl
    {
        private ContentManager content;
        private SpriteBatch spriteBatch;

        public Map map;
        private string currentMapString = "";
        private SpriteFont font;

        protected override void Initialize()
        {
            content = new ContentManager(Services, "Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.Instance.LoadAllContent(content);

            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            if (map != null)
                map.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.DrawString(font, "Name: " + currentMapString, new Vector2(10, 10), Color.Black);
            spriteBatch.End();

            Invalidate();
        }

        public void LoadMap(string path, string name)
        {
            currentMapString = name;
            ReadJson jsonReader = new ReadJson();
            map = new Map(jsonReader.ReadData(path));
        }
    }
}
