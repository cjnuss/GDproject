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
        private static SpriteFont text;


        public void Load(ContentManager content)
        {
            text = content.Load<SpriteFont>("Desc");
            render = content.Load<Texture2D>("HUDsheet");
        }

        public SpriteFont GetText()
        {
            return text;
        }

        public Texture2D GetImage()
        {
            return render;
        }
        public static Rectangle HPheart = new Rectangle(645, 117, 8, 8);
        public static Rectangle MainHUD = new Rectangle(346, 27, 256, 56);
        public static Rectangle MapKey = new Rectangle(584, 1, 64, 40);
        public static Rectangle Num0 = new Rectangle(528, 117, 8, 8);
        public static Rectangle Num1 = new Rectangle(537, 117, 8, 8);
        public static Rectangle Num2 = new Rectangle(546, 117, 8, 8);
        public static Rectangle Num3 = new Rectangle(555, 117, 8, 8);

        public static Rectangle Num4 = new Rectangle(564, 117, 8, 8);
        public static Rectangle Num5 = new Rectangle(573, 117, 8, 8);
        public static Rectangle Num6 = new Rectangle(555, 117, 8, 8);
        public static Rectangle Num7 = new Rectangle(555, 117, 8, 8);
        public static Rectangle Num8 = new Rectangle(555, 117, 8, 8);
        public static Rectangle Num9 = new Rectangle(555, 117, 8, 8);
        public static Rectangle NumX = new Rectangle(555, 117, 8, 8);



    }
}
