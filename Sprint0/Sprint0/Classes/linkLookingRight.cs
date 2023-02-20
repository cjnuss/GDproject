using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class LinkLookingRight : ISprite
    {
        public Texture2D Texture { get; set; }

        //private bool down;

        public LinkLookingRight(Texture2D texture)
        {
            Texture = texture;
            //down = false;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            sourceRectangle = new Rectangle(35, 11, 16, 16);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 40);

            //draw the sprite
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
