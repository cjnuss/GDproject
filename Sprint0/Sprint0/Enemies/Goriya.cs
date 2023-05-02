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
    public class Goriya : IEnemy
    {
        private int width = EnemyConstants.GoriyaSize;
        private int height = EnemyConstants.GoriyaSize;
        private Texture2D texture;
        private Vector2 deathLoc;
        private int direction;
        public bool toDraw = true;
        public bool death = false;
        private Rectangle source;
        private Rectangle destination;
        public Vector2 location;
        public int hits = GameConstants.Zero, count = GameConstants.Zero;
        public bool hit = false;

        public Vector2 GetSize()
        {
            return new Vector2(width, height);
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        public int frame, textureFrame, currentFrame, boomerangCount, totalFrames;
        public System.Random RNG = new System.Random();
        public Boolean boomerang;
        IEnemy projectileSprite;

        private static List<Rectangle> GoriyaUp = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaUp,
            EnemyTextureStorage.GoriyaUp1,
            new Rectangle(0,0,0,0)
        };

        private static List<Rectangle> GoriyaDown = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaDown,
            EnemyTextureStorage.GoriyaDown1,
            new Rectangle(0,0,0,0)
        };

        private static List<Rectangle> GoriyaLeft = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaLeft,
            EnemyTextureStorage.GoriyaLeft1,
            new Rectangle(0,0,0,0)
        };

        private static List<Rectangle> GoriyaRight = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaRight,
            EnemyTextureStorage.GoriyaRight1,
            new Rectangle(0,0,0,0)
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

        private static List<Rectangle> deathFrames = new List<Rectangle>
        {
            EnemyTextureStorage.EnemyDeath1,
            EnemyTextureStorage.EnemyDeath2,
            EnemyTextureStorage.EnemyDeath3,
            EnemyTextureStorage.EnemyDeath4,
            Rectangle.Empty
        };


        public Goriya(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            direction = RNG.Next(EnemyConstants.Zero, EnemyConstants.Up + EnemyConstants.One);
            location = coords;
            boomerangCount = EnemyConstants.Zero;
            totalFrames = EnemyConstants.GoriyaTotalFrames;
            width = 20;
            height = 20;
        }

        public void Update()
        {
            if (toDraw)
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
            }

            if (boomerang)
            {
                projectileSprite.Draw(spriteBatch);
            }

            if (hit)
            {
                count++;

                // add flipped source?
                if (count <= 10 && count >= 7 || count <= 18 && count >= 15)
                {
                    System.Diagnostics.Debug.WriteLine("drawing flashing");
                    source = frames[direction][EnemyConstants.Frame3];

                }
                else
                    source = frames[direction][EnemyConstants.Frame1];

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
            boomerang = false;
        }
    }
}
