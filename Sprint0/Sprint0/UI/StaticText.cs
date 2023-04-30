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
    public class StaticText : IUserInterface
    {
        private SpriteFont font;
        private Game1 game1;
        public StaticText(Game1 game) 
        {
            this.game1 = game;
            font = UITextureStorage.Instance.GetText();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "LEVEL-1", new Vector2(100, 25), Color.White);
            spriteBatch.DrawString(font, "-LIFE-", new Vector2(600, 50), Color.DarkRed);
        }

        public void Update()
        {
        }
    }
}
