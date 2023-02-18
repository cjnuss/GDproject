using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Sprint0
{
    // create a sprite factory for link block sprite sheet
    internal class BlockFactory : IBlock
    {
        private Texture2D linkBlockSpriteSheet;
        private static LinkBlockSpriteFactory instance = new LinkBlockSpriteFactory();

        public static LinkBlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkBlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkBlockSpriteSheet = content.Load<Texture2D>("LinkBlockSpriteSheet");
        }

        public ISprite CreateLinkBlockSprite()
        {
            return new LinkBlockSprite(linkBlockSpriteSheet);
        }
    }
}
