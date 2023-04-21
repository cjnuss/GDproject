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
    public class SoundManager
    {
        Game1 game;
        public SoundManager(Game1 game)
        {
            this.game = game;
        }

        public void LoadAllSounds()
        {
            game.soundEffects.LoadSound(game, "BombBlow", "bombblow");
            game.soundEffects.LoadSound(game, "BombDrop", "bombdrop");
            game.soundEffects.LoadSound(game, "ArrowAndBoomerang", "arrowandboomerang");
            game.soundEffects.LoadSound(game, "GetHeartOrKey", "getheartorkey");
            game.soundEffects.LoadSound(game, "GetRupee", "getrupee");
            game.soundEffects.LoadSound(game, "GetItem", "getitem");
            game.soundEffects.LoadSound(game, "LinkDie", "linkdie");
            game.soundEffects.LoadSound(game, "LinkHurt", "linkhurt");
            game.soundEffects.LoadSound(game, "WoodenSword", "woodensword");
            game.soundEffects.LoadSound(game, "Triforce", "triforcefanfare");
            game.soundEffects.LoadSound(game, "SwordBeam", "swordbeam");
            game.soundEffects.LoadSound(game, "EnemyHit", "enemyhit");
            game.soundEffects.LoadSound(game, "EnemyDie", "enemydie");
        }
    }
}
