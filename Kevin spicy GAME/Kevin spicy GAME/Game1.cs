using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Kevin_spicy_GAME
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();

        public static Dictionary<string, Texture2D> LoadedTextures
        {
            get { return loadedTextures; }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Player player;

        //Game World
        // List<Enemies> enemies = new List<Enemies>();

        Random random = new Random();

        public static List<Bullet> bullets = new List<Bullet>();
        //Pause


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            // graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
            EnemySpawn.SpawnEnemy(Window);
            player = new Player();

            IsMouseVisible = true;

            // Window.ClientBounds.Width

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            loadedTextures["EnemyShip"] = Content.Load<Texture2D>("EnemyShip");

            loadedTextures["Ship"] = Content.Load<Texture2D>("KEvinsShip");

            loadedTextures["Bullet"] = Content.Load<Texture2D>("bullet");




            // pointTexture = Content.Load<Texture2D>("point");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        float spawn = 0;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime, Window);
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }

            foreach(Enemy e in EnemySpawn.SpawnedEnemies)
            {
                e.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randY = random.Next(100, 400);

            if (spawn >= 1)
            {

            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            EnemySpawn.Draw(spriteBatch);
            player.Draw(spriteBatch);
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
