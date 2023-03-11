using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class LinkEnemyCollision
    {
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle obstacleRectangle;
        bool linkOnLeft;
        bool linkOnRight;
        int linkOnLeftDistance;
        int linkOnRightDistance;

        public LinkEnemyCollision(KeyBoardController KeyBoardController, Link link)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(CollisionEnemy collisionEnemy)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y, 16 * 3, 16 * 3);
            obstacleRectangle = new Rectangle((int)collisionEnemy.location.X, (int)collisionEnemy.location.Y, collisionEnemy.width, collisionEnemy.height);

            if (obstacleRectangle.Intersects(linkRectangle))
            {
                link.velocity = 0;
                // do damge command
                if (KeyBoardController.dir == 1)
                    link.location.X = link.location.X + 2;
                else if (KeyBoardController.dir == 2)
                    link.location.X = link.location.X - 2;
                else if (KeyBoardController.dir == 3)
                    link.location.Y = link.location.Y + 2;
                else if (KeyBoardController.dir == 0)
                    link.location.Y = link.location.Y - 2;
            }
        }
    }
}
