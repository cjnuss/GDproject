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
    public class BatBlueArrowCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle arrowRectangle;
        private Rectangle batRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public BatBlueArrowCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Bat bat)
        {
            itemDrop = null;
            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.blueArrow.currentX, KeyBoardController.linkSprite.attack.blueArrow.currentY, ItemConstants.ArrowHeight * GameConstants.Sizing, ItemConstants.ArrowWidth * GameConstants.Sizing);
            else
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.blueArrow.currentX, KeyBoardController.linkSprite.attack.blueArrow.currentY, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (!bat.death && batRectangle.Intersects(arrowRectangle) && KeyBoardController.linkSprite.attack.blueArrow.toDraw)
            {
                itemDrop = enemyDrops.dropItem(bat.location);
                KeyBoardController.linkSprite.attack.blueArrow.Dispose();
                bat.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
