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
    static class AquamentusConstants
    {
        public const int TotalFrames = 20;
        public const int TextureFrames = 20;
        public const int InitialRandom = 2;
        public const int NextRandom1 = 1;
        public const int NextRandom2 = 3;
        public const int NextRandomFrame1 = 20;
        public const int NextRandomFrame2 = 50;
        public const int Case1 = 1;
        public const int Case2 = 2;
        public const int PosChange = 5;
        public const int MaxProjectile = 250;
        public const int Phase1 = TotalFrames / 4;
        public const int Phase2 = TotalFrames / 2;
        public const int Phase3 = (3 * TotalFrames) / 4;
    }
}
