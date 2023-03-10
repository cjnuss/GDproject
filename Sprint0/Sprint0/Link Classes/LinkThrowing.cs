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
        public Vector2 location1;
        private Texture2D texture;

        public GreenArrow greenArrow;
        public Fire fire;
        public Bomb bomb;
        public Boolean arrowBool, fireBool, bombBool, setArrowPos, setFirePos, setBomb;

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
            fire = new Fire();
            bomb = new Bomb();
            setArrowPos = true; setFirePos = true; setBomb = true;
        }

        public void Update()
        {
            if (arrowBool)
            {
                if (setArrowPos)
                {
                    //greenArrow = new GreenArrow();
                    greenArrow.direction = direction;
                    greenArrow.RegisterPos(location1);
                    setArrowPos = false;
                }
                else
                {
                    if (!greenArrow.toDraw)
                    {
                        greenArrow = new GreenArrow();
                        arrowBool = false; setArrowPos = true;
                    }
                }
                greenArrow.Update();
            }
            else if (fireBool)
            {
                if (setFirePos)
                {
                    //fire = new Fire();
                    fire.direction = direction;
                    fire.RegisterPos(location1);
                    setFirePos = false;
                }
                else
                {
                    if (!fire.toDraw)
                    {
                        fire = new Fire();
                        fireBool = false; setFirePos = true;
                    }
                }
                fire.Update();
            }
            else if (bombBool)
            {
                if (setBomb)
                {
                    //bomb = new Bomb();
                    setBomb = false;
                }
                else
                {
                    if (!bomb.toDraw)
                    {
                        bomb = new Bomb();
                        bombBool = false; setBomb = true;
                    }
                }
                bomb.direction = direction;
                bomb.UpdatePos(location1);
                bomb.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle source = frames[direction];
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, source.Width * 3, source.Height * 3); // DEBUG *3?
            spriteBatch.Draw(texture, dest, source, Color.White);

            if (arrowBool)
                greenArrow.Draw(spriteBatch);
            else if (fireBool)
                fire.Draw(spriteBatch);
            else if (bombBool)
                bomb.Draw(spriteBatch);
        }
    }
}
