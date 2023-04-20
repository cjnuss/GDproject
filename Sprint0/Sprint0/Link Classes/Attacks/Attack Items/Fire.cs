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
        public Boolean toDraw = false, updatePos = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> FireList = new List<Rectangle>
        {
            LinkTextureStorage.LinkFire1,
            LinkTextureStorage.LinkFire2,
            new Rectangle(GameConstants.Zero, GameConstants.Zero, GameConstants.Zero, GameConstants.Zero)
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public Fire()
        {
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.FireTotalFrames;
            count = GameConstants.Zero;
            updatePos = true;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == GameConstants.Down)
            {
                finalPos = (int)location.Y + LinkConstants.FirePosChange * LinkConstants.FireMultiplier;
            }
            if (direction == GameConstants.Left)
            {
                finalPos = (int)location.X - LinkConstants.FirePosChange * LinkConstants.FireMultiplier;
            }
            if (direction == GameConstants.Right)
            {
                finalPos = (int)location.X + LinkConstants.FirePosChange * LinkConstants.FireMultiplier;
            }
            if (direction == GameConstants.Up)
            {
                finalPos = (int)location.Y - LinkConstants.FirePosChange * LinkConstants.FireMultiplier;
            }
        }

        public bool CheckFinalPos()
        {
            return ((direction == GameConstants.Down && currentY > stillPos) ||
                (direction == GameConstants.Left && currentX < stillPos) ||
                (direction == GameConstants.Right && currentX > stillPos) ||
                (direction == GameConstants.Up && currentY < stillPos));
        }

        public void Update()
        {
            // distance updates
            if (updatePos && toDraw)
            {
                if (direction == GameConstants.Down && currentY <= finalPos)
                    currentY += LinkConstants.FirePosChange; // magic?
                if (direction == GameConstants.Left && currentX >= finalPos)
                    currentX -= LinkConstants.FirePosChange;
                if (direction == GameConstants.Right && currentX <= finalPos)
                    currentX += LinkConstants.FirePosChange;
                if (direction == GameConstants.Up && currentY >= finalPos)
                    currentY -= LinkConstants.FirePosChange;
            }

           // overall frame updates
           currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = GameConstants.Zero;

            FrameUpdate();
        }

        public void FrameUpdate()
        {
            frame = GameConstants.Frame0;
            if (currentFrame <= LinkConstants.FirePhase)
                frame = GameConstants.Frame0;
            else if (currentFrame > LinkConstants.FirePhase)
                frame = GameConstants.Frame1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;

            if (toDraw)
            {
                if (direction == GameConstants.Down && currentY >= finalPos || direction == GameConstants.Left && currentX <= finalPos ||
                    direction == GameConstants.Right && currentX >= finalPos || direction == GameConstants.Up && currentY <= finalPos)
                {
                    // update standing still, StillCount times
                    if (count >= LinkConstants.StillCount)
                        toDraw = false;

                    count++;
                }

                source = FireList[frame]; // frame
                dest = new Rectangle((int)currentX, (int)currentY, source.Width*GameConstants.Sizing, source.Height*GameConstants.Sizing);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
