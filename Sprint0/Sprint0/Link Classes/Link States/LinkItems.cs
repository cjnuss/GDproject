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
        public int bombs, keys, rupies, heart;
        public bool triforce, map, clock, fairy, compass, bow, arrow;
        private Texture2D texture;


        // implement damage in different directions later..

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkItems()
        {
            heart = 0;
            bombs = 0;
            keys = 0;
            rupies = 0;
            triforce = false; map = false; clock = false; fairy = false; compass = false; bow = false; arrow = false;
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