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
    public class BatFireCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private BatFireCollision batFireCollision;
        private Game1 game;
        private Bat bat;

        public BatFireCollisionCheck(KeyBoardController KeyBoardController, BatFireCollision batFireCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.batFireCollision = new BatFireCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Bat))
                {
                    bat = (Bat)enemy;
                    if (bat.location.X - (int)KeyBoardController.linkSprite.attack.fire.currentX >= GameConstants.Zero && bat.location.X - (int)KeyBoardController.linkSprite.attack.fire.currentX <=
                        ItemConstants.FireWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.fire.currentX - bat.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.fire.currentX - bat.location.X <= ItemConstants.FireWidth * GameConstants.Sizing)
                    {
                        return batFireCollision.Update(bat);
                    }
                }
            }

            return null;
        }
    }
}