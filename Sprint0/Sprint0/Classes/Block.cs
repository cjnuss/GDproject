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
    internal class Block : ISprite
    {
        public Texture2D Texture { get; set; }

        public Block(Texture2D texture)
        {
            Texture = texture;
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

        public void Update()
        {
            // cycle forward in block list
            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                if (blockIdx <= 8)
                    blockIdx++;
                else
                    blockIdx = 0;
            }
            // cycle back in block list
            else if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                if (blockIdx >= 1)
                    blockIdx--;
                else
                    blockIdx = 9;
            }
            // reset back to original state
            else if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                blockIdx = 0;
            }
        }
    }
}
