using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // sword attack
    public class LinkSwordBeamCommand : ICommand
    {
        private Game1 game;
        private Link link;
        private LinkAttacking linkAttacking;
        private KeyBoardController KeyBoardController;

        public LinkSwordBeamCommand(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkAttacking = new LinkAttacking();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.SwordBeam;
            KeyBoardController.location = KeyBoardController.linkSprite.location;

            if (!game.soundEffects.IsPlaying("SwordBeam"))
                game.soundEffects.PlaySound("SwordBeam");
        }
    }
}
