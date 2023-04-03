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
    public class Heart : ISprite
    {
        Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        Rectangle sourceRect = ItemsTextureStorage.heart;
        Rectangle destRect;

        Vector2 location;

        public Heart(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y + 150, sourceRect.Width * 3, sourceRect.Height * 3);
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
