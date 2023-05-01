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
    public class AquamentusBombCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private AquamentusBombCollision aquamentusBombCollision;
        private Game1 game;
        private Aquamentus aquamentus;

        public AquamentusBombCollisionCheck(KeyBoardController KeyBoardController, AquamentusBombCollision aqwuamentusBombCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.aquamentusBombCollision = new AquamentusBombCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Aquamentus))
                {
                    aquamentus = (Aquamentus)enemy;
                    if (aquamentus.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X >= GameConstants.Zero && aquamentus.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X <=
                        ItemConstants.BombWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.bomb.location1.X - aquamentus.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.bomb.location1.X - aquamentus.location.X <= ItemConstants.BombWidth * GameConstants.Sizing)
                    {
                        return aquamentusBombCollision.Update(aquamentus);
                    }
                }
            }

            return null;
        }
    }
}
