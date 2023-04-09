using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class BackgroundMusicCommand : ICommand
    {
        private Game1 game;
        public BackgroundMusicCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute(GameTime gameTime)
        {
            if (game.backgroundAudio.IsPlaying())
                game.backgroundAudio.StopSound();
            else
                game.backgroundAudio.PlaySound();
        }
    }
}
