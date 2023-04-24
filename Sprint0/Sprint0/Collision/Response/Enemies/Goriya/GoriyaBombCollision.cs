using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Enemies
{
    public class GoriyaBombCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle bombRectangle;
        private Rectangle goriyaRectangle;

        public GoriyaBombCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
        }

        public void Update(Goriya goriya)
        {
            bombRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.bomb.location1.X, (int)KeyBoardController.linkSprite.attack.bomb.location1.Y, ItemConstants.BombWidth * GameConstants.Sizing, ItemConstants.BombHeight * GameConstants.Sizing);
            goriyaRectangle = new Rectangle((int)goriya.location.X, (int)goriya.location.Y, EnemyConstants.GoriyaSize * GameConstants.Sizing, EnemyConstants.GoriyaSize * GameConstants.Sizing);

            if (goriyaRectangle.Intersects(bombRectangle) && KeyBoardController.linkSprite.attack.bomb.frame == GameConstants.Two && KeyBoardController.linkSprite.attack.bomb.toDraw)
            {
                if (goriya.hits < EnemyConstants.GoriyaHP)
                {
                    if (!goriya.hit)
                        goriya.Hit(KeyBoardController.linkSprite.attack.bomb.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    goriya.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
