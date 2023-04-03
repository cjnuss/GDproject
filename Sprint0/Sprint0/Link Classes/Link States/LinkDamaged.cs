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
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.TotalDamageFrames;
        }

        public void Update()
        {
            // overall frame updates
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = GameConstants.Zero;

            // animation frame updates
            frame = LinkConstants.Frame0;
            if (currentFrame <= 10)
                frame = LinkConstants.Frame0;
            else if (currentFrame <= 20)
                frame = LinkConstants.Frame1;
            else if (currentFrame > 20)
                frame = LinkConstants.Frame2;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle sprite = LinkTakingDamage[frame];
            spriteBatch.Draw(texture, new Rectangle((int)location.X, (int)location.Y, sprite.Width*GameConstants.Sizing, 
                         sprite.Width*GameConstants.Sizing), sprite, Color.White);
        }
    }
}
