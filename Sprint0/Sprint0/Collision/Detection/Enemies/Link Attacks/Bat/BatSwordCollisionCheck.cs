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
    public class BatSwordCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private BatSwordCollision batSwordCollision;
        private Game1 game;
        private Link link;
        private Bat bat;

        public BatSwordCollisionCheck(KeyBoardController KeyBoardController, BatSwordCollision batSwordCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.batSwordCollision = new BatSwordCollision(this.game, this.KeyBoardController, this.link);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Bat))
                {
                    bat = (Bat)enemy;
                    if (bat.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && bat.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - bat.location.X >= 0 && KeyBoardController.linkSprite.location.X - bat.location.X <= LinkConstants.Size * GameConstants.Sizing)
                    {
                        return batSwordCollision.Update(bat);
                    }
                }
            }

            return null;
        }
    }
}
