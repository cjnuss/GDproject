using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class LinkGreenArrowDown : ISprite
    {
        //private int currentPos;

        private int currentPosX;
        private int currentPosY;
        private int finalPosition;
        private int poofPosition;

        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        public Texture2D Texture { get; set; }
        public LinkGreenArrowDown(Texture2D texture)
        {
            Texture = texture;
            //currentPos = 0;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (currentPosY <= finalPosition)
            {
                sourceRectangle = new Rectangle(734, 185, 5, 16);
                destinationRectangle = new Rectangle(currentPosX, currentPosY, 10, 32);
            }
            else if (currentPosY <= poofPosition)
            {
                sourceRectangle = new Rectangle(53, 189, 8, 8);
                destinationRectangle = new Rectangle(currentPosX, currentPosY, 16, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(0, 0, 0, 0);
                destinationRectangle = new Rectangle(currentPosX, currentPosY, 16, 16);
            }

            //now draw the sprite
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void registerPos(int x, int y)
        {
            currentPosX = x;
            currentPosY = y;
            finalPosition = y + 5 * 16;
            poofPosition = finalPosition + 5;
        }

        public void Update()
        {
            //set the frames for animation
            currentPosY = currentPosY + 5;
            //need to add both dimensions later
            //if (currentPos < 299) currentPos--;

        }
    }
}
