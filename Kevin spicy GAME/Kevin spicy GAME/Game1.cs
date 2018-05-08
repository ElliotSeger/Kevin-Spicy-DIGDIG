﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kevin_spicy_GAME
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        SpriteFont font;
        float enemySpawnTimer = 0;
        float enemySpawnSpeed = 1f;
        public static int Ammo { get; set; } = 100;
        public static float Health { get; set; } = 100.0f;
        public static int Points { get; set; } = 0;
        Vector2 bgPosition = new Vector2(0, 0);

        static Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();

        public static Dictionary<string, Texture2D> LoadedTextures
        {
            get { return loadedTextures; }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public static Player player;

        //Game World
        // List<Enemies> enemies = new List<Enemies>();

        Random random = new Random();

        public static List<Bullet> bullets = new List<Bullet>();
        //Pause


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
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

            player = new Player();

            IsMouseVisible = false;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            loadedTextures["SpaceWallpaper"] = Content.Load<Texture2D>("SpaceWallpaper");

            loadedTextures["EnemyShip"] = Content.Load<Texture2D>("EnemyShip");

            loadedTextures["Ship"] = Content.Load<Texture2D>("KEvins Ship");

            loadedTextures["Bullet"] = Content.Load<Texture2D>("bullet");

            loadedTextures["Crosshair"] = Content.Load<Texture2D>("crosshair");

            loadedTextures["BulletGreen"] = Content.Load<Texture2D>("BulletGreen");

            loadedTextures["HUD"] = Content.Load<Texture2D>("HUD");

            font = Content.Load<SpriteFont>("font");




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

            enemySpawnTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (bgPosition.X > -11515)
            {
                bgPosition += new Vector2(-25, 0);
            }
            else
            {
                bgPosition = new Vector2(0, 0);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player?.Update(gameTime, Window);
            for(int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime, player);
            }

            foreach(Enemy e in EnemySpawn.SpawnedEnemies)
            {
                e.Update(gameTime);
            }

            if (enemySpawnTimer <= 0)
            {
                enemySpawnTimer = enemySpawnSpeed;
                SpawnEnemeies();
            }
            base.Update(gameTime);
        }

        public void SpawnEnemeies()
        {
            EnemySpawn.SpawnEnemy(Window);
        }


        /// <summary>
        /// This is called when the game should draw itself.5
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(LoadedTextures["SpaceWallpaper"], bgPosition, Color.White);
            EnemySpawn.Draw(spriteBatch);
            player?.Draw(spriteBatch);
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
               // crosshair.draw(spriteBatch);
            }
            spriteBatch.DrawString(font, Ammo.ToString(), new Vector2(1650, 900), Color.Blue);

            spriteBatch.DrawString(font, Health.ToString(), new Vector2(500, 500), Color.Blue);

            spriteBatch.DrawString(font, Points.ToString(), new Vector2(500, 900), Color.Blue);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
