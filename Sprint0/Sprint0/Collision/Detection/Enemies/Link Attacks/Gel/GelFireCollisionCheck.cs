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
    public class GelFireCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GelFireCollision gelFireCollision;
        private Game1 game;
        private Gel gel;

        public GelFireCollisionCheck(KeyBoardController KeyBoardController, GelFireCollision gelFireCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.gelFireCollision = new GelFireCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Gel))
                {
                    gel = (Gel)enemy;
                    if (gel.location.X - (int)KeyBoardController.linkSprite.attack.fire.currentX >= GameConstants.Zero && gel.location.X - (int)KeyBoardController.linkSprite.attack.fire.currentX <=
                        ItemConstants.FireWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.fire.currentX - gel.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.fire.currentX - gel.location.X <= ItemConstants.FireWidth * GameConstants.Sizing)
                    {
                        gelFireCollision.Update(gel);
                    }
                }
            }
        }
    }
}