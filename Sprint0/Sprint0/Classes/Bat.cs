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
    public class Bat : ISprite1
    {
        public int currentFrame, textureFrame, frame;
        public int totalFrames = 40;
        public int textureFrame1 = 10;
        public Vector2 location;
        public int random = 1;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Bat1,
            EnemyTextureStorage.Bat2
        };

        public Bat()
        {
            currentFrame = 0;
            textureFrame = 0;
            location = new Vector2(600, 240) ;
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
                random = RNG.Next(1, 9);
                totalFrames = RNG.Next(45, 75);
            }
            if (currentFrame % 10 == 0)
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
                    case 5:
                        location.X += 6;
                        location.Y += 6;
                        break;
                    case 6:
                        location.X += 6;
                        location.Y -= 6;
                        break;
                    case 7:
                        location.X -= 6;
                        location.Y += 6;
                        break;
                    case 8:
                        location.X -= 6;
                        location.Y -= 6;
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
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width, source.Height);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
