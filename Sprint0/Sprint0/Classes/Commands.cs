﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class ExitCommand : ICommand
    {
        private Game1 game;
        public ExitCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }

    public class LinkChangeSpriteCommand : ICommand
    {
        private ISprite sprite;
        private KeyBoardController KeyBoardController;

        public LinkChangeSpriteCommand(KeyBoardController KeyBoardController, ISprite sprite)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
        }

        public void Execute()
        {
            KeyBoardController.sprite = sprite;
        }
    }

    public class LinkMoveLeftCommand : ICommand
    {
        private ISprite sprite;
        private KeyBoardController KeyBoardController;
        private ISprite linkLookingLeft;

        public LinkMoveLeftCommand(KeyBoardController KeyBoardController, ISprite sprite, ISprite linkLookingLeft)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
            this.linkLookingLeft = linkLookingLeft;
        }

        public void Execute()
        {
            KeyBoardController.dir = 3;
            KeyBoardController.sprite = sprite;
            KeyBoardController.xPos--;
            KeyBoardController.StillSprite = linkLookingLeft;
        }
    }

    public class LinkMoveRightCommand : ICommand
    {
        private ISprite sprite;
        private KeyBoardController KeyBoardController;
        private ISprite linkLookingRight;

        public LinkMoveRightCommand(KeyBoardController KeyBoardController, ISprite sprite, ISprite linkLookingRight)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
            this.linkLookingRight = linkLookingRight;
        }

        public void Execute()
        {
            KeyBoardController.dir = 2;
            KeyBoardController.sprite = sprite;
            KeyBoardController.xPos++;
            KeyBoardController.StillSprite = linkLookingRight;
        }
    }

    public class LinkMoveUpCommand : ICommand
    {
        private ISprite sprite;
        private KeyBoardController KeyBoardController;
        private ISprite linkLookingUp;

        public LinkMoveUpCommand(KeyBoardController KeyBoardController, ISprite sprite, ISprite linkLookingUp)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
            this.linkLookingUp = linkLookingUp;
        }

        public void Execute()
        {
            KeyBoardController.dir = 4;
            KeyBoardController.sprite = sprite;
            KeyBoardController.yPos--;
            KeyBoardController.StillSprite = linkLookingUp;
        }
    }

    public class LinkMoveDownCommand : ICommand
    {
        private ISprite sprite;
        private KeyBoardController KeyBoardController;
        private ISprite linkLookingDown;

        public LinkMoveDownCommand(KeyBoardController KeyBoardController, ISprite sprite, ISprite linkLookingDown)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
            this.linkLookingDown = linkLookingDown;
        }

        public void Execute()
        {
            KeyBoardController.dir = 1;
            KeyBoardController.sprite = sprite;
            KeyBoardController.yPos++;
            KeyBoardController.StillSprite = linkLookingDown;
        }
    }

    public class ResetCommand : ICommand
    {

        private KeyBoardController KeyBoardController;
        private ISprite sprite;

        public ResetCommand(KeyBoardController KeyBoardController, ISprite sprite)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
        }

        public void Execute()
        {
            KeyBoardController.blockState = 0;
            KeyBoardController.itemState = 0;
            KeyBoardController.enemyState= 0;
            KeyBoardController.sprite = sprite;
            KeyBoardController.xPos = 50; KeyBoardController.yPos = 100;

        }
    }

    public class BlockChangeCommand : ICommand
    {

        private KeyBoardController KeyBoardController;
        private int blockState;

        public BlockChangeCommand(KeyBoardController KeyBoardController, int blockState)
        {
            this.KeyBoardController = KeyBoardController;
            this.blockState = blockState;
        }

        public void Execute()
        {
            KeyBoardController.blockState = blockState;
        }
    }

    public class ItemChangeCommand : ICommand
    {

        private KeyBoardController KeyBoardController;
        private int itemState;

        public ItemChangeCommand(KeyBoardController KeyBoardController, int itemState)
        {
            this.KeyBoardController = KeyBoardController;
            this.itemState = itemState;
        }

        public void Execute()
        {
            KeyBoardController.itemState = itemState;
        }
    }
    public class EnemyChangeCommand : ICommand
    {
        private KeyBoardController KeyBoardController;
        private int EnemyState;

        public EnemyChangeCommand(KeyBoardController keyboardController, int enemyState)
        {
            this.KeyBoardController = keyboardController;
            this.EnemyState = enemyState;
        }

        public void Execute()
        {
            KeyBoardController.enemyState = EnemyState;
        }
    }

    public class LinkThrowCommand : ICommand
    {
        private ISprite throwDown;
        private ISprite throwUp;
        private ISprite throwLeft;
        private ISprite throwRight;

        private ISprite greenArrowRight;
        private ISprite greenArrowLeft;
        private ISprite greenArrowUp;
        private ISprite greenArrowDown;

        private KeyBoardController KeyBoardController;

        public LinkThrowCommand(KeyBoardController KeyBoardController, ISprite throwDown, ISprite throwUp, ISprite throwLeft, ISprite throwRight, ISprite greenArrowRight, ISprite greenArrowLeft, ISprite greenArrowUp, ISprite greenArrowDown)
        {
            this.KeyBoardController = KeyBoardController;

            this.throwUp = throwUp;
            this.throwDown = throwDown;
            this.throwLeft = throwLeft;
            this.throwRight = throwRight;

            this.greenArrowRight = greenArrowRight;
            this.greenArrowLeft = greenArrowLeft;
            this.greenArrowUp = greenArrowUp;
            this.greenArrowDown = greenArrowDown;
        }

        public void Execute()
        {
            if(KeyBoardController.dir.Equals(1))
            {
                KeyBoardController.sprite = throwDown;
                KeyBoardController.greenArrow = greenArrowDown;
            } else if(KeyBoardController.dir.Equals(4))
            {
                KeyBoardController.sprite = throwUp;
                KeyBoardController.greenArrow = greenArrowUp;
            } else if(KeyBoardController.dir.Equals(3))
            {
                KeyBoardController.sprite = throwLeft;
                KeyBoardController.greenArrow = greenArrowLeft;
            } else if(KeyBoardController.dir.Equals(2))
            {
                KeyBoardController.sprite = throwRight;
                KeyBoardController.greenArrow = greenArrowRight;
            }
        }
    }

    public class LinkAttackCommand : ICommand
    {
        private ISprite attackDown;
        private ISprite attackUp;
        private ISprite attackLeft;
        private ISprite attackRight;

        private KeyBoardController KeyBoardController;

        public LinkAttackCommand(KeyBoardController KeyBoardController, ISprite attackUp, ISprite attackDown, ISprite attackLeft, ISprite attackRight)
        {
            this.KeyBoardController =  KeyBoardController;
            this.attackUp = attackUp;
            this.attackDown = attackDown;
            this.attackLeft = attackLeft;
            this.attackRight = attackRight;
        }

        public void Execute()
        {
            if (KeyBoardController.dir.Equals(1))
            {
                KeyBoardController.sprite = attackDown;
            }
            else if (KeyBoardController.dir.Equals(4))
            {
                KeyBoardController.sprite = attackUp;
            }
            else if (KeyBoardController.dir.Equals(3))
            {
                KeyBoardController.sprite = attackLeft;
            }
            else if (KeyBoardController.dir.Equals(2))
            {
                KeyBoardController.sprite = attackRight;
            }
        }
    }
}
