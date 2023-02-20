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
    internal class LinkTakingDamage : ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;

        public LinkTakingDamage(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 6;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            if (currentFrame <= 2)
            {
                //animates one frame
                sourceRectangle = new Rectangle(35, 232, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame <= 4)
            {
                //animates one frame
                sourceRectangle = new Rectangle(18, 232, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }
            else if (currentFrame > 4)
            {
                //animates one frame
                sourceRectangle = new Rectangle(1, 232, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);
            }

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }
    }
}
