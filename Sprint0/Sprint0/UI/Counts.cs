using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.UI
{
    internal class Counts : IUserInterface
    {

        private Game1 game1;
        Texture2D texture;
        Rectangle sourceRect;
        Rectangle mapRect;
        Rectangle oneRect, twoRect, threeRect, fourRect, fiveRect, sixRect, sevenRect, eightRect, nineRect, zeroRect, XRect;
        Rectangle boxRect;
        public Counts(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            oneRect = UITextureStorage.Num1;
            zeroRect = UITextureStorage.Num0;
            boxRect = UITextureStorage.NumBox;
            XRect = UITextureStorage.NumX;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(294, 106, XRect.Width * 3, XRect.Height * 3), XRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(318, 106, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(342, 106, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);

            spriteBatch.Draw(texture, new Rectangle(294, 82, XRect.Width * 3, XRect.Height * 3), XRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(318, 82, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(342, 82, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);

            spriteBatch.Draw(texture, new Rectangle(294, 34, XRect.Width * 3, XRect.Height * 3), XRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(318, 34, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(342, 34, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);
            //spriteBatch.Draw(texture, new Rectangle(230, 8, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);
        }
        public void Update()
        {
        }
    }
}
