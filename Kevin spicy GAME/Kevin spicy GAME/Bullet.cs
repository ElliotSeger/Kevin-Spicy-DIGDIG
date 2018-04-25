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
        Vector2 position;
        Vector2 direction = new Vector2(1, 0);
        Texture2D redBullet;
        Rectangle collisionBoxBullet;
        Vector2 bulletOffset;
        Vector2 bulletScale;

        public Bullet(Vector2 pos, Texture2D texture, float speed, Vector2 scale, Vector2 playerScale)
        {
            position = pos + playerScale * 0.26f;
            redBullet = texture;
            bulletSpeed = speed;
            bulletScale = scale;
            collisionBoxBullet = new Rectangle(position.ToPoint(), bulletScale.ToPoint());
            bulletOffset = (texture.Bounds.Size.ToVector2() * 2f) * scale;
        }

        public void Update(GameTime gameTime)
        {
            position += direction * bulletSpeed;
            collisionBoxBullet.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(redBullet, position, null, Color.White, 0, bulletOffset, bulletScale , SpriteEffects.None, 0);
        }
    }
}
