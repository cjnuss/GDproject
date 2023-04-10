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
    public class Triforce : ISprite
    {
        private Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        private Rectangle sourceRect = ItemsTextureStorage.triforce1;
        private Rectangle destRect;
        private int currentFrame;
        private int totalFrames = ItemConstants.TriforceTotalFrames;

        public Vector2 location;

        public Triforce(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y,  sourceRect.Width * GameConstants.Sizing, sourceRect.Height * GameConstants.Sizing);
            currentFrame = GameConstants.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sourceRect == new Rectangle(0,0,0,0))
            {
                // do nothing
            }
            else if (currentFrame < ItemConstants.TriforcePhase)
            {
                sourceRect = ItemsTextureStorage.triforce1;
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            }
            else
            {
                sourceRect = ItemsTextureStorage.triforce2;
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
        }
    }
}
