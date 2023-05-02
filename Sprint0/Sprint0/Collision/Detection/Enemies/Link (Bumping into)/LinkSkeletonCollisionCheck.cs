using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Detection.Enemies.Room;
using Sprint0.Collision.Response.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkSkeletonCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkSkeletonCollision linkSkeletonCollision;
        public EnemyRoomCollisionCheck enemyRoomCollisionCheck;
        public Game1 game1;
        public Link link;
        public int roomType;

        public LinkSkeletonCollisionCheck(KeyBoardController KeyBoardController, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkSkeletonCollision = new LinkSkeletonCollision(this.KeyBoardController, this.link, this.game1);
        }

        public void CheckCollision()
        {
            Skeleton skeleton;
            foreach (IEnemy enemy in game1.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.GetLocation().X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && skeleton.GetLocation().X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - skeleton.GetLocation().X >= 0 && KeyBoardController.linkSprite.location.X - skeleton.GetLocation().X <= skeleton.GetSize().X)
                    {
                        linkSkeletonCollision.Update(skeleton);
                    }

                    if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
                    {
                        KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
                        break;
                    }
                }
            }

            foreach (IEnemy enemy in game1.currentRoom.GetEnemies())
            {
                enemyRoomCollisionCheck = new EnemyRoomCollisionCheck(KeyBoardController, enemy);
                enemyRoomCollisionCheck.CheckCollision();
            }
        }
    }
}
