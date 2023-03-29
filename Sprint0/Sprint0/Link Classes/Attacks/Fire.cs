using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprint0
{
    public class Fire : ISprite
    {
        public int frame, currentFrame, totalFrames, count, direction, currentX, currentY, finalPos, stillPos;
        public Boolean toDraw = true, updatePos = true;
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
            count = 0;
            updatePos = true;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == 0)
            {
                finalPos = (int)location.Y + 5 * 16;
                stillPos = finalPos + 5;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - 5 * 16;
                stillPos = finalPos - 5;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + 5 * 16;
                stillPos = finalPos + 5;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - 5 * 16;
                stillPos = finalPos - 5;
            }
        }

        public bool CheckFinalPos()
        {
            return ((direction == 0 && currentY > stillPos) ||
                (direction == 1 && currentX < stillPos) ||
                (direction == 2 && currentX > stillPos) ||
                (direction == 3 && currentY < stillPos));
        }

        public void Update()
        {

            // distance updates
            if (updatePos && toDraw)
            {
                if (direction == 0 && currentY <= finalPos)
                {
                    currentY += 3; // magic?
                }
                //else
                //{
                //    frame = 2;
                //}
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

            FrameUpdate();
        }

        public void FrameUpdate()
        {
            frame = 0;
            if (currentFrame <= totalFrames/2)
                frame = 0;
            else if (currentFrame > totalFrames/2)
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
                    // update standing still, 20 times
                    if (count >= 20)
                        toDraw = false;

                    count++;
                }

                source = FireList[frame]; // frame
                dest = new Rectangle((int)currentX, (int)currentY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
