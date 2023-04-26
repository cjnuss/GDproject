using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;
using System.Threading;

namespace Sprint0
{
    public class LosingState
    {
        Game1 game;
        SpriteBatch spriteBatch;
        int currentFrame = GameConstants.Zero;
        int totalFrames = LinkConstants.TotalDeathFrames;
        public int indicator = GameConstants.Zero;
        Rectangle linkRect;
        private bool check = false;

        public LosingState(Game1 game, SpriteBatch spriteBatch)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
        }

        public void Update(KeyBoardController Kcontroller)
        {
            if (!check)
            {
                game.soundEffects.PlaySound("LinkDie");
                check = true;
            }

            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = GameConstants.Zero;
                indicator++;
            }

            if (currentFrame <= LinkConstants.DeathFrame1)
                linkRect = LinkTextureStorage.LinkTakingDamage;
            else if (currentFrame <= LinkConstants.DeathFrame2)
                linkRect = LinkTextureStorage.LinkLookingRight;
            else if (currentFrame <= LinkConstants.DeathFrame3)
                linkRect = LinkTextureStorage.LinkLookingUp;
            else
                linkRect = LinkTextureStorage.LinkLookingLeft;

            Texture2D linkTexture = LinkTextureStorage.Instance.GetLinkTextures();
            Rectangle dest = new Rectangle((int)Kcontroller.linkSprite.location.X, (int)Kcontroller.linkSprite.location.Y, linkRect.Width * GameConstants.Sizing, linkRect.Height * GameConstants.Sizing);
            spriteBatch.Draw(linkTexture, dest, linkRect, Color.White);

            if (!game.soundEffects.IsPlaying("LinkDie") && check)
            {
                game.Exit();
            }
        }
    }
}
