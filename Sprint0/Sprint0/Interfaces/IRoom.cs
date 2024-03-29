﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IRoom
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update();

        public List<IEnemy> GetEnemies();
        public List<IBlock> GetBlocks();
        public List<ISprite> GetItems();
        public List<Door> GetDoors();

        public List<int> GetRooms();

        public bool GetState();
    }
}
