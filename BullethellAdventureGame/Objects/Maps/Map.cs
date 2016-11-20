using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CoreGame.Objects.Maps.Tiles;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using LitJson;

namespace CoreGame.Objects
{
    public class Map
    {

        List<Tile> tiles = new List<Tile>();

        int rows;
        int columns;
        int tileSize;
        
        string mapString;

        public Map(JsonData data)
        {
            rows = (int)data["rows"];
            columns = (int)data["columns"];
            tileSize = (int)data["tileSize"];

            mapString = (string)data["tiles"];
            string[] tempString = mapString.Split(',');

            for (int y = 0; y < rows; y++)
            {
                string stringToUse = tempString[y];
                for (int x = 0; x < columns; x++)
                {
                    string tile = stringToUse.Substring(x, 1);
                    if (tile == "1")
                    {
                        Tile newTile = new Tile();
                        newTile.position = new Vector2(x * tileSize, y * tileSize);
                        newTile.Initialize();
                        tiles.Add(newTile);
                    }
                }
            }

        }

        public virtual void Initialize()
        {

        }

        public virtual void LoadContent(ContentManager content)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {

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

