using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link_Classes.Item_Usage
{
    public class Bomb : ISprite
    {
        public int frame, currentFrame, totalFrames, direction;
        public Vector2 location1;
        public Boolean toDraw = true;
        Rectangle source;
        Rectangle dest;

        private Texture2D texture;

        private static List<Rectangle> BombList = new List<Rectangle>
        {
            LinkTextureStorage.LinkBomb,
            LinkTextureStorage.LinkBombExplode,
            LinkTextureStorage.LinkBombExplode1,
            LinkTextureStorage.LinkBombExplode2,
        };

        private Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public Bomb()
        {
            direction = GameConstants.Down;
            currentFrame = GameConstants.Zero;
            totalFrames = LinkConstants.BombTotalFrames;
        }

        public void UpdatePos(Vector2 location)
        {
            location1 = location;
            if (direction == GameConstants.Down)
            {
                location1.X += LinkConstants.xOffset1; // magic nums all around
                location1.Y += LinkConstants.yOffset1;
            }
            if (direction == GameConstants.Left)
            {
                location1.X -= LinkConstants.xOffset2;
                location1.Y += LinkConstants.yOffset2;
            }
            if (direction == GameConstants.Right)
            {
                location1.X += LinkConstants.xOffset3;
                location1.Y += LinkConstants.yOffset2;
            }
            if (direction == GameConstants.Up)
            {
                location1.X += LinkConstants.xOffset1;
                location1.Y -= LinkConstants.yOffset1;
            }
            
        }

        public void Update()
        {
            if (toDraw)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = GameConstants.Zero;

                FrameUpdate(currentFrame, totalFrames);
            }
        }

        public void FrameUpdate(int currentFrame, int totalFrames)
        {
            frame = GameConstants.Frame0;
            if (currentFrame <= LinkConstants.BombPhase1)
                frame = GameConstants.Frame0;
            else if (currentFrame > LinkConstants.BombPhase1 && currentFrame <= LinkConstants.BombPhase2)
                frame = GameConstants.Frame1;
            else if (currentFrame > LinkConstants.BombPhase2 && currentFrame <= LinkConstants.BombPhase3)
                frame = GameConstants.Frame2;
            else if (currentFrame > LinkConstants.BombPhase3 && currentFrame < LinkConstants.BombPhase4) // totalFrames-1
                frame = GameConstants.Frame3;
            // we completed animation sequence
            else
                toDraw = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = _texture;
            if (toDraw)
            {
                source = BombList[frame];
                dest = new Rectangle((int)location1.X, (int)location1.Y, source.Width*GameConstants.Sizing, source.Height*GameConstants.Sizing);
                spriteBatch.Draw(texture, dest, source, Color.White);
            }
        }
    }
}
