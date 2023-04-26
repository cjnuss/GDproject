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
using System.Threading;

namespace Sprint0.Levels
{
    public class RoomLoad
    {

        int roomNum;
        List<IBlock> blocks = new List<IBlock>();
        List<ISprite> items = new List<ISprite>();
        List<IEnemy> enemies = new List<IEnemy>();
        List<Door> doors = new List<Door>();
        List<int> rooms = new List<int>();

        public RoomLoad()
        {
        }


        public Room load(String sourcefile)
        {
            blocks = new List<IBlock>();
            items = new List<ISprite>();
            enemies = new List<IEnemy>();
            roomNum = GameConstants.One;
            loadin(sourcefile);
            return new Room(blocks, items, enemies, doors, rooms, roomNum);
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
                        case "BLOCKS":
                            addBlock(line);
                            break;
                        case "ITEMS":
                            addItem(line);
                            break;
                        case "ENEMIES":
                            addEnemy(line);
                            break;
                        case "DOORS":
                            addDoor(line);
                            break;
                        case "ROOMS":
                            addRoom(line);
                            break;
                        case "WALLS":
                            addWalls(line);
                            break;
                    }
                }
            }

        }

        void addBlock(String line)
        {
            String[] all = line.Split(",");
            IBlock block;

            int x = int.Parse(all[RoomConstants.XInt]);
            int y = int.Parse(all[RoomConstants.YInt]);

            switch (all[GameConstants.Zero])
            {
                case "tallWall":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TallWallWidth, RoomConstants.TallWallHeight);
                    break;
                case "wideWall":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.WideWallWidth, RoomConstants.WideWallHeight);
                    break;
                case "twoByThree":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TwoThreeWidth, RoomConstants.TwoThreeHeight);
                    break;
                case "oneByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.OneOneWidth, RoomConstants.OneOneHeight);
                    break;
                case "twoByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TwoOneWidth, RoomConstants.TwoOneHeight);
                    break;
                case "fiveByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.FiveOneWidth, RoomConstants.FiveOneHeight);
                    break;
                case "oneByFour":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.OneFourWidth, RoomConstants.OneFourHeight);
                    break;
                case "oneByTwo":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.OneTwoWidth, RoomConstants.OneTwoHeight);
                    break;
                case "threeByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.ThreeOneWidth, RoomConstants.ThreeOneHeight);
                    break;
                case "tenByOne":
                    block = new CollisionBlock(new Vector2(x, y), RoomConstants.TenOneWidth, RoomConstants.TenOneHeight);
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

            int x = int.Parse(all[RoomConstants.XInt]);
            int y = int.Parse(all[RoomConstants.YInt]);

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
            IEnemy enemy;

            int x = int.Parse(all[RoomConstants.XInt]);
            int y = int.Parse(all[RoomConstants.YInt]);

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
        void addDoor(String line)
        {
            String[] all = line.Split(",");
            Door door;

            int type = int.Parse(all[1]);

            switch (all[0])
            {
                case "north":
                    door = new Door(new Vector2(395, 207), type);
                    break;
                case "south":
                    door = new Door(new Vector2(395, 563), type);
                    break;
                case "east":
                    door = new Door(new Vector2(65, 385), type);
                    break;
                case "west":
                    door = new Door(new Vector2(725, 385), type);
                    break;
                default:
                    door = null;
                    break;
            }
            doors.Add(door);
        }

        void addRoom(String line)
        {
            rooms = line.Split(",").Select(int.Parse).ToList();
        }

        void addWalls(String line)
        {
            String[] all = line.Split(",");

            IBlock blockW1, blockN1, blockE1, blockS1;

            int W = int.Parse(all[0]);
            int N = int.Parse(all[1]);
            int E = int.Parse(all[2]);
            int S = int.Parse(all[3]);

            if (W == 0)
            {
                blockW1 = new CollisionBlock(new Vector2(0, 150), 95, 480);
                blocks.Add(blockW1);
            }
            else
            {
                blockW1 = new CollisionBlock(new Vector2(0, 150), 95, 206);
                IBlock blockW2 = new CollisionBlock(new Vector2(0, 424), 95, 196);
                blocks.Add(blockW1);
                blocks.Add(blockW2);
            }

            if (N == 0)
            {
                blockN1 = new CollisionBlock(new Vector2(0, 150), 800, 82);
                blocks.Add(blockN1);
            }
            else
            {
                blockN1 = new CollisionBlock(new Vector2(0, 150), 360, 82);
                IBlock blockN2 = new CollisionBlock(new Vector2(440, 150), 350, 82);
                blocks.Add(blockN1);
                blocks.Add(blockN2);
            }

            if (E == 0)
            {
                blockE1 = new CollisionBlock(new Vector2(705, 150), 95, 480);
                blocks.Add(blockE1);
            }
            else
            {
                blockE1 = new CollisionBlock(new Vector2(705, 150), 95, 206);
                IBlock blockE2 = new CollisionBlock(new Vector2(705, 424), 95, 196);
                blocks.Add(blockE1);
                blocks.Add(blockE2);
            }

            if (S == 0)
            {
                blockS1 = new CollisionBlock(new Vector2(0, 548), 800, 82);
                blocks.Add(blockS1);
            }
            else
            {
                blockS1 = new CollisionBlock(new Vector2(0, 548), 360, 82);
                IBlock blockS2 = new CollisionBlock(new Vector2(440, 548), 350, 82);
                blocks.Add(blockS1);
                blocks.Add(blockS2);
            }
        }
    }
}
