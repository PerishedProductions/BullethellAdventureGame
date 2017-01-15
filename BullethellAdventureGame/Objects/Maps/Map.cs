using CoreGame.Objects.Entities.NPCS.Monsters;
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

        public Player player;
        public List<Entity> entities = new List<Entity>();

        public Map(JsonData data)
        {
            LoadMap(data);
        }

        public void LoadMap(JsonData data)
        {
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

            for (int i = 0; i < data["entities"].Count; i++)
            {
                string name = data["entities"][i]["name"].ToString();
                switch (name)
                {
                    case "slime":
                        Slime slime = new Slime();
                        slime.Initialize("Slime", "SlimeCollision");
                        slime.Position = new Vector2((int)data["entities"][i]["position"][0], (int)data["entities"][i]["position"][1]);
                        entities.Add(slime);
                        break;
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

        public virtual void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(spriteBatch);
            }
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Draw(spriteBatch);
            }
        }
    }
}

