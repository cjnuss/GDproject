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
        // size
        public const int Size = 16;
        // collision
        public const int YChange = 7;
        public const int CollisionSize = 14;
        public const int Correction = 1;
        // locations
        public const int InitialX = 200;
        public const int InitialY = 400;
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
        // blue arrow
        public const int TotalBlueArrowFrames = 30;
        public const int BlueArrowMultiplier = 32;
        public const int BlueArrowPosChange = 7;
        // green arrow
        public const int TotalGreenArrowFrames = 30;
        public const int GreenArrowMultiplier = 16;
        public const int GreenArrowPosChange = 5;
        // bomb
        public const int BombTotalFrames = 60;
        public const int xOffset1 = 10;
        public const int xOffset2 = 32;
        public const int xOffset3 = 48;
        public const int yOffset1 = 48;
        public const int yOffset2 = 10;
        public const int BombPhase1 = 36;
        public const int BombPhase2 = 44;
        public const int BombPhase3 = 52;
        public const int BombPhase4 = 59;
        // fire
        public const int FireTotalFrames = 10;
        public const int FireMultiplier = 24;
        public const int FirePosChange = 3;
        public const int FirePhase = FireTotalFrames / 2;
        public const int StillCount = 20;
        // sword beam
        public const int SwordBeamWidth = 7, SwordBeamHeight = 16;
        public const int SwordBeamTotalFrames = 10;
        public const int SwordBeamPosChange = 12;
        public const int SwordBeamPosChange2 = 5;
        public const int SwordBeamMultiplier = 20;
        public const int SwordBeamPhase = (SwordBeamTotalFrames / 2) + 1;
        public const int SwordBeamXOffset1 = 15;
        public const int SwordBeamXOffset2 = -18;
        public const int SwordBeamXOffset3 = 18;
        public const int SwordBeamXOffset4 = 9;
        public const int SwordBeamYOffset1 = 18;
        public const int SwordBeamYOffset2 = 17;
        public const int SwordBeamYOffset3 = 16;
        public const int SwordBeamYOffset4 = -19;
        public const int SwordBeamOffsetIncrease = 3; // changed from 2
        public const int SwordBeamCount = 20; // changed from 30
    }
}
