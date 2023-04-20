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
    public class BatSwordBeamCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private BatSwordBeamCollision batSwordBeamCollision;
        private Game1 game;
        private Link link;
        private Bat bat;

        public BatSwordBeamCollisionCheck(KeyBoardController KeyBoardController, BatSwordBeamCollision batSwordBeamCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.batSwordBeamCollision = new BatSwordBeamCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Bat))
                {
                    bat = (Bat)enemy;
                    if (bat.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX >= GameConstants.Zero && bat.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX <=
                        LinkConstants.SwordBeamWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.swordBeam.currentX - bat.location.X >= 0 && KeyBoardController.linkSprite.attack.swordBeam.currentX - bat.location.X <= LinkConstants.SwordBeamWidth * GameConstants.Sizing)
                    {
                        batSwordBeamCollision.Update(bat);
                    }
                }
            }
        }
    }
}
