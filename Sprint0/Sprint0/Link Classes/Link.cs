using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using Sprint0.Link_Classes.Item_Usage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        private bool arrowKey = false, fireKey = false, bombKey = false;

        private LinkLooking linkLooking;
        private LinkMoving linkMoving;
        private LinkDamaged linkDamaged;
        private LinkAttacking linkAttacking;
        private LinkThrowing linkThrowing;
        // rest of them

        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;

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

            greenArrow = new GreenArrow();
            fire = new Fire();
            bomb = new Bomb();

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

            if (arrowKey) greenArrow.Draw(spriteBatch);
            if (fireKey) fire.Draw(spriteBatch);
            if (bombKey) bomb.Draw(spriteBatch);

            if (!greenArrow.toDraw) arrowKey = false;
            if (!fire.toDraw) fireKey = false;
            if (!bomb.toDraw) bombKey = false; // error: draws forever
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            // dir adjustments
            linkLooking.direction = dir; linkMoving.direction = dir; linkAttacking.direction = dir; linkThrowing.direction = dir;
            //linkDamaged.direction = dir;

            // loc adjustments
            //linkThrowing.location1 = location;

            // update currentSprite: stationary, 0; moving, 1; damaged, 2; attacking, 3; throwing, 4 and beyond
            if (linkState >= 5)
                currentSprite = 4;
            else
                currentSprite = linkState;

            // update linkStates
            linkLooking.Update(); linkMoving.Update(); linkAttacking.Update(); linkThrowing.Update();

            // projectile setup
            if (linkState == 4 && !arrowKey)
            {
                greenArrow = new GreenArrow();
                arrowKey = true;
                greenArrow.direction = dir;
                greenArrow.RegisterPos(location);
            }
            if (linkState == 5 && !fireKey)
            {
                fire = new Fire();
                fireKey = true;
                fire.direction = dir;
                fire.RegisterPos(location);
            }
            if (linkState == 6 && !bombKey)
            {
                bomb = new Bomb();
                bombKey = true;
                bomb.direction = dir;
                bomb.UpdatePos(location);
            }

            if (arrowKey)
                greenArrow.Update();
            if (fireKey)
                fire.Update();
            if (bombKey)
                bomb.Update();

            //if (currentSprite == 5)
            //    currentSprite--;

            //if (linkState == 1)
            //    linkMoving.Update();
            //if (linkState == 2)
            //    linkDamaged.Update();
            //if (linkState == 3)
            //    linkAttacking.Update();
            //if (linkState == 4)
            //{
            //    linkThrowing.arrowBool = true; linkThrowing.fireBool = false; linkThrowing.bombBool = false;
            //    //linkThrowing.Update();
            //}
            //if (linkState == 5)
            //{
            //    linkThrowing.fireBool = true; linkThrowing.arrowBool = false; linkThrowing.bombBool = false;
            //    //linkThrowing.Update();
            //}
            //if (linkState == 6)
            //{
            //    linkThrowing.bombBool = true; linkThrowing.arrowBool = false; linkThrowing.fireBool = false;
            //    //linkThrowing.Update();
            //}
            // DEBUG: update fixed directional issue
            //linkThrowing.Update();

            // update currentSprite: stationary, 0; moving, 1; damaged, 2; attacking, 3; throwing, 4
            //if (linkState < 5)
            //    currentSprite = linkState;
            //else
            //    currentSprite = 4;
        }
    }
}
