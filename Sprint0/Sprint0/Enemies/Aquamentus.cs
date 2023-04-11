using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Xml.Linq;

namespace Sprint0
{
    public class Aquamentus : IEnemy
    {
        private int width;
        private int height;

        public Vector2 GetSize()
        {
            return new Vector2(width, height);
        }

        public Vector2 location;
        public Vector2 GetLocation()
        {
            return location;
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        public int frame, currentFrame, totalFrames, textureFrame, random, projCount;
        public bool projectile;
        private IEnemy projectileSprite;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Aquamentus1,
            EnemyTextureStorage.Aquamentus2,
            EnemyTextureStorage.Aquamentus3,
            EnemyTextureStorage.Aquamentus4,
        };

        public Aquamentus(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            projCount = EnemyConstants.Zero;
            totalFrames = EnemyConstants.AquaTotalFrames;
            location = coords;
            random = EnemyConstants.Left;
            projectile = true;
            width = 20;
            height = 20;
        }

        public void Update()
        {
            if (projCount == EnemyConstants.Zero)
            {
                projectileSprite = new AquamentusProjectile(location);
            }
            projCount++;
            textureFrame++;
            currentFrame++;
            if (textureFrame == EnemyConstants.AquaTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = EnemyConstants.Zero;
                random = RNG.Next(EnemyConstants.Left, EnemyConstants.Right + EnemyConstants.One);
                totalFrames = RNG.Next(EnemyConstants.AquaMinFrame, EnemyConstants.AquaMaxFrame);
            }
            if (currentFrame % EnemyConstants.AquaFrameChange == EnemyConstants.Zero)
            {
                switch (random)
                {
                    case EnemyConstants.Left:
                        location.X -= EnemyConstants.AquaDisplacement;
                        break;
                    case EnemyConstants.Right:
                        location.X += EnemyConstants.AquaDisplacement;
                        break;
                }
            }
            if (projCount == EnemyConstants.AquaProjCount)
            {
                projCount = EnemyConstants.Zero;
            }
            projectileSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame < EnemyConstants.Texture1)
                frame = EnemyConstants.Frame1;
            else if (textureFrame < EnemyConstants.Texture2)
                frame = EnemyConstants.Frame2;
            else if (textureFrame < EnemyConstants.Texture3)
                frame = EnemyConstants.Frame3;
            else if (textureFrame >= EnemyConstants.Texture3)
                frame = EnemyConstants.Frame4;

            Texture2D texture = EnemyTextureStorage.Instance.GetEnemies();
            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
            projectileSprite.Draw(spriteBatch);
        }
    }
}
