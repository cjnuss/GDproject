using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class LinkMovingLeft: ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;
        private int currentPos;
        //private bool down;

        public LinkMovingLeft(Texture2D texture)
        {
            Texture = texture;
            //for animation
            currentFrame = 0;
            totalFrames = 30;
            //for movement
            currentPos = 0;
            //down = false;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            //if statements to alternate through the frames slowly
            //no left facing Link on the sheet I am going to ask in class how to make him face left
            if (currentFrame <= 15)
            {
                //animates one frame
                sourceRectangle = new Rectangle(674, 11, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame > 15)
            {
                //animates one frame
                sourceRectangle = new Rectangle(691, 11, 16, 16);
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
            //if (currentPos < 299) currentPos--;

            if (currentFrame == totalFrames)
                currentFrame = 0;

        }
    }
}
