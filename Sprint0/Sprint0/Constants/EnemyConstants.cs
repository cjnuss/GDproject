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


        public const int Texture1 = 5;
        public const int Texture2 = 10;
        public const int Texture3 = 15;

        public const int Frame1 = 0;
        public const int Frame2 = 1;
        public const int Frame3 = 2;
        public const int Frame4 = 3;

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
        public const int BatTextureFrames = 10;
        public const int BatTotalFrames = 40;
        public const int BatMinFrame = 45;
        public const int BatMaxFrame = 75;
        public const int BatFrameChange = 10;


        public const int GelTextureFrames = 10;
        public const int GelTotalFrames = 40;
        public const int GelStatic = 5;
        public const int GelDisplacement = 5;
        public const int GelMinFrame = 50;
        public const int GelMaxFrame = 120;
        public const int GelFrameChange = 10;
        public const int GelStaticTime = 80;

        public const int GoriyaTextureFrames = 20;
        public const int GoriyaTotalFrames = 40;
        public const int GoriyaMinFrame = 30;
        public const int GoriyaMaxFrame = 60;
        public const int GoriyaFrameChange = 15;

        public const int GoriyaProjXAdjustment = 12;
        public const int GoriyaProjTextureFrames = 20;
        public const int GoriyaProjTotalFrames = 40;
        public const int GoriyaProjCount = 500;
        public const int GoriyaProjTime = 150;
        public const int GoriyaDisplacement = 6;
        public const int GoriyaProjDisplacement = 5;
        public const int GoriyaProjFrameChange = 5;
        public const int GoriyaProjChange = 75;

        public const int SkeletonTotalFrames = 60;
        public const int SkeletonTextureFrames = 14;
        public const int SkeletonDisplacement = 6;
        public const int SkeletonTexture1 = 7;
        public const int SkeletonMinFrame = 30;
        public const int SkeletonMaxFrame = 60;
        public const int SkeletonFrameChange = 15;
    }
}
