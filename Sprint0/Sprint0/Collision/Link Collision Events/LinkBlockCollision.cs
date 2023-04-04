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
        bool linkOnLeft;
        bool linkOnRight;
        int linkOnLeftDistance;
        int linkOnRightDistance;

        public LinkBlockCollision(KeyBoardController KeyBoardController, Link link)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(CollisionBlock collisionBlock)
        {
                linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + 7, 16*3, 14*3);
                obstacleRectangle = new Rectangle((int)collisionBlock.location.X, (int)collisionBlock.location.Y, collisionBlock.width, collisionBlock.height);

            if (obstacleRectangle.Intersects(linkRectangle))
            {
                link.velocity = 0;
                if(KeyBoardController.dir == 1)
                    link.location.X = link.location.X + 2;
                else if(KeyBoardController.dir == 2)
                    link.location.X = link.location.X - 2;
                else if(KeyBoardController.dir == 3)
                    link.location.Y = link.location.Y + 2;
                else if (KeyBoardController.dir == 0)
                    link.location.Y = link.location.Y - 2;
            }
        }
    }
}
