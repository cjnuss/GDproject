using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkEnemyCollision
    {
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle enemyRectangle;

        public LinkEnemyCollision(KeyBoardController KeyBoardController, Link link)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(ISprite collisionEnemy)
        {
           /*     linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size*LinkConstants.Size, LinkConstants.Size *GameConstants.Sizing);
                enemyRectangle = new Rectangle((int)collisionEnemy.location.X, (int)collisionEnemy.location.Y, collisionEnemy.width, collisionEnemy.height);

            if (enemyRectangle.Intersects(linkRectangle))
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
            } */
        }
    }
}
