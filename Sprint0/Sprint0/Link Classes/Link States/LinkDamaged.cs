using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;

namespace Sprint0
{
    public class LinkDamaged : ILinkSprite
    {
        public int frame, currentFrame, totalFrames, direction;
        private Texture2D texture;

        private static List<Rectangle> LinkTakingDamage = new List<Rectangle>()
        {
            LinkTextureStorage.LinkTakingDamage,
            LinkTextureStorage.LinkTakingDamage1,
            LinkTextureStorage.LinkTakingDamage2
        };

        // implement damage in different directions later..

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkDamaged()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 30;
            // location
        }

        public void Update()
        {
            // overall frame updates
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            // animation frame updates
            frame = 0;
            if (currentFrame <= 10)
                frame = 0;
            else if (currentFrame <= 20)
                frame = 1;
            else if (currentFrame > 20)
                frame = 2;

            // direction updates?
            // DEBUG: above might be in keyboard controller
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle sprite = LinkTakingDamage[frame];
            spriteBatch.Draw(texture,
                         new Rectangle((int)location.X, (int)location.Y, sprite.Width*3, sprite.Width*3),
                         sprite, Color.White);
        }
    }
}
