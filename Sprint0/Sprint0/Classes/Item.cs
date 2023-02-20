using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class Item : IItem
    {
        public Texture2D Texture { get; set; }

        private int currentFrame;
        private int totalFrames;

        private int currentCount;
        private int totalCount;

        public Item(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 30;

            currentCount = 0;
            totalCount = 10;
        }

        // item information
        int itemIdx = 0;
        private Rectangle[] items = { new Rectangle(0, 0, 7, 8), new Rectangle(0, 8, 7, 8), // heart (2)
                              new Rectangle(58, 0, 11, 16), new Rectangle(258, 1, 11, 12), // clock & compass
                              new Rectangle(275, 3, 10, 10), new Rectangle(275, 19, 10, 10), // triforce (2)
                              new Rectangle(240, 0, 8, 16), new Rectangle(88, 0, 8, 16), // key & map
                              new Rectangle(144, 0, 8, 16), new Rectangle(154, 0, 5, 16), // bow & arrow
                              new Rectangle(72, 0, 8, 16), new Rectangle(72, 16, 8, 16), // rupee (2)
                              new Rectangle(40, 0, 8, 16), new Rectangle(48, 0, 8, 16), // fairy (2)
                              new Rectangle(136, 0, 8, 16), new Rectangle(25, 1, 13, 13) }; // bomb & heart container

        private int[] itemWidth = { 7, 7, 11, 11, 10, 10, 8, 8, 8, 5, 8, 8, 8, 8, 8, 13 };
        private int[] itemHeight = { 8, 8, 16, 12, 10, 10, 16, 16, 16, 16, 16, 16, 16, 16, 16, 13 };

        // keys for which indicate we need frame adjustments
        private int[] animKeys = { 0, 4, 10, 12 };

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            // first set of animated frames OR non-animated item
            if (currentFrame <= 15)
            {
                sourceRectangle = items[itemIdx]; // draw first sprite at itemIdx
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, itemWidth[itemIdx] * 3, itemHeight[itemIdx] * 3);
            }
            // second set of animated frames
            else if (currentFrame > 15)
            {
                sourceRectangle = items[itemIdx + 1]; // draw second sprite at next index
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, itemWidth[itemIdx] * 3, itemHeight[itemIdx] * 3);
            }

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update(int itemState)
        {
            // frame updates if animated item
            if (animKeys.Contains(itemIdx))
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }

            if (currentCount >= totalCount)
            {
                currentCount = 0;
                // cycle forward in item list
                if (itemState == 1)
                {
                    currentFrame = 0; // reset frames
                    if (itemIdx <= items.Length - 2)
                        if (animKeys.Contains(itemIdx)) // if animating
                            itemIdx += 2; // skip over other animated half of item
                        else
                            itemIdx++; // go to next item
                    else
                        itemIdx = 0; // beginning of array
                }
                // cycle back in item list
                if (itemState == 2)
                {
                    currentFrame = 0;
                    if (itemIdx >= 1)
                        if (animKeys.Contains(itemIdx))
                            itemIdx -= 2;
                        else
                            itemIdx--;
                    else
                        itemIdx = items.Length - 1; // end of array
                }
            } else
            {
                currentCount++;
            }

            // reset back to original state
            if (itemState == 0)
            {
                itemIdx = 0;
            }

            // correct frame adjustment
            if (animKeys.Contains(itemIdx - 1))
                itemIdx--;
        }

        public void KeyItemUpdate(bool check, ref int itemState)
        {
            if (check)
            {
                itemState = 1;
            }
            else
            {
                itemState = 2;
            }
        }
    }
}
