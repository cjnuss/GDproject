﻿using Microsoft.Xna.Framework;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // throw green arrow
    public class LinkThrowGreenArrowCommand : ICommand
    {
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowGreenArrowCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.GreenArrow;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
        }
    }
}