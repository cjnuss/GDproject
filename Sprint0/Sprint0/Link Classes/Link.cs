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

        private int currentSprite = LinkConstants.Default;
        public Vector2 location;
        public float velocity = LinkConstants.Velocity;

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
            location = new Vector2(LinkConstants.InitialX, LinkConstants.InitialY);

            linkLooking = new LinkLooking();
            linkMoving = new LinkMoving();
            linkDamaged = new LinkDamaged();
            linkAttacking = new LinkAttacking();
            linkThrowing = new LinkThrowing();

            greenArrow = new GreenArrow();
            fire = new Fire();
            bomb = new Bomb();
            blueArrow = new BlueArrow();
            swordBeam = new SwordBeam();

            sprites = new ILinkSprite[] {linkLooking, linkMoving, linkDamaged, linkAttacking, linkThrowing};
            attack = new Attack(linkAttacking, greenArrow, fire, bomb, blueArrow, swordBeam);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch, location);
            attack.Draw(spriteBatch, location);
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            UpdateDirection(dir);
            currentSprite = UpdateSprite(linkState);
            linkMoving.Update();
            attack.Update(linkState, ref currentSprite, dir, location);
        }

        public int UpdateSprite(int linkState)
        {
            if (linkState == LinkConstants.GreenArrow || linkState == LinkConstants.Fire ||
                    linkState == LinkConstants.Bomb || linkState == LinkConstants.BlueArrow)
                return LinkConstants.Throwing;
            else if (linkState != LinkConstants.SwordBeam)
                return linkState;
            else
                return GameConstants.Zero;
        }

        public void UpdateDirection(int dir)
        {
            // dir adjustments
            linkLooking.direction = dir;
            linkMoving.direction = dir;
            //linkAttacking.direction = dir;
            linkThrowing.direction = dir;
        }
    }
}
