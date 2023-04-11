using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;

namespace Sprint0
{
    public class Bat : ISprite
    {
        public int currentFrame, textureFrame, frame, random, totalFrames;
        public Vector2 location;
        public System.Random RNG = new System.Random();
        public int height;
        public int width;

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Bat1,
            EnemyTextureStorage.Bat2
        };

        public Bat(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            location = coords;
            random = EnemyConstants.Right;
            totalFrames = EnemyConstants.BatTotalFrames;
            height = 10;
            width = 10;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == EnemyConstants.BatTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = EnemyConstants.Zero;
                random = RNG.Next(EnemyConstants.Zero, EnemyConstants.NW + EnemyConstants.One);
                totalFrames = RNG.Next(EnemyConstants.BatMinFrame, EnemyConstants.BatMaxFrame);
            }
            if (currentFrame % EnemyConstants.BatFrameChange == EnemyConstants.Zero)
            {
                switch (random)
                {
                    case EnemyConstants.Down:
                        location.Y += EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.Left:
                        location.X -= EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.Right:
                        location.X += EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.Up:
                        location.Y -= EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.NE:
                        location.X += EnemyConstants.BatDisplacement;
                        location.Y -= EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.SE:
                        location.X += EnemyConstants.BatDisplacement;
                        location.Y += EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.SW:
                        location.X -= EnemyConstants.BatDisplacement;
                        location.Y += EnemyConstants.BatDisplacement;
                        break;
                    case EnemyConstants.NW:
                        location.X -= EnemyConstants.BatDisplacement;
                        location.Y -= EnemyConstants.BatDisplacement;
                        break;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame <= EnemyConstants.Texture1)
            {
                frame = EnemyConstants.Frame1;
            }
            else if (textureFrame > EnemyConstants.Texture1)
            {
                frame = EnemyConstants.Frame2;
            }

            Texture2D texture = EnemyTextureStorage.Instance.GetEnemies1();
            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
