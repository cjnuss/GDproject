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
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> LinkSwordBeamDown = new List<Rectangle>
        {
            // LinkTextureStorage.LinkSwordBeamDown, 1, 2, 3,..
        };

        private static List<Rectangle> LinkSwordBeamLeft = new List<Rectangle>
        {
            // LinkTextureStorage.LinkSwordBeamLeft, 1, 2, 3,..
        };

        private static List<Rectangle> LinkSwordBeamRight = new List<Rectangle>
        {
            // LinkTextureStorage.LinkSwordBeamRight, 1, 2, 3,..
        };

        private static List<Rectangle> LinkSwordBeamUp = new List<Rectangle>
        {
            // LinkTextureStorage.LinkSwordBeamUp, 1, 2, 3,..
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public SwordBeam()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 30;
        }

        public void RegisterPos(Vector2 location)
        {
            if (direction == 0)
            {
                finalPos = (int)location.Y + 5 * 32; // changed to 32
                explodePos = finalPos + 5;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - 5 * 32;
                explodePos = finalPos - 5;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + 5 * 32;
                explodePos = finalPos + 5;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - 5 * 32;
                explodePos = finalPos - 5;
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
                    currentY += 5; // magic?
                if (direction == 1)
                    currentX -= 5;
                if (direction == 2)
                    currentX += 5;
                if (direction == 3)
                    currentY -= 5;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;
            List<Rectangle> thisDirectionSwordBeam; // = directions[direction]
            // logic below: AFTER SPRITESHEET UPDATES
        }
    }
}
