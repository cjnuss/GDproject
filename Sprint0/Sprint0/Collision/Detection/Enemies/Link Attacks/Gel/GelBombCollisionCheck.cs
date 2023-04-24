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
    public class GelBombCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GelBombCollision gelBombCollision;
        private Game1 game;
        private Gel gel;

        public GelBombCollisionCheck(KeyBoardController KeyBoardController, GelBombCollision gelBombCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.gelBombCollision = new GelBombCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Gel))
                {
                    gel = (Gel)enemy;
                    if (gel.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X >= GameConstants.Zero && gel.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X <=
                        ItemConstants.BombWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.bomb.location1.X - gel.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.bomb.location1.X - gel.location.X <= ItemConstants.BombWidth * GameConstants.Sizing)
                    {
                        gelBombCollision.Update(gel);
                    }
                }
            }
        }
    }
}
