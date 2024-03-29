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
    public class LinkKeyCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle keyRectangle;
        private LinkItems linkItems;

        public LinkKeyCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkItems = game.linkItems;
        }

        public void Update(Key key)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            keyRectangle = new Rectangle((int)key.location.X, (int)key.location.Y, ItemConstants.KeyWidth * GameConstants.Sizing, ItemConstants.KeyHeight * GameConstants.Sizing);

            if (keyRectangle.Intersects(linkRectangle))
            {
                key.Dispose();
                game.soundEffects.PlaySound("GetHeartOrKey");
                linkItems.increaseKey();
            }
        }
    }
}
