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
        public int currentFrame;
        public int totalFrames = 60;
        public int textureFrame;
        public int textureFrame1 = 14;
        private Vector2 location;
        public int frame;
        public int random;
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
            currentFrame = 0;
            textureFrame = 0;
            location = coords;
            random = 1;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == textureFrame1)
            {
                textureFrame = 0;
            }
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                random = RNG.Next(1, 5);
                totalFrames = RNG.Next(30, 60);
            }
            if (currentFrame % 15 == 0)
            {
                switch (random)
                {
                    case 1:
                        location.X -= 6;
                        break;
                    case 2:
                        location.X += 6;
                        break;
                    case 3:
                        location.Y -= 6;
                        break;
                    case 4:
                        location.Y += 6;
                        break;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame <= 7)
            {
                texture = textures[0];
                frame = 0;
            }
            else if (textureFrame > 7)
            {
                texture = textures[1];
                frame = 1;
            }

            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * 2, source.Height * 2);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
