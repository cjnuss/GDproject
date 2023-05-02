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
    public class BatSwordBeamCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle swordBeamRectangle;
        private Rectangle batRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public BatSwordBeamCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Bat bat)
        {
            itemDrop = null;
            if (KeyBoardController.dir == GameConstants.Up || KeyBoardController.dir == GameConstants.Up)
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamWidth * GameConstants.Sizing, LinkConstants.SwordBeamHeight * GameConstants.Sizing);

            else
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamHeight * GameConstants.Sizing, LinkConstants.SwordBeamWidth * GameConstants.Sizing);


            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (!bat.death && batRectangle.Intersects(swordBeamRectangle) && KeyBoardController.linkSprite.attack.swordBeam.toDraw)
            {
                itemDrop = enemyDrops.dropItem(bat.location);
                //KeyBoardController.linkSprite.attack.swordBeam.Dispose(); debug??
                bat.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
