using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class LinkHeartCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle heartRectangle;
        private LinkItems linkItems;
        public LinkHeartCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkItems = game.linkItems;
        }

        public void Update(Heart heart)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            heartRectangle = new Rectangle((int)heart.location.X, (int)heart.location.Y, ItemConstants.HeartWidth * GameConstants.Sizing, ItemConstants.HeartHeight * GameConstants.Sizing);

            if (heartRectangle.Intersects(linkRectangle))
            {
                heart.Dispose();
                game.soundEffects.PlaySound("GetHeartOrKey");
                linkItems.heart++;
            }
        }
    }
}
