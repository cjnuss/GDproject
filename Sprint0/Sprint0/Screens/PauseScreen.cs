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
        private KeyboardState previousKeyboardState;
        private bool paused = false;
        private bool canPress = true;
        TimeSpan delayTime = TimeSpan.FromSeconds(1);

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
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (canPress && currentKeyboardState.IsKeyDown(Keys.P) && previousKeyboardState.IsKeyUp(Keys.P))
            {
                if (!paused)
                {
                    paused = true;
                    gameManager.SetState(2);
                }
                else
                {
                    paused = false;
                    gameManager.SetState(1);
                }
                canPress = false;
                delayTime = TimeSpan.FromSeconds(2);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Q))
            {
                gameManager.game1.Exit();
            }

            if (!canPress)
            {
                delayTime -= TimeSpan.FromMilliseconds(30);

                if (delayTime <= TimeSpan.Zero)
                {
                    canPress = true;
                }
            }
            previousKeyboardState = currentKeyboardState;
        }
    }
}
