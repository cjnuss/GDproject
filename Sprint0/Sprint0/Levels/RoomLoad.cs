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
            roomNum = GameConstants.One;
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

            int x = Int32.Parse(all[RoomConstants.YInt]);
            int y = Int32.Parse(all[RoomConstants.XInt]);

            switch (all[GameConstants.Zero])
            {
                case "tallWall":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TallWallWidth * GameConstants.Sizing, RoomConstants.TallWallHeight * GameConstants.Sizing); // debug * 3
                    break;
                case "wideWall":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.WideWallWidth * GameConstants.Sizing, RoomConstants.WideWallHeight * GameConstants.Sizing);
                    break;
                case "twoByThree":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TwoThreeWidth * GameConstants.Sizing, RoomConstants.TwoThreeHeight * GameConstants.Sizing);
                    break;
                case "singleBlock":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.SingleWidth * GameConstants.Sizing, RoomConstants.SingleHeight * GameConstants.Sizing);
                    break;
                case "oneByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.OneOneWidth * GameConstants.Sizing, RoomConstants.OneOneHeight * GameConstants.Sizing);
                    break;
                case "twoByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TwoOneWidth * GameConstants.Sizing, RoomConstants.TwoOneHeight * GameConstants.Sizing);
                    break;
                case "sixByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.SixOneWidth * GameConstants.Sizing, RoomConstants.SixOneHeight * RoomConstants.SizeAdj);
                    break;
                case "threeByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.ThreeOneWidth * GameConstants.Sizing, RoomConstants.ThreeOneHeight * RoomConstants.SizeAdj);
                    break;
                case "oneByThree":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.OneThreeWidth * GameConstants.Sizing, RoomConstants.OneThreeHeight * GameConstants.Sizing);
                    break;
                case "tenByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TenOneWidth * GameConstants.Sizing, RoomConstants.TenOneWidth * GameConstants.Sizing);
                    break;
                case "fourByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.FourOneWidth * GameConstants.Sizing, RoomConstants.FourOneWidth * GameConstants.Sizing);
                    break;
                default:
                    block = new CollisionBlock(new Vector2(GameConstants.Zero, GameConstants.Zero), GameConstants.Zero, GameConstants.Zero);
                    break;

            }

            blocks.Add(block);
        }
        void addItem(String line)
        {
            String[] all = line.Split(",");
            ISprite item;

            int x = Int32.Parse(all[RoomConstants.XInt]);
            int y = Int32.Parse(all[RoomConstants.YInt]);

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

            int x = Int32.Parse(all[RoomConstants.XInt]);
            int y = Int32.Parse(all[RoomConstants.YInt]);

            switch (all[GameConstants.Zero])
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
