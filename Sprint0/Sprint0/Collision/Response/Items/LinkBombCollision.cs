using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Items
{
    public class LinkBombCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle bombRectangle;

        public LinkBombCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(BombItem bomb)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            bombRectangle = new Rectangle((int)bomb.location.X, (int)bomb.location.Y, ItemConstants.BombWidth * GameConstants.Sizing, ItemConstants.BombHeight * GameConstants.Sizing);

            if (bombRectangle.Intersects(linkRectangle))
            {
                bomb.location = new Vector2(GameConstants.Zero, GameConstants.Zero);
                bomb.Dispose();         
                if (!game.soundEffects.IsPlaying("GetItem"))
                {
                    game.soundEffects.PlaySound("GetItem");
                }
            }
        }
    }
}
