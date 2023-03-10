using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkMoveLeftCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveLeftCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = 1;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.X -= link.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds; // update with speed later     
        }
    }
}
