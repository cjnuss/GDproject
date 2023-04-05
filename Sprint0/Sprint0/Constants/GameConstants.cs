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
    static class GameConstants
    {
        // height adj
        public const int HeightAdj = 150;
        // numbers
        public const int Zero = 0;
        public const int One = 1;
        public const int Ten = 10;
        // size multiplier
        public const int Sizing = 3;
        public const int Sizing2 = 4;
        // directions
        public const int Down = 0;
        public const int Left = 1;
        public const int Right = 2;
        public const int Up = 3;
        // frames
        public const int Frame0 = 0;
        public const int Frame1 = 1;
        public const int Frame2 = 2;
        public const int Frame3 = 3;
        // levels
        public const int NumRooms = 17;
        public const int LevelState1 = 0;
        public const int LevelState2 = 16;
        // DEBUG: target rectangle in MouseController?
    }
}
