using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;

namespace Sprint0
{
    public class SwordBeam : ISprite
    {
        public int frame, currentFrame, totalFrames, direction, currentX, currentY, finalPos, explodePos;
        public Boolean toDraw = false, updatePos = true;
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
            totalFrames = 20; // changed
        }

        public void RegisterPos(Vector2 location)
        {
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
            if (updatePos && toDraw)
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
            if (currentFrame <= 15) // magic
                frame = 0;
            else if (currentFrame > 15)
                frame = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //texture = _texture;
            if (toDraw)
            {
                System.Diagnostics.Debug.WriteLine("drawing sword beam");
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
                }

                if (frame == 0)
                    source = directions[direction];
                else
                    source = flashing;

                dest = new Rectangle((int)currentX, (int)currentY, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
