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

        public void LoadAllContent(ContentManager Content)
        {
            Sprites.Add("BasicTile", Content.Load<Texture2D>("Sprites/BasicTile"));
            Sprites.Add("BG", Content.Load<Texture2D>("Sprites/BG"));
            Sprites.Add("Bullet", Content.Load<Texture2D>("Sprites/Bullet"));
            Sprites.Add("Player", Content.Load<Texture2D>("Sprites/Player"));
            Sprites.Add("Tree", Content.Load<Texture2D>("Sprites/Tree"));
            Sprites.Add("Window", Content.Load<Texture2D>("Sprites/Window"));

            Fonts.Add("FontSmall", Content.Load<SpriteFont>("Fonts/FontSmall"));
            Fonts.Add("FontMedium", Content.Load<SpriteFont>("Fonts/FontMedium"));
            Fonts.Add("FontBig", Content.Load<SpriteFont>("Fonts/FontBig"));
        }

    }
}
