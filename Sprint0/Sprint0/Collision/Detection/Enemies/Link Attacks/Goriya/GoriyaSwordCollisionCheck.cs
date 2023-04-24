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
    public class GoriyaSwordCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GoriyaSwordCollision goriyaSwordCollision;
        private Game1 game;
        private Link link;
        private Goriya goriya;

        public GoriyaSwordCollisionCheck(KeyBoardController KeyBoardController, GoriyaSwordCollision goriyaSwordCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.goriyaSwordCollision = new GoriyaSwordCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Goriya))
                {
                    goriya = (Goriya)enemy;
                    if (goriya.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && goriya.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - goriya.location.X >= 0 && KeyBoardController.linkSprite.location.X - goriya.location.X <= LinkConstants.Size * GameConstants.Sizing)
                    {
                        goriyaSwordCollision.Update(goriya);
                    }
                }
            }
        }
    }
}
