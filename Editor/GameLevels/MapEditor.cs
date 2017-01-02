using CoreGame.GameLevels;
using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.Utilities;
using Editor.DataContainers;
using Editor.Objects;
using Editor.Objects.Entities;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Editor.GameLevels
{
    public enum EditorMode { TileMode, EntityMode, CollisionMode }

    public class MapEditor : GameLevel
    {
        // GeonBit.UI: UI manager instance
        private UserInterface UIManager;
        private EditorMap map;
        private Camera cam;

        private string currentMapPath;

        private bool overUI = false;

        private Tile previewTile;
        private SpriteFont font;

        private EditorMode editorMode = EditorMode.TileMode;

        public override void Initialize()
        {
            previewTile = new Tile(1);
            previewTile.Initialize("GroundTile1");
            ResourceManager.Instance.Fonts.TryGetValue("FontMedium", out font);

            // GeonBit.UI: create and init the UI manager
            UIManager = new UserInterface(ResourceManager.Instance.Content);
            UIManager.Initialize();
            UserInterface.SCALE = 0.7f;

            Panel menuBar = new Panel(size: new Vector2(1920, 70), skin: PanelSkin.Simple, anchor: Anchor.TopCenter, offset: new Vector2(0, 0));
            menuBar.OnMouseEnter = (GeonBit.UI.Entities.Entity entity) =>
            {
                overUI = true;
            };
            menuBar.OnMouseLeave = (GeonBit.UI.Entities.Entity entity) =>
            {
                overUI = false;
            };
            UIManager.AddEntity(menuBar);

            Button file = new Button("File", ButtonSkin.Default, Anchor.CenterLeft, new Vector2(300, 60), null);
            menuBar.AddChild(file);

            Panel filePanel = new Panel(new Vector2(300, 305), PanelSkin.Simple, Anchor.TopLeft, new Vector2(0, 35));
            filePanel.Visible = false;
            filePanel.OnMouseEnter = (GeonBit.UI.Entities.Entity entity) =>
            {
                overUI = true;
            };
            filePanel.OnMouseLeave = (GeonBit.UI.Entities.Entity entity) =>
            {
                overUI = false;
            };
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
                LoadMap();
            };
            filePanel.AddChild(loadMap);

            Button saveMap = new Button("Save Map", ButtonSkin.Default, Anchor.TopCenter, new Vector2(290, 60), new Vector2(0, 130));
            saveMap.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                TogglePanel(filePanel);
                SaveMap();
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

            Button tileMode = new Button("Tile Mode", ButtonSkin.Default, Anchor.CenterLeft, new Vector2(300, 60), new Vector2(305, 0));
            tileMode.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                editorMode = EditorMode.TileMode;
            };
            menuBar.AddChild(tileMode);

            Button entityMode = new Button("Entity Mode", ButtonSkin.Default, Anchor.CenterLeft, new Vector2(300, 60), new Vector2(610, 0));
            entityMode.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                editorMode = EditorMode.EntityMode;
            };
            menuBar.AddChild(entityMode);

            Button collisionMode = new Button("Collision Mode", ButtonSkin.Default, Anchor.CenterLeft, new Vector2(350, 60), new Vector2(915, 0));
            collisionMode.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                editorMode = EditorMode.CollisionMode;
            };
            menuBar.AddChild(collisionMode);

        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
        }

        public override void Update(GameTime gameTime)
        {
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

            if (InputManager.Instance.isPressed(Keys.Tab))
            {
                ToggleTileID();
            }

            if (editorMode == EditorMode.TileMode)
            {
                if (map != null && !overUI)
                {
                    for (int i = 0; i < map.tiles.Count; i++)
                    {
                        EditorTile temp = (EditorTile)map.tiles[i];
                        temp.Update(gameTime, previewTile);
                    }
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
            if (map != null)
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
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.FileName = "New Map.json";
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ReadJson jsonReader = new ReadJson();
                WriteJson jsonWrite = new WriteJson();
                jsonWrite.WriteData(dialog.FileName, jsonReader.ReadData("Data/EmptyMap.json"));
                map = new EditorMap(jsonReader.ReadData("Data/EmptyMap.json"), ref cam);
                currentMapPath = dialog.FileName;
            }
        }

        void LoadMap()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = false;
            dialog.RestoreDirectory = false;
            dialog.Filter = "JSON Files (.json)|*.json";
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ReadJson jsonReader = new ReadJson();
                map = new EditorMap(jsonReader.ReadData(dialog.FileName), ref cam);
                currentMapPath = dialog.FileName;
            }
        }

        void SaveMap()
        {
            WriteJson jsonWrite = new WriteJson();
            MapData data = new MapData(map.rows, map.columns, map.tileSize, map.MapToString());
            jsonWrite.WriteData(currentMapPath, data);
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
