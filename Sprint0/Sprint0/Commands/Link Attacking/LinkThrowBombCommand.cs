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
    public class LinkThrowBombCommand : ICommand
    {
        private int count = 0;
        private Game1 game;
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowBombCommand(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = LinkConstants.Bomb;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
            
            game.soundEffects.LoadSound(game, "BombDrop", "bombdrop");
            if (!game.soundEffects.IsPlaying("BombDrop"))
                game.soundEffects.PlaySound("BombDrop");
        }
    }
}
