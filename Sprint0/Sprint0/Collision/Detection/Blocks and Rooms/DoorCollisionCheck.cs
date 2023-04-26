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

namespace Sprint0
{
    public class DoorCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public Game1 game1;
        public Link link;
        public int roomType;
        public Rectangle linkRectangle;
        public Rectangle doorRectangle;

        public DoorCollisionCheck(KeyBoardController KeyBoardController, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
        }

        public Door CheckCollision()
        {
            foreach (Door door in game1.currentRoom.GetDoors())
            {
                linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y, 50, 50);
                doorRectangle = new Rectangle((int)door.location.X, (int)door.location.Y, door.width, door.height);

                if (doorRectangle.Intersects(linkRectangle))
                {
                    return door;
                }
            }
            return null;
        }
    }
}




       
