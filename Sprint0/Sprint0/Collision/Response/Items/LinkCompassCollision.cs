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
    public class LinkCompassCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle compassRectangle;
        private LinkItems linkItems;
        public LinkCompassCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkItems = game.linkItems;
        }

        public void Update(Compass compass)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            compassRectangle = new Rectangle((int)compass.location.X, (int)compass.location.Y, ItemConstants.CompassWidth * GameConstants.Sizing, ItemConstants.CompassHeight * GameConstants.Sizing);

            if (compassRectangle.Intersects(linkRectangle))
            {
                compass.Dispose();
                game.soundEffects.PlaySound("GetItem");
                linkItems.compass = true;
            }
        }
    }
}
