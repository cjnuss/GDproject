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
    public class AquamentusFireCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle fireRectangle;
        private Rectangle aquamentusRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public AquamentusFireCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Aquamentus aquamentus)
        {
            itemDrop = null;
            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                fireRectangle = new Rectangle(KeyBoardController.linkSprite.attack.fire.currentX, KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireHeight * GameConstants.Sizing, ItemConstants.FireWidth * GameConstants.Sizing);
            else
                fireRectangle = new Rectangle(KeyBoardController.linkSprite.attack.fire.currentX, KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireWidth * GameConstants.Sizing, ItemConstants.FireHeight * GameConstants.Sizing);

            aquamentusRectangle = new Rectangle((int)aquamentus.location.X, (int)aquamentus.location.Y, EnemyConstants.AquaWidth * GameConstants.Sizing, EnemyConstants.AquaHeight * GameConstants.Sizing);

            if (!aquamentus.death && aquamentusRectangle.Intersects(fireRectangle) && KeyBoardController.linkSprite.attack.fire.toDraw)
            {
                if (aquamentus.hits < EnemyConstants.AquaHP)
                {
                    if (!aquamentus.hit)
                        aquamentus.Hit(KeyBoardController.linkSprite.attack.fire.direction);

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
