using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class LinkMovingDown : ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;
        //private int currentPos;
        //private bool down;

        public LinkMovingDown(Texture2D texture)
        {
            Texture = texture;
            //for animation
            currentFrame = 0;
            totalFrames = 40;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            //if statements to alternate through the frames slowly
            if (currentFrame <= 10)
            {
                //animates one frame
                sourceRectangle = new Rectangle(1, 47, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame <= 20)
            {
                //animates one frame
                sourceRectangle = new Rectangle(18, 47, 16, 27);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame <= 30)
            {
                //animates one frame
                sourceRectangle = new Rectangle(35, 47, 16, 23);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame > 30)
            {
                //animates one frame
                sourceRectangle = new Rectangle(52, 47, 16, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            //draw the sprite
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            //set the frames for animation
            currentFrame++;
            //need to add both dimensions later
            //if (currentPos < 299) currentPos++;

            if (currentFrame == totalFrames)
                currentFrame = 0;

        }
    }
}
