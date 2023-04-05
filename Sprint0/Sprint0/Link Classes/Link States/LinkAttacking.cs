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
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.TotalSwordFrames;
        }

        public void Update()
        {
            if (toDraw)
            {
                // overall frame updates
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = GameConstants.Zero;

                // animation frame updates
                frame = GameConstants.Frame0;
                if (currentFrame <= LinkConstants.SwordPhase1)
                    frame = GameConstants.Frame0;
                else if (currentFrame > LinkConstants.SwordPhase1 && currentFrame <= LinkConstants.SwordPhase2)
                    frame = GameConstants.Frame1;
                else if (currentFrame > LinkConstants.SwordPhase2 && currentFrame <= LinkConstants.SwordPhase3)
                    frame = GameConstants.Frame2;
                else if (currentFrame > LinkConstants.SwordPhase3 && currentFrame < LinkConstants.SwordPhase4) // total-1
                    frame = GameConstants.Frame3;
                else
                    toDraw = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;

            // offset logic
            int xOffset = GameConstants.Zero;
            int yOffset = GameConstants.Zero;
            if (direction == GameConstants.Left && frame == GameConstants.Frame1)
                xOffset = LinkConstants.LeftOffset1;
            if (direction == GameConstants.Left && frame == GameConstants.Frame2)
                xOffset = LinkConstants.LeftOffset2;
            if (direction == GameConstants.Left && frame == GameConstants.Frame3)
                xOffset = LinkConstants.LeftOffset3;
            if (direction == GameConstants.Up && frame == GameConstants.Frame1)
                yOffset = LinkConstants.UpOffset1;
            if (direction == GameConstants.Up && frame == GameConstants.Frame2)
                yOffset = LinkConstants.UpOffset2;
            if (direction == GameConstants.Up && frame == GameConstants.Frame3)
                yOffset = LinkConstants.UpOffset3;

            if (toDraw)
            {
                Rectangle sprite = frames[direction][frame];
                spriteBatch.Draw(texture, new Rectangle((int)location.X - xOffset, (int)location.Y - yOffset, sprite.Width * GameConstants.Sizing, 
                    sprite.Height * GameConstants.Sizing), sprite, Color.White);
            }
            else
            {
                Rectangle sprite;
                if (direction == GameConstants.Down)
                    sprite = LinkTextureStorage.LinkLookingDown;
                else if (direction == GameConstants.Left)
                    sprite = LinkTextureStorage.LinkLookingLeft;
                else if (direction == GameConstants.Right)
                    sprite = LinkTextureStorage.LinkLookingRight;
                else /* direction up */
                    sprite = LinkTextureStorage.LinkLookingUp;


                spriteBatch.Draw(texture, new Rectangle((int)location.X, (int)location.Y, sprite.Width * GameConstants.Sizing, 
                    sprite.Height * GameConstants.Sizing), sprite, Color.White);
            }
        }
    }
}
