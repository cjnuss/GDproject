using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // link taking damage
    public class LinkDamageCommand : ICommand
    {
        private Link link;
        private LinkDamaged linkDamaged;
        private KeyBoardController KeyBoardController;

        public LinkDamageCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkDamaged = new LinkDamaged();
        }

        public void Execute(GameTime gameTime)
        {
            // no direction change necessary
            KeyBoardController.linkState = 2; // non-moving sprite
        }
    }
}
