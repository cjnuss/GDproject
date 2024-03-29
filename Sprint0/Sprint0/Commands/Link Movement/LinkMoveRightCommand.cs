﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkMoveRightCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveRightCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = GameConstants.Right;
            KeyBoardController.linkState = LinkConstants.Movement; // moving sprite
            KeyBoardController.linkSprite.location.X += link.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
