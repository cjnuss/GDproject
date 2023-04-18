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
    public class BatFireCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle fireRectangle;
        private Rectangle batRectangle;

        public BatFireCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(Bat bat)
        {
            fireRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.fire.currentX, (int)KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireWidth * GameConstants.Sizing, ItemConstants.FireHeight * GameConstants.Sizing);
            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (batRectangle.Intersects(fireRectangle))
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
