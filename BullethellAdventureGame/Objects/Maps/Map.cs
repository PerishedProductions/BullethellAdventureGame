using System;
using System.Collections.Generic;

using CoreGame.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using LitJson;

namespace CoreGame.Objects
{
    public class Map
    {

        public List<Tile> tiles = new List<Tile>();

        int rows;
        int columns;
        int tileSize;

        string mapString;

        public Map(JsonData data)
        {
            rows = (int)data["rows"];
            columns = (int)data["columns"];
            tileSize = (int)data["tileSize"];

            for (int y = 0; y < rows; y++)
            {
                mapString = (string)data["tiles"][y];
                for (int x = 0; x < columns; x++)
                {
                    string tile = mapString.Substring(x, 1);
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

