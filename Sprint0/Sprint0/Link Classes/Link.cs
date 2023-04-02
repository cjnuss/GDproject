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

        private int currentSprite = 0; // default looking sprite
        public Vector2 location;
        public float velocity = 100f; // magic

        private bool attackKey = false, arrowKey = false, fireKey = false, bombKey = false, blueArrowKey = false;
        private int swordBeamKey = 0; // (0) initial, (1) draw, (2) don't draw

        private AttackSequence attackSequence;

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
            location = new Vector2(200, 100); // debug: magic number initial location

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

            attackSequence = new AttackSequence(greenArrow, fire, bomb, blueArrow);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch, location);
            attackSequence.DrawAttack(spriteBatch, location, ref arrowKey, ref fireKey, ref bombKey, ref blueArrowKey);

            swordBeam.Draw(spriteBatch);
            if (!swordBeam.toDraw) swordBeamKey = 1;
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            // dir adjustments
            linkLooking.direction = dir;
            linkMoving.direction = dir;
            //linkAttacking.direction = dir;
            linkThrowing.direction = dir;

            // update currentSprite: (0) looking; (1) moving; (2)damaged; (3) attacking; (4) throwing
            if (linkState == 5 || linkState == 6 || linkState == 7) // throwing fire, bomb, blue arrow
                currentSprite = 4;
            else if (linkState == 8) // sword beam
            {
                swordBeamKey = 1;
                currentSprite = 3;
            }
            else // 4 and below
                currentSprite = linkState;

            // update movement state
            linkMoving.Update();

            // update attack state
            if (linkState == 3 && !attackKey)
            {
                linkAttacking.toDraw = true;
                attackKey = true;
                linkAttacking.direction = dir;
            }
            if (attackKey)
            {
                currentSprite = 3;
                linkAttacking.Update();
            }
            if (!linkAttacking.toDraw)
                attackKey = false;

            // sword beam adjustments
            if (linkState == 8 && swordBeamKey == 1)
            {
                swordBeam = new SwordBeam();
                swordBeamKey = 2; // drawing in progress
                swordBeam.direction = dir;
                swordBeam.RegisterPos(location);
            }
            if (swordBeamKey == 2)
            {
                if (!attackKey)
                {
                    linkAttacking.toDraw = true;
                    attackKey = true;
                    linkAttacking.direction = dir;
                }
                if (attackKey)
                {
                    currentSprite = 3;
                    linkAttacking.Update();
                }
                if (!linkAttacking.toDraw)
                    attackKey = false;

                // time to draw
                if (linkAttacking.frame == 2)
                    swordBeam.toDraw = true;

                currentSprite = 3;
                swordBeam.Update();
            }

            // update attack item states
            attackSequence.UpdateAttack(linkState, dir, location, ref arrowKey, ref fireKey, ref bombKey, ref blueArrowKey);
        }
    }
}
