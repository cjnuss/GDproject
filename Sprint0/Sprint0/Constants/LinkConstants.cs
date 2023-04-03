using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using Sprint0.Link_Classes.Item_Usage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sprint0
{
    static class LinkConstants
    {
        // locations
        public const int InitialX = 200;
        public const int InitialY = 100;
        // velocity
        public const float Velocity = 100f;
        // link sprites
        public const int Looking = 0;
        public const int Moving = 1;
        public const int Damaged = 2;
        public const int Attacking = 3;
        public const int Throwing = 4;
        //link states
        public const int Default = 0;
        public const int Movement = 1;
        public const int Damage = 2;
        public const int WoodenSword = 3;
        public const int GreenArrow = 4;
        public const int Fire = 5;
        public const int Bomb = 6;
        public const int BlueArrow = 7;
        public const int SwordBeam = 8;
        // sword beam trigger frame
        public const int PeakAnimation = 2;
        // frames
        public const int Frame0 = 0;
        public const int Frame1 = 1;
        public const int Frame2 = 2;
        public const int Frame3 = 3;
        // link attacking
        public const int TotalSwordFrames = 20;
        public const int SwordPhase1 = TotalSwordFrames / 4;
        public const int SwordPhase2 = TotalSwordFrames / 2;
        public const int SwordPhase3 = (TotalSwordFrames * 3) / 4;
        public const int SwordPhase4 = TotalSwordFrames - 1;
        public const int LeftOffset1 = 28;
        public const int LeftOffset2 = 18;
        public const int LeftOffset3 = 8;
        public const int UpOffset1 = 29;
        public const int UpOffset2 = 28;
        public const int UpOffset3 = 8;
        // link damaged
        public const int TotalDamageFrames = 30;
        // link moving
        public const int TotalMovingFrames = 20;
        public const int MovingPhase = TotalMovingFrames / 2;
    }
}
