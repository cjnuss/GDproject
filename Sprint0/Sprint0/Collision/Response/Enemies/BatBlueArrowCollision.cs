using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public BatBlueArrowCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(Bat bat)
        {
            arrowRectangle = new Rectangle(KeyBoardController.linkSprite.attack.blueArrow.currentX, KeyBoardController.linkSprite.attack.blueArrow.currentY, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);
            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (batRectangle.Intersects(arrowRectangle))
            {
                bat.location = new Vector2(GameConstants.Zero, GameConstants.Zero);
                bat.toDraw = false;
                // DEBUG : HURT?
                game.soundEffects.LoadSound(game, "EnemyDie", "enemydie");
                if (!game.soundEffects.IsPlaying("EnemyDie"))
                {
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
