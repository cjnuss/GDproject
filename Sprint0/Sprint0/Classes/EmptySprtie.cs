using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Classes
{
    internal class EmptySprtie : ISprite
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;

        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        //private int currentPos;
        //private bool down;

        public EmptySprtie(Texture2D texture)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(0, 0, 0, 0);
            destinationRectangle = new Rectangle(0, 0, 0, 0);
        }

        public void Update()
        {

        }
    }
}
