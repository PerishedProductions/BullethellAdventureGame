using Microsoft.Xna.Framework;
using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using WinFormsGraphicsDevice;

namespace Editor
{
    public class MapEditor : GraphicsDeviceControl
    {
        private ContentManager content;
        private SpriteBatch spriteBatch;

        public Map map;
        private string currentMap = "Null";
        private SpriteFont font;

        private Camera cam;

        protected override void Initialize()
        {
            content = new ContentManager(Services, "Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.Instance.LoadAllContent(content);

            cam = new Camera(GraphicsDevice.Viewport);

            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);
            LoadMap("Data/Map.json");
        }

        //TODO: Why is this only called once? Try to fix it
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (map != null)
                map.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Name: " + currentMap, new Vector2(10, 10), Color.Black);
            spriteBatch.End();
        }

        public void LoadMap(string path)
        {
            currentMap = path;
            ReadJson jsonReader = new ReadJson();
            map = new Map(jsonReader.ReadData(currentMap));
            map.LoadContent();
        }
    }
}
