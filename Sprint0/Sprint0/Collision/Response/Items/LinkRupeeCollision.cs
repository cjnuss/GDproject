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
    public class LinkRupeeCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle rupeeRectangle;

        public LinkRupeeCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Rupee rupee)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            rupeeRectangle = new Rectangle((int)rupee.location.X, (int)rupee.location.Y, ItemConstants.ArrowWidth * GameConstants.Sizing, ItemConstants.ArrowHeight * GameConstants.Sizing);

            if (rupeeRectangle.Intersects(linkRectangle))
            {
                rupee.location = new Vector2(GameConstants.Zero, GameConstants.Zero);
                rupee.Dispose();
                game.soundEffects.LoadSound(game, "GetRupee", "getrupee");
                if (!game.soundEffects.IsPlaying("GetRupee"))
                {
                    game.soundEffects.PlaySound("GetRupee");
                }
            }
        }
    }
}
