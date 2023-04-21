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
    public class LinkItems : ILinkSprite
    {
        public int bombs, keys, rupies;
        private Texture2D texture;


        // implement damage in different directions later..

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkItems()
        {
            bombs = 0;
            keys = 0;
            rupies = 0;
        }

        public void Update()
        {
            // overall frame updates

        }
        public void increaseBomb()
        {
            bombs++;
        }
        public void increaseRupee()
        {
            rupies++;
        }
        public void increaseKey()
        {
            keys++;
        }
        public void decreaseBomb()
        {
            if (bombs != 0) { 
            bombs--;
            }
        }
        public void decreaseRupee()
        {
            if (rupies != 0)
            {
                rupies--;
            }
        }
        public void decreaseKey()
        {
            if (keys != 0)
            {
                keys--;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //do nothing for now
        }
    }
}