using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // link taking damage
    public class LinkDamageCommand : ICommand
    {
        private Game1 game;
        private Link link;
        private LinkDamaged linkDamaged;
        private KeyBoardController KeyBoardController;

        public LinkDamageCommand(KeyBoardController KeyBoardController, Link link, Game1 game)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkDamaged = new LinkDamaged();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.Damage; // non-moving sprite
            if (!game.soundEffects.IsPlaying("LinkHurt"))
                game.soundEffects.PlaySound("LinkHurt");
        }
    }
}
