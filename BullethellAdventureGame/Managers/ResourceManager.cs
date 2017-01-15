using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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

        public ContentManager Content;

        private bool loaded = false;

        /// <summary>
        /// Loads all the content (Sprites, fonts etc...)
        /// </summary>
        /// <param name="Content">The Content manager we want to load from</param>
        public void LoadAllContent(ContentManager Content)
        {
            this.Content = Content;
            if (!loaded)
            {
                Sprites.Add("BasicTile", Content.Load<Texture2D>("Sprites/BasicTile"));
                Sprites.Add("BG", Content.Load<Texture2D>("Sprites/BG"));
                Sprites.Add("Bullet", Content.Load<Texture2D>("Sprites/Bullet"));
                Sprites.Add("Player", Content.Load<Texture2D>("Sprites/Player"));
                Sprites.Add("PlayerCollision", Content.Load<Texture2D>("Sprites/PlayerCollision"));
                Sprites.Add("PlayerAnimations", Content.Load<Texture2D>("Sprites/PlayerAnimations"));
                Sprites.Add("PlayerWalk", Content.Load<Texture2D>("Sprites/PlayerWalk"));
                Sprites.Add("Slime", Content.Load<Texture2D>("Sprites/Slime"));
                Sprites.Add("SlimeCollision", Content.Load<Texture2D>("Sprites/SlimeCollision"));
                Sprites.Add("Tree", Content.Load<Texture2D>("Sprites/Tree"));
                Sprites.Add("Backdrop", Content.Load<Texture2D>("Sprites/Backdrop"));
                Sprites.Add("Window", Content.Load<Texture2D>("Sprites/Window"));

                Sprites.Add("GroundTile0", Content.Load<Texture2D>("Sprites/Tiles/GroundTile0"));
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
                Fonts.Add("FontHuge", Content.Load<SpriteFont>("Fonts/FontHuge"));
                loaded = true;
            }
        }

    }
}
