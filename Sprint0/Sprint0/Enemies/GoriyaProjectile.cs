using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Sprint0;

namespace Sprint0
{
    public class GoriyaProjectile : ISprite
    {
        public Vector2 location1;
        public int frame, textureFrame, currentFrame;
        public int totalFrames = 150;
        public int textureFrame1 = 20;
        private Boolean toDraw;
        private int direction1;

        private static List<Rectangle> projectile = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaProjectile1,
            EnemyTextureStorage.GoriyaProjectile2,
            EnemyTextureStorage.GoriyaProjectile3
        };

        public GoriyaProjectile(Vector2 location, int direction)
        {
            location1 = new Vector2(location.X + 8, location.Y);
            direction1 = direction;
            toDraw = true;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == textureFrame1)
            {
                textureFrame = 0;
            }
            if (currentFrame != totalFrames)
            {
                currentFrame++;
            }
            else
            {
                toDraw = false;
            }

            if (currentFrame % 5 == 0)
            {
                if (currentFrame <= 75)
                {
                    switch (direction1)
                    {
                        case 0:
                            location1.Y -= 5;
                            break;
                        case 1:
                            location1.Y += 5;
                            break;
                        case 2:
                            location1.X -= 5;
                            break;
                        case 3:
                            location1.X += 5;
                            break;
                    }
                }
                else
                {
                    switch (direction1)
                    {
                        case 0:
                            location1.Y += 5;
                            break;
                        case 1:
                            location1.Y -= 5;
                            break;
                        case 2:
                            location1.X += 5;
                            break;
                        case 3:
                            location1.X -= 5;
                            break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame != totalFrames)
            {
                if (textureFrame <= 5)
                    frame = 0;
                else if (textureFrame > 5 && textureFrame <= 10)
                    frame = 1;
                else if (textureFrame <= 15)
                    frame = 2;

                if (toDraw)
                {
                    Texture2D texture = EnemyTextureStorage.Instance.GetEnemies1();
                    Rectangle source = projectile[frame];
                    Rectangle destinaton = new Rectangle((int)location1.X, (int)location1.Y, source.Width * 3, source.Height * 3);
                    spriteBatch.Draw(texture, destinaton, source, Color.White);
                }
            }
        }
    }
}
