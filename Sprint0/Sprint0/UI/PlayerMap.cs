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
    internal class PlayerMap : IUserInterface
    {

        private Game1 game1;
        Texture2D texture, mapTexture;
        Rectangle mainRect;
        Rectangle linkRect;
        Rectangle wholeMap;
        Rectangle singleBlock;
        LinkItems linkItems;
        GameManager manager;
        public PlayerMap(Game1 game, GameManager manager) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            mapTexture = UITextureStorage.Instance.GetImage2();
            mainRect = UITextureStorage.AnnoyingAssBoxes;
            linkRect = UITextureStorage.linkLocation;
            wholeMap = UITextureStorage.basicMap;
            singleBlock = UITextureStorage.singleBlock;
            linkItems = game1.linkItems;

            this.manager = manager;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(52, 30, mainRect.Width * 3, mainRect.Height * 3), mainRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(52, 80, mainRect.Width * 3, mainRect.Height * 3), mainRect, Color.White);
            
            if (linkItems.map)
            {
                spriteBatch.Draw(mapTexture, new Rectangle(60, 50, wholeMap.Width * 3, wholeMap.Height * 3), wholeMap, Color.White);

                if (!linkItems.compass)
                {
                    spriteBatch.Draw(mapTexture, new Rectangle(180, 61, singleBlock.Width * 3, (singleBlock.Height * 3)+2), singleBlock, Color.White);
                }

                spriteBatch.Draw(mapTexture, new Rectangle(108, 109, singleBlock.Width * 3, (singleBlock.Height * 3)+1), singleBlock, Color.White);

            }
            switch(manager.roomNum){
                case (0):
                    //level1
                    spriteBatch.Draw(texture, new Rectangle(92, 111, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (1):
                    //level2
                    spriteBatch.Draw(texture, new Rectangle(116, 111, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break; 
                case (2):
                    //level3
                    spriteBatch.Draw(texture, new Rectangle(140, 111, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (3):
                    //level4
                    spriteBatch.Draw(texture, new Rectangle(116, 99, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (4):
                    //level5
                    spriteBatch.Draw(texture, new Rectangle(92, 87, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (5):
                    //level6
                    spriteBatch.Draw(texture, new Rectangle(116, 87, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (6):
                    //level7
                    spriteBatch.Draw(texture, new Rectangle(140, 87, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (7):
                    //level8
                    spriteBatch.Draw(texture, new Rectangle(68, 75, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (8):
                    //level9
                    spriteBatch.Draw(texture, new Rectangle(92, 75, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (9):
                    //level10
                    spriteBatch.Draw(texture, new Rectangle(116, 75, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (10):
                    //level11
                    spriteBatch.Draw(texture, new Rectangle(140, 75, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (11):
                    //level12
                    spriteBatch.Draw(texture, new Rectangle(164, 75, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (12):
                    //level13
                    spriteBatch.Draw(texture, new Rectangle(116, 63, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (13):
                    //level14
                    spriteBatch.Draw(texture, new Rectangle(164, 63, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (14):
                    //level15
                    spriteBatch.Draw(texture, new Rectangle(188, 63, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (15):
                    //level16
                    spriteBatch.Draw(texture, new Rectangle(92, 51, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
                case (16):
                    //level17
                    spriteBatch.Draw(texture, new Rectangle(116, 51, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
                    break;
            }
        }
        public void Update()
        {
            //unused
        }
    }
}
