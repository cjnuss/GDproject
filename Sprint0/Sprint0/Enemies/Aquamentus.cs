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
            new Rectangle(0,0,0,0)
        };

        private static List<Rectangle> deathFrames = new List<Rectangle>
        {
            EnemyTextureStorage.EnemyDeath1,
            EnemyTextureStorage.EnemyDeath2,
            EnemyTextureStorage.EnemyDeath3,
            EnemyTextureStorage.EnemyDeath4,
            new Rectangle(0,0,0,0)
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
            if (toDraw)
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

            if (hit)
            {
                // aquamentus does not get pushed back when hit
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
                if (textureFrame < EnemyConstants.Texture1)
                    frame = EnemyConstants.Frame1;
                else if (textureFrame < EnemyConstants.Texture2)
                    frame = EnemyConstants.Frame2;
                else if (textureFrame < EnemyConstants.Texture3)
                    frame = EnemyConstants.Frame3;
                else if (textureFrame >= EnemyConstants.Texture3)
                    frame = EnemyConstants.Frame4;

                texture = EnemyTextureStorage.Instance.GetEnemies();
                Rectangle source = frames[frame];
                Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destinaton, source, Color.White);
                projectileSprite.Draw(spriteBatch);
            }

            if (hit)
            {
                count++;

                // add flipped source?
                if (count <= 10 && count >= 7 || count <= 18 && count >= 15)
                {
                    System.Diagnostics.Debug.WriteLine("drawing flashing");
                    source = frames[EnemyConstants.Frame5];

                }
                else
                    source = frames[EnemyConstants.Frame1];

                texture = EnemyTextureStorage.Instance.GetEnemies();
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
        }

        public void Dispose()
        {
            currentFrame = GameConstants.Zero;
            deathLoc = location;
            location = new Vector2(GameConstants.Zero, GameConstants.Zero); // debug : can hit dead enemies when this is loc
            toDraw = false;
            death = true;
            projectile = false;
        }
    }
}
