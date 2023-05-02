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
    public class BatBombCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle bombRectangle;
        private Rectangle batRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public BatBombCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Bat bat)
        {
            itemDrop = null;
            bombRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.bomb.location1.X, (int)KeyBoardController.linkSprite.attack.bomb.location1.Y, ItemConstants.BombWidth * GameConstants.Sizing, ItemConstants.BombHeight * GameConstants.Sizing);
            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (!bat.death && batRectangle.Intersects(bombRectangle) && KeyBoardController.linkSprite.attack.bomb.frame == GameConstants.Two && KeyBoardController.linkSprite.attack.bomb.toDraw)
            {
                itemDrop = enemyDrops.dropItem(bat.location);
                bat.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
