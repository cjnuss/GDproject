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
    public class BatSwordCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle batRectangle;

        public BatSwordCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Bat bat)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            batRectangle = new Rectangle((int)bat.location.X, (int)bat.location.Y, EnemyConstants.BatSize * GameConstants.Sizing, EnemyConstants.BatSize * GameConstants.Sizing);

            if (batRectangle.Intersects(linkRectangle) && KeyBoardController.linkState == LinkConstants.WoodenSword)
            {
                bat.location = new Vector2(GameConstants.Zero, GameConstants.Zero);
                bat.toDraw = false;
                // DEBUG : HURT?
                game.soundEffects.LoadSound(game, "EnemyDie", "enemydie");
                if (!game.soundEffects.IsPlaying("EnemyDie"))
                {
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
