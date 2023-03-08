using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link_Classes.Item_Usage
{
    public class Bomb : ISprite1
    {
        public int frame, currentFrame, totalFrames, direction;
        Vector2 location1;
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> BombList = new List<Rectangle>
        {
            LinkTextureStorage.LinkBomb,
            LinkTextureStorage.LinkBombExplode,
            LinkTextureStorage.LinkBombExplode1,
            LinkTextureStorage.LinkBombExplode2
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public Bomb()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 60;
        }

        public void RegisterPos(Vector2 location)
        {
            location1 = location;
            if (direction == 0)
            {
                location1.X += 10; // magic nums all around
                location1.Y += 48;
            }
            if (direction == 1)
            {
                location1.X -= 32;
                location1.Y += 10;
            }
            if (direction == 2)
            {
                location1.X += 48;
                location1.Y += 10;
            }
            if (direction == 3)
            {
                location1.X += 10;
                location1.Y -= 48;
            }
            
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            frame = 0;
            if (currentFrame <= 36)
                frame = 0;
            else if (currentFrame > 36 && currentFrame <= 44)
                frame = 1;
            else if (currentFrame > 44 && currentFrame <= 52)
                frame = 2;
            else if (currentFrame > 52)
                frame = 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;
            if (toDraw)
            {
                source = BombList[frame];
                dest = new Rectangle((int)location1.X, (int)location1.Y, source.Width * 3, source.Height * 3);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
            if (frame == 3)
                toDraw = false;
        }
    }
}
