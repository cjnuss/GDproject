using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprint0
{
    public class HealthHeart : ISprite
    {
        private Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        private Rectangle sourceRect = ItemsTextureStorage.healthHeart1;
        private Rectangle destRect;
        private int currentFrame;
        private int totalFrames = 20;

        public Vector2 location;

        public HealthHeart(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y, sourceRect.Width * GameConstants.Sizing, sourceRect.Height * GameConstants.Sizing);
            currentFrame = GameConstants.Zero;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sourceRect != new Rectangle(0,0,0,0))
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);

            if (sourceRect == new Rectangle(0, 0, 0, 0))
            {
                // nothing
            }
            else if (currentFrame < ItemConstants.RupeePhase)
            {
                sourceRect = ItemsTextureStorage.healthHeart1;
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            }
            else
            {
                sourceRect = ItemsTextureStorage.healthHeart2;
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            }
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = GameConstants.Zero;
            }
        }

        public void Dispose()
        {
            sourceRect = new Rectangle(0, 0, 0, 0);
            location = new Vector2(GameConstants.Zero, GameConstants.Zero);
        }
    }
}
