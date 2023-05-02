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
    internal class MainHUD : IUserInterface
    {

        private Game1 game1;
        Texture2D texture;
        Rectangle sourceRect;
        Rectangle mapRect;
        Rectangle oneRect;
        Rectangle boxRect;
        Rectangle sword; Rectangle notSword;
        Boolean map;
        public MainHUD(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            sourceRect = UITextureStorage.MainHUD;
            mapRect = UITextureStorage.MapKey;
            oneRect = UITextureStorage.Num1;
            boxRect = UITextureStorage.NumBox;
            sword = UITextureStorage.woodSword;
            notSword = UITextureStorage.nothing;
            map = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(54, 8, mapRect.Width * 3, mapRect.Height * 3), mapRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(198, 8, oneRect.Width * 3, oneRect.Height * 3), oneRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(230, 8, boxRect.Width * 3, boxRect.Height * 3), boxRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(460, 56, (sword.Width * 3)+4, (sword.Height * 3) + 2), sword, Color.White);
            spriteBatch.Draw(texture, new Rectangle(388, 56, (notSword.Width * 3) + 8, (notSword.Height * 3) + 2), notSword, Color.White);
        }
        public void Update()
        {
        }
    }
}
