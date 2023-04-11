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
    public class LinkFairyCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle fairyRectangle;
        private bool playSound = true;

        public LinkFairyCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Fairy fairy)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            fairyRectangle = new Rectangle((int)fairy.location.X, (int)fairy.location.Y, ItemConstants.FairyWidth * GameConstants.Sizing, ItemConstants.FairyHeight * GameConstants.Sizing);

            if (fairyRectangle.Intersects(linkRectangle))
            {
                fairy.Dispose();
                game.soundEffects.LoadSound(game, "GetFairy", "getitem");
                if (!game.soundEffects.IsPlaying("GetFairy") && playSound)
                {
                    game.soundEffects.PlaySound("GetFairy");
                    playSound = false;
                }
            }
        }
    }
}
