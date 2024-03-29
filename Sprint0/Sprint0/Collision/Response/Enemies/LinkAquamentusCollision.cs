﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Enemies
{
    public class LinkAquamentusCollision
    {
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle enemyRectangle;
        private LinkHP linkHP;
        private Game1 game;
        public LinkAquamentusCollision(KeyBoardController KeyBoardController, Link link, Game1 game)
        {
            this.link = link;
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            linkHP = game.linkHealth;
        }

        public void Update(Aquamentus aquamentus)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.Size * GameConstants.Sizing);
            enemyRectangle = new Rectangle((int)aquamentus.GetLocation().X, (int)aquamentus.GetLocation().Y, (int)aquamentus.GetSize().X, (int)aquamentus.GetSize().Y);

            if (!aquamentus.death && enemyRectangle.Intersects(linkRectangle))
            {
                if (game.linkHealth.health > GameConstants.One)
                    game.soundEffects.PlaySound("LinkHurt");
                if (linkHP.health > GameConstants.Zero)
                {
                    linkHP.health--;
                    link.invisibilityFrames = 10;
                }
                link.UpdateDirection(KeyBoardController.dir);
                link.UpdateSprite(LinkConstants.Damage);
                link.velocity = GameConstants.Zero;
            }
            else
            {
                link.UpdateSprite(LinkConstants.Default);
                link.velocity = LinkConstants.Velocity;
            }
        }
    }
}
