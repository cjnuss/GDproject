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
    public class GreenArrow : ISprite
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
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.TotalGreenArrowFrames;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;
            
            if (direction == GameConstants.Down)
            {
                finalPos = (int)location.Y + LinkConstants.GreenArrowPosChange * LinkConstants.GreenArrowMultiplier;
                poofPos = finalPos + LinkConstants.GreenArrowPosChange;
            }
            if (direction == 1)
            {
                finalPos = (int)location.X - LinkConstants.GreenArrowPosChange * LinkConstants.GreenArrowMultiplier;
                poofPos = finalPos - LinkConstants.GreenArrowPosChange;
            }
            if (direction == 2)
            {
                finalPos = (int)location.X + LinkConstants.GreenArrowPosChange * LinkConstants.GreenArrowMultiplier;
                poofPos = finalPos + LinkConstants.GreenArrowPosChange;
            }
            if (direction == 3)
            {
                finalPos = (int)location.Y - LinkConstants.GreenArrowPosChange * LinkConstants.GreenArrowMultiplier;
                poofPos = finalPos - LinkConstants.GreenArrowPosChange;
            }
        }

        public bool CheckFinalPos()
        {
            return ((direction == GameConstants.Down && currentY > poofPos) ||
                (direction == GameConstants.Left && currentX < poofPos) ||
                (direction == GameConstants.Right && currentX > poofPos) ||
                (direction == GameConstants.Up && currentY < poofPos));
        }

        public void Update()
        {
            if (toDraw)
            {
                if (direction == GameConstants.Down)
                    currentY += LinkConstants.GreenArrowPosChange;
                if (direction == GameConstants.Left)
                    currentX -= LinkConstants.GreenArrowPosChange;
                if (direction == GameConstants.Right)
                    currentX += LinkConstants.GreenArrowPosChange;
                if (direction == GameConstants.Up)
                    currentY -= LinkConstants.GreenArrowPosChange;
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
                if (direction == GameConstants.Down)
                {
                    if (currentY <= finalPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame0];
                    }
                    else if (currentY <= poofPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame1];
                    }
                    else
                    {
                        source = thisDirectionArrows[GameConstants.Frame2];
                        toDraw = false;
                    }
                }

                // left
                if (direction == GameConstants.Left)
                {
                    if (currentX >= finalPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame0];
                    }
                    else if (currentX >= poofPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame1];
                    }
                    else
                    {
                        source = thisDirectionArrows[GameConstants.Frame2];
                        toDraw = false;
                    }
                }

                // right
                if (direction == GameConstants.Right)
                {
                    if (currentX <= finalPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame0];
                    }
                    else if (currentX <= poofPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame1];
                    }
                    else
                    {
                        source = thisDirectionArrows[GameConstants.Frame2];
                        toDraw = false;
                    }

                }

                if (direction == GameConstants.Up)
                {
                    if (currentY >= finalPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame0];
                    }
                    else if (currentY >= poofPos)
                    {
                        source = thisDirectionArrows[GameConstants.Frame1];
                    }
                    else
                    {
                        source = thisDirectionArrows[GameConstants.Frame2];
                        toDraw = false;
                    }
                }
            }

            dest = new Rectangle(currentX, currentY, source.Width * GameConstants.Sizing, source.Height * GameConstants.Sizing);
            spriteBatch.Draw(texture, dest, source, Color.White);
        }
    }
}
