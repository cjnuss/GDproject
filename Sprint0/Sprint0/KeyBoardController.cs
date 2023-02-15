using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        //implement
        private Game1 game1;
        ISprite sprite;
        ISprite blockSprite;
        ISprite itemSprite;
        public Texture2D Texture { get; set; }

        private LinkMovingUp LinkUpSprite;
        private LinkMovingDown LinkDownSprite;
        private LinkMovingLeft LinkLeftSprite;
        private LinkDoingNothing StillSprite;
        private LinkMovingRight LinkRightSprite;
        private LinkTakingDamage DamagedSprite;
        private Block block;
        // private Item item;
        private SpriteBatch _spriteBatch;

        int xPos;
        int yPos;

        //private int gameState;

        public KeyBoardController(Game1 game1, Texture2D atlas, Texture2D blocks, Texture2D items, SpriteBatch spriteBatch)
        {
            //need to change atlas and these calls
            this.game1 = game1;
            LinkRightSprite = new LinkMovingRight(atlas);
            LinkDownSprite = new LinkMovingDown(atlas);
            LinkLeftSprite = new LinkMovingLeft(atlas);
            LinkUpSprite = new LinkMovingUp(atlas);
            StillSprite = new LinkDoingNothing(atlas);
            DamagedSprite = new LinkTakingDamage(atlas);
            block = new Block(blocks);
            // item = new Item(items);
            xPos= 50; yPos = 100;

            _spriteBatch = spriteBatch;
            //gameState = 1;
        }
        public void Update()
        {
            //set game state so that once a key is pressed it will hold a state
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                //exit
                game1.Exit();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //w key is pressed link will move up
                sprite = LinkUpSprite;
                yPos--;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //s key is press link will move down
                sprite = LinkDownSprite;
                yPos++;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //a key is press link will move left
                sprite = LinkLeftSprite;
                xPos--;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //d key is press link will move right
                sprite = LinkRightSprite;
                xPos++;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                //Use 'e' to cause Link to become damaged.
                sprite = DamagedSprite;
            }
            // block stuff
            else if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                // do stuff
            }

            else
            {
                //default state for link
                sprite = StillSprite;

            }

            //now set the sprite using the game state
            /* should not need
            if(gameState == 1)
            {
                sprite = nonanimatedSprite;
            }else if(gameState == 2)
            {
                sprite = animatedSprite;
            }else if(gameState == 3)
            {
                sprite = vertSprite;
            }else if (gameState == 4)
            {
                sprite = horizSprite;
            }
            */
            sprite.Update();
            sprite.Draw(_spriteBatch, new Vector2(xPos, yPos));
        }

    }
}
