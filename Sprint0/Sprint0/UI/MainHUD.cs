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
        public MainHUD(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            sourceRect = UITextureStorage.MainHUD;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(250, 25, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
            
        }
        public void Update()
        {
        }
    }
}
