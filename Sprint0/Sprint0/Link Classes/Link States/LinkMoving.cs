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
    public class LinkMoving : ILinkSprite
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

        public LinkMoving()
        {
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.TotalMovingFrames;
        }

        public void Update()
        {
            // overall frame updates
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = GameConstants.Zero;

            // animation frame updates
            frame = GameConstants.Frame0;
            if (currentFrame <= LinkConstants.MovingPhase)
                frame = GameConstants.Frame0;
            else if (currentFrame > LinkConstants.MovingPhase)
                frame = GameConstants.Frame1;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle sprite = frames[direction][frame];
            spriteBatch.Draw(texture,
                         new Rectangle((int)location.X, (int)location.Y, sprite.Width*GameConstants.Sizing, 
                         sprite.Height*GameConstants.Sizing), sprite, Color.White);
        }
    }
}
