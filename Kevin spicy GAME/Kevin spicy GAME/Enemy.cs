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
    class Enemy
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Texture2D _texure { get; set; }
        Texture2D _textureSpace;
        Vector2 _position;
        Vector2 _scale;
        Vector2 _offset;
        Rectangle _rectangle;

        public Rectangle EnemyRectangle
        {
            get { return _rectangle; }
        }
        float theEnemySpeed;
        float speed;
        Color color;
       
        public Enemy(Texture2D texture, Vector2 startPosition, float theEnemySpeed, Vector2 enemyScale)
        {
            _position = startPosition;
            _offset = Game1.LoadedTextures["EnemyShip"].Bounds.Size.ToVector2() * 0.5f;
            _scale = enemyScale;
            _rectangle = new Rectangle((startPosition - _offset).ToPoint(), (Game1.LoadedTextures["EnemyShip"].Bounds.Size.ToVector2() * _scale).ToPoint());
            _rectangle.Size = new Point(100);
            color = Color.White;
            speed = theEnemySpeed;
        }

        public void Update(GameTime gameTime)
        {
            _position += new Vector2(1, 0);
            _rectangle.Location = _position.ToPoint();
        }
    }
}
