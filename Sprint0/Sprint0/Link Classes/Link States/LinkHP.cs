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
        public int bombs, keys, rupies;
        private Texture2D texture;

        private static List<Rectangle> LinkTakingDamage = new List<Rectangle>()
        {
            LinkTextureStorage.LinkTakingDamage,
            LinkTextureStorage.LinkTakingDamage1,
            LinkTextureStorage.LinkTakingDamage2
        };

        // implement damage in different directions later..

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkHP()
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
            bombs--;
        }
        public void decreaseRupee()
        {
            rupies--;
        }
        public void decreaseKey()
        {
            keys--;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //do nothing for now
        }
    }
}
