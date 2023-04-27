using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Sprint0
{
    class StartScreen
    {
        Texture2D texture = LevelsTextureStorage.Instance.GetTitleScreen();
        Rectangle source = new Rectangle(1, 11, 256, 244);
        Rectangle target = new Rectangle(0, 0, 800, 630);

        private KeyboardState keyboardState;

        GameManager gameManager;

        public StartScreen(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, target, source, Color.White);
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.N))
            {
                gameManager.SetState(1);
            }
        }
    }
}