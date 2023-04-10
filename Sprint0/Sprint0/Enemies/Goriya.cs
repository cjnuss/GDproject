using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Security.Principal;

namespace Sprint0
{
    public class Goriya : ISprite
    {
        public int frame, textureFrame, currentFrame, direction, boomerangCount, totalFrames;
        public Vector2 location;
        private Texture2D texture;
        public System.Random RNG = new System.Random();
        public Boolean boomerang;
        ISprite projectileSprite;

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
            GoriyaDown,
            GoriyaLeft,
            GoriyaRight,
            GoriyaUp
        };

        private static List<Texture2D> textures = new List<Texture2D>
        {
            EnemyTextureStorage.Instance.GetEnemies1(),
            EnemyTextureStorage.Instance.GetEnemies1Flipped()
        };


        public Goriya(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            direction = RNG.Next(EnemyConstants.Zero, EnemyConstants.Up + EnemyConstants.One);
            location = coords;
            boomerangCount = EnemyConstants.Zero;
            totalFrames = EnemyConstants.GoriyaTotalFrames;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == EnemyConstants.GoriyaTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            currentFrame++;
            if (currentFrame >= totalFrames && !boomerang)
            {
                currentFrame = EnemyConstants.Zero;
                direction = RNG.Next(EnemyConstants.Zero, EnemyConstants.Up + EnemyConstants.One);
                if (direction == 1 | direction == 2)
                {
                    totalFrames = RNG.Next(EnemyConstants.GoriyaMinFrame, EnemyConstants.GoriyaMaxFrame) * EnemyConstants.GoriyaXFrames;
                }
                else
                {
                    totalFrames = RNG.Next(EnemyConstants.GoriyaMinFrame, EnemyConstants.GoriyaMaxFrame) * EnemyConstants.GoriyaYFrames;
                }
            }

            boomerangCount++;
            if (boomerangCount == EnemyConstants.GoriyaProjCount)
            {
                projectileSprite = new GoriyaProjectile(location, direction);
                boomerang = true;
            }
            else if (boomerangCount == (EnemyConstants.GoriyaProjCount + EnemyConstants.GoriyaProjTime))
            {
                boomerang = false;
                boomerangCount = EnemyConstants.Zero;
            }

            if (currentFrame % EnemyConstants.GoriyaFrameChange == EnemyConstants.Zero && !boomerang)
            {
                switch (direction)
                {
                    case EnemyConstants.Down:
                        location.Y += EnemyConstants.GoriyaDisplacement;
                        break;
                    case EnemyConstants.Left:
                        location.X -= EnemyConstants.GoriyaDisplacement;
                        break;
                    case EnemyConstants.Right:
                        location.X += EnemyConstants.GoriyaDisplacement;
                        break;
                    case EnemyConstants.Up:
                        location.Y -= EnemyConstants.GoriyaDisplacement;
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
            if (textureFrame <= EnemyConstants.Texture2)
            {
                if (direction == EnemyConstants.Left)
                {
                    texture = textures[EnemyConstants.Frame2];
                }
                else
                {
                    texture = textures[EnemyConstants.Frame1];
                }
                frame = EnemyConstants.Frame1;
            }
            else if (textureFrame > EnemyConstants.Texture2)
            {
                if (direction == EnemyConstants.Right)
                {
                    texture = textures[EnemyConstants.Frame1];
                }
                else
                {
                    texture = textures[EnemyConstants.Frame2];
                }
                frame = EnemyConstants.Frame2;
            }

            Rectangle source = frames[direction][frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
            spriteBatch.Draw(texture, destinaton, source, Color.White);

            if (boomerang)
            {
                projectileSprite.Draw(spriteBatch);
            }
        }
    }
}
