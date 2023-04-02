using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Sprint0
{
    public class LinkAttacking : ILinkSprite
    {
        public int frame, currentFrame, totalFrames, direction;
        public bool toDraw = true;
        private Texture2D texture;

        private static List<Rectangle> LinkAttackingDown = new List<Rectangle>
        {
            LinkTextureStorage.LinkAttackingDown,
            LinkTextureStorage.LinkAttackingDown1,
            LinkTextureStorage.LinkAttackingDown2,
            LinkTextureStorage.LinkAttackingDown3
        };

        private static List<Rectangle> LinkAttackingUp = new List<Rectangle>
        {
            LinkTextureStorage.LinkAttackingUp,
            LinkTextureStorage.LinkAttackingUp1,
            LinkTextureStorage.LinkAttackingUp2,
            LinkTextureStorage.LinkAttackingUp3
        };

        private static List<Rectangle> LinkAttackingLeft = new List<Rectangle>
        {
            LinkTextureStorage.LinkAttackingLeft,
            LinkTextureStorage.LinkAttackingLeft1,
            LinkTextureStorage.LinkAttackingLeft2,
            LinkTextureStorage.LinkAttackingLeft3
        };

        private static List<Rectangle> LinkAttackingRight = new List<Rectangle>
        {
            LinkTextureStorage.LinkAttackingRight,
            LinkTextureStorage.LinkAttackingRight1,
            LinkTextureStorage.LinkAttackingRight2,
            LinkTextureStorage.LinkAttackingRight3
        };

        private static List<List<Rectangle>> frames = new List<List<Rectangle>>
        {
            LinkAttackingDown,
            LinkAttackingLeft,
            LinkAttackingRight,
            LinkAttackingUp
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkAttacking()
        {
            direction = 0;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            if (toDraw)
            {
                // overall frame updates
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                // animation frame updates
                frame = 0;
                if (currentFrame <= 5)
                    frame = 0;
                else if (currentFrame > 5 && currentFrame <= 10)
                    frame = 1;
                else if (currentFrame > 10 && currentFrame <= 15)
                    frame = 2;
                else if (currentFrame > 15 && currentFrame < 19) // total-1
                    frame = 3;
                else
                    toDraw = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            System.Diagnostics.Debug.WriteLine("entering draw with frame " + frame);
            texture = _texture;

            // offset logic
            int xOffset = 0;
            int yOffset = 0;
            if (direction == 1 && frame == 1)
                xOffset = 28;
            if (direction == 1 && frame == 2)
                xOffset = 18;
            if (direction == 1 && frame == 3)
                xOffset = 8;
            if (direction == 3 && frame == 1)
                yOffset = 29;
            if (direction == 3 && frame == 2)
                yOffset = 28;
            if (direction == 3 && frame == 3)
                yOffset = 8;

            if (toDraw)
            {
                Rectangle sprite = frames[direction][frame];
                System.Diagnostics.Debug.WriteLine("drawing frame " + frame);
                // draw
                spriteBatch.Draw(texture, new Rectangle((int)location.X - xOffset, (int)location.Y - yOffset, sprite.Width * 3, sprite.Height * 3), // debug *3
                                 sprite, Color.White);
            }
            else
            {
                Rectangle sprite;
                if (direction == 0)
                    sprite = LinkTextureStorage.LinkLookingDown;
                else if (direction == 1)
                    sprite = LinkTextureStorage.LinkLookingLeft;
                else if (direction == 2)
                    sprite = LinkTextureStorage.LinkLookingRight;
                else /*(direction == 3)*/
                    sprite = LinkTextureStorage.LinkLookingUp;


                spriteBatch.Draw(texture, new Rectangle((int)location.X, (int)location.Y, sprite.Width * 3, sprite.Height * 3), // debug *3
                                 sprite, Color.White);
            }
        }
    }
}
