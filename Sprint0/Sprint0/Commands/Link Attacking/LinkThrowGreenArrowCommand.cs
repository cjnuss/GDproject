using Microsoft.Xna.Framework;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // throw green arrow
    public class LinkThrowGreenArrowCommand : ICommand
    {
        private Game1 game;
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowGreenArrowCommand(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.GreenArrow;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
            if (!game.soundEffects.IsPlaying("ArrowAndBoomerang"))
                game.soundEffects.PlaySound("ArrowAndBoomerang");
        }
    }
}
