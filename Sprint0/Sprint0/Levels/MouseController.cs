using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vector2 = System.Numerics.Vector2;

namespace Sprint0.Levels
{
    public class MouseController : IController
    {
        private Game1 game1;
        ISprite sprite;
        //get sprites and needed classes ready
        public Texture2D Texture { get; set; }
        private SpriteBatch _spriteBatch;
        private int levelState;
        Texture2D texture;

        private static List<Rectangle> levels = new List<Rectangle>
        {
            LevelsTextureStorage.level1,
            LevelsTextureStorage.level2,
            LevelsTextureStorage.level3,
            LevelsTextureStorage.level4,
            LevelsTextureStorage.level5,
            LevelsTextureStorage.level6,
            LevelsTextureStorage.level7,
            LevelsTextureStorage.level8,
            LevelsTextureStorage.level9,
            LevelsTextureStorage.level10,
            LevelsTextureStorage.level11,
            LevelsTextureStorage.level12,
            LevelsTextureStorage.level13,
            LevelsTextureStorage.level14,
            LevelsTextureStorage.level15,
            LevelsTextureStorage.level16,
            LevelsTextureStorage.level17,
        };
        /*
        //reading xml
        XmlDocument levelDoc;
        string XMLpath;
        XmlNodeList Typelist;
        XmlNodeList Namelist;
        XmlNodeList Loclist;
        */
        public MouseController(Game1 game1, Texture2D atlas, SpriteBatch spriteBatch)
        {
            this.game1 = game1;
            _spriteBatch = spriteBatch;
            levelState = 0;
            texture = atlas;
            /*
            levelDoc = new XmlDocument();
            XMLpath = Directory.GetCurrentDirectory + @"\1.xml";
            levelDoc.Load(XMLpath);
            Typelist = levelDoc.GetElementsByTagName("Type");
            Namelist = levelDoc.GetElementsByTagName("Name");
            Loclist = levelDoc.GetElementsByTagName("Location");
            */
        }

        public void Update()
        {
            /*all xml level logic
            for (int i = 0; i < Typelist.Count; i++)
            {
                if (Typelist[i].InnerText.ToString() == "Enemy") sprite = LinkRightSprite;
            }
            */

            if (Mouse.GetState().RightButton.Equals(ButtonState.Pressed))
            {
                //next level
                if (levelState < 16) levelState++;
            }
            else if (Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                //prev level
                if (levelState > 0) levelState--;

            }
            Rectangle source = levels[levelState];
            Rectangle target = new Rectangle(0,0, 800, 480);
            _spriteBatch.Draw(texture, target, source, Color.White);



            //sprite.Update();
            //sprite.Draw(_spriteBatch, new Vector2(390, 210));
        }
    }

}
