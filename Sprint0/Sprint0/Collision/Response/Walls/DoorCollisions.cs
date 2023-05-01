using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Walls
{
    public class DoorCollisions
    {
        public KeyBoardController KeyBoardController;
        public Game1 game1;
        public Link link;
        public int roomType;
        public Rectangle linkRectangle;
        public Rectangle[] doorRectangle;
        int numDoors;



        public DoorCollisions(KeyBoardController KeyBoardController, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y, LinkConstants.Size * GameConstants.Sizing, LinkConstants.Size * GameConstants.Sizing);
        }

        public void UpdateCollisionBlocks()
        {

            numDoors = game1.currentRoom.GetDoors().Count;
            doorRectangle = new Rectangle[numDoors];

            int i = 0;
            foreach (Door door in game1.currentRoom.GetDoors())
            {
                doorRectangle[i] = new Rectangle((int)door.location.X, (int)door.location.Y, door.width, door.height);
                i++;
            }
        }

        public Door Check()
        {
            linkRectangle.X = (int)link.location.X;
            linkRectangle.Y = (int)link.location.Y;

            int i = 0;
            foreach (Door door in game1.currentRoom.GetDoors())
            {
                if (doorRectangle[i].Intersects(linkRectangle))
                {
                    return door;
                }
                i++;
            }
            return null;
        }
    }
}





