﻿// using GeonBit UI elements
using CoreGame.Managers;
using Editor.GameLevels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Editor
{
    /// This is the main class for your game.
    public class Game1 : Game
    {
        // graphics and spritebatch
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// Game constructor.
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// Allows the game to perform any initialization it needs to before starting to run.
        /// here we create and init the UI manager.
        protected override void Initialize()
        {
            //Set the resolution of the window
            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 810;
            graphics.ApplyChanges();

            //Set title and allow resolution
            Window.Title = "Persished Engine";
            Window.AllowUserResizing = true;

            ResourceManager.Instance.LoadAllContent(Content);
            LevelManager.Instance.currentLevel = new EditorStartPage();
            LevelManager.Instance.currentLevel.Initialize();
            // GeonBit.UI: tbd create your GUI layouts here..

            // call base initialize func
            base.Initialize();
        }

        /// LoadContent will be called once per game and is the place to load.
        /// here we init the spriteBatch (this is code you probably already have).
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// Allows the game to run logic such as updating the world.
        /// here we call the UI manager update() function to update the UI.
        protected override void Update(GameTime gameTime)
        {
            if (this.IsActive)
            {
                LevelManager.Instance.currentLevel.Update(gameTime);
            }

            // tbd add your own update() stuff here..

            // call base update
            base.Update(gameTime);
        }

        /// This is called when the game should draw itself.
        /// here we call the UI manager draw() function to render the UI.
        protected override void Draw(GameTime gameTime)
        {
            // clear buffer
            GraphicsDevice.Clear(Color.CornflowerBlue);

            LevelManager.Instance.currentLevel.Draw(spriteBatch);

            // call base draw function
            base.Draw(gameTime);
        }
    }
}