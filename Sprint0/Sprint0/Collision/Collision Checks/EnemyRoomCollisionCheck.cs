using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class EnemyRoomCollisionCheck
    {
        private IEnemy enemy;
        private KeyBoardController KeyBoardController;

        public int roomType;

        public EnemyRoomCollisionCheck(KeyBoardController KeyBoardController, IEnemy enemy)
        {
            this.enemy = enemy;
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
                if (enemy.GetLocation().X >= RoomConstants.DungeonWallXR)
                {
                    enemy.SetLocation(new Vector2(enemy.GetLocation().X - 20, enemy.GetLocation().Y));
                } else if (enemy.GetLocation().X <= RoomConstants.DungeonWallXL)
                {
                    enemy.SetLocation(new Vector2(enemy.GetLocation().X + 20, enemy.GetLocation().Y));
                }

                if(enemy.GetLocation().Y >= RoomConstants.DungeonWalYD)
                {
                    enemy.SetLocation(new Vector2(enemy.GetLocation().X, enemy.GetLocation().Y - 20));
                }
                else if(enemy.GetLocation().Y <= RoomConstants.DungeonWallYU)
                {
                    enemy.SetLocation(new Vector2(enemy.GetLocation().X, enemy.GetLocation().Y + 20));
                }
            }

            if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
            {
                KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
            }
        }
    }
}
