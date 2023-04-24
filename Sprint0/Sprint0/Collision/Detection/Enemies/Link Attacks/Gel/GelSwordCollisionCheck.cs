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
    public class GelSwordCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GelSwordCollision gelSwordCollision;
        private Game1 game;
        private Link link;
        private Gel gel;

        public GelSwordCollisionCheck(KeyBoardController KeyBoardController, GelSwordCollision gelSwordCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.gelSwordCollision = new GelSwordCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Gel))
                {
                    gel = (Gel)enemy;
                    if (gel.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && gel.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - gel.location.X >= 0 && KeyBoardController.linkSprite.location.X - gel.location.X <= LinkConstants.Size * GameConstants.Sizing)
                    {
                        gelSwordCollision.Update(gel);
                    }
                }
            }
        }
    }
}
