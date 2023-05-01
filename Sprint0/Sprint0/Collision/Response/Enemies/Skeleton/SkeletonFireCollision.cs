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
    public class SkeletonFireCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle fireRectangle;
        private Rectangle skeletonRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public SkeletonFireCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Skeleton skeleton)
        {
            itemDrop = null;

            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                fireRectangle = new Rectangle(KeyBoardController.linkSprite.attack.fire.currentX, KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireHeight * GameConstants.Sizing, ItemConstants.FireWidth * GameConstants.Sizing);
            else
                fireRectangle = new Rectangle(KeyBoardController.linkSprite.attack.fire.currentX, KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireWidth * GameConstants.Sizing, ItemConstants.FireHeight * GameConstants.Sizing);

            skeletonRectangle = new Rectangle((int)skeleton.location.X, (int)skeleton.location.Y, EnemyConstants.SkeletonSize * GameConstants.Sizing, EnemyConstants.SkeletonSize * GameConstants.Sizing);

            if (skeletonRectangle.Intersects(fireRectangle) && KeyBoardController.linkSprite.attack.fire.toDraw)
            {
                if (skeleton.hits < EnemyConstants.SkeletonHP)
                {
                    if (!skeleton.hit)
                        skeleton.Hit(KeyBoardController.linkSprite.attack.fire.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");

                    itemDrop = null;
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
