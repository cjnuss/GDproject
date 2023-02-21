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
    public class EnemyTextureStorage : ISpriteFactory
    {
        private static EnemyTextureStorage instance = null;

        public static EnemyTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D enemies = null;
        private static Texture2D enemiesFlipped = null;
        private static Texture2D enemies1 = null;
        private static Texture2D enemies1Flipped = null;
        private static Texture2D npc = null;

        public void Load(ContentManager content)
        {
            enemies = content.Load<Texture2D>("enemies1v2");
            enemiesFlipped = content.Load<Texture2D>("enemies1 flippedv2");
            enemies1 = content.Load<Texture2D>("enemies2v2");
            enemies1Flipped = content.Load<Texture2D>("enemies2 flippedv2");
            npc = content.Load<Texture2D>("npc sheetv2");
        }

        public Texture2D GetEnemies()
        {
            return enemies;
        }

        public Texture2D GetEnemiesFlipped()
        {
            return enemiesFlipped;
        }

        public Texture2D GetEnemies1()
        {
            return enemies1;
        }

        public Texture2D GetEnemies1Flipped()
        {
            return enemies1Flipped;
        }

        public Texture2D GetNPC()
        {
            return npc;
        }

        public static Rectangle SkeletonSource = new Rectangle(1, 59, 16, 16);
        public static Rectangle SkeletonFlippedSource = new Rectangle(440, 59, 16, 16);

        public static Rectangle OldManSource = new Rectangle(1, 11, 16, 16);

        public static Rectangle GoriyaUp = new Rectangle(239, 11, 16, 16);
        public static Rectangle GoriyaDown = new Rectangle(222, 11, 16, 16);
        public static Rectangle GoriyaRight = new Rectangle(256, 11, 16, 16);
        public static Rectangle GoriyaRight1 = new Rectangle(273, 11, 16, 16);

        public static Rectangle GoriyaUp1 = new Rectangle(202, 11, 16, 16);
        public static Rectangle GoriyaDown1 = new Rectangle(219, 11, 16, 16);
        public static Rectangle GoriyaLeft = new Rectangle(185, 11, 16, 16);
        public static Rectangle GoriyaLeft1 = new Rectangle(168, 11, 16, 16);

        public static Rectangle GoriyaProjectile1 = new Rectangle(290, 11, 8, 16);
        public static Rectangle GoriyaProjectile2 = new Rectangle(299, 11, 8, 16);
        public static Rectangle GoriyaProjectile3 = new Rectangle(308, 11, 8, 16);

        public static Rectangle Gel1 = new Rectangle(1, 11, 8, 16);
        public static Rectangle Gel2 = new Rectangle(10, 11, 8, 16);

        public static Rectangle Bat1 = new Rectangle(183, 11, 16, 16);
        public static Rectangle Bat2 = new Rectangle(200, 11, 16, 16);

        public static Rectangle Aquamentus1 = new Rectangle(1, 11, 24, 32);
        public static Rectangle Aquamentus2 = new Rectangle(26, 11, 24, 32);
        public static Rectangle Aquamentus3 = new Rectangle(51, 11, 24, 32);
        public static Rectangle Aquamentus4 = new Rectangle(76, 11, 24, 32);

        public static Rectangle AquamentusProjectile1 = new Rectangle(128, 14, 8, 10);
        public static Rectangle AquamentusProjectile2 = new Rectangle(101, 14, 8, 10);
        public static Rectangle AquamentusProjectile3 = new Rectangle(110, 14, 8, 10);
        public static Rectangle AquamentusProjectile4 = new Rectangle(119, 14, 8, 10);
    }
}
