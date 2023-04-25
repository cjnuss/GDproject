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
    public class GelBlueArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GelBlueArrowCollision gelBlueArrowCollision;
        private Game1 game;
        private Gel gel;

        public GelBlueArrowCollisionCheck(KeyBoardController KeyBoardController, GelBlueArrowCollision gelblueArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.gelBlueArrowCollision = new GelBlueArrowCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Gel))
                {
                    gel = (Gel)enemy;
                    if (gel.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX >= GameConstants.Zero && gel.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.blueArrow.currentX - gel.location.X >= 0 && KeyBoardController.linkSprite.attack.blueArrow.currentX - gel.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        gelBlueArrowCollision.Update(gel);
                    }
                }
            }
        }
    }
}
