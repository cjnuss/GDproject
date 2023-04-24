using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Enemies;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class GoriyaBombCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GoriyaBombCollision goriyaBombCollision;
        private Game1 game;
        private Goriya goriya;

        public GoriyaBombCollisionCheck(KeyBoardController KeyBoardController, GoriyaBombCollision goriyaBombCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.goriyaBombCollision = new GoriyaBombCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Goriya))
                {
                    goriya = (Goriya)enemy;
                    if (goriya.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X >= GameConstants.Zero && goriya.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X <=
                        ItemConstants.BombWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.bomb.location1.X - goriya.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.bomb.location1.X - goriya.location.X <= ItemConstants.BombWidth * GameConstants.Sizing)
                    {
                        goriyaBombCollision.Update(goriya);
                    }
                }
            }
        }
    }
}
