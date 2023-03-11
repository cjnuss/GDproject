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
        public int currentFrame;
        public int totalFrames = 40;
        public Vector2 location;
        public int frame;
        public int random;
        public int textureFrame;
        public int textureFrame1 = 10;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Gel1,
            EnemyTextureStorage.Gel2
        };

        public Gel(Vector2 coords)
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
                if (random == 5)
                {
                    random = RNG.Next(1, 5);
                    totalFrames = RNG.Next(50, 120);
                }
                else
                {
                    random = 5;
                    totalFrames = 80;
                }

            }
            if (currentFrame % 10 == 0)
            {
                switch (random)
                {
                    case 1:
                        location.X -= 5;
                        break;
                    case 2:
                        location.X += 5;
                        break;
                    case 3:
                        location.Y -= 5;
                        break;
                    case 4:
                        location.Y += 5;
                        break;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame <= 5)
            {
                frame = 0;
            }
            else if (textureFrame > 5)
            {
                frame = 1;
            }

            Texture2D texture = EnemyTextureStorage.Instance.GetEnemies1();
            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}