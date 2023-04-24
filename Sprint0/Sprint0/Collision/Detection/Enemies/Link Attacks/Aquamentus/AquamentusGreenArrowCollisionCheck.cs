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
    public class AquamentusGreenArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private AquamentusGreenArrowCollision aquamentusGreenArrowCollision;
        private Game1 game;
        private Aquamentus aquamentus;

        public AquamentusGreenArrowCollisionCheck(KeyBoardController KeyBoardController, AquamentusGreenArrowCollision aquamentusGreenArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.aquamentusGreenArrowCollision = new AquamentusGreenArrowCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Aquamentus))
                {
                    aquamentus = (Aquamentus)enemy;
                    if (aquamentus.location.X - KeyBoardController.linkSprite.attack.greenArrow.currentX >= GameConstants.Zero && aquamentus.location.X - KeyBoardController.linkSprite.attack.greenArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.greenArrow.currentX - aquamentus.location.X >= 0 && KeyBoardController.linkSprite.attack.greenArrow.currentX - aquamentus.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        aquamentusGreenArrowCollision.Update(aquamentus);
                    }
                }
            }
        }
    }
}
