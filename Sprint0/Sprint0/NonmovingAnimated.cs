using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class NonmovingAnimated : ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;

        public NonmovingAnimated(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 30;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle= new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(204, 149, 20, 35);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame >= 10 && currentFrame <= 20)
            {
                //sourceRectangle = new Rectangle(251, 183, 18, 35);
                //destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
                sourceRectangle = new Rectangle(233, 183, 20, 35);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }
            else if (currentFrame > 20)
            {
                //sourceRectangle = new Rectangle(233, 183, 20, 35);
                //destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
                sourceRectangle = new Rectangle(251, 183, 18, 35);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);
            }

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
    }
}
