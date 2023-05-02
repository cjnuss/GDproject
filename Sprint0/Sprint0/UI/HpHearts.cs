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
    internal class HpHearts : IUserInterface
    {

        private Game1 game1;
        Texture2D texture;
        Rectangle sourceRect;
        Rectangle halfRect;
        Rectangle emptyRect;
        Rectangle blackRect;
        LinkHP linkHP;
        private int hp, maxHp;
        private int first, second, third, fourth, fifth,sixth,seventh,octo, height;
        public HpHearts(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            sourceRect = UITextureStorage.HPheart;
            halfRect = UITextureStorage.halfHeart;
            emptyRect = UITextureStorage.emptyHeart;
            blackRect = UITextureStorage.AnnoyingAssBoxes;
            maxHp = 3;
            hp = 6;
            first = 533;
            second = 532 + (8 * 3);
            third = 531 + 2 * (8 * 3);
            fourth = 530 + 3 * (8 * 3);
            fifth = 529 + 4 * (8 * 3);
            sixth = 528 + 5 * (8 * 3);
            seventh = 527 + 6 * (8 * 3);
            octo = 526 + 7 * (8 * 3);
            height = 106;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(533, 80, blackRect.Width * 3, blackRect.Height * 3), blackRect, Color.White);
            switch (maxHp) 
            {
                case 4:
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(seventh, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                case >= 8:
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(seventh, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(octo, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
            }
            switch (hp)
            {
                case 0:
                    break;
                case 1:
                    spriteBatch.Draw(texture, new Rectangle(first, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                    case 2:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                    case 3:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                    case 4:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, emptyRect.Width * 3, emptyRect.Height * 3), emptyRect, Color.White);
                    break;
                    case 5:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    break;
                    case 6:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    break;
                    case 7:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    break;
                    case 8:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    break;
                case 10:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    break;
                case 12:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    break;
                case 13:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(seventh, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    break;
                case 14:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(seventh, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    break;
                case 15:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(seventh, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(octo, height, halfRect.Width * 3, halfRect.Height * 3), halfRect, Color.White);
                    break;
                case 16:
                    spriteBatch.Draw(texture, new Rectangle(first, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(second, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(third, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fourth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(fifth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(sixth, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(seventh, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    spriteBatch.Draw(texture, new Rectangle(octo, height, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
                    break;
            }

        }
        public void Update()
        {
            hp = game1.linkHealth.health;
            maxHp = game1.linkHealth.maxhealth;
        }
    }
}
