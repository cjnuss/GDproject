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
    public class AquamentusSwordBeamCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle swordBeamRectangle;
        private Rectangle aquamentusRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;
        public AquamentusSwordBeamCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Aquamentus aquamentus)
        {
            if (KeyBoardController.dir == GameConstants.Up || KeyBoardController.dir == GameConstants.Up)
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamWidth * GameConstants.Sizing, LinkConstants.SwordBeamHeight * GameConstants.Sizing);

            else
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamHeight * GameConstants.Sizing, LinkConstants.SwordBeamWidth * GameConstants.Sizing);


            aquamentusRectangle = new Rectangle((int)aquamentus.location.X, (int)aquamentus.location.Y, EnemyConstants.AquaWidth * GameConstants.Sizing, EnemyConstants.AquaHeight * GameConstants.Sizing);

            if (!aquamentus.death && aquamentusRectangle.Intersects(swordBeamRectangle) && KeyBoardController.linkSprite.attack.swordBeam.toDraw)
            {
                //KeyBoardController.linkSprite.attack.swordBeam.Dispose(); debug??
                if (aquamentus.hits < EnemyConstants.AquaHP)
                {
                    if (!aquamentus.hit)
                        aquamentus.Hit(KeyBoardController.linkSprite.attack.swordBeam.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                    itemDrop = null;
                }
                else
                {
                    itemDrop = enemyDrops.dropItem(aquamentus.location);
                    aquamentus.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
            return itemDrop;
        }
    }
}
