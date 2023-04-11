﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkMapCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle mapRectangle;
        private bool playSound = true;

        public LinkMapCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Map map)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            mapRectangle = new Rectangle((int)map.location.X, (int)map.location.Y, ItemConstants.MapWidth * GameConstants.Sizing, ItemConstants.MapHeight * GameConstants.Sizing);

            if (mapRectangle.Intersects(linkRectangle))
            {
                map.Dispose();
                game.soundEffects.LoadSound(game, "GetItem", "getitem");
                if (!game.soundEffects.IsPlaying("GetItem") && playSound)
                {
                    game.soundEffects.PlaySound("GetItem");
                    playSound = false;
                }
            }
        }
    }
}
