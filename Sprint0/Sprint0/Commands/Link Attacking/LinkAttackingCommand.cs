using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // sword attack
    public class LinkAttackingCommand : ICommand
    {
        private Link link;
        private LinkAttacking linkAttacking;
        private KeyBoardController KeyBoardController;

        public LinkAttackingCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkAttacking = new LinkAttacking();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = 3; // attacking sprites
        }
    }
}
