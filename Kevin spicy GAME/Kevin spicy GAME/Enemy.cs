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
    public class Enemy
    {
        Texture2D bulletGreenTexture;
        float attackTimer = 0;
        float attackSpeed = 2;

        private float health;
        public Texture2D _texure { get; set; }
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Rectangle rectangle;
        private float enemyDamage;

        public Rectangle EnemyRectangle
        {
            get { return rectangle; }
        }
        float speed;
        Color color;
       
        public Enemy(Texture2D texture, Vector2 startPosition, float enemySpeed, Vector2 enemyScale)
        {
            position = startPosition;
            offset = Game1.LoadedTextures["EnemyShip"].Bounds.Size.ToVector2() * 0.5f;
            scale = enemyScale;
            rectangle = new Rectangle((startPosition - offset).ToPoint(), (Game1.LoadedTextures["EnemyShip"].Bounds.Size.ToVector2() * scale).ToPoint());
            rectangle.Size = new Point(100);
            enemyDamage = 5.0f;
            health = 50.0f;
            color = Color.White;
            speed = enemySpeed;
            bulletGreenTexture = Game1.LoadedTextures["BulletGreen"];
        }

        public void Update(GameTime gameTime)
        {
            attackTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(attackTimer <= 0)
            {
                Shoot();
                attackTimer = attackSpeed;
            }

            position += new Vector2(-1, 0) * speed;
            rectangle.Location = position.ToPoint();
        }

        public void Shoot()
        {
            Game1.bullets.Add(new Bullet(position, bulletGreenTexture, 20, Vector2.One * 0.025f, rectangle.Size.ToVector2(), -Vector2.UnitX, enemyDamage, typeof(Enemy)));
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Game1.Points+=100;
                EnemySpawn.SpawnedEnemies.Remove(this);
            }
        }
    }
}
