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
        Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        Rectangle sourceRect = ItemsTextureStorage.fairy1;
        Rectangle destRect;
        int currentFrame;
        int totalFrames = ItemConstants.FairyTotalFrames;

        Vector2 location;

        public Fairy(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y + GameConstants.HeightAdj, sourceRect.Width * GameConstants.Sizing2, sourceRect.Height * GameConstants.Sizing2);
            currentFrame = GameConstants.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame < ItemConstants.FairyPhase)
            {
                sourceRect = ItemsTextureStorage.fairy1;
            } else
            {
                sourceRect = ItemsTextureStorage.fairy2;
            }
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = GameConstants.Zero;
            }
        }
    }
}
