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

namespace Sprint0
{
    public class LinkThrowing : ISprite
    {
        public int frame, currentFrame, totalFrames, direction;
        public Vector2 location1;
        private Texture2D texture;

        public GreenArrow greenArrow;
        public LinkFire linkFire;
        public Boolean arrow = false, fire = false;
        public Boolean setArrowPos, setFirePos;

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
            greenArrow = new GreenArrow();
            setArrowPos = true;
            setFirePos = true;
        }

        public void Update()
        {
            if (arrow)
            {
                if (setArrowPos)
                {
                    greenArrow = new GreenArrow();
                    greenArrow.direction = direction;
                    greenArrow.RegisterPos(location1);
                    setArrowPos = false;
                }
                else
                {
                    if (!greenArrow.toDraw)
                    {
                        arrow = false;
                        setArrowPos = true;
                    }
                }
                greenArrow.Update();
            }
            else if (fire)
            {
                if (setFirePos)
                {
                    linkFire = new LinkFire();
                    linkFire.direction = direction;
                    linkFire.RegisterPos(location1);
                    setFirePos = false;
                }
                else
                {
                    if (!linkFire.toDraw)
                    {
                        fire = false;
                        setFirePos = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle source = frames[direction];
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, source.Width * 3, source.Height * 3); // DEBUG *3?
            spriteBatch.Draw(texture, dest, source, Color.White);

            if (arrow)
                greenArrow.Draw(spriteBatch);
            else if (fire)
                linkFire.Draw(spriteBatch);
        }
    }
}
