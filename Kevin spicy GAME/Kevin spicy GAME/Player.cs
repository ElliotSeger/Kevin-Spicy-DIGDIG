using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kevin_spicy_GAME
{
    class Player
    {
        Texture2D spaceshipTexture;
        Rectangle spaceshipRectangle;
        Vector2 position;
        Vector2 offset;
        Color spaceshipColor;
        float speed;
        float rotation;

        public Player(Texture2D texture)
        {
            spaceshipTexture = texture;
            position = new Vector2(0, 200);
            speed = 300;
            rotation = 0;
            spaceshipColor = Color.White;
            spaceshipRectangle = new Rectangle(position.ToPoint(), new Point(130));
        }

        public void Update(GameTime gameTime, GameWindow window)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
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
            if (position.X >= (window.ClientBounds.Width - (spaceshipTexture.Width)))
            {
                position.X = (window.ClientBounds.Width - spaceshipTexture.Width);
            }
            if (position.Y <= 0 - 57)
            {
                position.Y = -57;
            }
            if (position.Y >= (window.ClientBounds.Height - spaceshipTexture.Height))
            {
                position.Y = (window.ClientBounds.Height - spaceshipTexture.Height);
            }

            spaceshipRectangle.Location = (position).ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spaceshipTexture, spaceshipRectangle, Color.White);
        }
    }
}