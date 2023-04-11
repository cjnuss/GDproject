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
        private int expOffsetX = GameConstants.Zero, expOffsetY = GameConstants.Zero;
        private int count = GameConstants.Zero;
        Rectangle source, source1, source2, source3;
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
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.SwordBeamTotalFrames;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == GameConstants.Down)
            {
                finalPos = (int)location.Y + LinkConstants.SwordBeamPosChange * LinkConstants.SwordBeamMultiplier;
                explodePos = finalPos + LinkConstants.SwordBeamPosChange2;
            }
            if (direction == GameConstants.Left)
            {
                finalPos = (int)location.X - LinkConstants.SwordBeamPosChange * LinkConstants.SwordBeamMultiplier;
                explodePos = finalPos - LinkConstants.SwordBeamPosChange2;
            }
            if (direction == GameConstants.Right)
            {
                finalPos = (int)location.X + LinkConstants.SwordBeamPosChange * LinkConstants.SwordBeamMultiplier;
                explodePos = finalPos + LinkConstants.SwordBeamPosChange2;
            }
            if (direction == GameConstants.Up)
            {
                finalPos = (int)location.Y - LinkConstants.SwordBeamPosChange * LinkConstants.SwordBeamMultiplier;
                explodePos = finalPos - LinkConstants.SwordBeamPosChange2;
            }
        }

        public bool CheckFinalPos()
        {
            return ((direction == GameConstants.Down && currentY > explodePos) ||
                (direction == GameConstants.Left && currentX < explodePos) ||
                (direction == GameConstants.Right && currentX > explodePos) ||
                (direction == GameConstants.Up && currentY < explodePos));
        }

        public void Update()
        {
            if (toDraw)
            {
                if (direction == GameConstants.Down)
                    currentY += LinkConstants.SwordBeamPosChange;
                if (direction == GameConstants.Left)
                    currentX -= LinkConstants.SwordBeamPosChange;
                if (direction == GameConstants.Right)
                    currentX += LinkConstants.SwordBeamPosChange;
                if (direction == GameConstants.Up)
                    currentY -= LinkConstants.SwordBeamPosChange;

                // overall frame updates
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = GameConstants.Zero;

                FrameUpdate();
            }
            if (explodeKey)
            {
                // overall frame updates
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = GameConstants.Zero;

                FrameUpdate();
            }
        }

        public void FrameUpdate()
        {
            frame = GameConstants.Frame0;
            if (currentFrame <= LinkConstants.SwordBeamPhase)
                frame = GameConstants.Frame0;
            else if (currentFrame > LinkConstants.SwordBeamPhase)
                frame = GameConstants.Frame1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // offset logic
            int xOffset = GameConstants.Zero;
            int yOffset = GameConstants.Zero;
            if (direction == GameConstants.Down)
            {
                xOffset = LinkConstants.SwordBeamXOffset1;
                yOffset = LinkConstants.SwordBeamYOffset1;
            }
            if (direction == GameConstants.Left)
            {
                xOffset = LinkConstants.SwordBeamXOffset2;
                yOffset = LinkConstants.SwordBeamYOffset2;
            }
            if (direction == GameConstants.Right)
            {
                xOffset = LinkConstants.SwordBeamXOffset3;
                yOffset = LinkConstants.SwordBeamYOffset3;
            }
            if (direction == GameConstants.Up)
            {
                xOffset = LinkConstants.SwordBeamXOffset4;
                yOffset = LinkConstants.SwordBeamYOffset4;
            }

            //texture = _texture;
            if (toDraw)
            {
                if (direction == GameConstants.Down)
                    texture = _texture2;
                else
                    texture = _texture;

                // we reach finalPos
                if (direction == GameConstants.Down && currentY >= finalPos || direction == GameConstants.Left && currentX <= finalPos ||
                    direction == GameConstants.Right && currentX >= finalPos || direction == GameConstants.Up && currentY <= finalPos)
                {
                    // draw explode stuff now
                    toDraw = false;
                    explodeKey = true;
                }

                if (frame == GameConstants.Frame0)
                    source = directions[direction];
                else
                    source = flashing;

                dest = new Rectangle((int)currentX+xOffset, (int)currentY+yOffset, source.Width*GameConstants.Sizing, source.Height * GameConstants.Sizing);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }

            if (explodeKey)
            {
                // offset
                expOffsetX += LinkConstants.SwordBeamOffsetIncrease;
                expOffsetY += LinkConstants.SwordBeamOffsetIncrease;

                // frame adj
                if (frame != GameConstants.Frame0)
                {
                    source = explode[GameConstants.Frame0];
                    source1 = explode[GameConstants.Frame1];
                    source2 = explode[GameConstants.Frame2];
                    source3 = explode[GameConstants.Frame3];
                }
                else
                {
                    source = flashing; source1 = flashing; source2 = flashing; source3 = flashing;
                }

                // top left
                dest = new Rectangle((int)currentX - expOffsetX, (int)currentY - expOffsetY, source.Width * GameConstants.Sizing, source.Height * GameConstants.Sizing);
                spriteBatch.Draw(_texture, dest, source, Color.White);

                // top right
                dest = new Rectangle((int)currentX + expOffsetX, (int)currentY - expOffsetY, source.Width * GameConstants.Sizing, source.Height * GameConstants.Sizing);
                spriteBatch.Draw(_texture, dest, source1, Color.White);

                // bottom left
                dest = new Rectangle((int)currentX - expOffsetX, (int)currentY + expOffsetY, source.Width * GameConstants.Sizing, source.Height * GameConstants.Sizing);
                spriteBatch.Draw(_texture2, dest, source2, Color.White);

                // bottom right
                dest = new Rectangle((int)currentX + expOffsetX, (int)currentY + expOffsetY, source.Width * GameConstants.Sizing, source.Height * GameConstants.Sizing);
                spriteBatch.Draw(_texture2, dest, source3, Color.White);

                if (count > LinkConstants.SwordBeamCount)
                    explodeKey = false;
                count++;
            }
        }
    }
}
