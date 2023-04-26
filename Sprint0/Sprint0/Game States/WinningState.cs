using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Diagnostics;

namespace Sprint0
{
    public class WinningState
    {
        Game1 game;
        SpriteBatch spriteBatch;
        public WinningState(Game1 game, SpriteBatch spriteBatch)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
        }

        public void FinishGame(Game1 game, KeyBoardController Kcontroller)
        {
            Texture2D triTexture = ItemsTextureStorage.Instance.GetItems();
            Texture2D linkTexture = LinkTextureStorage.Instance.GetLinkTextures();
            Rectangle triforce = ItemsTextureStorage.triforce1;
            Rectangle linkRect = LinkTextureStorage.LinkPickingUpTriforce;
            Rectangle dest = new Rectangle((int)Kcontroller.linkSprite.location.X + 7, (int)Kcontroller.linkSprite.location.Y - 32, triforce.Width * GameConstants.Sizing, triforce.Height * GameConstants.Sizing);
            Rectangle dest2 = new Rectangle((int)Kcontroller.linkSprite.location.X, (int)Kcontroller.linkSprite.location.Y, linkRect.Width * GameConstants.Sizing, linkRect.Height * GameConstants.Sizing);

            spriteBatch.Draw(triTexture, dest, triforce, Color.White);
            spriteBatch.Draw(linkTexture, dest2, linkRect, Color.White);
            
            if (!game.soundEffects.IsPlaying("Triforce"))
            {
                game.Exit();
            }
        }
    }
}
