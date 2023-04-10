using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class RoomCollisionCheck
    {
        private Link link;
        private KeyBoardController KeyBoardController;

        public int roomType;

        public RoomCollisionCheck(KeyBoardController KeyBoardController, Link link)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
        }

        public void SetRoomType(int roomType)
        {
            this.roomType = roomType;
        }

        public void CheckCollision()
        {
            if (roomType == 0)
            {
                if (KeyBoardController.linkSprite.location.X >= RoomConstants.DungeonWallXR)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.X = link.location.X - LinkConstants.Correction;
                } else if (KeyBoardController.linkSprite.location.X <= RoomConstants.DungeonWallXL)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.X = link.location.X + LinkConstants.Correction;
                }

                if(KeyBoardController.linkSprite.location.Y >= RoomConstants.DungeonWalYD)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.Y = link.location.Y - LinkConstants.Correction;
                }
                else if(KeyBoardController.linkSprite.location.Y <= RoomConstants.DungeonWallYU)
                {
                    link.velocity = GameConstants.Zero;
                    link.location.Y = link.location.Y + LinkConstants.Correction;
                }
            }

            if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
            {
                KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
            }
        }
    }
}
