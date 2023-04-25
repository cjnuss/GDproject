using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Enemies
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

        public void Update(IEnemy collisionEnemy)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.Size * GameConstants.Sizing);
            enemyRectangle = new Rectangle((int)collisionEnemy.GetLocation().X, (int)collisionEnemy.GetLocation().Y, (int)collisionEnemy.GetSize().X, (int)collisionEnemy.GetSize().Y);

            if (enemyRectangle.Intersects(linkRectangle))
            {
                link.UpdateDirection(KeyBoardController.dir);
                link.UpdateSprite(LinkConstants.Damage);
                link.velocity = GameConstants.Zero;
            } else
            {
                link.UpdateSprite(LinkConstants.Default);
                link.velocity = LinkConstants.Velocity;
            }
        }
    }
}
