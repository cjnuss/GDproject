using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprint0
{
#region Master Commands
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

    public class ResetCommand : ICommand
    {

        private KeyBoardController KeyBoardController;
        private Link link;
        private Game1 game1;

        public ResetCommand(KeyBoardController KeyBoardController, Link link, Game1 game1)
        {
            this.game1 = game1;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Execute()
        {

            //mine
            KeyBoardController.linkState = 0;
            KeyBoardController.dir = 0;
            KeyBoardController.linkSprite.location = new Vector2(200, 100); // debug: initial location
            KeyBoardController.linkSprite = new Link(game1);
        }
    }
    #endregion

    //public class LinkChangeSpriteCommand : ICommand
    //{
    //    private Link link;
    //    private KeyBoardController KeyBoardController;

    //    public LinkChangeSpriteCommand(KeyBoardController KeyBoardController, Link link)
    //    {
    //        this.KeyBoardController = KeyBoardController;
    //        this.link = link;
    //    }

    //    public void Execute()
    //    {
    //        KeyBoardController.linkSprite = link;
    //    }
    //}

    #region Link Movement
    public class LinkMoveLeftCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveLeftCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute()
        {
            KeyBoardController.dir = 1;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.X--; // update with speed later     
        }
    }

    public class LinkMoveRightCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveRightCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute()
        {
            KeyBoardController.dir = 2;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.X++;
        }
    }

    public class LinkMoveUpCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveUpCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute()
        {
            KeyBoardController.dir = 3;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.Y--;
        }
    }

    public class LinkMoveDownCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;

        public LinkMoveDownCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
        }

        public void Execute()
        {
            KeyBoardController.dir = 0;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.Y++;
        }
    }
    #endregion

    // link taking damage
    public class LinkDamageCommand : ICommand
    {
        private Link link;
        private LinkDamaged linkDamaged;
        private KeyBoardController KeyBoardController;

        public LinkDamageCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkDamaged = new LinkDamaged();
        }

        public void Execute()
        {
            // no direction change necessary
            KeyBoardController.linkState = 2; // non-moving sprite
        }
    }

    // sword attack
    public class LinkAttackingCommand : ICommand
    {
        private Link link;
        private LinkAttacking linkAttacking;
        private KeyBoardController KeyBoardController;

        public LinkAttackingCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkAttacking = new LinkAttacking();
        }

        public void Execute()
        {
            KeyBoardController.linkState = 3; // attacking sprites
        }
    }

    // throw command
    public class LinkThrowGreenArrowCommand : ICommand
    {
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowGreenArrowCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute()
        {
            KeyBoardController.linkState = 4;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
        }
    }

    #region Block Item Enemy useless stuff
    //public class BlockChangeCommand : ICommand
    //{

    //    private KeyBoardController KeyBoardController;
    //    private int blockState;

    //    public BlockChangeCommand(KeyBoardController KeyBoardController, int blockState)
    //    {
    //        this.KeyBoardController = KeyBoardController;
    //        this.blockState = blockState;
    //    }

    //    public void Execute()
    //    {
    //        KeyBoardController.blockState = blockState;
    //    }
    //}

    //public class ItemChangeCommand : ICommand
    //{

    //    private KeyBoardController KeyBoardController;
    //    private int itemState;

    //    public ItemChangeCommand(KeyBoardController KeyBoardController, int itemState)
    //    {
    //        this.KeyBoardController = KeyBoardController;
    //        this.itemState = itemState;
    //    }

    //    public void Execute()
    //    {
    //        KeyBoardController.itemState = itemState;
    //    }
    //}
    //public class EnemyChangeCommand : ICommand
    //{
    //    private KeyBoardController KeyBoardController;
    //    private int EnemyState;

    //    public EnemyChangeCommand(KeyBoardController keyboardController, int enemyState)
    //    {
    //        this.KeyBoardController = keyboardController;
    //        this.EnemyState = enemyState;
    //    }

    //    public void Execute()
    //    {
    //        KeyBoardController.enemyState = EnemyState;
    //    }
    //}
    #endregion

    //public class LinkThrowCommand : ICommand
    //{
    //    private ISprite spriteDown;
    //    private ISprite spriteUp;
    //    private ISprite spriteLeft;
    //    private ISprite spriteRight;

    //    private ISprite throwDown;
    //    private ISprite throwUp;
    //    private ISprite throwLeft;
    //    private ISprite throwRight;

    //    private ISprite greenArrowRight;
    //    private ISprite greenArrowLeft;
    //    private ISprite greenArrowUp;
    //    private ISprite greenArrowDown;

    //    private KeyBoardController KeyBoardController;

    //    public LinkThrowCommand(KeyBoardController KeyBoardController, ISprite throwDown, ISprite spriteDown, ISprite throwUp, ISprite spriteUp, ISprite throwLeft, ISprite spriteLeft, ISprite throwRight, ISprite spriteRight, ISprite greenArrowRight, ISprite greenArrowLeft, ISprite greenArrowUp, ISprite greenArrowDown)
    //    {
    //        this.KeyBoardController = KeyBoardController;

    //        this.spriteDown = spriteDown;
    //        this.spriteUp = spriteUp;
    //        this.spriteLeft = spriteLeft;
    //        this.spriteRight = spriteRight;

    //        this.throwUp = throwUp;
    //        this.throwDown = throwDown;
    //        this.throwLeft = throwLeft;
    //        this.throwRight = throwRight;

    //        this.greenArrowRight = greenArrowRight;
    //        this.greenArrowLeft = greenArrowLeft;
    //        this.greenArrowUp = greenArrowUp;
    //        this.greenArrowDown = greenArrowDown;
    //    }

    //    public void Execute()
    //    {
    //        //if(KeyBoardController.sprite.Equals(spriteDown))
    //        //{
    //        //    KeyBoardController.sprite = throwDown;
    //        //    KeyBoardController.greenArrow = greenArrowDown;
    //        //} else if(KeyBoardController.sprite.Equals(spriteUp))
    //        //{
    //        //    KeyBoardController.sprite = throwUp;
    //        //    KeyBoardController.greenArrow = greenArrowUp;
    //        //} else if(KeyBoardController.sprite.Equals(spriteLeft))
    //        //{
    //        //    KeyBoardController.sprite = throwLeft;
    //        //    KeyBoardController.greenArrow = greenArrowLeft;
    //        //} else if(KeyBoardController.sprite.Equals(spriteRight))
    //        //{
    //        //    KeyBoardController.sprite = throwRight;
    //        //    KeyBoardController.greenArrow = greenArrowRight;
    //        //}
    //    }
}
