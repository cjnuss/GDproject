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
    public class Goriya : ISprite1
    {
        public int frame, textureFrame, currentFrame, direction, boomerangCount;
        public int totalFrames = 40;
        public int textureFrame1 = 20;
        public Vector2 location;
        private Texture2D texture;
        public System.Random RNG = new System.Random();
        public Boolean boomerang;
        ISprite1 projectileSprite;

        private static List<Rectangle> GoriyaUp = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaUp,
            EnemyTextureStorage.GoriyaUp1
        };

        private static List<Rectangle> GoriyaDown = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaDown,
            EnemyTextureStorage.GoriyaDown1
        };

        private static List<Rectangle> GoriyaLeft = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaLeft,
            EnemyTextureStorage.GoriyaLeft1
        };

        private static List<Rectangle> GoriyaRight = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaRight,
            EnemyTextureStorage.GoriyaRight1
        };

        private static List<List<Rectangle>> frames = new List<List<Rectangle>>
        {
            GoriyaUp,
            GoriyaDown,
            GoriyaLeft,
            GoriyaRight
        };

        private static List<Texture2D> textures = new List<Texture2D>
        {
            EnemyTextureStorage.Instance.GetEnemies1(),
            EnemyTextureStorage.Instance.GetEnemies1Flipped()
        };


        public Goriya()
        {
            currentFrame = 0;
            textureFrame = 0;
            direction = RNG.Next(0, 4);
            location = new Vector2(200, 150);
            boomerangCount = 0;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == textureFrame1)
            {
                textureFrame = 0;
            }
            currentFrame++;
            if (currentFrame >= totalFrames && !boomerang)
            {
                currentFrame = 0;
                direction = RNG.Next(0, 4);
                totalFrames = RNG.Next(30, 60);
            }

            boomerangCount++;
            if (boomerangCount == 500)
            {
                projectileSprite = new GoriyaProjectile(location, direction);
                boomerang = true;
            }
            else if (boomerangCount == 650)
            {
                boomerang = false;
                boomerangCount = 0;
            }

            if (currentFrame % 15 == 0 && !boomerang)
            {
                switch (direction)
                {
                    case 0:
                        location.Y -= 6;
                        break;
                    case 1:
                        location.Y += 6;
                        break;
                    case 2:
                        location.X -= 6;
                        break;
                    case 3:
                        location.X += 6;
                        break;
                }
            }
            if (boomerang)
            {
                projectileSprite.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame <= 10)
            {
                if (direction == 2)
                {
                    texture = textures[1];
                }
                else
                {
                    texture = textures[0];
                }
                frame = 0;
            }
            else if (textureFrame > 10)
            {
                if (direction == 3)
                {
                    texture = textures[0];
                }
                else
                {
                    texture = textures[1];
                }
                frame = 1;
            }

            Rectangle source = frames[direction][frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width, source.Height);
            spriteBatch.Draw(texture, destinaton, source, Color.White);

            if (boomerang)
            {
                projectileSprite.Draw(spriteBatch);
            }
        }
    }
}
