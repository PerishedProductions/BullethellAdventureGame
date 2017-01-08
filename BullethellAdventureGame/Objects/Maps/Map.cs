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
                    //TODO: Add seperate layer for collision boxes for the map
                    if (tile != "0")
                    {
                        Tile newTile = new Tile(int.Parse(tile));
                        newTile.IsCollisionActive = true;
                        newTile.Position = new Vector2(x * tileSize, y * tileSize);
                        newTile.Initialize();
                        tiles.Add(newTile);
                    }
                }
            }
        }


        public string[] MapToString()
        {
            string[] mapArray = new string[rows];
            for (int y = 0; y < rows; y++)
            {
                string mapString = "";
                for (int x = 0; x < columns; x++)
                {
                    mapString += GetTile(x * tileSize, y * tileSize).Id;
                }
                mapArray[y] = mapString;
            }
            return mapArray;
        }

        public Tile GetTile(int x, int y)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].Position == new Vector2(x, y))
                {
                    return tiles[i];
                }
            }
            return null;
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

