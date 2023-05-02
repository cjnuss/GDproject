using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;
using Sprint0.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Sprint0
{
    public class Inventory : IGameScreen
    {
        private GameManager gameManager;
        private SpriteFont font;
        private KeyboardState keyboardState;
        private bool paused = false;

        public Inventory(GameManager gameManager)
        {
            this.gameManager = gameManager;
            font = UITextureStorage.Instance.GetText();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            gameManager.game1.GraphicsDevice.Clear(Color.Black);
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.P) && !paused)
            {
                paused = true;
                gameManager.SetState(GameConstants.Two);
            }
            else if (keyboardState.IsKeyDown(Keys.P) && paused)
            {
                paused = false;
                gameManager.SetState(GameConstants.One);
            }
            else if (keyboardState.IsKeyDown(Keys.Q))
            {
                gameManager.game1.Exit();
            }
        }
    }
}
