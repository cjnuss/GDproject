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
    static class EnemyConstants
    {
        public const int Zero = 0;
        public const int One = 1;
        // size multiplier
        public const int Sizing = 3;
        // directions
        public const int Down = 0;
        public const int Left = 1;
        public const int Right = 2;
        public const int Up = 3;
        public const int NE = 4;
        public const int SE = 5;
        public const int SW = 6;
        public const int NW = 7;

        public const int DeathFrames = 37;
        public const int HitFrames = 16;

        public const int DeathFrame1 = 5, DeathFrame2 = 10, DeathFrame3 = 15, DeathFrame4 = 20,
                         DeathFrame5 = 25, DeathFrame6 = 30, DeathFrame7 = 35;

        public const int Texture1 = 5;
        public const int Texture2 = 10;
        public const int Texture3 = 15;

        public const int Frame1 = 0;
        public const int Frame2 = 1;
        public const int Frame3 = 2;
        public const int Frame4 = 3;
        public const int Frame5 = 4;

        public const int AquaWidth = 24, AquaHeight = 32;
        public const int AquaHP = 6;
        public const int AquaTotalFrames = 20;
        public const int AquaTextureFrames = 20;
        public const int AquaDisplacement = 5;
        public const int AquaMinFrame = 20;
        public const int AquaMaxFrame = 50;
        public const int AquaFrameChange = 10;

        public const int AquaProjTextureFrames = 20;
        public const int AquaProjFrameChange = 10;
        public const int AquaProjCount = 250;
        public const int AquaProjTotalFrames = 200;
        public const int AquaProjXAdjustment = 24;
        public const int AquaProjYAdjustment = 31;
        public const int AquaProjXDisplacement = 6;
        public const int AquaProjYDisplacement = 3;

        public const int BatDisplacement = 6;
        public const int BatSize = 16;
        public const int BatTextureFrames = 10;
        public const int BatTotalFrames = 40;
        public const int BatMinFrame = 45;
        public const int BatMaxFrame = 75;
        public const int BatFrameChange = 10;

        public const int GelWidth = 8, GelHeight = 8;
        public const int GelTextureFrames = 10;
        public const int GelTotalFrames = 100;
        public const int GelStatic = 5;
        public const int GelDisplacement = 5;
        public const int GelMinFrame = 1;
        public const int GelMaxFrame = 4;
        public const int GelXFrames = 100;
        public const int GelYFrames = 90;
        public const int GelFrameChange = 10;
        public const int GelStaticTime = 80;
        public const int GelXOffset = 13;

        public const int GoriyaTextureFrames = 20;
        public const int GoriyaTotalFrames = 100;
        public const int GoriyaMinFrame = 1;
        public const int GoriyaMaxFrame = 3;
        public const int GoriyaXFrames = 100;
        public const int GoriyaYFrames = 90;
        public const int GoriyaFrameChange = 10;
        public const int GoriyaDisplacement = 5;

        public const int GoriyaSize = 16;
        public const int GoriyaHP = 3;
        public const int GoriyaProjXAdjustment = 12;
        public const int GoriyaProjTextureFrames = 20;
        public const int GoriyaProjTotalFrames = 40;
        public const int GoriyaProjCount = 500;
        public const int GoriyaProjTime = 150;
        public const int GoriyaProjDisplacement = 5;
        public const int GoriyaProjFrameChange = 5;
        public const int GoriyaProjChange = 75;

        public const int SkeletonTotalFrames = 100;
        public const int SkeletonTextureFrames = 14;
        public const int SkeletonDisplacement = 5;
        public const int SkeletonTexture1 = 7;
        public const int SkeletonMinFrame = 1;
        public const int SkeletonMaxFrame = 3;
        public const int SkeletonXFrames = 100;
        public const int SkeletonYFrames = 90;
        public const int SkeletonFrameChange = 10;
        public const int SkeletonSize = 16;
        public const int SkeletonHP = 2;
    }
}
