using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Sprint0
{
    public class Gel : IEnemy
    {
        private int width = EnemyConstants.GelWidth;
        private int height = EnemyConstants.GelHeight;
        private Texture2D texture;
        private Vector2 deathLoc;
        //private int width;
        //private int height;
        public bool toDraw = true;
        public bool death = false;
        private Rectangle source;
        private Rectangle destination;

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

        public int currentFrame, frame, random, textureFrame, totalFrames;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Gel1,
            EnemyTextureStorage.Gel2
        };

        private static List<Rectangle> deathFrames = new List<Rectangle>
        {
            EnemyTextureStorage.EnemyDeath1,
            EnemyTextureStorage.EnemyDeath2,
            EnemyTextureStorage.EnemyDeath3,
            EnemyTextureStorage.EnemyDeath4,
            Rectangle.Empty
        };

        public Gel(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            location = coords;
            location.X += EnemyConstants.GelXOffset;
            random = EnemyConstants.Left;
            totalFrames = EnemyConstants.GelTotalFrames;
            width = 20;
            height = 20;
        }

        public void Update()
        {
            if (toDraw)
            {
                textureFrame++;
                if (textureFrame == EnemyConstants.GelTextureFrames)
                {
                    textureFrame = EnemyConstants.Zero;
                }
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = EnemyConstants.Zero;
                    if (random == EnemyConstants.GelStatic)
                    {
                        random = RNG.Next(EnemyConstants.Down, EnemyConstants.GelStatic);
                        if (random == 1 | random == 2)
                        {
                            totalFrames = RNG.Next(EnemyConstants.GelMinFrame, EnemyConstants.GelMaxFrame) * EnemyConstants.GelXFrames;
                        }
                        else
                        {
                            totalFrames = RNG.Next(EnemyConstants.GelMinFrame, EnemyConstants.GelMaxFrame) * EnemyConstants.GelYFrames;
                        }
                    }
                    else
                    {
                        random = EnemyConstants.GelStatic;
                        totalFrames = EnemyConstants.GelStaticTime;
                    }

                }
                if (currentFrame % EnemyConstants.GelFrameChange == EnemyConstants.Zero)
                {
                    switch (random)
                    {
                        case EnemyConstants.Down:
                            location.Y += EnemyConstants.GelDisplacement;
                            break;
                        case EnemyConstants.Left:
                            location.X -= EnemyConstants.GelDisplacement;
                            break;
                        case EnemyConstants.Right:
                            location.X += EnemyConstants.GelDisplacement;
                            break;
                        case EnemyConstants.Up:
                            location.Y -= EnemyConstants.GelDisplacement;
                            break;
                    }
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
                if (textureFrame <= EnemyConstants.Texture1)
                {
                    frame = EnemyConstants.Frame1;
                }
                else if (textureFrame > EnemyConstants.Texture1)
                {
                    frame = EnemyConstants.Frame2;
                }

                Texture2D texture = EnemyTextureStorage.Instance.GetEnemies1();
                Rectangle source = frames[frame];
                Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destinaton, source, Color.White);
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