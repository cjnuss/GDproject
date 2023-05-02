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
using System.Transactions;

namespace Sprint0
{
    public class GoriyaGreenArrowCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle arrowRectangle;
        private Rectangle goriyaRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public GoriyaGreenArrowCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Goriya goriya)
        {
            itemDrop = null;
            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.greenArrow.currentX, KeyBoardController.linkSprite.attack.greenArrow.currentY, ItemConstants.ArrowHeight * GameConstants.Sizing, ItemConstants.ArrowWidth * GameConstants.Sizing);
            else
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.greenArrow.currentX, KeyBoardController.linkSprite.attack.greenArrow.currentY, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            goriyaRectangle = new Rectangle((int)goriya.location.X, (int)goriya.location.Y, EnemyConstants.GoriyaSize * GameConstants.Sizing, EnemyConstants.GoriyaSize * GameConstants.Sizing);

            if (!goriya.death && goriyaRectangle.Intersects(arrowRectangle) && KeyBoardController.linkSprite.attack.greenArrow.toDraw)
            {
                KeyBoardController.linkSprite.attack.greenArrow.Dispose();
                if (goriya.hits < EnemyConstants.GoriyaHP)
                {
                    if (!goriya.hit)
                        goriya.Hit(KeyBoardController.linkSprite.attack.greenArrow.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    itemDrop = enemyDrops.dropItem(goriya.location);
                    goriya.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
            return itemDrop;
        }
    }
}
