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
    public class AquamentusProjectile : ISprite
    {
        public Vector2 location1, location2, location3;
        public int frame, textureFrame, currentFrame;
        public int totalFrames = EnemyConstants.AquaProjTotalFrames;

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.AquamentusProjectile1,
            EnemyTextureStorage.AquamentusProjectile2,
            EnemyTextureStorage.AquamentusProjectile3,
            EnemyTextureStorage.AquamentusProjectile4
        };

        public AquamentusProjectile(Vector2 location)
        {
            location1 = new Vector2(location.X + EnemyConstants.AquaProjXAdjustment, location.Y + EnemyConstants.AquaProjYAdjustment);
            location2 = new Vector2(location.X + EnemyConstants.AquaProjXAdjustment, location.Y + EnemyConstants.AquaProjYAdjustment);
            location3 = new Vector2(location.X + EnemyConstants.AquaProjXAdjustment, location.Y + EnemyConstants.AquaProjYAdjustment);
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == EnemyConstants.AquaProjTextureFrames)
            {
                textureFrame = EnemyConstants.Zero;
            }
            if (currentFrame != totalFrames)
            {
                currentFrame++;
            }
            if (currentFrame % EnemyConstants.AquaProjFrameChange == EnemyConstants.Zero)
            {
                location1.X -= EnemyConstants.AquaProjXDisplacement;
                location1.Y += EnemyConstants.AquaProjYDisplacement;

                location2.X -= EnemyConstants.AquaProjXDisplacement;

                location3.X -= EnemyConstants.AquaProjXDisplacement;
                location3.Y -= EnemyConstants.AquaProjYDisplacement;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame != totalFrames)
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
                Rectangle destinaton1 = new Rectangle((int)location1.X, (int)location1.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                Rectangle destinaton2 = new Rectangle((int)location2.X, (int)location2.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                Rectangle destinaton3 = new Rectangle((int)location3.X, (int)location3.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
                spriteBatch.Draw(texture, destinaton1, source, Color.White);
                spriteBatch.Draw(texture, destinaton2, source, Color.White);
                spriteBatch.Draw(texture, destinaton3, source, Color.White);
            }
        }
    }
}
