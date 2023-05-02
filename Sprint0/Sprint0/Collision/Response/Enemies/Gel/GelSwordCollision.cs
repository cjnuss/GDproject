using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class GelSwordCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle gelRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public GelSwordCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Gel gel)
        {
            itemDrop = null;
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            gelRectangle = new Rectangle((int)gel.location.X, (int)gel.location.Y, EnemyConstants.GelWidth * GameConstants.Sizing, EnemyConstants.GelHeight * GameConstants.Sizing);

            if (!gel.death && gelRectangle.Intersects(linkRectangle) && KeyBoardController.linkState == LinkConstants.WoodenSword)
            {
                itemDrop = enemyDrops.dropItem(gel.location);
                gel.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
