using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;
using System.Threading;

namespace Sprint0
{
    public class SwordBeam : ISprite
    {
        public int frame, currentFrame, totalFrames, direction, currentX, currentY, finalPos, explodePos;
        public Boolean toDraw = false, explodeKey = false;
        private int expOffsetX = 0, expOffsetY = 0;
        private int count = 0;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> directions = new List<Rectangle>()
        {
            LinkTextureStorage.LinkSwordBeamDown,
            LinkTextureStorage.LinkSwordBeamLeft,
            LinkTextureStorage.LinkSwordBeamRight,
            LinkTextureStorage.LinkSwordBeamUp
        };

        Rectangle flashing = LinkTextureStorage.LinkSwordBeamFlashing;

        private static List<Rectangle> explode = new List<Rectangle>()
        {
            LinkTextureStorage.LinkSwordBeamExplode,
            LinkTextureStorage.LinkSwordBeamExplode1,
            LinkTextureStorage.LinkSwordBeamExplode2,
            LinkTextureStorage.LinkSwordBeamExplode3
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();
        private Texture2D _texture2 = LinkTextureStorage.Instance.GetUpsideDown();

        public SwordBeam()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 10; // changed
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == 0)
            {
                finalPos = (int)location.Y + 7 * 32; // changed to 7 and 32
                explodePos = finalPos + 7;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - 7 * 32;
                explodePos = finalPos - 7;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + 7 * 32;
                explodePos = finalPos + 7;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - 7 * 32;
                explodePos = finalPos - 7;
            }
        }

        public bool CheckFinalPos()
        {
            return ((direction == 0 && currentY > explodePos) ||
                (direction == 1 && currentX < explodePos) ||
                (direction == 2 && currentX > explodePos) ||
                (direction == 3 && currentY < explodePos));
        }

        public void Update()
        {
            if (toDraw)
            {
                if (direction == 0)
                    currentY += 7; // magic?
                if (direction == 1)
                    currentX -= 7;
                if (direction == 2)
                    currentX += 7;
                if (direction == 3)
                    currentY -= 7;

                // overall frame updates
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                FrameUpdate();
            }
        }

        public void FrameUpdate()
        {
            frame = 0;
            if (currentFrame <= 6) // magic
                frame = 0;
            else if (currentFrame > 7)
                frame = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // offset logic
            int xOffset = 0;
            int yOffset = 0;
            if (direction == 0)
            {
                xOffset = 15;
                yOffset = 18;
            }
            if (direction == 1)
            {
                xOffset = -18;
                yOffset = 17;
            }
            if (direction == 2)
            {
                xOffset = 18;
                yOffset = 16;
            }
            if (direction == 3)
            {
                xOffset = 9;
                yOffset = -19;
            }

            //texture = _texture;
            if (toDraw)
            {
                if (direction == 0)
                    texture = _texture2;
                else
                    texture = _texture;

                // we reach finalPos
                if (direction == 0 && currentY >= finalPos || direction == 1 && currentX <= finalPos ||
                    direction == 2 && currentX >= finalPos || direction == 3 && currentY <= finalPos)
                {
                    // draw explode stuff now
                    toDraw = false;
                    explodeKey = true;
                }

                if (frame == 0)
                    source = directions[direction];
                else
                    source = flashing;

                dest = new Rectangle((int)currentX+xOffset, (int)currentY+yOffset, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }

            if (explodeKey)
            {
                // offset
                expOffsetX += 2;
                expOffsetY += 2;

                // top left
                dest = new Rectangle((int)currentX - expOffsetX, (int)currentY - expOffsetY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(_texture, dest, explode[0], Color.White);

                // top right
                dest = new Rectangle((int)currentX + expOffsetX, (int)currentY - expOffsetY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(_texture, dest, explode[1], Color.White);

                // bottom left
                dest = new Rectangle((int)currentX - expOffsetX, (int)currentY + expOffsetY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(_texture2, dest, explode[2], Color.White);

                // bottom right
                dest = new Rectangle((int)currentX + expOffsetX, (int)currentY + expOffsetY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(_texture2, dest, explode[3], Color.White);

                if (count > 30)
                    explodeKey = false;
                count++;
            }
        }
    }
}
