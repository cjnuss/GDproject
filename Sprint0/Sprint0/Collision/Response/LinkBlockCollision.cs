using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
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
                linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size*LinkConstants.Size, LinkConstants.CollisionSize *GameConstants.Sizing);
                obstacleRectangle = new Rectangle((int)collisionBlock.location.X, (int)collisionBlock.location.Y, collisionBlock.width, collisionBlock.height);

            if (obstacleRectangle.Intersects(linkRectangle))
            {
                link.velocity = GameConstants.Zero;
                if(KeyBoardController.dir == GameConstants.Left)
                    link.location.X = link.location.X + LinkConstants.Correction;
                else if(KeyBoardController.dir == GameConstants.Right)
                    link.location.X = link.location.X - LinkConstants.Correction;
                else if(KeyBoardController.dir == GameConstants.Up)
                    link.location.Y = link.location.Y + LinkConstants.Correction;
                else if (KeyBoardController.dir == GameConstants.Down)
                    link.location.Y = link.location.Y - LinkConstants.Correction;
            }
        }
    }
}
