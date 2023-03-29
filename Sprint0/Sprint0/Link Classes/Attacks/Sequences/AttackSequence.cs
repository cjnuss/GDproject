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
    public class AttackSequence
    {
        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;
        // private BlueArrow blueArrow;
        // private SwordBeam swordBeam;

        public AttackSequence(GreenArrow greenArrow, Fire fire, Bomb bomb)
        {
            this.greenArrow = greenArrow;
            this.fire = fire;
            this.bomb = bomb;
        }

        public void UpdateAttack(int linkState, int dir, Vector2 location,
                                 ref bool arrowKey, ref bool fireKey, ref bool bombKey)
        {
            // attack update sequence
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
        }

        public void DrawAttack(SpriteBatch spriteBatch, ref bool arrowKey, ref bool fireKey, ref bool bombKey)
        {
            if (arrowKey) greenArrow.Draw(spriteBatch);
            if (fireKey) fire.Draw(spriteBatch);
            if (bombKey) bomb.Draw(spriteBatch);

            if (!greenArrow.toDraw) arrowKey = false;
            if (!fire.toDraw) fireKey = false;
            if (!bomb.toDraw) bombKey = false;
        }
    }
}
