using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
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

        public void Execute(GameTime gameTime)
        {

            //mine
            KeyBoardController.linkState = LinkConstants.Default;
            KeyBoardController.dir = GameConstants.Down;
            KeyBoardController.linkSprite.location = new Vector2(LinkConstants.InitialX, LinkConstants.InitialY); // debug: initial location
            KeyBoardController.linkSprite = new Link(game1);
        }
    }
}
