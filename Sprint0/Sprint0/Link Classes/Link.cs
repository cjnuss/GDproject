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

        private bool arrowKey = false, fireKey = false, bombKey = false; // blueArrowKey = false, swordBeamKey = false;

        private AttackSequence attackSequence;

        private LinkLooking linkLooking;
        private LinkMoving linkMoving;
        private LinkDamaged linkDamaged;
        private LinkAttacking linkAttacking;
        private LinkThrowing linkThrowing;

        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;

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
            // blueArrow = new BlueArrow();
            // swordBeam = new SwordBeam();

            sprites = new ILinkSprite[] {linkLooking, linkMoving, linkDamaged, linkAttacking, linkThrowing};

            attackSequence = new AttackSequence(greenArrow, fire, bomb);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch, location);
            attackSequence.DrawAttack(spriteBatch, ref arrowKey, ref fireKey, ref bombKey);
        }
        public void Update(int linkState, int dir, Vector2 location)
        {
            // dir adjustments
            linkLooking.direction = dir; 
            linkMoving.direction = dir; 
            linkAttacking.direction = dir; 
            linkThrowing.direction = dir;

            // update currentSprite: (0) looking; (1) moving; (2)damaged; (3) attacking; (4) throwing
            if (linkState == 5 || linkState == 6 || linkState == 7) // throwing fire, bomb, blue arrow
                currentSprite = 4;
            else if (linkState == 8) // DEBUG: swordBeam attack (is this right??)
                currentSprite = 3;  // DEBUG: attacking sprite (is this right??)
            else // 4 and below
                currentSprite = linkState;

            // update linkStates
            linkLooking.Update(); 
            linkMoving.Update(); 
            linkAttacking.Update(); 
            linkThrowing.Update();

            attackSequence.UpdateAttack(linkState, dir, location, ref arrowKey, ref fireKey, ref bombKey);
        }
    }
}
