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
    public class Fairy : ISprite
    {
        private Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        private Rectangle sourceRect = ItemsTextureStorage.fairy1;
        private Rectangle destRect;
        int currentFrame;
        int totalFrames = ItemConstants.FairyTotalFrames;

        public Vector2 location;

        public Fairy(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y, sourceRect.Width * GameConstants.Sizing2, sourceRect.Height * GameConstants.Sizing2);
            currentFrame = GameConstants.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sourceRect == new Rectangle(0,0,0,0))
            {
                // nothing
            }
            else if (currentFrame < ItemConstants.FairyPhase)
            {
                sourceRect = ItemsTextureStorage.fairy1;
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            } else
            {
                sourceRect = ItemsTextureStorage.fairy2;
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
