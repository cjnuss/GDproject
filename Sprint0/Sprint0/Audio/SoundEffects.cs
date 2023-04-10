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
    public class SoundEffects
    {
        private Dictionary<string, SoundEffect> soundEffects;
        private Dictionary<string, SoundEffectInstance> soundEffectInstances;

        public SoundEffects()
        {
            soundEffects = new Dictionary<string, SoundEffect>();
            soundEffectInstances = new Dictionary<string, SoundEffectInstance>();
        }

        public void LoadSound(Game1 game, String sound, String name)
        {
            SoundEffect soundEffect = game.Content.Load<SoundEffect>(name);
            soundEffects[sound] = soundEffect;
        }

        public void PlaySound(String sound)
        {
            SoundEffect soundEffect;
            if (soundEffects.TryGetValue(sound, out soundEffect))
            {
                SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();
                soundEffectInstances[sound] = soundEffectInstance;
                soundEffectInstance.Play();
            }
        }

        public void StopSound(String sound)
        {
            SoundEffectInstance soundEffectInstance;
            if (soundEffectInstances.TryGetValue(sound, out soundEffectInstance))
            {
                soundEffectInstance.Stop(false);
                soundEffectInstance.Dispose();
                soundEffectInstance = null;
            }
        }

        public bool IsPlaying(String sound)
        {
            SoundEffectInstance soundEffectInstance;
            if (soundEffectInstances.TryGetValue(sound, out soundEffectInstance))
                return soundEffectInstance.State == SoundState.Playing;
            else
                return false;
        }
    }
}
