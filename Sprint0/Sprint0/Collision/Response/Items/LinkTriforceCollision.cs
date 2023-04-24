using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Items
{
    public class LinkTriforceCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle triforceRectangle;

        public LinkTriforceCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Triforce triforce)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            triforceRectangle = new Rectangle((int)triforce.location.X, (int)triforce.location.Y, ItemConstants.TriforceWidth * GameConstants.Sizing, ItemConstants.TriforceHeight * GameConstants.Sizing);

            if (triforceRectangle.Intersects(linkRectangle))
            {
                triforce.Dispose();
                game.backgroundAudio.StopSound();
                game.soundEffects.PlaySound("Triforce");
                game.win = true;
            }
        }
    }
}
