using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class ToggleMusicCommand : ICommand
    {
        private Game1 game;
        public ToggleMusicCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute(GameTime gameTime)
        {
            if (game.audio.IsPlaying())
                game.audio.StopBackground();
            else
                game.audio.PlayBackground();
        }
    }
}
