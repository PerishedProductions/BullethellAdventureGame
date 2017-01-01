using CoreGame.Utilities;
using LitJson;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CoreGame.Objects
{
    public class Map
    {

        public List<Tile> tiles = new List<Tile>();

        public JsonData MapData;

        public int rows;
        public int columns;
        public int tileSize;

        public Map(JsonData data)
        {
            LoadMap(data);
        }

        public void LoadMap(JsonData data)
        {
            rows = (int)data["rows"];
            columns = (int)data["columns"];
            tileSize = (int)data["tileSize"];

            for (int y = 0; y < rows; y++)
            {
                string mapString = (string)data["tiles"][y];
                for (int x = 0; x < columns; x++)
                {
                    string tile = mapString.Substring(x, 1);
                    Tile newTile = new Tile(int.Parse(tile));
                    newTile.Position = new Vector2(x * tileSize, y * tileSize);
                    newTile.Initialize();
                    tiles.Add(newTile);
                }
            }
        }

        public void SaveMap(string path)
        {
            //TODO: SaveMaps
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Draw(spriteBatch);
            }
        }
    }
}

