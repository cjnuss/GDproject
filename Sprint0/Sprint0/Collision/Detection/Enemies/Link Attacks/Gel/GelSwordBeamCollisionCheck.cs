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
    public class GelSwordBeamCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GelSwordBeamCollision gelSwordBeamCollision;
        private Game1 game;
        private Link link;
        private Gel gel;

        public GelSwordBeamCollisionCheck(KeyBoardController KeyBoardController, GelSwordBeamCollision gelSwordBeamCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.gelSwordBeamCollision = new GelSwordBeamCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Gel))
                {
                    gel = (Gel)enemy;
                    if (gel.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX >= GameConstants.Zero && gel.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX <=
                        LinkConstants.SwordBeamWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.swordBeam.currentX - gel.location.X >= 0 && KeyBoardController.linkSprite.attack.swordBeam.currentX - gel.location.X <= LinkConstants.SwordBeamWidth * GameConstants.Sizing)
                    {
                        gelSwordBeamCollision.Update(gel);
                    }
                }
            }
        }
    }
}
