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
    internal class LinkGreenArrowRight : ISprite
    {
        //private int currentPos;

        private int currentPosX;
        private int currentPosY;
        private int finalPosition;
        private int poofPosition;

        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        public Texture2D Texture { get; set; }
        public LinkGreenArrowRight(Texture2D texture)
        {
            Texture = texture;
            //currentPos = 0;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            currentPosX = (int)location.X;
            currentPosY = (int)location.Y;
            finalPosition = (int)location.X + 5*16;
            poofPosition = finalPosition + 5;

            if (currentPosX <= finalPosition)
            {
                sourceRectangle = new Rectangle(10, 185, 16, 16);
                destinationRectangle = new Rectangle(currentPosX, currentPosY, 32, 32);
            } else if(currentPosX <= poofPosition)
            {
                sourceRectangle = new Rectangle(53, 189, 16, 16);
                destinationRectangle = new Rectangle(currentPosX, currentPosY, 16, 16);
            }
     
            //now draw the sprite
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            //set the frames for animation
            currentPosX++;
            //need to add both dimensions later
            //if (currentPos < 299) currentPos--;

        }
    }
}
