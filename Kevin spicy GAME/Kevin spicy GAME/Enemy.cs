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
        Vector2 _position;
        Vector2 _scale;
        Vector2 _offset;
        Rectangle _rectangle;
        private float enemyDamage;

        public Rectangle EnemyRectangle
        {
            get { return _rectangle; }
        }
        float speed;
        Color color;
       
        public Enemy(Texture2D texture, Vector2 startPosition, float theEnemySpeed, Vector2 enemyScale)
        {
            _position = startPosition;
            _offset = Game1.LoadedTextures["EnemyShip"].Bounds.Size.ToVector2() * 0.5f;
            _scale = enemyScale;
            _rectangle = new Rectangle((startPosition - _offset).ToPoint(), (Game1.LoadedTextures["EnemyShip"].Bounds.Size.ToVector2() * _scale).ToPoint());
            _rectangle.Size = new Point(100);
            enemyDamage = 5.0f;
            health = 50.0f;
            color = Color.White;
            speed = theEnemySpeed;
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

            _position += new Vector2(-1, 0) * speed;
            _rectangle.Location = _position.ToPoint();
        }

        public void Shoot()
        {
            Game1.bullets.Add(new Bullet(_position, bulletGreenTexture, 20, Vector2.One * 0.025f, _rectangle.Size.ToVector2(), -Vector2.UnitX, enemyDamage, typeof(Enemy)));
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                EnemySpawn.SpawnedEnemies.Remove(this);
            }
        }
    }
}
