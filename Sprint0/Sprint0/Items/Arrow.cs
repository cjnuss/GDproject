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
    public class Arrow : ISprite
    {
        private Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        private Rectangle sourceRect = ItemsTextureStorage.arrow;
        private Rectangle destRect;

        public Vector2 location;

        public Arrow(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y, sourceRect.Width * GameConstants.Sizing, sourceRect.Height * GameConstants.Sizing);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sourceRect != new Rectangle(0, 0, 0, 0))
            {
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            }   
        }

        public void Update()
        {

        }

        public void Dispose()
        {
            sourceRect = new Rectangle(0, 0, 0, 0);
        }
    }
}
