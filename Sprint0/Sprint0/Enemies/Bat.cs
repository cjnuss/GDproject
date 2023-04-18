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
        private int width;
        private int height;
        public bool toDraw = true;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame <= EnemyConstants.Texture1)
            {
                frame = EnemyConstants.Frame1;
            }
            else if (textureFrame > EnemyConstants.Texture1)
            {
                frame = EnemyConstants.Frame2;
            }

            if (toDraw)
            {
                Texture2D texture = EnemyTextureStorage.Instance.GetEnemies1();
                source = frames[frame];
                destination = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destination, source, Color.White);
            }
        }
    }
}
