using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Walls
{
    public class LinkWallCollision
    {
        private Link link;
        private KeyBoardController KeyBoardController;

        public int roomType;

        public LinkWallCollision(KeyBoardController KeyBoardController, Link link)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
        }

        public void SetRoomType(int roomType)
        {
            this.roomType = roomType;
        }

        public void Update()
        {
            if (roomType == 0)
            {
                if (KeyBoardController.linkSprite.location.X >= RoomConstants.DungeonWallXR)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.X = RoomConstants.DungeonWallXR;
                }
                else if (KeyBoardController.linkSprite.location.X <= RoomConstants.DungeonWallXL)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.X = RoomConstants.DungeonWallXL;
                }

                if (KeyBoardController.linkSprite.location.Y >= RoomConstants.DungeonWalYD)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.Y = RoomConstants.DungeonWalYD;
                }
                else if (KeyBoardController.linkSprite.location.Y <= RoomConstants.DungeonWallYU)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.Y = RoomConstants.DungeonWallYU;
                }
            }

            if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
            {
                KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
            }
        }
    }
}
