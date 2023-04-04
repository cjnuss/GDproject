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
        Texture2D texture;
        Rectangle mainRect;
        Rectangle linkRect;
        public PlayerMap(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            mainRect = UITextureStorage.AnnoyingAssBoxes;
            linkRect = UITextureStorage.linkLocation;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(52, 30, mainRect.Width * 3, mainRect.Height * 3), mainRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(52, 80, mainRect.Width * 3, mainRect.Height * 3), mainRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(150, 90, linkRect.Width * 3, linkRect.Height * 3), linkRect, Color.White);

        }
        public void Update()
        {
        }
    }
}
