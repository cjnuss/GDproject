using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Sprint0;

namespace Sprint0
{
    public class GoriyaProjectile : IEnemy
    {
        private int width;
        private int height;

        public Vector2 GetSize()
        {
            return new Vector2(width, height);
        }

        public Vector2 location1;
        public Vector2 GetLocation()
        {
            return location1;
        }

        public void SetLocation(Vector2 location)
        {
            location1 = location;
        }

        public int frame, textureFrame, currentFrame, direction1;
        public int totalFrames = EnemyConstants.GoriyaProjTime;
        private Boolean toDraw;

        private static List<Rectangle> projectile = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaProjectile1,
            EnemyTextureStorage.GoriyaProjectile2,
            EnemyTextureStorage.GoriyaProjectile3
        };

        public GoriyaProjectile(Vector2 location, int direction)
        {
            location1 = new Vector2(location.X + EnemyConstants.GoriyaProjXAdjustment, location.Y);
            direction1 = direction;
            toDraw = true;
            width = 20;
            height = 20;
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == EnemyConstants.GoriyaProjTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            if (currentFrame < totalFrames)
            {
                currentFrame++;
            }
            else
            {
                toDraw = false;
            }

            if (currentFrame % 5 == EnemyConstants.Zero)
            {
                if (currentFrame <= EnemyConstants.GoriyaProjChange)
                {
                    switch (direction1)
                    {
                        case EnemyConstants.Down:
                            location1.Y += EnemyConstants.GoriyaProjDisplacement;
                            break;
                        case EnemyConstants.Left:
                            location1.X -= EnemyConstants.GoriyaProjDisplacement;
                            break;
                        case EnemyConstants.Right:
                            location1.X += EnemyConstants.GoriyaProjDisplacement;
                            break;
                        case EnemyConstants.Up:
                            location1.Y -= EnemyConstants.GoriyaProjDisplacement;
                            break;
                    }
                }
                else
                {
                    switch (direction1)
                    {
                        case EnemyConstants.Down:
                            location1.Y -= EnemyConstants.GoriyaProjDisplacement;
                            break;
                        case EnemyConstants.Left:
                            location1.X += EnemyConstants.GoriyaProjDisplacement;
                            break;
                        case EnemyConstants.Right:
                            location1.X -= EnemyConstants.GoriyaProjDisplacement;
                            break;
                        case EnemyConstants.Up:
                            location1.Y += EnemyConstants.GoriyaProjDisplacement;   
                            break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame != totalFrames)
            {
                if (textureFrame <= EnemyConstants.Texture1)
                    frame = EnemyConstants.Frame1;
                else if (textureFrame <= EnemyConstants.Texture2)
                    frame = EnemyConstants.Frame2;
                else if (textureFrame <= EnemyConstants.Texture3)
                    frame = EnemyConstants.Frame3;

                if (toDraw)
                {
                    Texture2D texture = EnemyTextureStorage.Instance.GetEnemies1();
                    Rectangle source = projectile[frame];
                    Rectangle destinaton = new Rectangle((int)location1.X, (int)location1.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                    spriteBatch.Draw(texture, destinaton, source, Color.White);
                }
            }
        }
    }
}
