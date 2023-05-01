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
    public class AquamentusSwordBeamCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private AquamentusSwordBeamCollision aquamentusSwordBeamCollision;
        private Game1 game;
        private Link link;
        private Aquamentus aquamentus;

        public AquamentusSwordBeamCollisionCheck(KeyBoardController KeyBoardController, AquamentusSwordBeamCollision aquamentusSwordBeamCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.aquamentusSwordBeamCollision = new AquamentusSwordBeamCollision(this.game, this.KeyBoardController, this.link);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Aquamentus))
                {
                    aquamentus = (Aquamentus)enemy;
                    if (aquamentus.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX >= GameConstants.Zero && aquamentus.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX <=
                        LinkConstants.SwordBeamWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.swordBeam.currentX - aquamentus.location.X >= 0 && KeyBoardController.linkSprite.attack.swordBeam.currentX - aquamentus.location.X <= LinkConstants.SwordBeamWidth * GameConstants.Sizing)
                    {
                        return aquamentusSwordBeamCollision.Update(aquamentus);
                    }
                }
            }

            return null;
        }
    }
}
