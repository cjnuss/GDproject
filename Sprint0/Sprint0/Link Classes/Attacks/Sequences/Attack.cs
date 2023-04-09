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
    public class Attack
    {
        private LinkAttacking linkAttacking;
        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;
        private BlueArrow blueArrow;
        private SwordBeam swordBeam;

        // attack keys
        private bool attackKey = false, arrowKey = false, fireKey = false, bombKey = false, blueArrowKey = false, swordBeamKey = false;
        public Attack(LinkAttacking linkAttacking, GreenArrow greenArrow, Fire fire, Bomb bomb, BlueArrow blueArrow, SwordBeam swordBeam)
        {
            this.linkAttacking = linkAttacking;
            this.greenArrow = greenArrow;
            this.fire = fire;
            this.bomb = bomb;
            this.blueArrow = blueArrow;
            this.swordBeam = swordBeam;
        }

        public void Update(int linkState, ref int currentSprite, int dir, Vector2 location)
        {
            if (linkState == LinkConstants.GreenArrow && !arrowKey)
            {
                greenArrow = new GreenArrow();
                arrowKey = true;
                greenArrow.direction = dir;
                greenArrow.RegisterPos(location);
            }
            if (linkState == LinkConstants.Fire && !fireKey)
            {
                fire = new Fire();
                fireKey = true;
                fire.direction = dir;
                fire.RegisterPos(location);
            }
            if (linkState == LinkConstants.Bomb && !bombKey)
            {
                bomb = new Bomb();
                bombKey = true;
                bomb.direction = dir;
                bomb.UpdatePos(location);
            }
            if (linkState == LinkConstants.BlueArrow && !blueArrowKey)
            {
                blueArrow = new BlueArrow();
                blueArrowKey = true;
                blueArrow.direction = dir;
                blueArrow.RegisterPos(location);
            }
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

            if (DrawNewSwordBeam(linkState))
            {
                swordBeamKey = true;
                swordBeam = new SwordBeam();
                swordBeam.direction = dir;
            }
            if (RegisterSwordBeam())
            {
                swordBeam.toDraw = true;
                swordBeam.RegisterPos(location);
            }

            greenArrow.Update();
            fire.Update();
            bomb.Update();
            blueArrow.Update();
            swordBeam.Update();
        }

        public bool DrawNewSwordBeam(int linkState)
        {
            return (linkState == LinkConstants.SwordBeam && !swordBeamKey && !swordBeam.explodeKey);
        }

        public bool RegisterSwordBeam()
        {
            return (!swordBeam.toDraw && swordBeamKey/* && linkAttacking.frame == LinkConstants.PeakAnimation*/);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (arrowKey) greenArrow.Draw(spriteBatch);
            if (fireKey) fire.Draw(spriteBatch);
            if (bombKey) bomb.Draw(spriteBatch);
            if (blueArrowKey) blueArrow.Draw(spriteBatch);
            if (swordBeamKey || swordBeam.explodeKey) swordBeam.Draw(spriteBatch);

            if (!greenArrow.toDraw) arrowKey = false;
            if (!fire.toDraw) fireKey = false;
            if (!bomb.toDraw) bombKey = false;
            if (!blueArrow.toDraw) blueArrowKey = false;
            if (!swordBeam.toDraw) swordBeamKey = false;
        }
    }
}
