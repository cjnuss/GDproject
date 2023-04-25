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
    public class LinkArrowCollision
    {
        private Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle arrowRectangle;
        private LinkItems linkItems;

        public LinkArrowCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkItems = game.linkItems;

        }

        public void Update(Arrow arrow)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            arrowRectangle = new Rectangle((int)arrow.location.X, (int)arrow.location.Y, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            if (arrowRectangle.Intersects(linkRectangle))
            { 
                arrow.Dispose();
                // if sound is playing, stop it, start new?
                game.soundEffects.PlaySound("GetItem");
                linkItems.arrow = true;
            }
        }
    }
}
