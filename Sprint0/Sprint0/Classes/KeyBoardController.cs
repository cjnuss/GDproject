﻿using Microsoft.Xna.Framework.Input;
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
using Sprint0.Classes;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        //implement
        private Game1 game1;

        public ISprite sprite;
        public ISprite StillSprite;
        public ISprite DamagedSprite;

        // private IBlock blockSprite;
        // private IItem itemSprite;
        // private Enemy enemySprite;

        private EmptySprtie emptySprtie;
        public ISprite greenArrow;

        private LinkGreenArrowRight greenArrowRight;
        private LinkGreenArrowLeft greenArrowLeft;
        private LinkGreenArrowUp greenArrowUp;
        private LinkGreenArrowDown greenArrowDown;

        public Texture2D Texture { get; set; }

        private LinkMovingUp LinkUpSprite;
        private LinkMovingDown LinkDownSprite;
        private LinkMovingLeft LinkLeftSprite;
        private LinkMovingRight LinkRightSprite;


        private LinkLookingLeft linkLookingLeft;
        private LinkLookingRight linkLookingRight;
        private LinkLookingDown linkLookingDown;
        private LinkLookingUp linkLookingUp;


        private LinkAttackLeft linkAttackLeft;
        private LinkAttackRight linkAttackRight;
        private LinkAttackDown linkAttackDown;
        private LinkAttackUp linkAttackUp;

        private LinkThrowDown linkThrowDown;
        private LinkThrowUp linkThrowUp;
        private LinkThrowLeft linkThrowLeft;
        private LinkThrowRight linkThrowRight;

        // private Block block;
        // private Item item;
        
        private SpriteBatch _spriteBatch;

        public int xPos;
        public int yPos;
        public int dir;

        public int blockState;
        public int itemState;
        public int enemyState;

        private ExitCommand exitCommand;
        private LinkMoveLeftCommand moveLeftCommand;
        private LinkMoveRightCommand moveRightCommand;
        private LinkMoveUpCommand moveUpCommand;
        private LinkMoveDownCommand moveDownCommand;
        private LinkChangeSpriteCommand linkDamagedCommand;
        private LinkThrowCommand linkThrowCommand;
        private LinkAttackCommand attackCommand;

        private BlockChangeCommand blockStateOne;
        private BlockChangeCommand blockStateTwo;
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

            greenArrowRight = new LinkGreenArrowRight(atlas);
            greenArrowLeft = new LinkGreenArrowLeft(atlas);
            greenArrowUp = new LinkGreenArrowUp(atlas);
            greenArrowDown = new LinkGreenArrowDown(atlas);

            emptySprtie = new EmptySprtie(atlas);
            greenArrow = emptySprtie;

            linkThrowDown = new LinkThrowDown(atlas);
            linkThrowUp = new LinkThrowUp(atlas);
            linkThrowLeft = new LinkThrowLeft(atlas);
            linkThrowRight = new LinkThrowRight(atlas);

            // block = new Block(blocks);
            // item = new Item(items);
            controllerMapping = new Dictionary<Keys, ICommand>();

            linkLookingLeft = new LinkLookingLeft(atlas);
            linkLookingDown = new LinkLookingDown(atlas);
            linkLookingUp = new LinkLookingUp(atlas);
            linkLookingRight = new LinkLookingRight(atlas);

            linkAttackDown = new LinkAttackDown(atlas);
            linkAttackLeft = new LinkAttackLeft(atlas);
            linkAttackRight = new LinkAttackRight(atlas);
            linkAttackUp = new LinkAttackUp(atlas);

            StillSprite = new LinkLookingDown(atlas);

            exitCommand = new ExitCommand(game1);
            moveLeftCommand = new LinkMoveLeftCommand(this, LinkLeftSprite, linkLookingLeft);
            moveRightCommand = new LinkMoveRightCommand(this, LinkRightSprite, linkLookingRight);
            moveDownCommand = new LinkMoveDownCommand(this, LinkDownSprite, linkLookingDown);
            moveUpCommand = new LinkMoveUpCommand(this, LinkUpSprite, linkLookingUp);

            linkDamagedCommand = new LinkChangeSpriteCommand(this, DamagedSprite);
            linkThrowCommand = new LinkThrowCommand(this, linkThrowDown, linkThrowUp, linkThrowLeft, linkThrowRight, greenArrowRight, greenArrowLeft, greenArrowUp, greenArrowDown);

            attackCommand = new LinkAttackCommand(this, linkAttackUp, linkAttackDown, linkAttackLeft, linkAttackRight);

            blockStateOne = new BlockChangeCommand(this, 1);
            blockStateTwo = new BlockChangeCommand(this, 2);
            itemStateOne = new ItemChangeCommand(this, 1);
            itemStateTwo = new ItemChangeCommand(this, 2);
            enemyStateOne = new EnemyChangeCommand(this, 1);
            enemyStateTwo = new EnemyChangeCommand(this, 2);

            resetCommand = new ResetCommand(this, linkLookingDown);

            controllerMapping.Add(Keys.Q, exitCommand);
            //player movement
            controllerMapping.Add(Keys.W, moveUpCommand);
            controllerMapping.Add(Keys.S, moveDownCommand);
            controllerMapping.Add(Keys.A, moveLeftCommand);
            controllerMapping.Add(Keys.D, moveRightCommand);
            controllerMapping.Add(Keys.Up, moveUpCommand);
            controllerMapping.Add(Keys.Down, moveDownCommand);
            controllerMapping.Add(Keys.Left, moveLeftCommand);
            controllerMapping.Add(Keys.Right, moveRightCommand);

            controllerMapping.Add(Keys.E, linkDamagedCommand);
            controllerMapping.Add(Keys.Y, blockStateOne);
            controllerMapping.Add(Keys.T, blockStateTwo);
            controllerMapping.Add(Keys.I, itemStateOne);
            controllerMapping.Add(Keys.U, itemStateTwo);
            controllerMapping.Add(Keys.R, resetCommand);
            controllerMapping.Add(Keys.O, enemyStateOne);
            controllerMapping.Add(Keys.P, enemyStateTwo);
            controllerMapping.Add(Keys.D1, linkThrowCommand);

            controllerMapping.Add(Keys.Z, attackCommand);


            // draw and update sprites
            // blockSprite = block;
            // itemSprite = item;
            // enemySprite = new Enemy(game1);

            xPos = 50; yPos = 100;
            dir = 0;
            blockState = 0;
            itemState = 0;
            enemyState = 0;
            _spriteBatch = spriteBatch;
        }
        public void Update()
        {
            sprite = StillSprite;

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (pressedKeys.Contains(Keys.W) || pressedKeys.Contains(Keys.Up))
            {
                controllerMapping[Keys.W].Execute();
            }
            else if (pressedKeys.Contains(Keys.S) || pressedKeys.Contains(Keys.Down))
            {
                controllerMapping[Keys.S].Execute();
            }
            else if (pressedKeys.Contains(Keys.A) || pressedKeys.Contains(Keys.Left))
            {
                controllerMapping[Keys.A].Execute();
            }
            else if (pressedKeys.Contains(Keys.D) || pressedKeys.Contains(Keys.Right))
            {
                controllerMapping[Keys.D].Execute();
            }
            else if (pressedKeys.Contains(Keys.D1))
            {
                greenArrow = emptySprtie;
                greenArrowRight.registerPos(xPos, yPos);
                greenArrowLeft.registerPos(xPos, yPos);
                greenArrowDown.registerPos(xPos, yPos);
                greenArrowUp.registerPos(xPos, yPos);
                controllerMapping[Keys.D1].Execute();
            }
            else
            {
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMapping.ContainsKey(key))
                        controllerMapping[key].Execute();

                    if (key.Equals(Keys.R))
                    {
                        StillSprite = linkLookingDown;
                        dir = 1;
                    }
                }
            }

                greenArrow.Update();
                sprite.Update();

                // blockSprite.Update(blockState);
                // itemSprite.Update(itemState);
                // enemySprite.Update(enemyState);


                // set default states
                blockState = 3;
                itemState = 3;
                enemyState = 3;

                greenArrow.Draw(_spriteBatch, new Vector2(xPos, yPos));
                sprite.Draw(_spriteBatch, new Vector2(xPos, yPos));
                
                // blockSprite.Draw(_spriteBatch, new Vector2(440, 150));
                // itemSprite.Draw(_spriteBatch, new Vector2(200, 300));
                // enemySprite.Draw(_spriteBatch);
            }

        }
    }
