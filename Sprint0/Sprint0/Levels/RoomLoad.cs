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
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes.Item_Usage;
using System.Data;

namespace Sprint0.Levels
{
    public class RoomLoad
    {

        int roomNum;
        List<IBlock> blocks = new List<IBlock>();
        List<ISprite> items = new List<ISprite>();
        List<ISprite> enemies = new List<ISprite>();

        public RoomLoad()
        {
        }


        public Room load(String sourcefile)
        {
            blocks = new List<IBlock>();
            items = new List<ISprite>();
            enemies = new List<ISprite>();
            roomNum = 1;
            loadin(sourcefile);
            return new Room(blocks, items, enemies, roomNum);
        }

        public void loadin(String sourcefile)
        {
            String path = Directory.GetCurrentDirectory();
            path = path.Replace(@"bin\Debug\net6.0", @"Content\Rooms\");
            StreamReader reader = new StreamReader(path + sourcefile);
            String type = "";

            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                if (!line.Contains(','))
                {
                    type = line;
                }
                else
                {
                    switch (type)
                    {
                        case "ROOM":
                            roomNum = Int32.Parse(line);
                            break;
                        case "BLOCKS":
                            addBlock(line);
                            break;
                        case "ITEMS":
                            addItem(line);
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
                case "oneByOne":
                    block = new CollisionBlock(new Vector2(x, y), 16 * 3, 16 * 3);
                    break;
                case "twoByOne":
                    block = new CollisionBlock(new Vector2(x, y), 32 * 3, 16 * 3);
                    break;
                default:
                    block = new CollisionBlock(new Vector2(0, 0), 0, 0);
                    break;
            }

            blocks.Add(block);
        }
        void addItem(String line)
        {
            String[] all = line.Split(",");
            ISprite item;

            int x = Int32.Parse(all[1]);
            int y = Int32.Parse(all[2]);

            switch (all[0])
            {
                case "arrow":
                    item = new Arrow(new Vector2(x, y));
                    break;
                case "bomb":
                    item = new BombItem(new Vector2(x, y));
                    break;
                case "bow":
                    item = new Bow(new Vector2(x, y));
                    break;
                case "clock":
                    item = new Clock(new Vector2(x, y));
                    break;
                case "compass":
                    item = new Compass(new Vector2(x, y));
                    break;
                case "fairy":
                    item = new Fairy(new Vector2(x, y));
                    break;
                case "heart":
                    item = new Heart(new Vector2(x, y));
                    break;
                case "key":
                    item = new Key(new Vector2(x, y));
                    break;
                case "map":
                    item = new Map(new Vector2(x, y));
                    break;
                case "rupee":
                    item = new Rupee(new Vector2(x, y));
                    break;
                case "triforce":
                    item = new Triforce(new Vector2(x, y));
                    break;
                default:
                    item = null;
                    break;
            }
            items.Add(item);
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
