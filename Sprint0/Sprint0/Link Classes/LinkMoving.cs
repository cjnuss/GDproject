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
    public class LinkMoving : ISprite
    {
        public int frame, currentFrame, totalFrames, direction;
        private Texture2D texture;

        private static List<Rectangle> LinkMovingDown = new List<Rectangle>
        {
            LinkTextureStorage.LinkMovingDown,
            LinkTextureStorage.LinkMovingDown1
        };

        private static List<Rectangle> LinkMovingLeft = new List<Rectangle>
        {
            LinkTextureStorage.LinkMovingLeft,
            LinkTextureStorage.LinkMovingLeft1
        };

        private static List<Rectangle> LinkMovingRight = new List<Rectangle>
        {
            LinkTextureStorage.LinkMovingRight,
            LinkTextureStorage.LinkMovingRight1
        };

        private static List<Rectangle> LinkMovingUp = new List<Rectangle>
        {
            LinkTextureStorage.LinkMovingUp,
            LinkTextureStorage.LinkMovingUp1
        };

        private static List<List<Rectangle>> frames = new List<List<Rectangle>>
        {
            LinkMovingDown,
            LinkMovingLeft,
            LinkMovingRight,
            LinkMovingUp
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkMoving() // DEBUG
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
            if (currentFrame <= 15)
                frame = 0;
            else if (currentFrame > 15)
                frame = 1;

            // direction updates
            // DEBUG: above might be in keyboard controller
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle sprite = frames[direction][frame];
            spriteBatch.Draw(texture,
                         new Rectangle((int)location.X, (int)location.Y, sprite.Width*3, sprite.Height*3), // texture.width...
                         sprite, Color.White);
        }
    }
}
