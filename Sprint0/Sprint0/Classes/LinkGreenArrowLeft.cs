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
    internal class LinkGreenArrowLeft : ISprite
    {
        //private int currentPos;

        private int currentPosX;
        private int currentPosY;
        private int finalPosition;
        private int poofPosition;

        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        public Texture2D Texture { get; set; }
        public LinkGreenArrowLeft(Texture2D texture)
        {
            Texture = texture;
            //currentPos = 0;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (currentPosX >= finalPosition)
            {
                sourceRectangle = new Rectangle(716, 185, 16, 16);
                destinationRectangle = new Rectangle(currentPosX, currentPosY, 32, 32);
            }
            else if (currentPosX >= poofPosition)
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
            finalPosition = x - 5 * 16;
            poofPosition = finalPosition - 5;
        }

        public void Update()
        {
            //set the frames for animation
            currentPosX = currentPosX - 5;
            //need to add both dimensions later
            //if (currentPos < 299) currentPos--;

        }
    }
}
