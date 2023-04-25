using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class UITextureStorage : ISpriteFactory
    {
        private static UITextureStorage instance;

        public static UITextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UITextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D render;
        private static Texture2D mapTexture;
        private static SpriteFont text;


        public void Load(ContentManager content)
        {
            text = content.Load<SpriteFont>("Desc");
            render = content.Load<Texture2D>("HUDsheet");
            mapTexture = content.Load<Texture2D>("level1");

        }

        public SpriteFont GetText()
        {
            return text;
        }

        public Texture2D GetImage()
        {
            return render;
        }
        public Texture2D GetImage2()
        {
            return mapTexture;
        }
        public static Rectangle HPheart = new Rectangle(645, 117, 9, 9);
        public static Rectangle MainHUD = new Rectangle(256, 16, 256, 50);
        public static Rectangle MapKey = new Rectangle(584, 1, 65, 41);
        public static Rectangle AnnoyingAssBoxes = new Rectangle(10, 128, 65, 17);
        public static Rectangle wholeMap = new Rectangle(687, 58, 65, 33);
        public static Rectangle linkLocation = new Rectangle(519, 126, 2, 2);
        public static Rectangle halfHeart = new Rectangle(636, 117, 9, 9);
        public static Rectangle emptyHeart = new Rectangle(627, 117, 9, 9);
        public static Rectangle basicMap = new Rectangle(1383, 131, 47, 23);
        public static Rectangle singleBlock = new Rectangle(1391, 131, 7, 3);
        public static Rectangle woodSword = new Rectangle(555, 137, 8, 16);
        public static Rectangle nothing = new Rectangle(250, 136, 8, 16);

        public static Rectangle Num0 = new Rectangle(528, 117, 8, 8);
        public static Rectangle Num1 = new Rectangle(537, 117, 8, 8);
        public static Rectangle Num2 = new Rectangle(546, 117, 8, 8);
        public static Rectangle Num3 = new Rectangle(555, 117, 8, 8);
        public static Rectangle Num4 = new Rectangle(564, 117, 8, 8);
        public static Rectangle Num5 = new Rectangle(573, 117, 8, 8);
        public static Rectangle Num6 = new Rectangle(582, 117, 8, 8);
        public static Rectangle Num7 = new Rectangle(591, 117, 8, 8);
        public static Rectangle Num8 = new Rectangle(600, 117, 8, 8);
        public static Rectangle Num9 = new Rectangle(609, 117, 8, 8);
        public static Rectangle NumX = new Rectangle(519, 117, 8, 8);
        public static Rectangle NumBox = new Rectangle(96, 48, 8, 8);



    }
}
