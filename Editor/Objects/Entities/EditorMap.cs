using CoreGame.Managers;
using CoreGame.Objects;
using CoreGame.Objects.Entities.NPCS.Monsters;
using LitJson;
using Microsoft.Xna.Framework;

namespace Editor.Objects.Entities
{
    public class EditorMap : Map
    {
        public EditorMap(JsonData data, ref Camera cam) : base(data)
        {
            LoadMap(data, ref cam);
        }

        public void LoadMap(JsonData data, ref Camera cam)
        {
            tiles.Clear();
            rows = (int)data["rows"];
            columns = (int)data["columns"];
            tileSize = (int)data["tileSize"];

            player = new Player();
            player.Initialize("PlayerAnimations", "PlayerCollision");
            player.Position = new Vector2((int)data["playerPos"][0], (int)data["playerPos"][1]);

            for (int y = 0; y < rows; y++)
            {
                string mapString = (string)data["tiles"][y];
                for (int x = 0; x < columns; x++)
                {
                    string tile = mapString.Substring(x, 1);
                    EditorTile newTile = new EditorTile(int.Parse(tile), ref cam);
                    newTile.Position = new Vector2(x * tileSize, y * tileSize);
                    newTile.Initialize();
                    tiles.Add(newTile);
                }
            }

            for (int i = 0; i < data["entities"].Count; i++)
            {
                string name = data["entities"][i]["name"].ToString();
                switch (name)
                {
                    case "slime":
                        Slime slime = new Slime();
                        slime.Initialize("Slime");
                        slime.Position = new Vector2((int)data["entities"][i]["position"][0], (int)data["entities"][i]["position"][1]);
                        entities.Add(slime);
                        break;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(gameTime);
            }
        }

    }
}
