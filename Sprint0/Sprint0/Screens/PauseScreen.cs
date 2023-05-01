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
    public class PauseScreen : IGameScreen
    {
        private GameManager gameManager;
        private SpriteFont font;
        private KeyboardState keyboardState;
        private bool paused = false;

        public PauseScreen(GameManager gameManager)
        {
            this.gameManager = gameManager;
            font = UITextureStorage.Instance.GetText();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            gameManager.game1.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(font, "PAUSED", new Vector2(GameConstants.XPause, GameConstants.YPause), Color.White);
            spriteBatch.DrawString(font, "Play Time", new Vector2(100, 70), Color.White);
            spriteBatch.DrawString(font, gameTime.TotalGameTime.ToString(), new Vector2(100, 100), Color.White);
            Link link = new Link(gameManager.game1);
            link.Draw(spriteBatch);
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
