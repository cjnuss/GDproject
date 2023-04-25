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
        public PlayerMap(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            mapTexture = UITextureStorage.Instance.GetImage2();
            mainRect = UITextureStorage.AnnoyingAssBoxes;
            linkRect = UITextureStorage.linkLocation;
            wholeMap = UITextureStorage.basicMap;
            singleBlock = UITextureStorage.singleBlock;
            linkItems = game1.linkItems;
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
            spriteBatch.Draw(texture, new Rectangle(116, 99, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);
        }
        public void Update()
        {
        }
    }
}
