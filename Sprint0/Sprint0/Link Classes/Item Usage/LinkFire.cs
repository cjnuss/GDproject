﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkFire : ISprite1
    {
        public int frame, currentFrame, totalFrames, direction, currentX, currentY, finalPos;
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> LinkFireList = new List<Rectangle>
        {
            LinkTextureStorage.LinkFire1,
            LinkTextureStorage.LinkFire2
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkFire()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 30;
        }

        public void RegisterPos(Vector2 location)
        {
            currentX = (int)location.X;
            currentY = (int)location.Y;

            if (direction == 0)
                finalPos = (int)location.Y + 5 * 16;
            if (direction == 1)
                finalPos = (int)location.X - 5 * 16;
            if (direction == 2)
                finalPos = (int)location.X + 5 * 16;
            if (direction == 3)
                finalPos = (int)location.Y - 5 * 16;
        }

        public void Update()
        {
            // distance updates
            if (toDraw)
            {
                if (direction == 0)
                    currentY += 5; // magic?
                if (direction == 1)
                    currentX -= 5;
                if (direction == 2)
                    currentX += 5;
                if (direction == 3)
                    currentY -= 5;
            }

        //    // overall frame updates
        //    currentFrame++;
        //    if (currentFrame == totalFrames)
        //        currentFrame = 0;

        //    // animation frame updates
        //    frame = 0;
        //    if (currentFrame <= 15)
        //        frame = 0;
        //    else if (currentFrame > 15)
        //        frame = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;

            if (toDraw)
            {
                if (direction == 0 && currentY >= finalPos || direction == 1 && currentX <= finalPos ||
                    direction == 2 && currentX >= finalPos || direction == 3 && currentY <= finalPos)
                    toDraw = false;

                source = LinkFireList[0]; // frame
                dest = new Rectangle((int)currentX, (int)currentY, source.Width * 3, source.Height * 3);
                System.Diagnostics.Debug.WriteLine("location is " + currentX + " , " + currentY);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
