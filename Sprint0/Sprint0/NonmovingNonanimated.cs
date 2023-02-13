using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class NonmovingNonanimated : ISprite
    {
        public Texture2D Texture { get; set; }

        public NonmovingNonanimated(Texture2D texture)
        {
            Texture = texture;
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(215, 90, 20, 35);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 40, 70);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            //nothing to do here
        }
    }
}
