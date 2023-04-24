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
    public class GoriyaFireCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle fireRectangle;
        private Rectangle goriyaRectangle;

        public GoriyaFireCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(Goriya goriya)
        {
            if (KeyBoardController.dir == GameConstants.Left || KeyBoardController.dir == GameConstants.Right)
                fireRectangle = new Rectangle(KeyBoardController.linkSprite.attack.fire.currentX, KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireHeight * GameConstants.Sizing, ItemConstants.FireWidth * GameConstants.Sizing);
            else
                fireRectangle = new Rectangle(KeyBoardController.linkSprite.attack.fire.currentX, KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireWidth * GameConstants.Sizing, ItemConstants.FireHeight * GameConstants.Sizing);

            goriyaRectangle = new Rectangle((int)goriya.location.X, (int)goriya.location.Y, EnemyConstants.GoriyaSize * GameConstants.Sizing, EnemyConstants.GoriyaSize * GameConstants.Sizing);

            if (goriyaRectangle.Intersects(fireRectangle) && KeyBoardController.linkSprite.attack.fire.toDraw)
            {
                if (goriya.hits < EnemyConstants.GoriyaHP)
                {
                    if (!goriya.hit)
                        goriya.Hit(KeyBoardController.linkSprite.attack.fire.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    goriya.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
