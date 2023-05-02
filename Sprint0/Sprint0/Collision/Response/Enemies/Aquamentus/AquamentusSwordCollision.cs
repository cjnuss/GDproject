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
    public class AquamentusSwordCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle aquamentusRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public AquamentusSwordCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Aquamentus aquamentus)
        {
            itemDrop = null;

            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            aquamentusRectangle = new Rectangle((int)aquamentus.location.X, (int)aquamentus.location.Y, EnemyConstants.AquaWidth * GameConstants.Sizing, EnemyConstants.AquaHeight * GameConstants.Sizing);

            if (!aquamentus.death && aquamentusRectangle.Intersects(linkRectangle) && KeyBoardController.linkState == LinkConstants.WoodenSword)
            {
                if (aquamentus.hits < EnemyConstants.AquaHP)
                {
                    if (!aquamentus.hit)
                        aquamentus.Hit(KeyBoardController.dir);

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
