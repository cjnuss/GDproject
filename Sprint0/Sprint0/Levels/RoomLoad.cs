using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Levels
{
    public class RoomLoad
    {

        int roomNum;
        List<IBlock> blocks = new List<IBlock>();
        List<IItem> items = new List<IItem>();
        List<ISprite> enemies = new List<ISprite>();

        int screenx = 256;
        int screeny = 176;

        public RoomLoad() 
        {
        }


        public Room load(String sourcefile)
        {
            blocks = new List<IBlock>();
            items = new List<IItem>();
            enemies = new List<ISprite>();
            roomNum = 1;
            loadin(sourcefile);
            return new Room(blocks, items, enemies, roomNum);
        }

        public void loadin(String sourcefile)
        {
            String path = Directory.GetCurrentDirectory();
            path = path.Replace(@"bin\Debug\net6.0", @"Content\");
            StreamReader reader = new StreamReader(path + sourcefile);
            String type = "";

            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                if(!line.Contains(','))
                {
                    type = line;
                } else
                {
                    switch(type)
                    {
                        case "ROOM":
                            roomNum = Int32.Parse(line);
                            break;
                        case "BLOCKS":
                            addBlock(line);
                            break;
                        case "ITEMS":
                            // addItem(line);
                            break;
                        case "ENEMIES":
                            addEnemy(line);
                            break;
                    }
                }
            }

        }

        void addBlock(String line)
        {
            String[] all = line.Split(",");
            IBlock block;

            int x = Int32.Parse(all[1]);
            int y = Int32.Parse(all[2]);

            switch (all[0])
            {
                case "tallWall":
                    block = new CollisionBlock(new Vector2(x, y), 25 * 3, 113 * 3);
                    break;
                case "widetWall":
                    block = new CollisionBlock(new Vector2(x, y), 190 * 3, 25 * 3);
                    break;
                case "twoByThree":
                    block = new CollisionBlock(new Vector2(x, y), 32 * 3, 48 * 3);
                    break;
                default :
                    block = new CollisionBlock(new Vector2(0, 0), 0, 0);
                    break;
            }
            
            blocks.Add(block);
        }
        void addItem(String line)
        {

        }
        void addEnemy(String line)
        {
            String[] all = line.Split(",");
            ISprite enemy;

            int x = Int32.Parse(all[1]);
            int y = Int32.Parse(all[2]);

            switch (all[0])
            {
                case "aquamentus":
                    enemy = new Aquamentus(new Vector2(x, y));
                    break;
                case "bat":
                    enemy = new Bat(new Vector2(x, y));
                    break;
                case "gel":
                    enemy = new Gel(new Vector2(x, y));
                    break;
                case "goriya":
                    enemy = new Goriya(new Vector2(x, y));
                    break;
                case "oldman":
                    enemy = new OldMan(new Vector2(x, y));
                    break;
                case "skeleton":
                    enemy = new Skeleton(new Vector2(x, y));
                    break;
                default:
                    enemy = null;
                    break;
            }
            enemies.Add(enemy);
        }
    }

}
