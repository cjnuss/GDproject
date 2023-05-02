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
    public class SkeletonBlueArrowCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle arrowRectangle;
        private Rectangle skeletonRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public SkeletonBlueArrowCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Skeleton skeleton)
        {
            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.blueArrow.currentX, KeyBoardController.linkSprite.attack.blueArrow.currentY, ItemConstants.ArrowHeight * GameConstants.Sizing, ItemConstants.ArrowWidth * GameConstants.Sizing);
            else
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.blueArrow.currentX, KeyBoardController.linkSprite.attack.blueArrow.currentY, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            skeletonRectangle = new Rectangle((int)skeleton.location.X, (int)skeleton.location.Y, EnemyConstants.SkeletonSize * GameConstants.Sizing, EnemyConstants.SkeletonSize * GameConstants.Sizing);

            if (!skeleton.death && skeletonRectangle.Intersects(arrowRectangle) && KeyBoardController.linkSprite.attack.blueArrow.toDraw)
            {
                //KeyBoardController.linkSprite.attack.blueArrow.Dispose();
                if (skeleton.hits < EnemyConstants.SkeletonHP)
                {
                    if (!skeleton.hit)
                        skeleton.Hit(KeyBoardController.linkSprite.attack.blueArrow.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    itemDrop = enemyDrops.dropItem(skeleton.location);
                    skeleton.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }

            return itemDrop;
        }
    }
}
