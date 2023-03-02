using Microsoft.Xna.Framework;
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

        public LinkAttackUp(Texture2D texture)
        {
            Texture = texture;
            //for animation
            currentFrame = 0;
            totalFrames = 20;


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
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y - 29, 40, 69);
            }
            else if (currentFrame <= 15)
            {
                //animates one frame
                sourceRectangle = new Rectangle(35, 98, 16, 27);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y - 28, 40, 68);
            }
            else if (currentFrame > 15)
            {
                //animates one frame
                sourceRectangle = new Rectangle(52, 106, 16, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y - 8, 40, 48);
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

        }
    }
}
