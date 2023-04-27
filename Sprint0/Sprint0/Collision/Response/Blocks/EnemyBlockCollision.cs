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

        public void Update(CollisionBlock collisionBlock)
        {
            enemyRectangle = new Rectangle((int)enemy.GetLocation().X, (int)enemy.GetLocation().Y, (int)enemy.GetSize().X, (int)enemy.GetSize().Y);
            obstacleRectangle = new Rectangle((int)collisionBlock.location.X, (int)collisionBlock.location.Y, collisionBlock.width, collisionBlock.height);

            if (obstacleRectangle.Intersects(enemyRectangle))
            {
                int blockCenterX = (int)collisionBlock.location.X + collisionBlock.width/2; 
                int blockCenterY = (int)collisionBlock.location.Y + collisionBlock.height/2;

                if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                {
                    if ((int)enemy.GetLocation().X < blockCenterX)
                        enemy.SetLocation(new Vector2(collisionBlock.location.X - LinkConstants.Size * GameConstants.Sizing, enemy.GetLocation().Y));
                    else if ((int)enemy.GetLocation().X > blockCenterX)
                        enemy.SetLocation(new Vector2(collisionBlock.location.X + collisionBlock.width + LinkConstants.Correction, enemy.GetLocation().Y));
                }

                else if(KeyBoardController.dir == GameConstants.Up || KeyBoardController.dir == GameConstants.Down)
                {
                    if ((int)enemy.GetLocation().Y > blockCenterY)
                        enemy.SetLocation(new Vector2(enemy.GetLocation().X, collisionBlock.location.Y + collisionBlock.height - 6));
                    else if ((int)enemy.GetLocation().Y < blockCenterY)
                        enemy.SetLocation(new Vector2(enemy.GetLocation().X, collisionBlock.location.Y - LinkConstants.Size * GameConstants.Sizing - LinkConstants.Correction));
                }
            }
        }
    }
}
