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
    internal class LinkGreenArrow : ISprite
    {
        //private int currentPos;
        private int currentFrame;
        private int totalFrames;

        public Texture2D Texture { get; set; }
        public LinkGreenArrow(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 30;
            //currentPos = 0;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                Rectangle sourceRectangle = new Rectangle(10, 185, 16, 16);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 32);

                //now draw the sprite
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
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
