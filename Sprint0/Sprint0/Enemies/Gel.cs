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
    public class Gel : ISprite
    {
        public int currentFrame, frame, random, textureFrame, totalFrames;
        public Vector2 location;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Gel1,
            EnemyTextureStorage.Gel2
        };

        public Gel(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            location = coords;
            random = EnemyConstants.Left;
            totalFrames = EnemyConstants.GelTotalFrames;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == EnemyConstants.GelTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = EnemyConstants.Zero;
                if (random == EnemyConstants.GelStatic)
                {
                    random = RNG.Next(EnemyConstants.Down, EnemyConstants.GelStatic);
                    totalFrames = RNG.Next(EnemyConstants.GelMinFrame, EnemyConstants.GelMaxFrame);
                }
                else
                {
                    random = EnemyConstants.GelStatic;
                    totalFrames = EnemyConstants.GelStaticTime;
                }

            }
            if (currentFrame % EnemyConstants.GelFrameChange == EnemyConstants.Zero)
            {
                switch (random)
                {
                    case EnemyConstants.Down:
                        location.Y += EnemyConstants.GelDisplacement;
                        break;
                    case EnemyConstants.Left:
                        location.X -= EnemyConstants.GelDisplacement;
                        break;
                    case EnemyConstants.Right:
                        location.X += EnemyConstants.GelDisplacement;
                        break;
                    case EnemyConstants.Up:
                        location.Y -= EnemyConstants.GelDisplacement;
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