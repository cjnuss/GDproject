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
        Rectangle blackRect;
        public HpHearts(Game1 game) 
        {
            this.game1 = game;
            texture = UITextureStorage.Instance.GetImage();
            sourceRect = UITextureStorage.HPheart;
            blackRect = UITextureStorage.AnnoyingAssBoxes;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(532, 80, blackRect.Width * 3, blackRect.Height * 3), blackRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(533, 106, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(532 +(8*3), 106, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(531 + 2*(8 * 3), 106, sourceRect.Width * 3, sourceRect.Height * 3), sourceRect, Color.White);
        }
        public void Update()
        {
        }
    }
}
