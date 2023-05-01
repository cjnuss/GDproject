using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Enemies
{
    public class AquamentusBombCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle bombRectangle;
        private Rectangle aquamentusRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public AquamentusBombCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Aquamentus aquamentus)
        {
            itemDrop = null;

            bombRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.bomb.location1.X, (int)KeyBoardController.linkSprite.attack.bomb.location1.Y, ItemConstants.BombWidth * GameConstants.Sizing, ItemConstants.BombHeight * GameConstants.Sizing);
            aquamentusRectangle = new Rectangle((int)aquamentus.location.X, (int)aquamentus.location.Y, EnemyConstants.AquaWidth * GameConstants.Sizing, EnemyConstants.AquaHeight * GameConstants.Sizing);

            if (aquamentusRectangle.Intersects(bombRectangle) && KeyBoardController.linkSprite.attack.bomb.frame == GameConstants.Two && KeyBoardController.linkSprite.attack.bomb.toDraw)
            {
                if (aquamentus.hits < EnemyConstants.AquaHP)
                {
                    if (!aquamentus.hit)
                        aquamentus.Hit(KeyBoardController.linkSprite.attack.bomb.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
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
