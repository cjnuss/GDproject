using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Enemies;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class BatGreenArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private BatGreenArrowCollision batGreenArrowCollision;
        private Game1 game;
        private Bat bat;

        public BatGreenArrowCollisionCheck(KeyBoardController KeyBoardController, BatGreenArrowCollision batGreenArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.batGreenArrowCollision = new BatGreenArrowCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Bat))
                {
                    bat = (Bat)enemy;
                    if (bat.location.X - KeyBoardController.linkSprite.attack.greenArrow.currentX >= GameConstants.Zero && bat.location.X - KeyBoardController.linkSprite.attack.greenArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.greenArrow.currentX - bat.location.X >= 0 && KeyBoardController.linkSprite.attack.greenArrow.currentX - bat.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        batGreenArrowCollision.Update(bat);
                    }
                }
            }
        }
    }
}
