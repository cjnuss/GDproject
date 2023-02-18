using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        //implement
        private Game1 game1;
        ISprite sprite;
        IBlock blockSprite;
        IItem itemSprite;
        public Texture2D Texture { get; set; }

        private LinkMovingUp LinkUpSprite;
        private LinkMovingDown LinkDownSprite;
        private LinkMovingLeft LinkLeftSprite;
        private LinkDoingNothing StillSprite;
        private LinkMovingRight LinkRightSprite;
        private LinkTakingDamage DamagedSprite;
        private Block block;
        private Item item;
        private SpriteBatch _spriteBatch;

        int xPos;
        int yPos;

        private int oldBlockState;
        private int blockState;
        private int itemState;


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
            item = new Item(items);
            xPos= 50; yPos = 100;
            blockState = 0; oldBlockState = 0;
            itemState = 0;
            _spriteBatch = spriteBatch;
        }
        public void Update()
        {
            // until the game is reset, do actions
            if (!Keyboard.GetState().IsKeyDown(Keys.R))
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
                    yPos-=2;

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    //s key is press
                    //link will move down
                    sprite = LinkDownSprite;
                    yPos+=2;

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    //a key is press link will move left
                    sprite = LinkLeftSprite;
                    xPos-=2;

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    //d key is press link will move right
                    sprite = LinkRightSprite;
                    xPos+=2;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    //Use 'e' to cause Link to become damaged.
                    sprite = DamagedSprite;
                }
                // block stuff
                else if (Keyboard.GetState().IsKeyDown(Keys.Y))
                {
                    oldBlockState = blockState;
                    blockState = 1;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.T))
                {
                    oldBlockState = blockState;
                    blockState = 2;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.I))
                {
                    itemState = 1;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.U))
                {
                    itemState = 2;
                }
                else
                {
                    //default state for link
                    sprite = StillSprite;

                }
            }
            // reset game to original state
            else
            {
                blockState = 0;
                itemState = 0;
                sprite = StillSprite;
                xPos = 50; yPos = 100;
            }

            // draw and update sprites
            blockSprite = block;
            itemSprite = item;
            
            sprite.Update();

            if (oldBlockState != blockState)                
                blockSprite.Update(blockState);

            itemSprite.Update(itemState);

            // set default states
            blockState = 3;
            itemState = 3;

            sprite.Draw(_spriteBatch, new Vector2(xPos, yPos));
            blockSprite.Draw(_spriteBatch, new Vector2(440, 150));
            itemSprite.Draw(_spriteBatch, new Vector2(200, 300));
        }

    }
}
