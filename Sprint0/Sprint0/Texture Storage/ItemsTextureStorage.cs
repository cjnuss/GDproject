using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class ItemsTextureStorage : ISpriteFactory
    {
        private static ItemsTextureStorage instance;

        public static ItemsTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemsTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D items;

        public void Load(ContentManager content)
        {
            items = content.Load<Texture2D>("items&weaponsSet");
        }

        public Texture2D GetItems()
        {
            return items;
        }

        public static Rectangle heart = new Rectangle(25, 1, 13, 13);
        public static Rectangle clock = new Rectangle(58, 0, 11, 16);
        public static Rectangle compass = new Rectangle(258, 1, 11, 12);
        public static Rectangle triforce1 = new Rectangle(275, 3, 10, 10);
        public static Rectangle triforce2 = new Rectangle(275, 19, 10, 10);
        public static Rectangle key = new Rectangle(240, 0, 8, 16);
        public static Rectangle map = new Rectangle(88, 0, 8, 16);
        public static Rectangle bow = new Rectangle(144, 0, 8, 16);
        public static Rectangle arrow = new Rectangle(154, 0, 5, 16);
        public static Rectangle rupee1 = new Rectangle(72, 0, 8, 16);
        public static Rectangle rupee2 = new Rectangle(72, 16, 8, 16);
        public static Rectangle bomb = new Rectangle(136, 0, 8, 16);
        public static Rectangle fairy1 = new Rectangle(40, 0, 8, 16);
        public static Rectangle fairy2 = new Rectangle(48, 0, 8, 16);
        public static Rectangle healthHeart = new Rectangle(0, 0, 8, 8);

    }
}