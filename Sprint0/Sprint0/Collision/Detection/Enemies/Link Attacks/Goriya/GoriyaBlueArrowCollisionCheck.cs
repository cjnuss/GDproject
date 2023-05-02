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
    public class GoriyaBlueArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GoriyaBlueArrowCollision goriyaBlueArrowCollision;
        private Game1 game;
        private Goriya goriya;

        public GoriyaBlueArrowCollisionCheck(KeyBoardController KeyBoardController, GoriyaBlueArrowCollision goriyaBlueArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.goriyaBlueArrowCollision = new GoriyaBlueArrowCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Goriya))
                {
                    goriya = (Goriya)enemy;
                    if (goriya.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX >= GameConstants.Zero && goriya.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.blueArrow.currentX - goriya.location.X >= 0 && KeyBoardController.linkSprite.attack.blueArrow.currentX - goriya.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        return goriyaBlueArrowCollision.Update(goriya);
                    }
                }
            }

            return null;
        }
    }
}
