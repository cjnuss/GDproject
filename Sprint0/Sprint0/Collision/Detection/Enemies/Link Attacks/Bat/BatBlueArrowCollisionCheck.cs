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
    public class BatBlueArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private BatBlueArrowCollision batBlueArrowCollision;
        private Game1 game;
        private Bat bat;

        public BatBlueArrowCollisionCheck(KeyBoardController KeyBoardController, BatBlueArrowCollision batblueArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.batBlueArrowCollision = new BatBlueArrowCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Bat))
                {
                    bat = (Bat)enemy;
                    if (bat.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX >= GameConstants.Zero && bat.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.blueArrow.currentX - bat.location.X >= 0 && KeyBoardController.linkSprite.attack.blueArrow.currentX - bat.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        return batBlueArrowCollision.Update(bat);
                    }
                }
            }
            return null;
        }
    }
}
