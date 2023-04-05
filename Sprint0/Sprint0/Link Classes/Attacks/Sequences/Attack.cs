﻿using Microsoft.Xna.Framework;
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
        private GreenArrow greenArrow;
        private Fire fire;
        private Bomb bomb;
        private BlueArrow blueArrow;

        public Attack(GreenArrow greenArrow, Fire fire, Bomb bomb, BlueArrow blueArrow)
        {
            this.greenArrow = greenArrow;
            this.fire = fire;
            this.bomb = bomb;
            this.blueArrow = blueArrow;
        }

        public void Update(int linkState, int dir, Vector2 location,
                                 ref bool arrowKey, ref bool fireKey, ref bool bombKey, ref bool blueArrowKey)
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

            if (arrowKey)
                greenArrow.Update();
            if (fireKey)
                fire.Update();
            if (bombKey)
                bomb.Update();
            if (blueArrowKey)
                blueArrow.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, ref bool arrowKey, ref bool fireKey, ref bool bombKey, ref bool blueArrowKey)
        {
            if (arrowKey) greenArrow.Draw(spriteBatch);
            if (fireKey) fire.Draw(spriteBatch);
            if (bombKey) bomb.Draw(spriteBatch);
            if (blueArrowKey) blueArrow.Draw(spriteBatch);

            if (!greenArrow.toDraw) arrowKey = false;
            if (!fire.toDraw) fireKey = false;
            if (!bomb.toDraw) bombKey = false;
            if (!blueArrow.toDraw) blueArrowKey = false;
        }
    }
}