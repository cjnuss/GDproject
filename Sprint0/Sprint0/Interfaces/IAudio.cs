using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IAudio
    {
        void PlaySound();
        void StopSound();
        bool IsPlaying();
        bool NotPlaying();
    }
}
