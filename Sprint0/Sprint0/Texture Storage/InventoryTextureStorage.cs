using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class InventoryTextureStorage : ISpriteFactory
    {
        private static InventoryTextureStorage instance = null;

        public static InventoryTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InventoryTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D inventory = null;
        private static List<Rectangle> levelsOnMap = new List<Rectangle>();
        private static List<Rectangle> locations = new List<Rectangle>();

        public void Load(ContentManager content)
        {
            inventory = content.Load<Texture2D>("inventory2");

            levelsOnMap.Add(new Rectangle(450, 555, 25, 25));
            levelsOnMap.Add(new Rectangle(475, 555, 25, 25));
            levelsOnMap.Add(new Rectangle(500, 555, 25, 25));

            levelsOnMap.Add(new Rectangle(475, 530, 25, 25));
            
            levelsOnMap.Add(new Rectangle(450, 505, 25, 25));
            levelsOnMap.Add(new Rectangle(475, 505, 25, 25));
            levelsOnMap.Add(new Rectangle(500, 505, 25, 25));
            
            levelsOnMap.Add(new Rectangle(425, 480, 25, 25));
            levelsOnMap.Add(new Rectangle(450, 480, 25, 25));
            levelsOnMap.Add(new Rectangle(475, 480, 25, 25));
            levelsOnMap.Add(new Rectangle(500, 480, 25, 25));
            levelsOnMap.Add(new Rectangle(525, 480, 25, 25));

            levelsOnMap.Add(new Rectangle(475, 455, 25, 25));
            levelsOnMap.Add(new Rectangle(525, 455, 25, 25));
            levelsOnMap.Add(new Rectangle(550, 455, 25, 25));

            levelsOnMap.Add(new Rectangle(450, 430, 25, 25));
            levelsOnMap.Add(new Rectangle(475, 430, 25, 25));

            locations.Add(new Rectangle(458, 563, 9, 9));
            locations.Add(new Rectangle(483, 563, 9, 9));
            locations.Add(new Rectangle(508, 563, 9, 9));

            locations.Add(new Rectangle(483, 538, 9, 9));

            locations.Add(new Rectangle(458, 513, 9, 9));
            locations.Add(new Rectangle(483, 513, 9, 9));
            locations.Add(new Rectangle(503, 513, 9, 9));

            locations.Add(new Rectangle(433, 488, 9, 9));
            locations.Add(new Rectangle(458, 488, 9, 9));
            locations.Add(new Rectangle(483, 488, 9, 9));
            locations.Add(new Rectangle(503, 488, 9, 9));
            locations.Add(new Rectangle(533, 488, 9, 9));

            locations.Add(new Rectangle(483, 463, 9, 9));
            locations.Add(new Rectangle(533, 463, 9, 9));
            locations.Add(new Rectangle(558, 463, 9, 9));

            locations.Add(new Rectangle(458, 438, 9, 9));
            locations.Add(new Rectangle(483, 438, 9, 9));
        }

        public Texture2D Inventory()
        {
            return inventory;
        }

        public List<Rectangle> MapLevels()
        {
            return levelsOnMap;
        }

        public List<Rectangle> Locations()
        {
            return locations;
        }

        public static Rectangle inv = new Rectangle(1, 35, 256, 64);
        public static Rectangle map = new Rectangle(258, 112, 256, 88);

        public static Rectangle woodSword = new Rectangle(555, 137, 8, 16);
        public static Rectangle whiteSword = new Rectangle(564, 137, 8, 16);
        public static Rectangle boomerang = new Rectangle(584, 137, 8, 16);
        public static Rectangle bomb = new Rectangle(604, 137, 8, 16);
        public static Rectangle arrow = new Rectangle(624, 137, 8, 16);
        public static Rectangle bow = new Rectangle(633, 137, 8, 16);
        public static Rectangle mapItem = new Rectangle(601, 156, 8, 16);
        public static Rectangle compass = new Rectangle(612, 156, 15, 16);

        public static Rectangle hover1 = new Rectangle(519, 137, 16, 16);
        public static Rectangle hover2 = new Rectangle(536, 137, 16, 16);

        public static Rectangle map1 = new Rectangle(519, 108, 8, 8);

        public static Rectangle dot = new Rectangle(519, 126, 3, 3);
    }
}
