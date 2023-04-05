using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprint0
{
    public class LinkThrowBombCommand : ICommand
    {
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowBombCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.Bomb;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
        }
    }
}
