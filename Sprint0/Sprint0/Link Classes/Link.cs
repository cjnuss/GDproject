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
    //static class LinkConstants
    //{
    //    public const int InitialX = 200;
    //    public const int InitialY = 100;
    //    public const int Looking = 0;
    //    public const int Moving = 1;
    //    public const int Damaged = 2;
    //    public const int Attacking = 3;
    //    public const int Throwing = 4;
    //}

    public class Link : ILink
    {
        private Game1 game1;

        private int currentSprite = LinkConstants.Default;
        public Vector2 location;
        public float velocity = LinkConstants.Velocity;

        private bool attackKey = false, arrowKey = false, fireKey = false, bombKey = false, blueArrowKey = false;
        private bool swordBeamKey = false;

        private Attack attack;

        private LinkLooking linkLooking;
        private LinkMoving linkMoving;
        private LinkDamaged linkDamaged;
        private LinkAttacking linkAttacking;
        private LinkThrowing linkThrowing;

        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;
        private BlueArrow blueArrow;
        private SwordBeam swordBeam;

        private ILinkSprite[] sprites;

        public Link(Game1 game1)
        {
            this.game1 = game1;
            location = new Vector2(LinkConstants.InitialX, LinkConstants.InitialY); // debug: magic number initial location

            // link states
            linkLooking = new LinkLooking();
            linkMoving = new LinkMoving();
            linkDamaged = new LinkDamaged();
            linkAttacking = new LinkAttacking();
            linkThrowing = new LinkThrowing();

            // link attacks
            greenArrow = new GreenArrow();
            fire = new Fire();
            bomb = new Bomb();
            blueArrow = new BlueArrow();
            swordBeam = new SwordBeam();

            sprites = new ILinkSprite[] {linkLooking, linkMoving, linkDamaged, linkAttacking, linkThrowing};

            attack = new Attack(greenArrow, fire, bomb, blueArrow);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch, location);
            attack.Draw(spriteBatch, location, ref arrowKey, ref fireKey, ref bombKey, ref blueArrowKey);

            if (swordBeamKey || swordBeam.explodeKey) swordBeam.Draw(spriteBatch);
            if (!swordBeam.toDraw) swordBeamKey = false;
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            // dir adjustments
            linkLooking.direction = dir;
            linkMoving.direction = dir;
            //linkAttacking.direction = dir;
            linkThrowing.direction = dir;

            // update currentSprite
            if (linkState == LinkConstants.GreenArrow || linkState == LinkConstants.Fire || 
                linkState == LinkConstants.Bomb|| linkState == LinkConstants.BlueArrow)
                currentSprite = LinkConstants.Throwing;
            else if (linkState != LinkConstants.SwordBeam)
                currentSprite = linkState;

            // update movement state
            linkMoving.Update();

            // update attack state
            if ((linkState == LinkConstants.WoodenSword || linkState == LinkConstants.SwordBeam) && !attackKey)
            {
                linkAttacking.toDraw = true;
                attackKey = true;
                linkAttacking.direction = dir;
            }
            if (attackKey)
            {
                currentSprite = LinkConstants.Attacking;
                linkAttacking.Update();
            }
            if (!linkAttacking.toDraw)
                attackKey = false;

            // sword beam checks 
            if (linkState == LinkConstants.SwordBeam && !swordBeamKey)
            {
                swordBeamKey = true;
                swordBeam = new SwordBeam();
                swordBeam.direction = dir;
            }
            if (swordBeamKey && linkAttacking.frame == LinkConstants.PeakAnimation)
            {
                swordBeam.toDraw = true;
                swordBeam.RegisterPos(location);
            }

            // update attack item states
            attack.Update(linkState, dir, location, ref arrowKey, ref fireKey, ref bombKey, ref blueArrowKey);
            swordBeam.Update();
        }
    }
}
