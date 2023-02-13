using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class MovingAnimatedHoriz : ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;
        private int currentPos;
        private bool down;

        public MovingAnimatedHoriz(Texture2D texture)
        {
            Texture = texture;
            //for animation
            currentFrame = 0;
            totalFrames = 30;
            //for movement
            currentPos = 0;
            down = false;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            //if statements to alternate through the frames slowly
            if (currentFrame < 10)
            {
                //animates one frame
                sourceRectangle = new Rectangle(204, 149, 20, 35);
                destinationRectangle = new Rectangle((int)location.X + currentPos, (int)location.Y, 40, 70);
            }
            else if (currentFrame >= 10 && currentFrame <= 20)
            {
                //animates one frame
                sourceRectangle = new Rectangle(233, 183, 20, 35);
                destinationRectangle = new Rectangle((int)location.X + currentPos, (int)location.Y, 40, 70);
            }
            else if (currentFrame > 20)
            {
                //animates one frame
                sourceRectangle = new Rectangle(251, 183, 18, 35);
                destinationRectangle = new Rectangle((int)location.X + currentPos, (int)location.Y, 40, 70);
            }
            //draw the sprite
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            //set the frames for animation
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            //set flags for movement
            if (currentPos == 299)
            {
                down = false;

            }
            else if (currentPos == -299)
            {
                down = true;
            }
            //when the sprite should go up or down
            if (down)
            {
                currentPos++;
            }
            if (!down)
            {
                currentPos--;
            }

        }
    }
}
