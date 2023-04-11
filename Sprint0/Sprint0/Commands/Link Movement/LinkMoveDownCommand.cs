using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkMoveDownCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveDownCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = GameConstants.Down;
            KeyBoardController.linkState = LinkConstants.Movement;
            KeyBoardController.linkSprite.location.Y += link.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
