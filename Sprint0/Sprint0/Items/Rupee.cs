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
    public class Rupee : ISprite
    {
        Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        Rectangle sourceRect = ItemsTextureStorage.rupee1;
        Rectangle destRect;
        int currentFrame;
        int totalFrames = 20;

        Vector2 location;

        public Rupee(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y + 150, sourceRect.Width * 4, sourceRect.Height * 4);
            currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame < 10)
            {
                sourceRect = ItemsTextureStorage.rupee1;
            }
            else
            {
                sourceRect = ItemsTextureStorage.rupee2;
            }
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }
    }
}
