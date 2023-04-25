using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;

namespace Sprint0
{
    public class LinkHP : ILinkSprite
    {
        public int health, maxhealth;
        const int baseHp = 3;
        private Texture2D texture;
        private LinkItems linkItems;

        // implement damage in different directions later..

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkHP(Game1 game)
        {
            linkItems = game.linkItems;
            maxhealth = 3;
            health = 6;
        }

        public void moreHealth()
        {
            if ((health + 1) / 2 < maxhealth) {
                health++;
            }
        }
        public void Update()
        {
            // update max health
            maxhealth = baseHp + linkItems.heart;
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //do nothing for now
        }
    }
}
