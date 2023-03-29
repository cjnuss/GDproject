using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;
using Sprint0.Link_Classes;
using Sprint0.Link_Classes.Item_Usage;

namespace Sprint0
{
    public class LinkThrowing : ILinkSprite
    {
        public int frame, currentFrame, totalFrames, direction;
        private Texture2D texture;

        private static Rectangle LinkThrowDown = LinkTextureStorage.LinkThrowDown;
        private static Rectangle LinkThrowLeft = LinkTextureStorage.LinkThrowLeft;
        private static Rectangle LinkThrowRight = LinkTextureStorage.LinkThrowRight;
        private static Rectangle LinkThrowUp = LinkTextureStorage.LinkThrowUp;

        private static List<Rectangle> frames = new List<Rectangle>()
        {
            LinkThrowDown,
            LinkThrowLeft,
            LinkThrowRight,
            LinkThrowUp
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkThrowing()
        {
            direction = 0;
        }

        public void Update()
        {
            // nothing to do here
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle source = frames[direction];
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, source.Width * 3, source.Height * 3); // DEBUG *3?
            spriteBatch.Draw(texture, dest, source, Color.White);
        }
    }
}
