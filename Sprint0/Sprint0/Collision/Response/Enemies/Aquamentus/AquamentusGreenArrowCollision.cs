using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sprint0
{
    public class AquamentusGreenArrowCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle arrowRectangle;
        private Rectangle aquamentusRectangle;

        public AquamentusGreenArrowCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(Aquamentus aquamentus)
        {
            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.greenArrow.currentX, KeyBoardController.linkSprite.attack.greenArrow.currentY, ItemConstants.ArrowHeight * GameConstants.Sizing, ItemConstants.ArrowWidth * GameConstants.Sizing);
            else
                arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.greenArrow.currentX, KeyBoardController.linkSprite.attack.greenArrow.currentY, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            aquamentusRectangle = new Rectangle((int)aquamentus.location.X, (int)aquamentus.location.Y, EnemyConstants.AquaWidth * GameConstants.Sizing, EnemyConstants.AquaHeight * GameConstants.Sizing);

            if (aquamentusRectangle.Intersects(arrowRectangle) && KeyBoardController.linkSprite.attack.greenArrow.toDraw)
            {
                KeyBoardController.linkSprite.attack.greenArrow.Dispose();
                if (aquamentus.hits < EnemyConstants.AquaHP)
                {
                    if (!aquamentus.hit)
                        aquamentus.Hit(KeyBoardController.linkSprite.attack.greenArrow.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    aquamentus.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
