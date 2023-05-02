using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Sprint0
{
    public class Door
    {
        public Vector2 location;
        public int width;
        public int height;
        public int type;

        public Door(Vector2 location, int type)
        {
            this.location = location;
            this.type = type;
            width = 10;
            height = 10;

            if (type == 0)
            {
                if (location.X < 75)
                {
                    this.width = 36;
                } 
                else if (location.Y < 215)
                {
                    this.height = 31;
                } 
                else if (location.X > 650)
                {
                    this.location.X = 699;
                } 
                else if (location.Y > 500)
                {
                    this.location.Y = 541;
                }
            }
        }

        public void openDoor(GameManager gameManager)
        {
            type = 1;

            Room adjRoom = null;
            int direction = 0;
            int roomNum = 0;

            if (location.X < 75)
            {
                width = 10;
                roomNum = gameManager.game1.currentRoom.GetRooms()[0];
                adjRoom = gameManager.roomList[roomNum];
                direction = 0;
            } 
            else if (location.Y < 215)
            {
                height = 10;
                roomNum = gameManager.game1.currentRoom.GetRooms()[1];
                adjRoom = gameManager.roomList[roomNum];
                direction = 1;
            } 
            else if (location.X > 650)
            {
                this.location.X = 725;
                roomNum = gameManager.game1.currentRoom.GetRooms()[2];
                adjRoom = gameManager.roomList[roomNum];
                direction = 2;
            } 
            else if (location.Y > 500)
            {
                this.location.Y = 563;
                roomNum = gameManager.game1.currentRoom.GetRooms()[0];
                adjRoom = gameManager.roomList[roomNum];
                direction = 3;
            }

            gameManager.updatedDoors.Add(new OpenedDoor(direction));

            foreach (CollisionBlock block in gameManager.game1.currentRoom.GetBlocks())
            {
                switch (direction)
                {
                    case 0:
                        if (block.location.X == 0 && block.height == 480)
                        {
                            block.height = 206;
                            gameManager.roomList[roomNum].AddBlock(new CollisionBlock(new Vector2(0, 424), 95, 196));
                        }
                        break;
                    case 1:
                        if (block.location.Y == 150 && block.width == 800)
                        {
                            block.width = 360;
                            gameManager.roomList[roomNum].AddBlock(new CollisionBlock(new Vector2(440, 150), 350, 82));
                        }
                        break;
                    case 2:
                        if (block.location.X == 705 && block.height == 480)
                        {
                            block.height = 206;
                            gameManager.roomList[roomNum].AddBlock(new CollisionBlock(new Vector2(705, 424), 95, 196));
                        }
                        break;
                    case 3:
                        if (block.location.Y == 548 && block.height == 800)
                        {
                            block.width = 360;
                            gameManager.roomList[roomNum].AddBlock(new CollisionBlock(new Vector2(440, 548), 350, 82));
                        }
                        break;
                }
            }

            foreach (Door door in adjRoom.GetDoors())
            {
                switch (direction)
                {
                    case 0:
                        if (door.location.X > 650)
                        {
                            door.type = 1;
                            door.location.X = 725;
                        }
                        break;
                    case 1:
                        if (door.location.Y > 500)
                        {
                            door.type = 1;
                            door.location.Y = 563;
                        }
                        break;
                    case 2:
                        if (door.location.X < 75)
                        {
                            door.type = 1;
                            door.width = 10;
                        }
                        break;
                    case 3:
                        if (door.location.Y < 215)
                        {
                            door.type = 1;
                            door.height = 10;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
