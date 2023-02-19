using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902sprint0
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
}
