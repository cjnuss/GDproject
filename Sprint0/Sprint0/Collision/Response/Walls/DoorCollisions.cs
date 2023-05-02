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
        public Rectangle doorRectangle;
        private Dictionary<Rectangle, Door> doors;
        int numDoors;

        public DoorCollisions(KeyBoardController KeyBoardController, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y, LinkConstants.Size * GameConstants.Sizing, LinkConstants.Size * GameConstants.Sizing);
            doors = new Dictionary<Rectangle, Door>();
        }

        public void UpdateCollisionBlocks()
        {
            foreach (Door door in game1.currentRoom.GetDoors())
            {
                doorRectangle = new Rectangle((int)door.location.X, (int)door.location.Y, door.width, door.height);
                if (!doors.ContainsKey(doorRectangle))
                    doors.Add(doorRectangle, door);
            }
        }

        public Door Check()
        {
            linkRectangle.X = (int)link.location.X;
            linkRectangle.Y = (int)link.location.Y;

            foreach (KeyValuePair<Rectangle, Door> door in doors)
            {
                if (door.Key.Intersects(linkRectangle))
                {
                    if (door.Value.type == 1)
                    {
                        return door.Value;
                    } else if (door.Value.type == 2)
                    {
                        if (game1.linkItems.keys > 0)
                        {
                            game1.linkItems.keys--;
                            return door.Value;
                        }
                    }
                }
            }
            return null;
        }
    }
}





