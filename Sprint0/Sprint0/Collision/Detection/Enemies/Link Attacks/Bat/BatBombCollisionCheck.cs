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
    public class BatBombCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private BatBombCollision batBombCollision;
        private Game1 game;
        private Bat bat;

        public BatBombCollisionCheck(KeyBoardController KeyBoardController, BatBombCollision batBmobCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.batBombCollision = new BatBombCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Bat))
                {
                    bat = (Bat)enemy;
                    if (bat.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X >= GameConstants.Zero && bat.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X <=
                        ItemConstants.BombWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.bomb.location1.X - bat.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.bomb.location1.X - bat.location.X <= ItemConstants.BombWidth * GameConstants.Sizing)
                    {
                        batBombCollision.Update(bat);
                    }
                }
            }
        }
    }
}
