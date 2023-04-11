using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Sprint0;

namespace Sprint0
{
    public class Skeleton : ISprite
    {
        public int currentFrame, textureFrame, totalFrames, frame, random;
        private Vector2 location;
        private Texture2D texture;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.SkeletonSource,
            EnemyTextureStorage.SkeletonFlippedSource
        };
        private static List<Texture2D> textures = new List<Texture2D>
        {
            EnemyTextureStorage.Instance.GetEnemies1(),
            EnemyTextureStorage.Instance.GetEnemies1Flipped(),
        };

        public Skeleton(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            location = coords;
            random = EnemyConstants.Left;
            totalFrames = EnemyConstants.SkeletonTotalFrames;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == EnemyConstants.SkeletonTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = EnemyConstants.Zero;
                random = RNG.Next(EnemyConstants.Zero, EnemyConstants.Up + EnemyConstants.One);
                if (random == 1 | random == 2)
                {
                    totalFrames = RNG.Next(EnemyConstants.SkeletonMinFrame, EnemyConstants.SkeletonMaxFrame) * EnemyConstants.SkeletonXFrames;
                } else
                {
                    totalFrames = RNG.Next(EnemyConstants.SkeletonMinFrame, EnemyConstants.SkeletonMaxFrame) * EnemyConstants.SkeletonYFrames;
                }
            }
            if (currentFrame % EnemyConstants.SkeletonFrameChange == EnemyConstants.Zero)
            {
                switch (random)
                {
                    case EnemyConstants.Down:
                        location.Y += EnemyConstants.SkeletonDisplacement;
                        break;
                    case EnemyConstants.Left:
                        location.X -= EnemyConstants.SkeletonDisplacement;
                        break;
                    case EnemyConstants.Right:
                        location.X += EnemyConstants.SkeletonDisplacement;
                        break;
                    case EnemyConstants.Up:
                        location.Y -= EnemyConstants.SkeletonDisplacement;
                        break;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame <= EnemyConstants.SkeletonTexture1)
            {
                texture = textures[EnemyConstants.Frame1];
                frame = EnemyConstants.Frame1;
            }
            else if (textureFrame > EnemyConstants.SkeletonTexture1)
            {
                texture = textures[EnemyConstants.Frame2];
                frame = EnemyConstants.Frame2;
            }

            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
