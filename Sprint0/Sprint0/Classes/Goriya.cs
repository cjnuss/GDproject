using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;

namespace Sprint0
{
    public class Goriya : ISprite1
    {
        public int currentFrame = 0;
        public int totalFrames = 40;
        public Vector2 location = new Vector2(600, 240);
        public int frame;
        private Texture2D texture;

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.GoriyaUp,
            EnemyTextureStorage.GoriyaDown,
            EnemyTextureStorage.GoriyaLeft1,
            EnemyTextureStorage.GoriyaLeft2,
            EnemyTextureStorage.GoriyaRight1,
            EnemyTextureStorage.GoriyaRight2,
        };

        private static List<Texture2D> textures = new List<Texture2D>
        {
            EnemyTextureStorage.Instance.GetEnemies1(),
            EnemyTextureStorage.Instance.GetEnemies1Flipped()
        };

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame <= 10)
            {
                texture = textures[0];
                frame = 0;
            }
            else if (currentFrame > 10)
            {
                texture = textures[0];
                frame = 1;
            }

            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width, source.Height);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
