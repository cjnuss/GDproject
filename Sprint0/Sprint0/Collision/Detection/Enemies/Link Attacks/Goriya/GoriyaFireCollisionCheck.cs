using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
    public class GoriyaFireCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GoriyaFireCollision goriyaFireCollision;
        private Game1 game;
        private Goriya goriya;

        public GoriyaFireCollisionCheck(KeyBoardController KeyBoardController, GoriyaFireCollision goriyaFireCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.goriyaFireCollision = new GoriyaFireCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Goriya))
                {
                    goriya = (Goriya)enemy;
                    if (goriya.location.X - KeyBoardController.linkSprite.attack.fire.currentX >= GameConstants.Zero && goriya.location.X - KeyBoardController.linkSprite.attack.fire.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.fire.currentX - goriya.location.X >= 0 && KeyBoardController.linkSprite.attack.fire.currentX - goriya.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        goriyaFireCollision.Update(goriya);
                    }
                }
            }
        }
    }
}
