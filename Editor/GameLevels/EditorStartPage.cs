using CoreGame.GameLevels;
using CoreGame.Managers;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Editor.GameLevels
{
    public class EditorStartPage : GameLevel
    {

        // GeonBit.UI: UI manager instance
        UserInterface UIManager;

        public override void Initialize()
        {
            // GeonBit.UI: create and init the UI manager
            UIManager = new UserInterface(ResourceManager.Instance.Content);
            UIManager.Initialize();

            UserInterface.SCALE = 1f;

            Panel panel = new Panel(size: new Vector2(900, 600), skin: PanelSkin.Golden, anchor: Anchor.Center, offset: new Vector2(10, 10));
            UIManager.AddEntity(panel);

            Header header = new Header("Welcome to Perished Engine!", Anchor.TopCenter, new Vector2(0, 40));
            panel.AddChild(header);

            HorizontalLine line = new HorizontalLine(Anchor.TopCenter, new Vector2(0, 100));
            panel.AddChild(line);

            Button mapEditor = new Button(text: "Open Map Editor", skin: ButtonSkin.Alternative, anchor: Anchor.Center, size: new Vector2(600, 50), offset: new Vector2(0, -27));
            mapEditor.OnClick = (Entity btn) =>
            {
                OpenMapEditor();
            };

            panel.AddChild(mapEditor);

            Button bulletEditor = new Button(text: "Open Bullet Pattern Editor", skin: ButtonSkin.Alternative, anchor: Anchor.Center, size: new Vector2(600, 50), offset: new Vector2(0, 27));
            panel.AddChild(bulletEditor);
        }

        public override void Update(GameTime gameTime)
        {
            // GeonBit.UIL update UI manager
            UIManager.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // GeonBit.UI: draw UI using the spriteBatch you created above
            UIManager.Draw(spriteBatch);
        }

        void OpenMapEditor()
        {
            LevelManager.Instance.ChangeLevel(new MapEditor());
        }

    }
}
