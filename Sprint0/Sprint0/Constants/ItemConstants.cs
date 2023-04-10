using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprint0
{
    static class ItemConstants
    {
        // arrow
        public const int ArrowWidth = 5, ArrowHeight = 16;
        // bomb
        public const int BombWidth = 8, BombHeight = 16;
        // rupee
        public const int RupeeWidth = 8, RupeeHeight = 16;
        // fairy
        public const int FairyTotalFrames = 20;
        public const int FairyPhase = FairyTotalFrames / 2;
        // rupee
        public const int RupeePhase = 10;
        // triforce
        public const int TriforceHeight = 10, TriforceWidth = 10;
        public const int TriforceTotalFrames = 20;
        public const int TriforcePhase = TriforceTotalFrames / 2;
    }
}
