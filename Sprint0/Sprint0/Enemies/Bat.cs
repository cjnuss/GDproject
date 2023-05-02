using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Data.Common;

namespace Sprint0
{
    public class Bat : IEnemy
    {
        private Texture2D texture;
        private Vector2 deathLoc;
        private int width = 16;
        private int height = 9;
        public bool toDraw = true;
        private bool death = false;
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

        public int currentFrame, textureFrame, frame, random, totalFrames;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Bat1,
            EnemyTextureStorage.Bat2
        };

        private static List<Rectangle> deathFrames = new List<Rectangle>
        {
            EnemyTextureStorage.EnemyDeath1,
            EnemyTextureStorage.EnemyDeath2,
            EnemyTextureStorage.EnemyDeath3,
            EnemyTextureStorage.EnemyDeath4,
            new Rectangle(0,0,0,0)
        };

        public Bat(Vector2 coords)
        {
            currentFrame = EnemyConstants.Zero;
            textureFrame = EnemyConstants.Zero;
            location = coords;
            random = EnemyConstants.Right;
            totalFrames = EnemyConstants.BatTotalFrames;
            height = 10;
            width = 10;
        }

        public void Update()
        {
            if (toDraw)
            {
                textureFrame++;
                if (textureFrame == EnemyConstants.BatTextureFrames)
                {
                    textureFrame = EnemyConstants.Zero;
                }
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = EnemyConstants.Zero;
                    random = RNG.Next(EnemyConstants.Zero, EnemyConstants.NW + EnemyConstants.One);
                    totalFrames = RNG.Next(EnemyConstants.BatMinFrame, EnemyConstants.BatMaxFrame);
                }
                if (currentFrame % EnemyConstants.BatFrameChange == EnemyConstants.Zero)
                {
                    switch (random)
                    {
                        case EnemyConstants.Down:
                            location.Y += EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.Left:
                            location.X -= EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.Right:
                            location.X += EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.Up:
                            location.Y -= EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.NE:
                            location.X += EnemyConstants.BatDisplacement;
                            location.Y -= EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.SE:
                            location.X += EnemyConstants.BatDisplacement;
                            location.Y += EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.SW:
                            location.X -= EnemyConstants.BatDisplacement;
                            location.Y += EnemyConstants.BatDisplacement;
                            break;
                        case EnemyConstants.NW:
                            location.X -= EnemyConstants.BatDisplacement;
                            location.Y -= EnemyConstants.BatDisplacement;
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

                texture = EnemyTextureStorage.Instance.GetEnemies1();
                source = frames[frame];
                destination = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destination, source, Color.White);
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
