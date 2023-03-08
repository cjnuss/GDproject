using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;

namespace Sprint0.Link_Classes
{
    public class GreenArrow : ISprite1
    {
        public int frame, currentFrame, totalFrames, direction, currentX, currentY, finalPos, poofPos;
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> LinkGreenArrowDown = new List<Rectangle>
        {
            LinkTextureStorage.LinkGreenArrowDown,
            LinkTextureStorage.LinkGreenArrowDown1,
            LinkTextureStorage.LinkGreenArrowDown2
        };

        private static List<Rectangle> LinkGreenArrowLeft = new List<Rectangle>
        {
            LinkTextureStorage.LinkGreenArrowLeft,
            LinkTextureStorage.LinkGreenArrowLeft1,
            LinkTextureStorage.LinkGreenArrowLeft2
        };

        private static List<Rectangle> LinkGreenArrowRight = new List<Rectangle>
        {
            LinkTextureStorage.LinkGreenArrowRight,
            LinkTextureStorage.LinkGreenArrowRight1,
            LinkTextureStorage.LinkGreenArrowRight2
        };

        private static List<Rectangle> LinkGreenArrowUp = new List<Rectangle>
        {
            LinkTextureStorage.LinkGreenArrowUp,
            LinkTextureStorage.LinkGreenArrowUp1,
            LinkTextureStorage.LinkGreenArrowUp2
        };

        private static List<List<Rectangle>> directions = new List<List<Rectangle>>
        {
            LinkGreenArrowDown,
            LinkGreenArrowLeft,
            LinkGreenArrowRight,
            LinkGreenArrowUp
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public GreenArrow()
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
                finalPos = (int)location.Y + 5 * 16;
                poofPos = finalPos + 5;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - 5 * 16;
                poofPos = finalPos - 5;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + 5 * 16;
                poofPos = finalPos + 5;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - 5 * 16;
                poofPos = finalPos - 5;
            }
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
            List<Rectangle> thisDirectionArrows = directions[direction];

            if (toDraw)
            {
                // pos checks
                // down
                if (direction == 0)
                {
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
                    if (currentX >= finalPos)
                    {
                        source = thisDirectionArrows[0];
                        dest = new Rectangle(currentX, currentY, 32, 32); // magic?
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
                    if (currentX <= finalPos)
                    {
                        source = thisDirectionArrows[0];
                        dest = new Rectangle(currentX, currentY, 32, 32); // magic?
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
                // finally draw sprite
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
