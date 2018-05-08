using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kevin_spicy_GAME
{
    public class Player
    {
        Texture2D kevinSpaceshipTexture;
        public Rectangle spaceshipRectangle;
        Vector2 position;
        Vector2 crosshairpos;
        Vector2 scale;
        Vector2 offset;
        Vector2 hudpos;
        Vector2 hudScale;
        Color spaceshipColor;
        Texture2D hudTexture;
        float health;
        float playerDamage;
        float speed;
        float attackInterval;
        float attackSpeed;
        float rotation;
        Texture2D bulletGreenTexture;
        Texture2D crosshairTexture;
        private Texture2D texture2D;
        private Vector2 vector21;
        private int v1;
        private Vector2 vector22;
        private int v2;
        private Color white;

        public Player()
        {
            kevinSpaceshipTexture = Game1.LoadedTextures["Ship"];

            position = new Vector2(0, 450);
            crosshairpos = new Vector2(1750, 437);
            hudpos = new Vector2 (50, 25);
            hudScale = new Vector2(1f, 1.2f);
            speed = 300;
            health = 100.0f;
            attackInterval = 0.2f;
            rotation = 0;
            scale = new Vector2(0.3f, 0.3f);
            playerDamage = 50.0f;
            attackSpeed = 100;
            spaceshipColor = Color.White;
            offset = (kevinSpaceshipTexture.Bounds.Size.ToVector2() * 0.5f) * scale;
            spaceshipRectangle = new Rectangle((position - offset).ToPoint(), (kevinSpaceshipTexture.Bounds.Size.ToVector2() * scale).ToPoint());
            hudTexture = Game1.LoadedTextures["HUD"];
            bulletGreenTexture = Game1.LoadedTextures["Bullet"];
            crosshairTexture = Game1.LoadedTextures["Crosshair"];
           
        }

        public Player(Texture2D texture2D, Vector2 vector21, int v1, Vector2 vector22, int v2, Color white)
        {
            this.texture2D = texture2D;
            this.vector21 = vector21;
            this.v1 = v1;
            this.vector22 = vector22;
            this.v2 = v2;
            this.white = white;
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
            if (keyboardState.IsKeyDown(Keys.LeftShift))
            {
                position += (Vector2.UnitX * speed * deltaTime * 3);
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                position += (-Vector2.UnitX * speed * deltaTime * 2);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                position += (Vector2.UnitY * speed * deltaTime * 3);
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position += (-Vector2.UnitY * speed * deltaTime * 3);
            }

            //bounds
            // crosshair
            crosshairpos = Vector2.Lerp(crosshairpos, new Vector2(1600, position.Y), 0.07f);

            //player
            if (position.X <= 40)
            {
                position.X = 40;
            }
            if (position.X >= (window.ClientBounds.Width - (kevinSpaceshipTexture.Width * scale.X)))
            {
                position.X = (window.ClientBounds.Width - kevinSpaceshipTexture.Width * scale.X);
            }
            if (position.Y <= 75)
            {
                position.Y = 75;
            }
            if (position.Y >= (window.ClientBounds.Height - kevinSpaceshipTexture.Height * scale.Y - 145))
            {
                position.Y = (window.ClientBounds.Height - kevinSpaceshipTexture.Height * scale.Y - 145);
            }

            spaceshipRectangle.Location = (position - offset * scale).ToPoint();

            if (keyboardState.IsKeyDown(Keys.Space) && attackSpeed >= attackInterval)
            {
                attackSpeed = 0;
                Shoot();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(kevinSpaceshipTexture, position, null, spaceshipColor, rotation, offset, scale, SpriteEffects.None, 0);

            spriteBatch.Draw(crosshairTexture, crosshairpos, null, spaceshipColor, rotation, offset, scale, SpriteEffects.None, 0);

            spriteBatch.Draw(hudTexture, hudpos, null, spaceshipColor, rotation, offset, hudScale, SpriteEffects.None, 0);
        }
       

        public void Shoot()
        {
            if (Game1.Ammo >= 1)
            {
                Game1.Ammo--;
                Game1.bullets.Add(new Bullet(position, bulletGreenTexture, 20, Vector2.One * 0.025f, spaceshipRectangle.Size.ToVector2(), Vector2.UnitX, playerDamage, typeof(Player)));
            }
            else
            {
                Game1.Ammo = 0;
            }
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Game1.player = null;
            }
        }
    }
}
