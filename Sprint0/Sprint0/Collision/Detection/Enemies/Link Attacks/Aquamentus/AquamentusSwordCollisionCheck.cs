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
    public class AquamentusSwordCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private AquamentusSwordCollision aquamentusSwordCollision;
        private Game1 game;
        private Link link;
        private Aquamentus aquamentus;

        public AquamentusSwordCollisionCheck(KeyBoardController KeyBoardController, AquamentusSwordCollision aquamentusSwordCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.aquamentusSwordCollision = new AquamentusSwordCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Aquamentus))
                {
                    aquamentus = (Aquamentus)enemy;
                    if (aquamentus.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && aquamentus.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - aquamentus.location.X >= 0 && KeyBoardController.linkSprite.location.X - aquamentus.location.X <= LinkConstants.Size * GameConstants.Sizing)
                    {
                        aquamentusSwordCollision.Update(aquamentus);
                    }
                }
            }
        }
    }
}
