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
        public int totalFrames = 200;
        public int textureFrame1 = 20;

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.AquamentusProjectile1,
            EnemyTextureStorage.AquamentusProjectile2,
            EnemyTextureStorage.AquamentusProjectile3,
            EnemyTextureStorage.AquamentusProjectile4
        };

        public AquamentusProjectile(Vector2 location)
        {
            location1 = new Vector2(location.X + 24, location.Y + 31);
            location2 = new Vector2(location.X + 24, location.Y + 31);
            location3 = new Vector2(location.X + 24, location.Y + 31);
        }

        public void Update()
        {
            textureFrame++;
            if (textureFrame == textureFrame1)
            {
                textureFrame = 0;
            }
            if (currentFrame != totalFrames)
            {
                currentFrame++;
            }
            if (currentFrame % 10 == 0)
            {
                location1.X -= 6;
                location1.Y += 3;
                location2.X -= 6;
                location3.X -= 6;
                location3.Y -= 3;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame != totalFrames)
            {
                if (textureFrame < 5)
                    frame = 0;
                else if (textureFrame >= 5 && textureFrame < 10)
                    frame = 1;
                else if (textureFrame >= 10 && textureFrame < 15)
                    frame = 2;
                else if (textureFrame >= 20)
                    frame = 3;

                Texture2D texture = EnemyTextureStorage.Instance.GetEnemies();
                Rectangle source = frames[frame];
                Rectangle destinaton1 = new Rectangle((int)location1.X, (int)location1.Y, source.Width * 3, source.Height * 3);
                Rectangle destinaton2 = new Rectangle((int)location2.X, (int)location2.Y, source.Width * 3, source.Height * 3);
                Rectangle destinaton3 = new Rectangle((int)location3.X, (int)location3.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, destinaton1, source, Color.White);
                spriteBatch.Draw(texture, destinaton2, source, Color.White);
                spriteBatch.Draw(texture, destinaton3, source, Color.White);
            }
        }
    }
}
