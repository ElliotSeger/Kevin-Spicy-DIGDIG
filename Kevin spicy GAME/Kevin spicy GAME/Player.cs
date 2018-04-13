using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kevin_spicy_GAME
{
    class Player
    {
        Texture2D kevinSpaceshipTexture;
        Rectangle spaceshipRectangle;
        // lol
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Color spaceshipColor;
        float speed;
        float attackInterval;
        float attackSpeed;
        float rotation;
        Texture2D bulletGreenTexture;

        public Player(Texture2D texture, Texture2D bulletTexture)
        {
            kevinSpaceshipTexture = texture;
            position = new Vector2(0, 200);
            speed = 300;
            attackInterval = 0.2f;
            rotation = 0;
            scale = new Vector2(0.5f, 0.5f);
            attackSpeed = 0;
            spaceshipColor = Color.White;
            offset = (kevinSpaceshipTexture.Bounds.Size.ToVector2() * 0.5f) * scale;
            spaceshipRectangle = new Rectangle((position - offset).ToPoint(), (kevinSpaceshipTexture.Bounds.Size.ToVector2() * scale).ToPoint());
            bulletGreenTexture = bulletTexture;
        }

        public void Update(GameTime gameTime, GameWindow window)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            attackSpeed += deltaTime;
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.D))
            {
                position += (Vector2.UnitX * speed * deltaTime);
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                position += (-Vector2.UnitX * speed * deltaTime);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                position += (Vector2.UnitY * speed * deltaTime);
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position += (-Vector2.UnitY * speed * deltaTime);
            }

            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X >= (window.ClientBounds.Width - (kevinSpaceshipTexture.Width * scale.X)))
            {
                position.X = (window.ClientBounds.Width - kevinSpaceshipTexture.Width * scale.X);
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.Y >= (window.ClientBounds.Height - kevinSpaceshipTexture.Height * scale.Y))
            {
                position.Y = (window.ClientBounds.Height - kevinSpaceshipTexture.Height * scale.Y);
            }

            spaceshipRectangle.Location = (position - offset * scale).ToPoint();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (attackSpeed >= attackInterval)
                {
                    attackSpeed = 0;
                    Shoot();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(kevinSpaceshipTexture, position, null, spaceshipColor, rotation, offset, scale, SpriteEffects.None, 0);
        }

        public void Shoot()
        {
            Game1.bullets.Add(new Bullet(position, bulletGreenTexture, 20, Vector2.One * 0.01f, spaceshipRectangle.Size.ToVector2() + new Vector2()));
        }
    }
}
