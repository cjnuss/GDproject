using Microsoft.Xna.Framework;
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

        List<IBlock> blocks;
        List<IItem> items;
        List<ISprite1> enemies;

        Rectangle roomSource;

        public Room(List<IBlock> blocks1, List<IItem> items1, List<ISprite1> enemies1, int roomNum1)
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
            foreach(ISprite1 enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
        
        public void Update()
        {
            /*
            foreach (IBlock block in blocks)
            {
            }

            foreach (IItem item in items)
            {
            }
            */
            foreach (ISprite1 enemy in enemies)
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
        public List<ISprite1> GetEnemies()
        {
            return enemies;
        }
    }
}
