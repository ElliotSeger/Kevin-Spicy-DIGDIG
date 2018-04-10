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
        
        Texture2D _texure;
        Texture2D _textureSpace;
        Texture2D _textureEnem;
        Texture2D _textureShip;
        Vector2 _position;
        Vector2 _scale;
        Vector2 _offset;
        Rectangle rectangle;
        float theEnemySpeed;
        float speed;
        Color color;
       
        public Enemy(Texture2D texture, Vector2 startPosition, float theEnemySpeed, Vector2 enemyScale)
        {
            texture = _textureEnem;
            _position = startPosition;
            _offset = _textureEnem.Bounds.Size.ToVector2() * 0.5f;
            _scale = enemyScale;
            rectangle = new Rectangle((startPosition - _offset).ToPoint(), (_textureEnem.Bounds.Size.ToVector2() * _scale).ToPoint());
            color = Color.White;
            speed = theEnemySpeed;
        }

        public void Update(float deltaTime, Vector2 _position)
        {

            spriteBatch.Draw(_textureEnem, _position, Color.White);

        }

    }
}
