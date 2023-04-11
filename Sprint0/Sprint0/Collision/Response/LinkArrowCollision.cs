using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkArrowCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle arrowRectangle;

        public LinkArrowCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Arrow arrow)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            arrowRectangle = new Rectangle((int)arrow.location.X, (int)arrow.location.Y, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            if (arrowRectangle.Intersects(linkRectangle))
            {
                arrow.Dispose();
                game.soundEffects.LoadSound(game, "GetItem", "getitem");
                if (!game.soundEffects.IsPlaying("GetItem"))
                {
                    game.soundEffects.PlaySound("GetItem");
                }
            }
        }
    }
}
