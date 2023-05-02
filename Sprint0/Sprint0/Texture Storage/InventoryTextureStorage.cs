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

        public void Load(ContentManager content)
        {
            inventory = content.Load<Texture2D>("inventory");
        }

        public Texture2D Inventory()
        {
            return inventory;
        }


        public static Rectangle inv = new Rectangle(1, 62, 205, 88);
        public static Rectangle map = new Rectangle(258, 112, 256, 88);
    }
}
