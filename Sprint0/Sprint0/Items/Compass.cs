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
    public class Compass : ISprite
    {
        Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        Rectangle sourceRect = ItemsTextureStorage.compass;
        Rectangle destRect;

        Vector2 location;

        public Compass(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y, sourceRect.Width * GameConstants.Sizing2, sourceRect.Height * GameConstants.Sizing2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Update()
        {

        }
    }
}
