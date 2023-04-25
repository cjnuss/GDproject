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
    public class LinkBowCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle bowRectangle;
        private LinkItems linkItems;
        public LinkBowCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkItems = game.linkItems;
        }

        public void Update(Bow bow)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            bowRectangle = new Rectangle((int)bow.location.X, (int)bow.location.Y, ItemConstants.BowWidth * GameConstants.Sizing, ItemConstants.BowHeight * GameConstants.Sizing);

            if (bowRectangle.Intersects(linkRectangle))
            {
                bow.Dispose();
                game.soundEffects.PlaySound("GetItem");
                linkItems.clock = true;
            }
        }
    }
}
