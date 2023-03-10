using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class Fire : ISprite
    {
        public int frame, currentFrame, totalFrames, direction, currentX, currentY, finalPos, stillPos;
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> FireList = new List<Rectangle>
        {
            LinkTextureStorage.LinkFire1,
            LinkTextureStorage.LinkFire2,
            new Rectangle(0,0,0,0)
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public Fire()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            System.Diagnostics.Debug.WriteLine("position registered at " + location);

            if (direction == 0)
            {
                finalPos = (int)location.Y + 5 * 16;
                //stillPos = finalPos + 5;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - 5 * 16;
                //stillPos = finalPos - 5;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + 5 * 16;
                //stillPos = finalPos + 5;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - 5 * 16;
                //stillPos = finalPos - 5;
            }
        }

        public void Update()
        {
            // distance updates
            if (toDraw)
            {
                if (direction == 0 && currentY <= finalPos)
                    currentY += 3; // magic?
                if (direction == 1 && currentX >= finalPos)
                    currentX -= 3;
                if (direction == 2 && currentX <= finalPos)
                    currentX += 3;
                if (direction == 3 && currentY >= finalPos)
                    currentY -= 3;
            }

            // overall frame updates
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            // animation frame updates
            frame = 0;
            if (currentFrame <= 10)
                frame = 0;
            else if (currentFrame > 10)
                frame = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;

            if (toDraw)
            {
                if (direction == 0 && currentY >= finalPos || direction == 1 && currentX <= finalPos ||
                    direction == 2 && currentX >= finalPos || direction == 3 && currentY <= finalPos)
                {
                    toDraw = false;
                }

                source = FireList[frame]; // frame
                dest = new Rectangle((int)currentX, (int)currentY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
