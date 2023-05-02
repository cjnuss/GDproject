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
    public class BatSwordCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle batRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public BatSwordCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Bat bat)
        {
            itemDrop = null;
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (!bat.death && batRectangle.Intersects(linkRectangle) && KeyBoardController.linkState == LinkConstants.WoodenSword)
            {
                itemDrop = enemyDrops.dropItem(bat.location);
                bat.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }

            return itemDrop;
        }
    }
}
