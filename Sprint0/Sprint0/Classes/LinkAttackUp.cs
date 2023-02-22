﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class LinkAttackUp : ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;
        //private int currentPos;
        //private bool down;

        public LinkAttackUp(Texture2D texture)
        {
            Texture = texture;
            //for animation
            currentFrame = 0;
            totalFrames = 20;
            //for movement
            //currentPos = 0;
            //down = false;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            //if statements to alternate through the frames slowly
            if (currentFrame <= 5)
            {
                //animates one frame
                sourceRectangle = new Rectangle(1, 109, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame <= 10)
            {
                //animates one frame
                sourceRectangle = new Rectangle(18, 97, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 69);
            }
            else if (currentFrame <= 15)
            {
                //animates one frame
                sourceRectangle = new Rectangle(35, 98, 16, 27);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 68);
            }
            else if (currentFrame > 15)
            {
                //animates one frame
                sourceRectangle = new Rectangle(52, 106, 16, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 48);
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