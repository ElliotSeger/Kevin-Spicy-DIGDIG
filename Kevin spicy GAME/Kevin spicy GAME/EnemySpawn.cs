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
        static Random random = new Random();

        static List<Enemy> enemies = new List<Enemy>();

        public static List<Enemy> SpawnedEnemies
        {
            get { return enemies; }
        }

        public static void SpawnEnemy(GameWindow Window)
        {
            float randomY = random.Next(0, Window.ClientBounds.Height - 20);
            float randomY = random.Next(80, Window.ClientBounds.Height - 240);
            enemies.Add(new Enemy(Game1.LoadedTextures["EnemyShip"], new Vector2 (1900, randomY), 5, Vector2.One));
           
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
