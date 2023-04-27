using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
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
        public Link link;
        public LinkItems linkItems;
        private int ruppee, key, bomb;
        private int first, second, height1, height2, height3;
        public Counts(Game1 game, LinkItems linkItems1) 
        {
            this.game1 = game;
            this.linkItems = linkItems1;
            texture = UITextureStorage.Instance.GetImage();
            oneRect = UITextureStorage.Num1;
            zeroRect = UITextureStorage.Num0;
            twoRect = UITextureStorage.Num2;
            threeRect = UITextureStorage.Num3;
            fourRect = UITextureStorage.Num4;
            fiveRect = UITextureStorage.Num5;
            sixRect = UITextureStorage.Num6;
            sevenRect = UITextureStorage.Num7;
            eightRect = UITextureStorage.Num8;
            nineRect = UITextureStorage.Num9;
            boxRect = UITextureStorage.NumBox;
            XRect = UITextureStorage.NumX;
            ruppee = 0;
            bomb = 0;
            key = 0;

            first = 318;
            second = 342;
            height1 = 106;
            height2 = 82;
            height3 = 34;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //bomb
            spriteBatch.Draw(texture, new Rectangle(294, 32, boxRect.Width * 10, boxRect.Height * 12), boxRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(294, 106, XRect.Width * 3, XRect.Height * 3), XRect, Color.White);

            switch (firstDigit(bomb)) {
                case 0:
                spriteBatch.Draw(texture, new Rectangle(first, height1, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
                    break;
                case 1:
                spriteBatch.Draw(texture, new Rectangle(first, height1, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, twoRect.Width * 3, twoRect.Height * 3), twoRect, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, threeRect.Width * 3, threeRect.Height * 3), threeRect, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, fourRect.Width * 3, fourRect.Height * 3), fourRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, fiveRect.Width * 3, fiveRect.Height * 3), fiveRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, sixRect.Width * 3, sixRect.Height * 3), sixRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, sevenRect.Width * 3, sevenRect.Height * 3), sevenRect, Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, eightRect.Width * 3, eightRect.Height * 3), eightRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(first, height1, nineRect.Width * 3, nineRect.Height * 3), nineRect, Color.White);
                    break;
            }
            switch (secondDigit(bomb))
            {
                case 0:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, twoRect.Width * 3, twoRect.Height * 3), twoRect, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, threeRect.Width * 3, threeRect.Height * 3), threeRect, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, fourRect.Width * 3, fourRect.Height * 3), fourRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, fiveRect.Width * 3, fiveRect.Height * 3), fiveRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, sixRect.Width * 3, sixRect.Height * 3), sixRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, sevenRect.Width * 3, sevenRect.Height * 3), sevenRect, Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, eightRect.Width * 3, eightRect.Height * 3), eightRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, nineRect.Width * 3, nineRect.Height * 3), nineRect, Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(texture, new Rectangle(second, height1, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);
                    break;
            }


            //for key
            spriteBatch.Draw(texture, new Rectangle(294, 82, XRect.Width * 3, XRect.Height * 3), XRect, Color.White);
            switch (firstDigit(key))
            {
                case 0:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, twoRect.Width * 3, twoRect.Height * 3), twoRect, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, threeRect.Width * 3, threeRect.Height * 3), threeRect, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, fourRect.Width * 3, fourRect.Height * 3), fourRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, fiveRect.Width * 3, fiveRect.Height * 3), fiveRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, sixRect.Width * 3, sixRect.Height * 3), sixRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, sevenRect.Width * 3, sevenRect.Height * 3), sevenRect, Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, eightRect.Width * 3, eightRect.Height * 3), eightRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(first, height2, nineRect.Width * 3, nineRect.Height * 3), nineRect, Color.White);
                    break;
            }
            switch (secondDigit(key))
            {
                case 0:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, twoRect.Width * 3, twoRect.Height * 3), twoRect, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, threeRect.Width * 3, threeRect.Height * 3), threeRect, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, fourRect.Width * 3, fourRect.Height * 3), fourRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, fiveRect.Width * 3, fiveRect.Height * 3), fiveRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, sixRect.Width * 3, sixRect.Height * 3), sixRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, sevenRect.Width * 3, sevenRect.Height * 3), sevenRect, Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, eightRect.Width * 3, eightRect.Height * 3), eightRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, nineRect.Width * 3, nineRect.Height * 3), nineRect, Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(texture, new Rectangle(second, height2, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);
                    break;
            }


            //for ruppee
            
            spriteBatch.Draw(texture, new Rectangle(294, 34, XRect.Width * 3, XRect.Height * 3), XRect, Color.White);

            switch (firstDigit(ruppee))
            {
                case 0:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, twoRect.Width * 3, twoRect.Height * 3), twoRect, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, threeRect.Width * 3, threeRect.Height * 3), threeRect, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, fourRect.Width * 3, fourRect.Height * 3), fourRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, fiveRect.Width * 3, fiveRect.Height * 3), fiveRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, sixRect.Width * 3, sixRect.Height * 3), sixRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, sevenRect.Width * 3, sevenRect.Height * 3), sevenRect, Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, eightRect.Width * 3, eightRect.Height * 3), eightRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(first, height3, nineRect.Width * 3, nineRect.Height * 3), nineRect, Color.White);
                    break;
            }
            switch (secondDigit(ruppee))
            {
                case 0:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, zeroRect.Width * 3, zeroRect.Height * 3), zeroRect, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, twoRect.Width * 3, twoRect.Height * 3), twoRect, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, threeRect.Width * 3, threeRect.Height * 3), threeRect, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, fourRect.Width * 3, fourRect.Height * 3), fourRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, fiveRect.Width * 3, fiveRect.Height * 3), fiveRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, sixRect.Width * 3, sixRect.Height * 3), sixRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, sevenRect.Width * 3, sevenRect.Height * 3), sevenRect, Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, eightRect.Width * 3, eightRect.Height * 3), eightRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, nineRect.Width * 3, nineRect.Height * 3), nineRect, Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(texture, new Rectangle(second, height3, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);
                    break;
            }

        }
        public void Update()
        {
            ruppee = linkItems.rupies;
            bomb = linkItems.bombs;
            key = linkItems.keys;
        }
        private int firstDigit(int check)
        {
            int digit = 0;
            if(check < 10)
            {
                digit = check;
            }else 
            {
                digit = check / 10;
            }
            return digit;
        }
        private int secondDigit(int check)
        {
            int digit;
            if (check >= 10)
            {
                digit = check % 10;
            }
            else
            {
                digit = 11;
            }
            return digit;
        }
    }
}
