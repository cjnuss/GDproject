using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using Sprint0.Link_Classes.Item_Usage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Sprint0
{
    public class BackgroundAudio : IAudio
    {
        public SoundEffect backgroundMusic;
        public SoundEffectInstance backgroundMusicInstance;

        public BackgroundAudio()
        {
            // nothing
        }

        public void LoadSound(Game1 game)
        {
            backgroundMusic = game.Content.Load<SoundEffect>("dungeontheme");
        }

        public void PlaySound()
        {
            if (NotPlaying())
            {
                backgroundMusicInstance = backgroundMusic.CreateInstance();
                backgroundMusicInstance.IsLooped = true;
                backgroundMusicInstance.Play();
            }
        }

        public void StopSound()
        {
            if (IsPlaying())
            {
                backgroundMusicInstance.Stop(false);
                backgroundMusicInstance = null;
            }
        }

        public bool IsPlaying()
        {
            return backgroundMusicInstance != null && backgroundMusicInstance.State == SoundState.Playing;
        }

        public bool NotPlaying()
        {
            return backgroundMusicInstance == null || backgroundMusicInstance.State == SoundState.Stopped;
        }
    }
}
