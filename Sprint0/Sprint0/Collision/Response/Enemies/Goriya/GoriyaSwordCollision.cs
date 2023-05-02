using Microsoft.Xna.Framework;
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
    public class GoriyaSwordCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle goriyaRectangle;

        public GoriyaSwordCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Goriya goriya)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            goriyaRectangle = new Rectangle((int)goriya.location.X, (int)goriya.location.Y, EnemyConstants.GoriyaSize * GameConstants.Sizing, EnemyConstants.GoriyaSize * GameConstants.Sizing);

            if (!goriya.death && goriyaRectangle.Intersects(linkRectangle) && KeyBoardController.linkState == LinkConstants.WoodenSword)
            {
                if (goriya.hits < EnemyConstants.GoriyaHP)
                {
                    if (!goriya.hit)
                        goriya.Hit(KeyBoardController.dir);

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
