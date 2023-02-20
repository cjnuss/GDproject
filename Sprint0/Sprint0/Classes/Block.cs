using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class Block : IBlock
    {
        public Texture2D Texture { get; set; }

        private int currentCount;
        private int totalCount;

        public Block(Texture2D texture)
        {
            Texture = texture;
            currentCount = 0;
            totalCount = 10;
        }

        // list of 10 blocks to cycle through
        int blockIdx = 0;  // start at first block
        Rectangle[] blocks = {new Rectangle(984, 11, 16, 16), new Rectangle(1001, 11, 16, 16),
                              new Rectangle(1018, 11, 16, 16), new Rectangle(1035, 11, 16, 16),
                              new Rectangle(984, 28, 16, 16), new Rectangle(1001, 28, 16, 16),
                              new Rectangle(1018, 28, 16, 16), new Rectangle(1035, 28, 16, 16),
                              new Rectangle(984, 45, 16, 16), new Rectangle(1001, 45, 16, 16)};

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = blocks[blockIdx]; // draw the block at the index
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 64, 64);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(int blockState)
        {
            if (currentCount >= totalCount)
            {
                currentCount = 0;
                // cycle forward in block list
                if (blockState == 1)
                {
                    if (blockIdx <= 8)
                        blockIdx++;
                    else
                        blockIdx = 0;
                }
                // cycle back in block list
                if (blockState == 2)
                {
                    if (blockIdx >= 1)
                        blockIdx--;
                    else
                        blockIdx = 9;
                }
                // reset back to original state
                if (blockState == 0)
                {
                    blockIdx = 0;
                }
            } else
            {
                currentCount++;
            }
        }

        public void KeyBlockUpdate(bool check, ref int oldBlockState, ref int blockState)
        {
            if (check)
            {
                oldBlockState = blockState;
                blockState = 1;
            }
            else
            {
                oldBlockState = blockState;
                blockState = 2;
            }
        }
    }
}
