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

    public class LinkMoveHorizCommand : ICommand
    {
        private ISprite sprite;
        private int increment;
        private KeyBoardController KeyBoardController;

        public LinkMoveHorizCommand(KeyBoardController KeyBoardController, ISprite sprite, int increment)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
            this.increment = increment;
        }

        public void Execute()
        {
            KeyBoardController.sprite = sprite;
            KeyBoardController.xPos = KeyBoardController.xPos + increment;
        }
    }

    public class LinkMoveVertCommand : ICommand
    {
        private ISprite sprite;
        private int increment;
        private KeyBoardController KeyBoardController;

        public LinkMoveVertCommand(KeyBoardController KeyBoardController, ISprite sprite, int increment)
        {
            this.KeyBoardController = KeyBoardController;
            this.sprite = sprite;
            this.increment = increment;
        }

        public void Execute()
        {
            KeyBoardController.sprite = sprite;
            KeyBoardController.yPos = KeyBoardController.yPos + increment;
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
}
