using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // sword attack
    public class LinkAttackingCommand : ICommand
    {
        private Game1 game;
        private Link link;
        private LinkAttacking linkAttacking;
        private KeyBoardController KeyBoardController;

        public LinkAttackingCommand(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game; 
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkAttacking = new LinkAttacking();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.WoodenSword;

            game.soundEffects.LoadSound(game, "WoodenSword", "woodensword");
            if (!game.soundEffects.IsPlaying("WoodenSword"))
                game.soundEffects.PlaySound("WoodenSword");
        }
    }
}
