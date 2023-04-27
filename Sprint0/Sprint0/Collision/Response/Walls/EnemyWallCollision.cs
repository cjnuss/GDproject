using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Walls
{
    public class EnemyWallCollision
    {
        private IEnemy enemy;
        private KeyBoardController KeyBoardController;

        public int roomType;

        public EnemyWallCollision(KeyBoardController KeyBoardController, IEnemy enemy)
        {
            this.enemy = enemy;
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
                if (enemy.GetLocation().X >= RoomConstants.DungeonWallXR)
                {
                    enemy.SetLocation(new Vector2(RoomConstants.DungeonWallXR, enemy.GetLocation().Y));
                }
                else if (enemy.GetLocation().X <= RoomConstants.DungeonWallXL)
                {
                    enemy.SetLocation(new Vector2(RoomConstants.DungeonWallXL, enemy.GetLocation().Y));
                }

                if (enemy.GetLocation().Y >= RoomConstants.DungeonWalYD)
                {
                    enemy.SetLocation(new Vector2(enemy.GetLocation().X, RoomConstants.DungeonWalYD));
                }
                else if (enemy.GetLocation().Y <= RoomConstants.DungeonWallYU)
                {
                    enemy.SetLocation(new Vector2(enemy.GetLocation().X, RoomConstants.DungeonWallYU));
                }
            }

            if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
            {
                KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
            }
        }
    }
}
