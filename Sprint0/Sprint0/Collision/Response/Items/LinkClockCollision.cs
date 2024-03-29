﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Items
{
    public class LinkClockCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle clockRectangle;
        private LinkItems linkItems;

        public LinkClockCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkItems = game.linkItems;

        }

        public void Update(Clock clock)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            clockRectangle = new Rectangle((int)clock.location.X, (int)clock.location.Y, ItemConstants.ClockWidth * GameConstants.Sizing, ItemConstants.ClockHeight * GameConstants.Sizing);

            if (clockRectangle.Intersects(linkRectangle))
            {
                clock.Dispose();
                game.soundEffects.PlaySound("GetItem");
                linkItems.clock = true;
            }
        }
    }
}
