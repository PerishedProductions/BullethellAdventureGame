using CoreGame.GameLevels;
using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.Utilities;
using Editor.Objects;
using Editor.Objects.Entities;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Editor.GameLevels
{
    public class MapEditor : GameLevel
    {
        // GeonBit.UI: UI manager instance
        private UserInterface UIManager;
        private EditorMap map;
        private Camera cam;

        private Tile previewTile;
        private SpriteFont font;

        public override void Initialize()
        {
            previewTile = new Tile(1);
            previewTile.Initialize("GroundTile1");

            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);

            // GeonBit.UI: create and init the UI manager
            UIManager = new UserInterface(ResourceManager.Instance.Content);
            UIManager.Initialize();
            UserInterface.SCALE = 0.7f;

            Panel menuBar = new Panel(size: new Vector2(1280, 70), skin: PanelSkin.Simple, anchor: Anchor.TopCenter, offset: new Vector2(0, 0));
            UIManager.AddEntity(menuBar);

            Button file = new Button("File", ButtonSkin.Default, Anchor.CenterLeft, new Vector2(300, 60), null);
            menuBar.AddChild(file);

            Panel filePanel = new Panel(new Vector2(300, 305), PanelSkin.Simple, Anchor.TopLeft, new Vector2(0, 35));
            filePanel.Visible = false;
            menuBar.AddChild(filePanel);

            file.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                TogglePanel(filePanel);
            };

            Button newMap = new Button("New Map", ButtonSkin.Default, Anchor.TopCenter, new Vector2(290, 60), null);
            newMap.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                TogglePanel(filePanel);
                NewMap();
            };
            filePanel.AddChild(newMap);

            Button loadMap = new Button("Load Map", ButtonSkin.Default, Anchor.TopCenter, new Vector2(290, 60), new Vector2(0, 65));
            loadMap.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                TogglePanel(filePanel);
            };
            filePanel.AddChild(loadMap);

            Button saveMap = new Button("Save Map", ButtonSkin.Default, Anchor.TopCenter, new Vector2(290, 60), new Vector2(0, 130));
            saveMap.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                TogglePanel(filePanel);
            };
            filePanel.AddChild(saveMap);

            HorizontalLine filePanleLine = new HorizontalLine(Anchor.TopCenter, new Vector2(0, 200));
            filePanel.AddChild(filePanleLine);

            Button exitEditor = new Button("Exit Editor", ButtonSkin.Default, Anchor.TopCenter, new Vector2(290, 60), new Vector2(0, 210));
            exitEditor.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                ExitMapEditor();
            };
            filePanel.AddChild(exitEditor);
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
            ReadJson reader = new ReadJson();
            map = new EditorMap(reader.ReadData("Data/Map.json"), ref cam);
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < map.tiles.Count; i++)
            {
                EditorTile temp = (EditorTile)map.tiles[i];
                temp.Update(gameTime, previewTile);
            }

            if (InputManager.Instance.isDown(Keys.W))
            {
                cam.position += new Vector2(0, -2);
            }
            if (InputManager.Instance.isDown(Keys.S))
            {
                cam.position += new Vector2(0, 2);
            }
            if (InputManager.Instance.isDown(Keys.A))
            {
                cam.position += new Vector2(-2, 0);
            }
            if (InputManager.Instance.isDown(Keys.D))
            {
                cam.position += new Vector2(2, 0);
            }

            if (InputManager.Instance.isPressed(Keys.Tab))
            {
                ToggleTileID();
            }

            if (previewTile.Id < 9 && InputManager.Instance.getMouseWheelState() > InputManager.Instance.getOldMouseWheelState())
            {
                previewTile.Id++;
            }
            if (previewTile.Id > 0 && InputManager.Instance.getMouseWheelState() < InputManager.Instance.getOldMouseWheelState() && cam.zoom > 0.1f)
            {
                previewTile.Id--;
            }

            if (InputManager.Instance.isDown(Keys.LeftAlt))
            {
                if (InputManager.Instance.getMouseWheelState() > InputManager.Instance.getOldMouseWheelState())
                {
                    cam.zoom += 1;
                }
                if (InputManager.Instance.getMouseWheelState() < InputManager.Instance.getOldMouseWheelState() && cam.zoom > 0.1f)
                {
                    cam.zoom -= 1;
                }
            }

            previewTile.Position = InputManager.Instance.getMouseWorldPos(cam.GetViewMatrix());

            // GeonBit.UIL update UI manager
            UIManager.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var viewMatrix = cam.GetViewMatrix();
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, transformMatrix: viewMatrix);
            map.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
            spriteBatch.DrawString(font, "GroundTile" + previewTile.Id, InputManager.Instance.getMousePos() + new Vector2(30, 0), Color.White);
            spriteBatch.End();

            // GeonBit.UI: draw UI using the spriteBatch you created above
            UIManager.Draw(spriteBatch);
        }

        void ToggleTileID()
        {
            for (int i = 0; i < map.tiles.Count; i++)
            {
                EditorTile tile = (EditorTile)map.tiles[i];
                tile.drawId = !tile.drawId;
            }
        }

        void NewMap()
        {
            ReadJson reader = new ReadJson();
            map = new EditorMap(reader.ReadData("Data/EmptyMap.json"), ref cam);
        }

        void ExitMapEditor()
        {
            LevelManager.Instance.ChangeLevel(new EditorStartPage());
        }

        void TogglePanel(Panel panel)
        {
            panel.Visible = !panel.Visible;
        }
    }
}
