using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreGame.Managers
{
    public class ResourceManager
    {
        private static ResourceManager instance;

        private ResourceManager() { }

        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceManager();
                }
                return instance;
            }
        }

        public Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();

        private bool loaded = false;

        /// <summary>
        /// Loads all the content (Sprites, fonts etc...)
        /// </summary>
        /// <param name="Content">The Content manager we want to load from</param>
        public void LoadAllContent(ContentManager Content)
        {
            if (!loaded)
            {
                Sprites.Add("BasicTile", Content.Load<Texture2D>("Sprites/BasicTile"));
                Sprites.Add("BG", Content.Load<Texture2D>("Sprites/BG"));
                Sprites.Add("Bullet", Content.Load<Texture2D>("Sprites/Bullet"));
                Sprites.Add("Player", Content.Load<Texture2D>("Sprites/Player"));
                Sprites.Add("PlayerWalk", Content.Load<Texture2D>("Sprites/PlayerWalk"));
                Sprites.Add("Tree", Content.Load<Texture2D>("Sprites/Tree"));
                Sprites.Add("Window", Content.Load<Texture2D>("Sprites/Window"));

                Sprites.Add("GroundTile1", Content.Load<Texture2D>("Sprites/Tiles/GroundTile1"));
                Sprites.Add("GroundTile2", Content.Load<Texture2D>("Sprites/Tiles/GroundTile2"));
                Sprites.Add("GroundTile3", Content.Load<Texture2D>("Sprites/Tiles/GroundTile3"));
                Sprites.Add("GroundTile4", Content.Load<Texture2D>("Sprites/Tiles/GroundTile4"));
                Sprites.Add("GroundTile5", Content.Load<Texture2D>("Sprites/Tiles/GroundTile5"));
                Sprites.Add("GroundTile6", Content.Load<Texture2D>("Sprites/Tiles/GroundTile6"));
                Sprites.Add("GroundTile7", Content.Load<Texture2D>("Sprites/Tiles/GroundTile7"));
                Sprites.Add("GroundTile8", Content.Load<Texture2D>("Sprites/Tiles/GroundTile8"));
                Sprites.Add("GroundTile9", Content.Load<Texture2D>("Sprites/Tiles/GroundTile9"));

                Fonts.Add("FontSmall", Content.Load<SpriteFont>("Fonts/FontSmall"));
                Fonts.Add("FontMedium", Content.Load<SpriteFont>("Fonts/FontMedium"));
                Fonts.Add("FontBig", Content.Load<SpriteFont>("Fonts/FontBig"));
                loaded = true;
            }
        }

    }
}
