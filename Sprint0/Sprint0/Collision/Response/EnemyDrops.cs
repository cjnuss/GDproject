using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Collision.Response
{
    internal class EnemyDrops
    {
        private Random randomizer;
        private int randomNum;
        int[] dropArray;

        public EnemyDrops()
        {
            randomizer = new Random();
            dropArray = new int[80];
            Array.Fill(dropArray, GameConstants.rupeeDrop, 0, 17);
            Array.Fill(dropArray, GameConstants.heartDrop, 16, 15);
            Array.Fill(dropArray, GameConstants.fairyDrop, 31, 3);
            Array.Fill(dropArray, GameConstants.bombDrop, 34, 3);
            Array.Fill(dropArray, GameConstants.clockDrop, 37, 2);
            Array.Fill(dropArray, 0, 39, 40);
        }

        public ISprite dropItem(Vector2 position)
        {
            randomNum = randomizer.Next(0, 80);

            if (dropArray[randomNum] != 0)
            {
                if (dropArray[randomNum] == GameConstants.rupeeDrop)
                {
                    return new Rupee(position);
                } else if (dropArray[randomNum] == GameConstants.heartDrop)
                {
                    return new Heart(position);
                } else if (dropArray[randomNum] == GameConstants.fairyDrop)
                {
                    return new Fairy(position);
                } else if (dropArray[randomNum] == GameConstants.bombDrop)
                {
                    return new BombItem(position);
                } else if (dropArray[randomNum] == GameConstants.clockDrop)
                {
                    return new Clock(position);
                }
            }
            return null;
        }
    }
}