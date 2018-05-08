using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kevin_spicy_GAME
{
    public class Bullet
    {
        float bulletSpeed;
        float damage;
        Vector2 position;
        Vector2 direction;
        Texture2D redBullet;
        Rectangle collisionBoxBullet;
        Vector2 bulletOffset;
        Vector2 bulletScale;
        private Type shooterType;

        public Bullet(Vector2 pos, Texture2D texture, float speed, Vector2 scale, Vector2 playerScale, Vector2 direction, float damage, Type shooterType)
        {
            position = pos + playerScale * 0.2555f;
            redBullet = texture;
            bulletSpeed = speed * 1.5f;
            bulletScale = scale;
            collisionBoxBullet = new Rectangle(position.ToPoint(), bulletScale.ToPoint());
            bulletOffset = (texture.Bounds.Size.ToVector2() * 2f) * scale;
            this.direction = direction;
            this.damage = damage;
            this.shooterType = shooterType;
        }

        public void Update(GameTime gameTime, Player player)
        {
            position += direction * bulletSpeed;
            collisionBoxBullet.Location = position.ToPoint();

            if (shooterType == typeof(Player))
            {
                IEnumerable<Enemy> hitEnemies = CheckEnemyCollision();
                foreach (Enemy enemy in hitEnemies)
                {
                    enemy.TakeDamage(damage);
                    Game1.bullets.Remove(this);
                }
            }
            else if (shooterType == typeof(Enemy) && player != null)
            {
                bool hitPlayer = player.spaceshipRectangle.Intersects(collisionBoxBullet);
                if (hitPlayer)
                {
                    player.TakeDamage(damage);
                    Game1.bullets.Remove(this);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(redBullet, position, null, Color.White, 0, bulletOffset, bulletScale , SpriteEffects.None, 0);
        }

        public IEnumerable<Enemy> CheckEnemyCollision()
        {
            for(int i = 0; i < EnemySpawn.SpawnedEnemies.Count; i++)
            {
                if (collisionBoxBullet.Intersects(EnemySpawn.SpawnedEnemies[i].EnemyRectangle))
                {
                    yield return EnemySpawn.SpawnedEnemies[i];
                }
            }
        }
    }
}
