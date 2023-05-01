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
    public class AquamentusFireCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private AquamentusFireCollision aquamentusFireCollision;
        private Game1 game;
        private Aquamentus aquamentus;

        public AquamentusFireCollisionCheck(KeyBoardController KeyBoardController, AquamentusFireCollision aquamentusFireCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.aquamentusFireCollision = aquamentusFireCollision;
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Aquamentus))
                {
                    aquamentus = (Aquamentus)enemy;
                    if (aquamentus.location.X - KeyBoardController.linkSprite.attack.fire.currentX >= GameConstants.Zero && aquamentus.location.X - KeyBoardController.linkSprite.attack.fire.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.fire.currentX - aquamentus.location.X >= 0 && KeyBoardController.linkSprite.attack.fire.currentX - aquamentus.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        aquamentusFireCollision.Update(aquamentus);
                    }
                }
            }
        }
    }
}
