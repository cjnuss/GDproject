using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Blocks
{
    public class EnemyBlockCollision
    {
        private IEnemy enemy;
        private KeyBoardController KeyBoardController;
        private Rectangle enemyRectangle;
        private Rectangle obstacleRectangle;
        //bool linkOnLeft;
        //bool linkOnRight;
        //int linkOnLeftDistance;
        //int linkOnRightDistance;

        public EnemyBlockCollision(KeyBoardController KeyBoardController, IEnemy enemy)
        {
            this.enemy = enemy;
            this.KeyBoardController = KeyBoardController;
        }

        public void UpdateCollisionBlocks()
        {

        }

        public void Update(CollisionBlock collisionBlock)
        {
            enemyRectangle = new Rectangle((int)enemy.GetLocation().X, (int)enemy.GetLocation().Y, (int)enemy.GetSize().X * GameConstants.Sizing, (int)enemy.GetSize().Y * GameConstants.Sizing);
            obstacleRectangle = new Rectangle((int)collisionBlock.location.X, (int)collisionBlock.location.Y, collisionBlock.width, collisionBlock.height);

            if (obstacleRectangle.Intersects(enemyRectangle))
            {
                int blockCenterX = (int)collisionBlock.location.X + collisionBlock.width/2; 
                int blockCenterY = (int)collisionBlock.location.Y + collisionBlock.height/2;

                    if (enemy.GetLocation().X < blockCenterX)
                        enemy.SetLocation(new Vector2(enemy.GetLocation().X - 5, enemy.GetLocation().Y));
                    else if (enemy.GetLocation().X > blockCenterX)
                        enemy.SetLocation(new Vector2(enemy.GetLocation().X + 5, enemy.GetLocation().Y));
                    
                    if (enemy.GetLocation().Y > blockCenterY)
                        enemy.SetLocation(new Vector2(enemy.GetLocation().X, enemy.GetLocation().Y + 5));
                    else if (enemy.GetLocation().Y < blockCenterY)
                        enemy.SetLocation(new Vector2(enemy.GetLocation().X, enemy.GetLocation().Y - 5));
            }
        }
    }
}
