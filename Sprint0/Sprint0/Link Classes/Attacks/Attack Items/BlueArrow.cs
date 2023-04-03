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
    public class BlueArrow : ISprite
    {
        public int frame, currentFrame, totalFrames, direction, currentX, currentY, finalPos, poofPos;
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        // DEBUG: CHANGE EVERYTHING BELOW THIS LINE

        private Texture2D texture;

        private static List<Rectangle> LinkBlueArrowDown = new List<Rectangle>
        {
            LinkTextureStorage.LinkBlueArrowDown,
            LinkTextureStorage.LinkBlueArrowDown1,
            LinkTextureStorage.LinkBlueArrowDown2
        };

        private static List<Rectangle> LinkBlueArrowLeft = new List<Rectangle>
        {
            LinkTextureStorage.LinkBlueArrowLeft,
            LinkTextureStorage.LinkBlueArrowLeft1,
            LinkTextureStorage.LinkBlueArrowLeft2
        };

        private static List<Rectangle> LinkBlueArrowRight = new List<Rectangle>
        {
            LinkTextureStorage.LinkBlueArrowRight,
            LinkTextureStorage.LinkBlueArrowRight1,
            LinkTextureStorage.LinkBlueArrowRight2
        };

        private static List<Rectangle> LinkBlueArrowUp = new List<Rectangle>
        {
            LinkTextureStorage.LinkBlueArrowUp,
            LinkTextureStorage.LinkBlueArrowUp1,
            LinkTextureStorage.LinkBlueArrowUp2
        };

        private static List<List<Rectangle>> directions = new List<List<Rectangle>>
        {
            LinkBlueArrowDown,
            LinkBlueArrowLeft,
            LinkBlueArrowRight,
            LinkBlueArrowUp
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();
        private Texture2D _texture2 = LinkTextureStorage.Instance.GetUpsideDown();

        public BlueArrow()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 30;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == 0)
            {
                finalPos = (int)location.Y + 7 * 32; // changed mult to 32
                poofPos = finalPos + 7;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - 7 * 32;
                poofPos = finalPos - 7;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + 7 * 32;
                poofPos = finalPos + 7;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - 7 * 32;
                poofPos = finalPos - 7;
            }
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
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;
            List<Rectangle> thisDirectionArrows = directions[direction];

            if (toDraw)
            {
                // pos checks
                // down
                if (direction == 0)
                {
                    texture = _texture2; 
                    if (currentY <= finalPos)
                    {
                        source = thisDirectionArrows[0];
                        dest = new Rectangle(currentX, currentY, 10, 32); // magic?
                    }
                    else if (currentY <= poofPos)
                    {
                        source = thisDirectionArrows[1];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                    }
                    else
                    {
                        source = thisDirectionArrows[2];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                        toDraw = false;
                    }
                }

                // left
                if (direction == 1)
                {
                    texture = _texture;
                    if (currentX >= finalPos)
                    {
                        source = thisDirectionArrows[0];
                        dest = new Rectangle(currentX, currentY, 32, 10); // magic?
                    }
                    else if (currentX >= poofPos)
                    {
                        source = thisDirectionArrows[1];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                    }
                    else
                    {
                        source = thisDirectionArrows[2];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                        toDraw = false;
                    }
                }

                // right
                if (direction == 2)
                {
                    texture = _texture;
                    if (currentX <= finalPos)
                    {
                        source = thisDirectionArrows[0];
                        dest = new Rectangle(currentX, currentY, 32, 10); // magic?
                    }
                    else if (currentX <= poofPos)
                    {
                        source = thisDirectionArrows[1];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                    }
                    else
                    {
                        source = thisDirectionArrows[2];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                        toDraw = false;
                    }
                }

                if (direction == 3)
                {
                    texture = _texture;
                    if (currentY >= finalPos)
                    {
                        source = thisDirectionArrows[0];
                        dest = new Rectangle(currentX, currentY, 10, 32); // magic?
                    }
                    else if (currentY >= poofPos)
                    {
                        source = thisDirectionArrows[1];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                    }
                    else
                    {
                        source = thisDirectionArrows[2];
                        dest = new Rectangle(currentX, currentY, 16, 16);
                        toDraw = false;
                    }
                }
            }

            // finally draw sprite
            spriteBatch.Draw(texture, dest, source, Color.White);
        }
    }
}
