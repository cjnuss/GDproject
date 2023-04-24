﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class SkeletonSwordBeamCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle swordBeamRectangle;
        private Rectangle skeletonRectangle;

        public SkeletonSwordBeamCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Skeleton skeleton)
        {
            if (KeyBoardController.dir == GameConstants.Up || KeyBoardController.dir == GameConstants.Up)
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamWidth * GameConstants.Sizing, LinkConstants.SwordBeamHeight * GameConstants.Sizing);

            else
                swordBeamRectangle = new Rectangle((int)KeyBoardController.linkSprite.attack.swordBeam.currentX, (int)KeyBoardController.linkSprite.attack.swordBeam.currentY, LinkConstants.SwordBeamHeight * GameConstants.Sizing, LinkConstants.SwordBeamWidth * GameConstants.Sizing);


            skeletonRectangle = new Rectangle((int)skeleton.location.X, (int)skeleton.location.Y, EnemyConstants.SkeletonSize * GameConstants.Sizing, EnemyConstants.SkeletonSize * GameConstants.Sizing);

            if (skeletonRectangle.Intersects(swordBeamRectangle) && KeyBoardController.linkSprite.attack.swordBeam.toDraw)
            {
                //KeyBoardController.linkSprite.attack.swordBeam.Dispose(); debug??
                if (skeleton.hits < EnemyConstants.SkeletonHP)
                {
                    if (!skeleton.hit)
                        skeleton.Hit(KeyBoardController.linkSprite.attack.blueArrow.direction);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    skeleton.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
