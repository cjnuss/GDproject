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
    public class GelSwordBeamCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle swordBeamRectangle;
        private Rectangle gelRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public GelSwordBeamCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Gel gel)
        {
            itemDrop = null;
            if (KeyBoardController.dir == GameConstants.Up || KeyBoardController.dir == GameConstants.Up)
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamWidth * GameConstants.Sizing, LinkConstants.SwordBeamHeight * GameConstants.Sizing);

            else
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamHeight * GameConstants.Sizing, LinkConstants.SwordBeamWidth * GameConstants.Sizing);


            gelRectangle = new Rectangle((int)gel.location.X, (int)gel.location.Y, EnemyConstants.GelWidth * GameConstants.Sizing, EnemyConstants.GelHeight * GameConstants.Sizing);

            if (!gel.death && gelRectangle.Intersects(swordBeamRectangle) && KeyBoardController.linkSprite.attack.swordBeam.toDraw)
            {
                itemDrop = enemyDrops.dropItem(gel.location);
                //KeyBoardController.linkSprite.attack.swordBeam.Dispose(); debug??
                gel.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
