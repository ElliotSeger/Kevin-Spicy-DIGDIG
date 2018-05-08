//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Input;

//namespace Kevin_spicy_GAME
//{
//    static class UserInterface
//    {
//        static bool pause;
//        static SpriteFont font;
//        static KeyboardState prevKeyboardState = Keyboard.GetState();
//        static List<Button> buttons = new List<Button>();
//        static MouseState prevMouseState;

//        public static void AddButton(Texture2D texture, string text, Vector2 scale, Vector2 textScale, Vector2 screenSize)
//        {
//            buttons.Add(new Button(texture, Vector2.Zero, text, scale, textScale, font));
//            PlaceButtons(screenSize);
//        }

//        public static void LoadSpriteFont(ContentManager content, string fontName)
//        {
//            font = content.Load<SpriteFont>(fontName);
//        }

//        public static bool Update(KeyboardState keyboardState, MouseState mouseState)
//        {
//            bool exit = false;
//            if (keyboardState.IsKeyDown(Keys.Escape) && prevKeyboardState.IsKeyUp(Keys.Escape))
//            {

//            }
//        }
//    }
//}
