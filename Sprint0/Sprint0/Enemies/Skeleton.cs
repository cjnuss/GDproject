using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Sprint0;
using System.Runtime.CompilerServices;

namespace Sprint0
{
    public class Skeleton : IEnemy
    {
        private Texture2D texture;
        private Vector2 deathLoc;
        private int direction;
        public bool toDraw = true;
        private bool death = false;
        private Rectangle source;
        private Rectangle destination;
        public Vector2 location;
        public int hits = GameConstants.Zero, count = GameConstants.Zero;
        public bool hit = false;

        public Vector2 GetLocation()
        {
            return location;
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        private int width;
        private int height;

        public Vector2 GetSize()
        {
            return new Vector2(width, height);
        }
        public int currentFrame, textureFrame, totalFrames, frame, random;

        //private Texture2D texture;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.SkeletonSource,
            EnemyTextureStorage.SkeletonFlippedSource,
            new Rectangle(0,0,0,0)
        };
        private static List<Texture2D> textures = new List<Texture2D>
        {
            EnemyTextureStorage.Instance.GetEnemies1(),
            EnemyTextureStorage.Instance.GetEnemies1Flipped(),
        };

        private static List<Rectangle> deathFrames = new List<Rectangle>
        {
            EnemyTextureStorage.EnemyDeath1,
            EnemyTextureStorage.EnemyDeath2,
            EnemyTextureStorage.EnemyDeath3,
            EnemyTextureStorage.EnemyDeath4,
            new Rectangle(0,0,0,0)
        };

        public Skeleton(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            location = coords;
            random = EnemyConstants.Left;
            totalFrames = EnemyConstants.SkeletonTotalFrames;
            width = 20;
            height = 20;
        }

        public void Update()
        {
            if (toDraw)
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
                    }
                    else
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

            if (hit)
            {
                if (direction == GameConstants.Left)
                    location.X -= GameConstants.EnemyPushBack;
                else if (direction == GameConstants.Right)
                    location.X += GameConstants.EnemyPushBack;
                else if (direction == GameConstants.Up)
                    location.Y -= GameConstants.EnemyPushBack;
                else
                    location.Y += GameConstants.EnemyPushBack;

                currentFrame++;
                if (count == 20)
                {
                    hit = false;
                }
            }

            if (death)
            {
                currentFrame++;
                if (currentFrame == EnemyConstants.DeathFrames)
                {
                    death = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (toDraw)
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

            if (hit)
            {
                count++;

                // add flipped source?
                if (count <= 10 && count >= 7 || count <= 18 && count >= 15)
                {
                    System.Diagnostics.Debug.WriteLine("drawing flashing");
                    source = frames[EnemyConstants.Frame3];
                    
                }
                else
                    source = frames[EnemyConstants.Frame1];

                Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destinaton, source, Color.DimGray);
            }

            if (death)
            {
                if (currentFrame <= EnemyConstants.DeathFrame1 || currentFrame > EnemyConstants.DeathFrame6 && currentFrame < EnemyConstants.DeathFrame7)
                    frame = EnemyConstants.Frame1;
                else if (currentFrame <= EnemyConstants.DeathFrame2 || currentFrame > EnemyConstants.DeathFrame5 && currentFrame <= EnemyConstants.DeathFrame6)
                    frame = EnemyConstants.Frame2;
                else if (currentFrame <= EnemyConstants.DeathFrame3 || currentFrame > EnemyConstants.DeathFrame4 && currentFrame <= EnemyConstants.DeathFrame5)
                    frame = EnemyConstants.Frame3;
                else if (currentFrame <= EnemyConstants.DeathFrame4 && currentFrame > EnemyConstants.DeathFrame3 && currentFrame <= EnemyConstants.DeathFrame4)
                    frame = EnemyConstants.Frame4;
                else if (currentFrame == EnemyConstants.DeathFrame7)
                    frame = EnemyConstants.Frame5;

                texture = EnemyTextureStorage.Instance.GetEnemyDeath();
                source = deathFrames[frame];
                destination = new Rectangle((int)deathLoc.X, (int)deathLoc.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destination, source, Color.White);
            }
        }

        public void Hit(int dir)
        {
            hits++;
            direction = dir;
            hit = true;
            currentFrame = GameConstants.Zero;
            count = GameConstants.Zero;
        }

        public void Dispose()
        {
            currentFrame = GameConstants.Zero;
            deathLoc = location;
            location = new Vector2(GameConstants.Zero, GameConstants.Zero); // debug : can hit dead enemies when this is loc
            toDraw = false;
            death = true;
        }
    }
}
