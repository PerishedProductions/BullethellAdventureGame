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

        int rows;
        int columns;
        int tileSize;

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
                    Tile newTile;
                    switch (tile)
                    {
                        case "1":
                            newTile = new Tile(1);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile1");
                            tiles.Add(newTile);
                            break;
                        case "2":
                            newTile = new Tile(2);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile2");
                            tiles.Add(newTile);
                            break;
                        case "3":
                            newTile = new Tile(3);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile3");
                            tiles.Add(newTile);
                            break;
                        case "4":
                            newTile = new Tile(4);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile4");
                            tiles.Add(newTile);
                            break;
                        case "5":
                            newTile = new Tile(5);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile5");
                            tiles.Add(newTile);
                            break;
                        case "6":
                            newTile = new Tile(6);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile6");
                            tiles.Add(newTile);
                            break;
                        case "7":
                            newTile = new Tile(7);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile7");
                            tiles.Add(newTile);
                            break;
                        case "8":
                            newTile = new Tile(8);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile8");
                            tiles.Add(newTile);
                            break;
                        case "9":
                            newTile = new Tile(9);
                            newTile.Position = new Vector2(x * tileSize, y * tileSize);
                            newTile.Initialize("GroundTile9");
                            tiles.Add(newTile);
                            break;
                    }
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

