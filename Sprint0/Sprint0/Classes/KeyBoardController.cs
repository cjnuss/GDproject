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
using System.ComponentModel.Design;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        //implement
        private Game1 game1;

        public ISprite sprite;
        public ISprite StillSprite;
        public ISprite DamagedSprite;

        private IBlock blockSprite;
        private IItem itemSprite;
        private Enemy enemySprite;

        private ISprite greenArow;

        public Texture2D Texture { get; set; }

        private LinkMovingUp LinkUpSprite;  
        private LinkMovingDown LinkDownSprite;
        private LinkMovingLeft LinkLeftSprite;
        private LinkMovingRight LinkRightSprite;
        

        private LinkLookingLeft linkLookingLeft;
        private LinkLookingRight linkLookingRight;
        private LinkLookingDown linkLookingDown;
        private LinkLookingUp linkLookingUp;

        private Block block;
        private Item item;
        private SpriteBatch _spriteBatch;

        public int xPos;
        public int yPos;

        public int blockState;
        public int oldBlockState;
        public int itemState;
        public int enemyState;

        private ExitCommand exitCommand;
        private LinkMoveLeftCommand moveLeftCommand;
        private LinkMoveRightCommand moveRightCommand;
        private LinkMoveUpCommand moveUpCommand;
        private LinkMoveDownCommand moveDownCommand;
        private LinkChangeSpriteCommand linkDamagedCommand;

        private BlockChangeCommand incBlock;
        private BlockChangeCommand decBlock;
        private ItemChangeCommand itemStateOne;
        private ItemChangeCommand itemStateTwo;
        private EnemyChangeCommand enemyStateOne;
        private EnemyChangeCommand enemyStateTwo;

        private ResetCommand resetCommand;


        private Dictionary<Keys, ICommand> controllerMapping;

        public KeyBoardController(Game1 game1, Texture2D atlas, Texture2D blocks, Texture2D items, SpriteBatch spriteBatch)
        {
            //need to change atlas and these calls
            this.game1 = game1;
            LinkRightSprite = new LinkMovingRight(atlas);
            LinkDownSprite = new LinkMovingDown(atlas);
            LinkLeftSprite = new LinkMovingLeft(atlas);
            LinkUpSprite = new LinkMovingUp(atlas);
            DamagedSprite = new LinkTakingDamage(atlas);
            block = new Block(blocks);
            item = new Item(items);

            controllerMapping = new Dictionary<Keys, ICommand>();

            linkLookingLeft = new LinkLookingLeft(atlas);
            linkLookingDown = new LinkLookingDown(atlas);
            linkLookingUp = new LinkLookingUp(atlas);
            linkLookingRight = new LinkLookingRight(atlas);

            StillSprite = new LinkLookingDown(atlas);

            exitCommand = new ExitCommand(game1);
            moveLeftCommand = new LinkMoveLeftCommand(this, LinkLeftSprite, linkLookingLeft);
            moveRightCommand = new LinkMoveRightCommand(this, LinkRightSprite, linkLookingRight);
            moveDownCommand = new LinkMoveDownCommand(this, LinkDownSprite, linkLookingDown);
            moveUpCommand = new LinkMoveUpCommand(this, LinkUpSprite, linkLookingUp);

            linkDamagedCommand = new LinkChangeSpriteCommand(this, DamagedSprite);

            blockState = 1;
            oldBlockState = 1;
            incBlock = new BlockChangeCommand(this, blockState);
            decBlock = new BlockChangeCommand(this, oldBlockState);
            itemStateOne = new ItemChangeCommand(this, 1);
            itemStateTwo = new ItemChangeCommand(this, 2);
            enemyStateOne = new EnemyChangeCommand(this, 1);
            enemyStateTwo = new EnemyChangeCommand(this, 2);

            resetCommand = new ResetCommand(this, linkLookingDown);

            controllerMapping.Add(Keys.Q, exitCommand);
            controllerMapping.Add(Keys.W, moveUpCommand);
            controllerMapping.Add(Keys.S, moveDownCommand);
            controllerMapping.Add(Keys.A, moveLeftCommand);
            controllerMapping.Add(Keys.D, moveRightCommand);
            controllerMapping.Add(Keys.E, linkDamagedCommand);
            controllerMapping.Add(Keys.Y, incBlock);
            controllerMapping.Add(Keys.T, decBlock);
            controllerMapping.Add(Keys.I, itemStateOne);
            controllerMapping.Add(Keys.U, itemStateTwo);
            controllerMapping.Add(Keys.R, resetCommand);
            controllerMapping.Add(Keys.O, enemyStateOne);
            controllerMapping.Add(Keys.P, enemyStateTwo);


            // draw and update sprites
            blockSprite = block;
            itemSprite = item;
            enemySprite = new Enemy(game1);

            xPos = 50; yPos = 100;
            blockState = 0;
            itemState = 0;
            enemyState = 0;
            _spriteBatch = spriteBatch;
        }
        public void Update()
        {
            sprite = StillSprite;

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (pressedKeys.Contains(Keys.W))
                controllerMapping[Keys.W].Execute();
            else if (pressedKeys.Contains(Keys.S))
                controllerMapping[Keys.S].Execute();
            else if (pressedKeys.Contains(Keys.A))
                controllerMapping[Keys.A].Execute();
            else if (pressedKeys.Contains(Keys.D))
                controllerMapping[Keys.D].Execute();
            else
            {
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMapping.ContainsKey(key))
                        controllerMapping[key].Execute();

                    if (key.Equals(Keys.R))
                        StillSprite = linkLookingDown;
                }
            }
            

            /*
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
                    yPos--;

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    //s key is press
                    //link will move down
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

                // block actions
                else if (Keyboard.GetState().IsKeyDown(Keys.Y))
                    block.KeyBlockUpdate(true, ref oldBlockState, ref blockState);

                else if (Keyboard.GetState().IsKeyDown(Keys.T))
                    block.KeyBlockUpdate(false, ref oldBlockState, ref blockState);
                
                // item actions
                else if (Keyboard.GetState().IsKeyDown(Keys.I))
                    item.KeyItemUpdate(true, ref itemState);

                else if (Keyboard.GetState().IsKeyDown(Keys.U))
                    item.KeyItemUpdate(false, ref itemState);

                // default state for link
                else
                    sprite = StillSprite;
                

            }
            // reset game to original state
            else
            {
                blockState = 0;
                itemState = 0;
                sprite = StillSprite;
                xPos = 50; yPos = 100;
            }
            */

            sprite.Update();

            blockSprite.Update(blockState);
            itemSprite.Update(itemState);
            enemySprite.Update(enemyState);

            // set default states
            blockState = 3;
            itemState = 3; 
            enemyState = 3;

            sprite.Draw(_spriteBatch, new Vector2(xPos, yPos));
            blockSprite.Draw(_spriteBatch, new Vector2(440, 150));
            itemSprite.Draw(_spriteBatch, new Vector2(200, 300));
            enemySprite.Draw(_spriteBatch);
        }

    }
}
