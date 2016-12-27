using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CoreGame.GameLevels;
using CoreGame.Managers;

namespace CoreGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            LevelManager.Instance.currentLevel = new MenuLevel();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Set the resolution of the window
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            //Centers the screem
            this.Window.Position = new Point(GraphicsDevice.DisplayMode.Width - (GraphicsDevice.DisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2), GraphicsDevice.DisplayMode.Height - (GraphicsDevice.DisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2));

            LevelManager.Instance.viewport = GraphicsDevice.Viewport;
            LevelManager.Instance.currentLevel.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.Instance.LoadAllContent(Content);
            LevelManager.Instance.currentLevel.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            LevelManager.Instance.currentLevel.Update(gameTime);

            if (UIManager.Instance.currentCanvas != null)
                UIManager.Instance.currentCanvas.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            LevelManager.Instance.currentLevel.Draw(spriteBatch);

            if (UIManager.Instance.currentCanvas != null)
                UIManager.Instance.currentCanvas.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}