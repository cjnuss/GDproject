﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sprint0
{
    public class Link : ILink
    {
        private Game1 game1;

        private int currentSprite = 0;
        public Vector2 location;
        public float velocity = 100f;

        private LinkLooking linkLooking;
        private LinkMoving linkMoving;
        private LinkDamaged linkDamaged;
        private LinkAttacking linkAttacking;
        private LinkThrowing linkThrowing;
        // rest of them

        private ILinkSprite[] sprites;

        public Link(Game1 game1)
        {
            this.game1 = game1;
            location = new Vector2(200, 100); // debug: magic number initial location
            linkLooking = new LinkLooking();
            linkMoving = new LinkMoving();
            linkDamaged = new LinkDamaged();
            linkAttacking = new LinkAttacking();
            linkThrowing = new LinkThrowing();
            // rest of them

            sprites = new ILinkSprite[]
            {
                linkLooking,
                linkMoving,
                linkDamaged,
                linkAttacking,
                linkThrowing
                // rest of them
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch, location);
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            // dir adjustments
            linkLooking.direction = dir;
            linkMoving.direction = dir;
            //linkDamaged.direction = dir;
            linkAttacking.direction = dir;
            linkThrowing.direction = dir;

            // loc adjustments
            linkThrowing.location1 = location;

            // update currentSprite: stationary, 0; moving, 1; damaged, 2; attacking, 3; throwing, 4
            currentSprite = linkState;

            if (currentSprite == 5)
                currentSprite--;

            if (linkState == 1)
                linkMoving.Update();
            if (linkState == 2)
                linkDamaged.Update();
            if (linkState == 3)
                linkAttacking.Update();
            if (linkState == 4)
            {
                linkThrowing.arrowBool = true;
                linkThrowing.fireBool = false;
                linkThrowing.bombBool = false;
                //linkThrowing.Update();
            }
            if (linkState == 5)
            {
                linkThrowing.fireBool = true;
                linkThrowing.arrowBool = false;
                linkThrowing.bombBool = false;
                //linkThrowing.Update();
            }
            if (linkState == 6)
            {
                linkThrowing.bombBool = true;
                linkThrowing.arrowBool = false;
                linkThrowing.fireBool = false;
                //linkThrowing.Update();
            }
            // DEBUG: update fixed directional issue
            linkThrowing.Update();

            // update currentSprite: stationary, 0; moving, 1; damaged, 2; attacking, 3; throwing, 4
            if (linkState < 5)
                currentSprite = linkState;
            else
                currentSprite = 4;
        }
    }
}
