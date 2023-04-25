using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using Sprint0.Link_Classes.Item_Usage;
using Sprint0.UI;
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
        private Game1 game;

        private int currentSprite = LinkConstants.Default;
        public Vector2 location;
        public float velocity = LinkConstants.Velocity;
        public int damageCounter { get; set; }

        public Attack attack; // debug - public?

        private LinkLooking linkLooking;
        private LinkMoving linkMoving;
        private LinkDamaged linkDamaged;
        public LinkAttacking linkAttacking; // debug - public?
        private LinkThrowing linkThrowing;

        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;
        private BlueArrow blueArrow;
        private SwordBeam swordBeam;

        private ILinkSprite[] sprites;
        public LinkItems linkItems;
        private Counts itemCounts;

        private int linkDirection;
        public Link(Game1 game)
        {
            this.game = game;
            location = new Vector2(LinkConstants.InitialX, LinkConstants.InitialY);

            linkLooking = new LinkLooking();
            linkMoving = new LinkMoving();
            linkDamaged = new LinkDamaged();
            linkAttacking = new LinkAttacking();
            linkThrowing = new LinkThrowing();

            greenArrow = new GreenArrow();
            fire = new Fire();
            bomb = new Bomb(game);
            blueArrow = new BlueArrow();
            swordBeam = new SwordBeam();

            sprites = new ILinkSprite[] {linkLooking, linkMoving, linkDamaged, linkAttacking, linkThrowing};
            attack = new Attack(game, linkAttacking, greenArrow, fire, bomb, blueArrow, swordBeam);

            linkItems = new LinkItems();
            itemCounts = new Counts(this.game, linkItems);

            damageCounter = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch, location);
            attack.Draw(spriteBatch, location);
            //itemCounts.Draw(spriteBatch);
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            if(damageCounter == 0)
            {
                UpdateDirection(dir);
                currentSprite = UpdateSprite(linkState);
                linkMoving.Update();
                attack.Update(linkState, ref currentSprite, dir, location);
            } else
            {
                damageCounter--;
                currentSprite = LinkConstants.Damage;
                if (linkDirection == GameConstants.Left)
                    this.location.X = this.location.X + 10;
                else if (linkDirection == GameConstants.Right)
                    this.location.X = this.location.X - 10;
                else if (linkDirection == GameConstants.Up)
                    this.location.Y = this.location.Y + 10;
                else if (linkDirection == GameConstants.Down)
                    this.location.Y = this.location.Y - 10;
            }
        }

        public int UpdateSprite(int linkState)
        {
            if (linkState == LinkConstants.Damage && damageCounter == 0)
            {
                damageCounter = 10;
                return linkState;
            }
            else if (linkState == LinkConstants.GreenArrow || linkState == LinkConstants.Fire ||
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

            linkDirection = dir;
        }
    }
}
