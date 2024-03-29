﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Response.Enemies
{
    public class GelFireCollision
    {
        public Game1 game;
        private KeyBoardController KeyBoardController;
        private Rectangle fireRectangle;
        private Rectangle gelRectangle;
        private EnemyDrops enemyDrops;
        private ISprite itemDrop;

        public GelFireCollision(Game1 game, KeyBoardController KeyBoardController)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            enemyDrops = new EnemyDrops();
        }

        public ISprite Update(Gel gel)
        {
            itemDrop = null;
            fireRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.fire.currentX, (int)KeyBoardController.linkSprite.attack.fire.currentY, ItemConstants.FireWidth * GameConstants.Sizing, ItemConstants.FireHeight * GameConstants.Sizing);
            gelRectangle = new Rectangle((int)gel.location.X, (int)gel.location.Y, EnemyConstants.GelWidth * GameConstants.Sizing, EnemyConstants.GelHeight * GameConstants.Sizing);

            if (!gel.death && gelRectangle.Intersects(fireRectangle) && KeyBoardController.linkSprite.attack.fire.toDraw)
            {
                itemDrop = enemyDrops.dropItem(gel.location);
                gel.Dispose();
                game.soundEffects.PlaySound("EnemyDie");
            }
            return itemDrop;
        }
    }
}
