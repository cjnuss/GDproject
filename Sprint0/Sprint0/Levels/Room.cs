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
        public Vector2 location;
        List<IBlock> blocks;
        List<ISprite> items;
        List<IEnemy> enemies;
        List<Door> doors;
        List<int> rooms;

        Rectangle roomSource;

        public Room(List<IBlock> blocks1, List<ISprite> items1, List<IEnemy> enemies1, List<Door> doors1, List<int> rooms1, int roomNum1)
        {
            blocks = blocks1;
            items = items1;
            enemies = enemies1;
            doors = doors1;
            roomNum = roomNum1;
            rooms = rooms1;
            string room = roomNum.ToString();
            roomSource = LevelsTextureStorage.Sources[room];
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (IBlock block in blocks)
            {
            }

            foreach (ISprite item in items)
            {
                item.Draw(spriteBatch);
            }

            foreach (IEnemy enemy in enemies)
            {
                //location = new Vector2(600, 240); // magic?
                enemy.Draw(spriteBatch);
            }
        }

        public void Update()
        {


            foreach (IBlock block in blocks)
            {
                block.Update(0);
            }


            foreach (ISprite item in items)
            {
                item.Update();
            }

            foreach (IEnemy enemy in enemies)
            {
                enemy.Update();
            }
        }
        public List<IBlock> GetBlocks()
        {
            return blocks;
        }
        public List<ISprite> GetItems()
        {
            return items;
        }
        public List<IEnemy> GetEnemies()
        {
            return enemies;
        }

        public List<Door> GetDoors()
        {
            return doors;
        }

        public List<int> GetRooms()
        {
            return rooms;
        }
    }
}
