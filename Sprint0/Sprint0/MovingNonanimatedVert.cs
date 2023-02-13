using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class MovingnonAnimatedVert : ISprite
    {
        private int currentPos;
        private bool down;

        public Texture2D Texture { get; set; }
        public MovingnonAnimatedVert(Texture2D texture)
        {
            Texture = texture;
            currentPos = 0;
            down = false;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(144, 90, 20, 35);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y + currentPos, 40, 70);

            //now draw the sprite with the updating location
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update()
        {
            
            //set flags
            if (currentPos == 199)
            {
                down = false;
                
            }
            else if (currentPos == -199)
            {
                down = true;
            }
            //when the sprite should go up or down
            if (down)
            {
                currentPos++;
            }
            if(!down)
            {
                currentPos--;
            }
        }
    }
}
