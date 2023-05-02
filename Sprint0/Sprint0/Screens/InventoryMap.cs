using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint0.Levels;

namespace Sprint0
{
    public class InventoryMap
    {
        public List<Rectangle> levelsOnMap = InventoryTextureStorage.Instance.MapLevels();
        Rectangle map1 = InventoryTextureStorage.map1;

        List<int> rooms = new List<int>();
        bool toDraw = false;

        List<bool> roomList = new List<bool>();

        Texture2D texture = InventoryTextureStorage.Instance.Inventory();

        private int type;
        private int roomNum;
        GameManager manager;

        public InventoryMap(Room room, GameManager gameManager, int roomNum)
        {
            this.rooms = room.GetRooms();
            this.roomNum = roomNum;
            this.manager = gameManager;
            toDraw = room.GetState();
        }

        public void Update()
        {
            toDraw = manager.roomList[roomNum].GetState();

            roomList = new List<bool>();

            foreach (int i in rooms)
            {
                if (i == 20)
                {
                    roomList.Add(false);
                }
                else
                {
                    if (manager.roomList[i].GetState())
                    {
                        roomList.Add(true);
                    }
                    else
                    {
                        roomList.Add(false);
                    }
                }
            }

            if (roomList[0])
            {
                if (roomList[1])
                {
                    if (roomList[2])
                    {
                        if (roomList[3])
                        {
                            type = 16;
                        }
                        else
                        {
                            type = 12;
                        }
                    }
                    else
                    {
                        if (roomList[3])
                        {
                            type = 15;
                        }
                        else
                        {
                            type = 11;
                        }
                    }
                }
                else
                {
                    if (roomList[2])
                    {
                        if (roomList[3])
                        {
                            type = 8;
                        }
                        else
                        {
                            type = 4;
                        }
                    }
                    else
                    {
                        if (roomList[3])
                        {
                            type = 7;
                        }
                        else
                        {
                            type = 3;
                        }
                    }
                }
            }
            else
            {
                if (roomList[1])
                {
                    if (roomList[2])
                    {
                        if (roomList[3])
                        {
                            type = 14;
                        }
                        else
                        {
                            type = 10;
                        }
                    }
                    else
                    {
                        if (roomList[3])
                        {
                            type = 13;
                        }
                        else
                        {
                            type = 9;
                        }
                    }
                }
                else
                {
                    if (roomList[2])
                    {
                        if (roomList[3])
                        {
                            type = 6;
                        }
                        else
                        {
                            type = 2;
                        }
                    }
                    else
                    {
                        if (roomList[3])
                        {
                            type = 5;
                        }
                        else
                        {
                            type = 1;
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            Rectangle source = new Rectangle();
            switch (type)
            {
                case 1:
                    source = new Rectangle(519, 108, 8, 8);
                    break;
                case 2:
                    source = new Rectangle(528, 108, 8, 8);
                    break;
                case 3:
                    source = new Rectangle(537, 108, 8, 8);
                    break;
                case 4:
                    source = new Rectangle(546, 108, 8, 8);
                    break;
                case 5:
                    source = new Rectangle(555, 108, 8, 8);
                    break;
                case 6:
                    source = new Rectangle(564, 108, 8, 8);
                    break;
                case 7:
                    source = new Rectangle(573, 108, 8, 8);
                    break;
                case 8:
                    source = new Rectangle(582, 108, 8, 8);
                    break;
                case 9:
                    source = new Rectangle(591, 108, 8, 8);
                    break;
                case 10:
                    source = new Rectangle(600, 108, 8, 8);
                    break;
                case 11:
                    source = new Rectangle(609, 108, 8, 8);
                    break;
                case 12:
                    source = new Rectangle(618, 108, 8, 8);
                    break;
                case 13:
                    source = new Rectangle(627, 108, 8, 8);
                    break;
                case 14:
                    source = new Rectangle(636, 108, 8, 8);
                    break;
                case 15:
                    source = new Rectangle(645, 108, 8, 8);
                    break;
                case 16:
                    source = new Rectangle(654, 108, 8, 8);
                    break;
                default:
                    source = new Rectangle(0, 0, 0, 0);
                    break;
            }
            if (toDraw)
            {
                _spriteBatch.Draw(texture, levelsOnMap[roomNum], source, Color.White);
            }
        }
    }
}
