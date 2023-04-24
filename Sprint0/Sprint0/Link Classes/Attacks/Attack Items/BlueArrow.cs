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
            direction = GameConstants.Zero;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.TotalBlueArrowFrames;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == GameConstants.Down)
            {
                finalPos = (int)location.Y + LinkConstants.BlueArrowPosChange * LinkConstants.BlueArrowMultiplier; // changed mult to 32
                poofPos = finalPos + LinkConstants.BlueArrowPosChange;
            }
            if (direction == GameConstants.Left)
            {
                finalPos = (int)location.X - LinkConstants.BlueArrowPosChange * LinkConstants.BlueArrowMultiplier;
                poofPos = finalPos - LinkConstants.BlueArrowPosChange;
            }
            if (direction == GameConstants.Right)
            {
                finalPos = (int)location.X + LinkConstants.BlueArrowPosChange * LinkConstants.BlueArrowMultiplier;
                poofPos = finalPos + LinkConstants.BlueArrowPosChange;
            }
            if (direction == GameConstants.Up)
            {
                finalPos = (int)location.Y - LinkConstants.BlueArrowPosChange * LinkConstants.BlueArrowMultiplier;
                poofPos = finalPos - LinkConstants.BlueArrowPosChange;
            }
        }

        public void Update()
        {
            if (toDraw)
            {
                if (direction == GameConstants.Down)
                    currentY += LinkConstants.BlueArrowPosChange; // magic?
                if (direction == GameConstants.Left)
                    currentX -= LinkConstants.BlueArrowPosChange;
                if (direction == GameConstants.Right)
                    currentX += LinkConstants.BlueArrowPosChange;
                if (direction == GameConstants.Up)
                    currentY -= LinkConstants.BlueArrowPosChange;
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
                    texture = _texture2; 
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
                    texture = _texture;
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
                    texture = _texture;
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
                    texture = _texture;
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

        public void Dispose()
        {
            toDraw = false;
            currentX = GameConstants.Zero; currentY = GameConstants.Zero;
        }
    }
}
