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
    public class LevelsTextureStorage : ISpriteFactory
    {
        private static LevelsTextureStorage instance;

        public static LevelsTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelsTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D levels;
        private static Texture2D TitleScreen;
        private static Texture2D doors;
        private static Texture2D blackscreen;

        public void Load(ContentManager content)
        {
            levels = content.Load<Texture2D>("level1");
            TitleScreen = content.Load<Texture2D>("TitleScreenlinksprites");
            doors = content.Load<Texture2D>("LevelsLinksprites");
            blackscreen = content.Load<Texture2D>("blackscreen");
        }

        public Texture2D GetLevels()
        {
            return levels;
        }

        public Texture2D GetTitleScreen()
        {
            return TitleScreen;
        }

        public Texture2D Doors()
        {
            return doors;
        }

        public Texture2D BlackScreen()
        {
            return blackscreen;
        }

        public static Dictionary<string, Rectangle> Sources = new Dictionary<string, Rectangle>()
        {
            ["1"] = new Rectangle(256, 880, 256, 176),
            ["2"] = new Rectangle(512, 880, 256, 176),
            ["3"] = new Rectangle(768, 880, 256, 176),
            ["4"] = new Rectangle(512, 704, 256, 176),
            ["5"] = new Rectangle(256, 528, 256, 176),
            ["6"] = new Rectangle(512, 528, 256, 176),
            ["7"] = new Rectangle(768, 528, 256, 176),
            ["8"] = new Rectangle(0, 352, 256, 176),
            ["9"] = new Rectangle(256, 352, 256, 176),
            ["10"] = new Rectangle(512, 352, 256, 176),
            ["11"] = new Rectangle(768, 352, 256, 176),
            ["12"] = new Rectangle(1024, 352, 256, 176),
            ["13"] = new Rectangle(512, 176, 256, 176),
            ["14"] = new Rectangle(1024, 176, 256, 176),
            ["15"] = new Rectangle(1280, 176, 256, 176),
            ["16"] = new Rectangle(256, 0, 256, 176),
            ["17"] = new Rectangle(512, 0, 256, 176)
        };

        public static Rectangle level1 = new Rectangle(256, 880, 256, 176);
        public static Rectangle level2 = new Rectangle(512, 880, 256, 176);
        public static Rectangle level3 = new Rectangle(768, 880, 256, 176);
        public static Rectangle level4 = new Rectangle(512, 704, 256, 176);
        public static Rectangle level5 = new Rectangle(256, 528, 256, 176);
        public static Rectangle level6 = new Rectangle(512, 528, 256, 176);
        public static Rectangle level7 = new Rectangle(768, 528, 256, 176);
        public static Rectangle level8 = new Rectangle(0, 352, 256, 176);
        public static Rectangle level9 = new Rectangle(256, 352, 256, 176);
        public static Rectangle level10 = new Rectangle(512, 352, 256, 176);
        public static Rectangle level11 = new Rectangle(768, 352, 256, 176);
        public static Rectangle level12 = new Rectangle(1024, 352, 256, 176);
        public static Rectangle level13 = new Rectangle(512, 176, 256, 176);
        public static Rectangle level14 = new Rectangle(1024, 176, 256, 176);
        public static Rectangle level15 = new Rectangle(1280, 176, 256, 176);
        public static Rectangle level16 = new Rectangle(256, 0, 256, 176);
        public static Rectangle level17 = new Rectangle(512, 0, 256, 176);

        public static Rectangle northDoor = new Rectangle(848, 11, 32, 32);
        public static Rectangle westDoor = new Rectangle(848, 44, 32, 32);
        public static Rectangle eastDoor = new Rectangle(848, 77, 32, 32);
        public static Rectangle southDoor = new Rectangle(848, 110, 32, 32);

        public static Rectangle brokenNorthDoor = new Rectangle(947, 11, 32, 32);
        public static Rectangle brokenSouthDoor = new Rectangle(947, 110, 32, 32);
    }
}
