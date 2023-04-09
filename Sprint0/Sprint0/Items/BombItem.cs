﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprint0
{
    public class BombItem : ISprite
    {
        Texture2D texture = ItemsTextureStorage.Instance.GetItems();
        Rectangle sourceRect = ItemsTextureStorage.bomb;
        Rectangle destRect;

        Vector2 location;

        public BombItem(Vector2 position)
        {
            location = position;

            destRect = new Rectangle((int)location.X, (int)location.Y + GameConstants.HeightAdj, sourceRect.Width * GameConstants.Sizing, sourceRect.Height * GameConstants.Sizing);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void Update()
        {

        }
    }
}