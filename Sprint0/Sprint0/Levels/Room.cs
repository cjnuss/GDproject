﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Levels
{
    public class Room : IRoom
    {

        int roomNum;
        public Vector2 location;
        List<IBlock> blocks;
        List<IItem> items;
        List<ISprite> enemies;

        private LinkBlockCollision linkMovementCollision;

        Rectangle roomSource;

        public Room(List<IBlock> blocks1, List<IItem> items1, List<ISprite> enemies1, int roomNum1)
        {
            blocks = blocks1;
            items = items1;
            enemies = enemies1;
            roomNum = roomNum1;
            string room = roomNum.ToString();
            roomSource = LevelsTextureStorage.Sources[room];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*
            foreach(IBlock block in blocks)
            {
            }

            foreach(IItem item in items)
            {
            }
            */
            foreach(ISprite enemy in enemies)
            {
                //location = new Vector2(600, 240); // magic?
                enemy.Draw(spriteBatch);
            }
        }
        
        public void Update()
        {
            
            /*
            foreach (IBlock block in blocks)
            {
                block.Update();
            }

            /*
            foreach (IItem item in items)
            {
            }
            */
            foreach (ISprite enemy in enemies)
            {
                enemy.Update();
            }
        }
        public List<IBlock> GetBlocks()
        {
            return blocks;
        }
        public List<IItem> GetItems()
        {
            return items;
        }
        public List<ISprite> GetEnemies()
        {
            return enemies;
        }
    }
}
