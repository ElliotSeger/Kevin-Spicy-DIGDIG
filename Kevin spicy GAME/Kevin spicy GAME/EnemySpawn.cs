using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kevin_spicy_GAME
{
    class EnemySpawn
    {
        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static Player player;
        static Random random;

        static int numEnemies;
        static List<Enemy> enemies;

        public static List<Enemy> SpawnedEnemies
        {
            get { return enemies; }
        }

        public static void SpawnEnemy(GameWindow Window)
        {
            random = new Random();
            enemies = new List<Enemy>();
            numEnemies = 10;

            player = new Player(Game1.LoadedTextures["Ship"], new Vector2(100, 50), 300, new Vector2(1, 1), 0, Color.White);

            for (int i = 0; i < numEnemies; i++)
            {
                float randomX = random.Next(Window.ClientBounds.Height);
                float randomY = random.Next(Window.ClientBounds.Width);
                enemies.Add(new Enemy(Game1.LoadedTextures["EnemyShip"], new Vector2(randomX, randomY), 300, Vector2.One));

            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach(Enemy enemy in enemies)
            {
                spriteBatch.Draw(Game1.LoadedTextures["EnemyShip"], enemy.EnemyRectangle, Color.White);
            }
        }
    }
}
