using Microsoft.Xna.Framework;
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
        private ISprite spriteDown;
        private ISprite spriteUp;
        private ISprite spriteLeft;
        private ISprite spriteRight;

        private ISprite throwDown;
        private ISprite throwUp;
        private ISprite throwLeft;
        private ISprite throwRight;

        private ISprite greenArrowRight;
        private ISprite greenArrowLeft;
        private ISprite greenArrowUp;
        private ISprite greenArrowDown;

        private KeyBoardController KeyBoardController;

        public LinkThrowCommand(KeyBoardController KeyBoardController, ISprite throwDown, ISprite spriteDown, ISprite throwUp, ISprite spriteUp, ISprite throwLeft, ISprite spriteLeft, ISprite throwRight, ISprite spriteRight, ISprite greenArrowRight, ISprite greenArrowLeft, ISprite greenArrowUp, ISprite greenArrowDown)
        {
            this.KeyBoardController = KeyBoardController;

            this.spriteDown = spriteDown;
            this.spriteUp = spriteUp;
            this.spriteLeft = spriteLeft;
            this.spriteRight = spriteRight;

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
            if(KeyBoardController.sprite.Equals(spriteDown))
            {
                KeyBoardController.sprite = throwDown;
                KeyBoardController.greenArrow = greenArrowDown;
            } else if(KeyBoardController.sprite.Equals(spriteUp))
            {
                KeyBoardController.sprite = throwUp;
                KeyBoardController.greenArrow = greenArrowUp;
            } else if(KeyBoardController.sprite.Equals(spriteLeft))
            {
                KeyBoardController.sprite = throwLeft;
                KeyBoardController.greenArrow = greenArrowLeft;
            } else if(KeyBoardController.sprite.Equals(spriteRight))
            {
                KeyBoardController.sprite = throwRight;
                KeyBoardController.greenArrow = greenArrowRight;
            }
        }
    }
}
