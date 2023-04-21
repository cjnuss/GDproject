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
    public class Clock : ISprite
    {
        private Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        private Rectangle sourceRect = ItemsTextureStorage.clock;
        private Rectangle destRect;
        public Vector2 location;

        public Clock(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y, sourceRect.Width * GameConstants.Sizing, sourceRect.Height * GameConstants.Sizing);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sourceRect != new Rectangle(0,0,0,0))
                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Update()
        {

        }

        public void Dispose()
        {
            sourceRect = new Rectangle(0, 0, 0, 0);
            location = new Vector2(GameConstants.Zero, GameConstants.Zero);
        }
    }
}
