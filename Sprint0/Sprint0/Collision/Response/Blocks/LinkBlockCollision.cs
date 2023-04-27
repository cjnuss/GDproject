using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Blocks
{
    public class LinkBlockCollision
    {
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle obstacleRectangle;
        //bool linkOnLeft;
        //bool linkOnRight;
        //int linkOnLeftDistance;
        //int linkOnRightDistance;

        public LinkBlockCollision(KeyBoardController KeyBoardController, Link link)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(CollisionBlock collisionBlock)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * GameConstants.Sizing, LinkConstants.CollisionSize * GameConstants.Sizing);
            obstacleRectangle = new Rectangle((int)collisionBlock.location.X, (int)collisionBlock.location.Y, collisionBlock.width, collisionBlock.height);

            if (obstacleRectangle.Intersects(linkRectangle))
            {
                link.velocity = GameConstants.Zero;
                int blockCenterX = (int)collisionBlock.location.X + collisionBlock.width/2; 
                int blockCenterY = (int)collisionBlock.location.Y + collisionBlock.height/2;

                if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                {
                    if ((int)link.location.X < blockCenterX)
                        link.location.X = (int)collisionBlock.location.X - LinkConstants.Size * GameConstants.Sizing;
                    else if ((int)link.location.X > blockCenterX)
                        link.location.X = (int)collisionBlock.location.X + collisionBlock.width + LinkConstants.Correction;
                }

                else if(KeyBoardController.dir == GameConstants.Up || KeyBoardController.dir == GameConstants.Down)
                {
                    if ((int)link.location.Y > blockCenterY)
                        link.location.Y = (int)collisionBlock.location.Y + collisionBlock.height - 6;
                    else if ((int)link.location.Y < blockCenterY)
                        link.location.Y = (int)collisionBlock.location.Y - LinkConstants.Size * GameConstants.Sizing - LinkConstants.Correction;
                }
            }
        }
    }
}
