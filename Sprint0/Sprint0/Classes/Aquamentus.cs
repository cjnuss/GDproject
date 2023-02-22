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
    public class Aquamentus : ISprite1
    {
        public int totalFrames = 20;
        public int textureFrame1 = 20;
        public Vector2 location;
        public int frame, currentFrame, textureFrame, random, projectileCount;
        public bool projectile;
        private ISprite1 projectileSprite;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Aquamentus1,
            EnemyTextureStorage.Aquamentus2,
            EnemyTextureStorage.Aquamentus3,
            EnemyTextureStorage.Aquamentus4,
        };

        public Aquamentus()
        {
            currentFrame = 0;
            textureFrame = 0;
            projectileCount = 0;
            location = new Vector2(600, 240);
            random = 2;
            projectile = true;
        }

        public void Update()
        {
            if (projectileCount == 0)
            {
                projectileSprite = new AquamentusProjectile(location);
            }
            projectileCount++;
            textureFrame++;
            currentFrame++;
            if (textureFrame == textureFrame1)
            {
                textureFrame = 0;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                random = RNG.Next(1, 3);
                totalFrames = RNG.Next(20, 50);
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
                }
            }
            if (projectileCount == 250)
            {
                projectileCount = 0;
            }
            projectileSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame < 5)
                frame = 0;
            else if (textureFrame >= 5 && textureFrame < 10)
                frame = 1;
            else if (textureFrame >= 10 && textureFrame < 15)
                frame = 2;
            else if (textureFrame >= 20)
                frame = 3;

            Texture2D texture = EnemyTextureStorage.Instance.GetEnemies();
            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * 2, source.Height * 2);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
            projectileSprite.Draw(spriteBatch);
        }
    }
}
