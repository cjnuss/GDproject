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
    public class GelBombCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle bombRectangle;
        private Rectangle gelRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public GelBombCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Gel gel)
        {
            itemDrop = null;
            bombRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.bomb.location1.X, (int)KeyBoardController.linkSprite.attack.bomb.location1.Y, ItemConstants.BombWidth * GameConstants.Sizing, ItemConstants.BombHeight * GameConstants.Sizing);
            gelRectangle = new Rectangle((int)gel.location.X, (int)gel.location.Y, EnemyConstants.GelWidth * GameConstants.Sizing, EnemyConstants.GelHeight * GameConstants.Sizing);

            if (!gel.death && gelRectangle.Intersects(bombRectangle) && KeyBoardController.linkSprite.attack.bomb.frame == GameConstants.Two && KeyBoardController.linkSprite.attack.bomb.toDraw)
            {
                itemDrop = enemyDrops.dropItem(gel.location);
                gel.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
