using CoreGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using Microsoft.Xna.Framework;
using CoreGame.Managers;

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
        }
    }
}
